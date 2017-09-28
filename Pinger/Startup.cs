using System;
using ServiceStack.Redis;

namespace Pinger
{
    class Startup
    {
        protected string redisConnection { get; set; }        

        public Startup()
        {
            this.setupRedis();
        }

        private void setupRedis()
        {
            var redisHostName = Environment.GetEnvironmentVariable("redis_hostname");
            var redisPort = Environment.GetEnvironmentVariable("redis_port");
            this.redisConnection = redisHostName + redisPort;
        }
    }
}
