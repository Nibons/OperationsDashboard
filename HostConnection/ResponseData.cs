using System;
using System.Collections.Generic;
using System.Text;

namespace OperationsDashboard.Common
{
    public class ResponseData : EventArgs
    {
        public string Hostname { get; set; }
        public string Servername { get; set; }
        public string Friendlyname { get; set; }
        public int HttpResponse { get; set; }
        public string IpAddress { get; set; }
        public DateTime TestTime { get; set; }
        public Uri Uri { get; set; }

        public ResponseData(int httpResponse, string IpAddress, Uri uri)
        {
            this.TestTime = DateTime.Now;
            this.Uri = uri;
            this.IpAddress = IpAddress;
        }
    }
}
