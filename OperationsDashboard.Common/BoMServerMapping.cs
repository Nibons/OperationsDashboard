using System;
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
            Console.WriteLine("Reading file " + filename);
            using(System.IO.TextReader textReader = new System.IO.StreamReader(filename)){
                var csv = new CsvReader(textReader);
                //this.ListServerMapping = csv.GetRecords<ServerMappingEntryMap>();
                csv.Configuration.HasHeaderRecord = true;
                csv.Configuration.RegisterClassMap<ServerMappingEntryMap>();                
                this.ListServerMapping = csv.GetRecords<ServerMappingEntry>().ToList();

                //this section will limit how many entries we get **FOR TESTING**
                int Servermapping_Limit = EnvVar.AsInt("Servermapping_Limit");
                if (Servermapping_Limit > 0)
                {
                    this.ListServerMapping = this.ListServerMapping.Take(Servermapping_Limit);
                }
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
            Console.WriteLine("Loading BoMServerMapping from file" + filename);
            this.ReadBomAsCsv(filename);
            this.AddAllToRedis();            
        }        
    }    
}
