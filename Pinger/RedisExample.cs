using System;
using ServiceStack.Redis;
using ServiceStack.Text;

namespace Pinger
{
    class RedisExample
    {
        private string hostname = Environment.GetEnvironmentVariable("redis_hostname");
        private int port = int.Parse(Environment.GetEnvironmentVariable("redis_port"));
        public RedisExample(string host, int port)
        {
            this.invokeRedis(host, port);
        }
        public RedisExample(string host)
        {
            invokeRedis(host, this.port);
        }
        public RedisExample()
        {
            invokeRedis(this.hostname, this.port);
        }

        private void invokeRedis(string host,int port)
        {
            using (var redis = new RedisClient(host, port))
            {
                var redisUsers = redis.As<Person>();

                var rick = new Person { id = redisUsers.GetNextSequence(), name = "Rick Sanchez" };
                var morty = new Person { id = redisUsers.GetNextSequence(), name = "Morty Sanchez" };

                redisUsers.Store(rick);
                redisUsers.Store(morty);

                var allThePeople = redisUsers.GetAll();

                Console.WriteLine(allThePeople.Dump());
            }
        }
        
    
    }
        
    class Person
    {
        public long id { get; set; }
        public string name { get; set; }
    }
}
