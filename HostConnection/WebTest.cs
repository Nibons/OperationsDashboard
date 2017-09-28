using System;
using System.Net;

namespace HostConnection
{
    public class WebTest
    {
        public WebClient WebClient { get; private set; }
        private string IpAddress;
        private string Hostname;
        private string url;
        public WebTest(string url,string originalHostname,string IpAddress)
        {
            //set the objects properties
            this.url = url;
            this.Hostname = originalHostname;
            this.IpAddress = IpAddress;

            //invoke the download
            this.StartDownload();
        }       

        private void StartDownload()
        {
            this.WebClient = new WebClient();
            string newURL = url.Replace(this.Hostname, this.IpAddress);
            WebClient.Headers[HttpRequestHeader.Host] = this.Hostname;
            WebClient.DownloadDataAsync(new Uri(newURL));
        }        

        public void CompleteEventSubscription()
        {
            this.WebClient.DownloadDataCompleted += HandleDownloadComplete;
        }

        void HandleDownloadComplete( object sender, EventArgs e)
        {
            ResponseData responseData = new ResponseData();
            responseData.IpAddress = 
        }
    }
}
