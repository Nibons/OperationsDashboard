using System;
using System.Net;

namespace OperationsDashboard.Common
{
    public class WebTest
    {
        public WebClient WebClient { get; private set; }
        public IPAddress IpAddress;
        public string Hostname;
        public Uri url;

        public WebTest(string url, IPAddress IpAddress)
        {
            //set the objects properties
            this.url = new Uri(url);
            this.Hostname = this.url.Host;
            this.IpAddress = IpAddress;

            //invoke the download
            this.StartDownload();
        }

        private void StartDownload()
        {
            string ipUrl = this.url.OriginalString.Replace(this.Hostname, this.IpAddress.ToString());

            this.WebClient = new WebClient();

            WebClient.Headers[HttpRequestHeader.Host] = this.Hostname;
            WebClient.DownloadDataAsync(new Uri(ipUrl));
        }
        public delegate void OnCompleteEventHandler(object obj, EventArgs e);

        public event OnCompleteEventHandler<EventArgs> OnComplete;
        

        //void HandleDownloadComplete( object sender, EventArgs e)
        //{
        //    ResponseData responseData = new ResponseData();
        //    responseData.IpAddress = 
        //}
    }
}
