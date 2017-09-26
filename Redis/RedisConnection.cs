using System;
using ServiceStack.Redis;

namespace Redis
{
    public class RedisConnection
    {
        private string hostname;
        private int port;
        public RedisConnection(string hostname,int port = 6379)
        {
            this.hostname = hostname;
            this.port = port;
        }
        private void testConnection()
        {
            TcpClient tcpClient = new TcpClient();
            tcpClient.Connect(this.hostname, this.port);
            if (tcpClient.Connected == true)
            {

            }
            else
            {
                string no_connect = "Connection to " + hostname + port.ToString();
                throw no_connect;
            }
        }
    }
}
