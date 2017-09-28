using System;
using System.Collections.Generic;
using System.Text;

namespace HostConnection
{
    class ResponseAction
    {
        private string ID;
        public ResponseAction(string ID,WebTest webTest)
        {
            this.ID = ID;
            webTest.WebClient.DownloadDataCompleted<ResponseData> 
        }
    }
}
