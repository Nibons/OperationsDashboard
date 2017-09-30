using System.Collections.Generic;
using CsvHelper;
using System.Linq;
using ServiceStack.Redis;

namespace OperationsDashboard.Common
{
    public class BoMServerMapping
    {
        private IEnumerable<ServerMappingEntry> ListServerMapping;
        public string BoMLoadState { get; set; }

        void ReadBomAsCsv() => ReadBomAsCsv(EnvVar.AsString("BoM_CsvFileName"));

        void ReadBomAsCsv(string filename)
        {
            using(System.IO.TextReader textReader = new System.IO.StreamReader(filename)){
                var csv = new CsvReader(textReader);
                //this.ListServerMapping = csv.GetRecords<ServerMappingEntryMap>();
                csv.Configuration.HasHeaderRecord = true;
                csv.Configuration.RegisterClassMap<ServerMappingEntryMap>();                
                this.ListServerMapping = csv.GetRecords<ServerMappingEntry>().ToList();
            }
        }

        void AddAllToRedis()
        {
            using (var RedisConnection = new RedisClient(EnvVar.AsString("Redis_Hostname"), EnvVar.AsInt("Redis_Port")))                
            {
                var ListServerMappingContext = RedisConnection.As<ServerMappingEntry>();
                foreach (ServerMappingEntry ServerMappingEntry in ListServerMapping)
                {
                    ServerMappingEntry.id = ListServerMappingContext.GetNextSequence();

                    //removed because it wasn't nearly as fast
                    //string key = string.Format("servermapping:{0}:{1}:{2}", ServerMappingEntry.LogicalEnvironment, ServerMappingEntry.Servername, ServerMappingEntry.IPAddress);
                    //ListServerMappingContext.SetValue(key, ServerMappingEntry);
                    //ListServerMappingContext.Store(ServerMappingEntry);
                }
                ListServerMappingContext.StoreAll(ListServerMapping);
            }
                         
        }
        public BoMServerMapping(string filename = "")
        {
            if (filename == "")
            {
                filename = EnvVar.AsString("BoM_CsvFileName");
            }
            this.ReadBomAsCsv(filename);
            this.AddAllToRedis();            
        }        
    }    
}
