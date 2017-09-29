using ServiceStack.Redis;
using System.Collections.Generic;
using CsvHelper.Configuration;

namespace OperationsDashboard.Common
{
    class ServerMappingEntry : CsvClassMap<ServerMappingEntry>
    {
        public long id;
        public string Servername;
        public string FriendlyName;
        public string LogicalEnvironment;
        public string Environment;
        public string Function;
        public string IPAddress;
        public string dnsHost;


        public ServerMappingEntry()
        {
            Map(m => m.Environment).Name("Environment");
            Map(m => m.FriendlyName).Name("Physical Server");
            Map(m => m.Servername).Name("Servername");
            Map(m => m.LogicalEnvironment).Name("Logical Environment Abbiv.");
            Map(m => m.IPAddress).Name("IP Address / Ports for Database");
            Map(m => m.dnsHost).Name("DNSName");
        }

        public void AddToRedis()
        {
            using(var RedisConnection = new RedisClient(EnvVar.AsString("Redis_Hostname"), EnvVar.AsInt("Redis_Port")))
            {
                var ListServerMappingEntry = RedisConnection.As<ServerMappingEntry>();
                this.id = ListServerMappingEntry.GetNextSequence();

                string key = string.Format("servermapping:{0}:{1}:{2}", this.LogicalEnvironment, this.Servername, this.IPAddress);
                ListServerMappingEntry.SetValue(key, this);
            }
        }
        public static IList<ServerMappingEntry> GetEntries(string logicalEnvironment = "*",string servername = "*",string function="*",string IPAddress = "*")        
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
