using ServiceStack.Redis;
using System.Collections.Generic;


namespace OperationsDashboard.Common
{
    public class ServerMappingEntry
    {
        public long id { get; set; }
        public string Servername { get; set; }
        public string FriendlyName { get; set; }
        public string LogicalEnvironment { get; set; }
        public string Environment { get; set; }
        public string Function { get; set; }
        public string IPAddress { get; set; }
        public string dnsHost { get; set; }

        public void AddToRedis()
        {
            using (var RedisConnection = new RedisClient(EnvVar.AsString("Redis_Hostname"), EnvVar.AsInt("Redis_Port")))
            {
                var ListServerMappingEntry = RedisConnection.As<ServerMappingEntry>();
                this.id = ListServerMappingEntry.GetNextSequence();

                string key = string.Format("servermapping:{0}:{1}:{2}", this.LogicalEnvironment, this.Servername, this.IPAddress);
                ListServerMappingEntry.SetValue(key, this);
            }
        }
        public static IList<ServerMappingEntry> GetEntries(string logicalEnvironment = "*", string servername = "*", string function = "*", string IPAddress = "*")
        {
            using (var RedisConnection = new RedisClient(EnvVar.AsString("Redis_Hostname"), EnvVar.AsInt("Redis_Port")))
            {
                var ListServerMappingEntry = RedisConnection.As<ServerMappingEntry>();
                string key = string.Format("servermapping:{0}:{1}:{2}", logicalEnvironment, servername, IPAddress);
                return ListServerMappingEntry.GetValue(key) as IList<ServerMappingEntry>;
            }
        }
        public static ServerMappingEntry GetEntry(string logicalEnvironment = "*", string servername = "*", string function = "*", string IPAddress = "*")
        {
            using (var RedisConnection = new RedisClient(EnvVar.AsString("Redis_Hostname"), EnvVar.AsInt("Redis_Port")))
            {
                var ListServerMappingEntry = RedisConnection.As<ServerMappingEntry>();
                string key = string.Format("servermapping:{0}:{1}:{2}", logicalEnvironment, servername, IPAddress);
                return ListServerMappingEntry.GetValue(key);
            }
        }
        public static ServerMappingEntry GetEntryById(long id)
        {
            using (var RedisConnection = new RedisClient(EnvVar.AsString("Redis_Hostname"), EnvVar.AsInt("Redis_Port")))
            {
                var ListServerMappingEntry = RedisConnection.As<ServerMappingEntry>();
                return ListServerMappingEntry.GetById(id);
            }
        }

        public static IList<ServerMappingEntry> GetAll()
        {
            using (var RedisConnection = new RedisClient(EnvVar.AsString("Redis_Hostname"), EnvVar.AsInt("Redis_Port")))
            {
                var ListServerMappingEntry = RedisConnection.As<ServerMappingEntry>();
                return ListServerMappingEntry.GetAll();
            }
        }
    }

}

