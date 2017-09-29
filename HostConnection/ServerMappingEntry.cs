using System;
using ServiceStack.Redis;
using System.Collections.Generic;

namespace OperationsDashboard.Common
{
    class ServerMappingEntry
    {
        public long id;
        public string Servername;
        public string FriendlyName;
        public string LogicalEnvironment;
        public string Environment;
        public string Function;
        public string IPAddress;
        public string dnsHost;

        public ServerMappingEntry(string Servername, string friendlyname, string logicalEnvironment, string environment,string function, string iPAddress, string dnsHost)
        {
            this.Servername = Servername;
            this.FriendlyName = friendlyname;
            this.LogicalEnvironment = logicalEnvironment;
            this.Environment = environment;
            this.Function = function;
            this.IPAddress = iPAddress;
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
        public static ServerMappingEntry GetEntry(string logicalEnvironment = "*",string servername = "*",string function="*",string IPAddress = "*")        
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
