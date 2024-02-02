namespace Trovantenato.Web.ExternalServices.AppApi.Common
{
    public class AppApiSettings
    {
        public string HostName { get; set; }

        public string UrlCreateContact
        {
            get
            {
                string path = "api/Contact";
                return string.Format("https://{0}/{1}", HostName, path);
            }
        }

        public string UrlGetImmigrantBySurname
        {
            get
            {
                string path = "api/Immigrant/{0}";
                return string.Format("https://{0}/{1}", HostName, path);
            }
        }
    }
}
