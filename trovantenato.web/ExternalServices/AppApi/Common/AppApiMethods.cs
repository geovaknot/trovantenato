using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using Trovantenato.Web.Common.Exceptions;

namespace Trovantenato.Web.ExternalServices.AppApi.Common
{
    public static class AppApiMethods
    {
        public async static Task<HttpResponseMessage> Post<T>(T request, string url)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();

                var data = JsonConvert.SerializeObject(request);
                var buffer = Encoding.UTF8.GetBytes(data);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");

                return await client.PostAsync(url, byteContent);
            }
        }

        public async static Task<HttpResponseMessage> Put<T>(T request, string url)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();

                var data = JsonConvert.SerializeObject(request);
                var buffer = Encoding.UTF8.GetBytes(data);
                var byteContent = new ByteArrayContent(buffer);
                byteContent.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/json");

                return await client.PutAsync(url, byteContent);
            }
        }

        public async static Task<HttpResponseMessage> Get(string url)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();

                return await client.GetAsync(url);
            }
        }

        public static void ResponseService(HttpResponseMessage response, string content, bool authorization = true, bool validateReturn = true)
        {
            if (authorization)
            {
                if (response.StatusCode == HttpStatusCode.Unauthorized || response.StatusCode == HttpStatusCode.Forbidden)
                {
                    throw new DomainException($"0{HttpStatusCode.Unauthorized.GetHashCode().ToString()}", "Your session has expired.");
                }
            }

            if (validateReturn)
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    dynamic c = JsonConvert.DeserializeObject<dynamic>(content);
                    throw new DomainException(c.code.ToString(), c.message.ToString());
                }
            }
        }
    }
}
