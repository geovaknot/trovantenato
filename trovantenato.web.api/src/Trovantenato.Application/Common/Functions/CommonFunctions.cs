using MailKit.Security;
using MimeKit;
using System.Security.Cryptography;
using System.Text;
using Trovantenato.Application.Services.Contacts.Command.CreateContact;
using Trovantenato.Infrastructure.Configurations;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace Trovantenato.Application.Common.Functions
{
    public class CommonFunctions
    {
        public static string GenerateConfirmToken()
        {

            var rand = new Random();
            string result = "";

            for (int ctr = 1; ctr <= 6; ctr++)
            {
                result += rand.Next(1, 10).ToString();
            }

            return result;
        }

        public static string CreateMD5Hash(string input)
        {
            // Step 1, calculate MD5 hash from input
            MD5 md5 = MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            // Step 2, convert byte array to hex string
            StringBuilder sb = new();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }
            return sb.ToString();
        }

        public static bool SendContactEmail(CreateContactCommand request, EmailSettings settings)
        {
            try
            {
                MimeMessage emailMessage = new();

                MailboxAddress emailFrom = new(settings.Name, settings.EmailId);
                MailboxAddress emailTo = new("Administrador", settings.AdmEmail);

                emailMessage.From.Add(emailFrom);
                emailMessage.To.Add(emailTo);

                emailMessage.Subject = "Novo Contato - Trovantenato";

                string FilePath = Directory.GetCurrentDirectory() + "/Templates/EmailTemplateCreateContact.html";
                string EmailTemplateText = File.ReadAllText(FilePath);

                EmailTemplateText = string.Format(EmailTemplateText, request.Name, request.Email, request.Subject, request.Message);

                BodyBuilder emailBodyBuilder = new();
                emailBodyBuilder.HtmlBody = EmailTemplateText;
                emailMessage.Body = emailBodyBuilder.ToMessageBody();

                SmtpClient emailClient = new();
                emailClient.Connect(settings.Host, settings.Port, SecureSocketOptions.StartTls);
                emailClient.Authenticate(settings.EmailId, settings.Password);
                emailClient.Send(emailMessage);
                emailClient.Disconnect(true);
                emailClient.Dispose();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
