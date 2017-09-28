using System;
using System.Collections.Generic;
using System.Text;

namespace HostConnection
{
    public class ResponseData : EventArgs
    {
        public string hostname { get; set; }
        public string servername { get; set; }
        public string friendlyname { get; set; }
        public int httpResponse { get; set; }
        public string IpAddress { get; set; }
        public DateTime testTime { get; set; }
        public Uri Uri { get; set; }

        public ResponseData(int httpResponse, string IpAddress, Uri uri)
        {
            this.testTime = DateTime.Now;
            this.Uri = uri;
            this.IpAddress = IpAddress;
        }
    }
}
