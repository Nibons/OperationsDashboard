using System.Collections.Generic;
using CsvHelper;
using System.Linq;

namespace OperationsDashboard.Common
{
    public class BoMServerMapping
    {
        private IEnumerable<ServerMappingEntry> ListServerMapping;

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
            foreach(ServerMappingEntry ServerMappingEntry in ListServerMapping)
            {
                ServerMappingEntry.AddToRedis();
            }            
        }
        public BoMServerMapping(string filename = "")
        {
            if(filename == "")
            {
                filename = EnvVar.AsString("BoM_CsvFileName");
            }
            this.ReadBomAsCsv(filename);
            this.AddAllToRedis();
        }
        //public string FilePath { get; set; }
        //public IList<ServerMappingEntry> GetServerMappingEntryList() => GetServerMappingEntryList(EnvVar.AsString("BoM_URL"));
        //public IList<ServerMappingEntry> GetServerMappingEntryList(string url)
        //{

        //}
        //SecureString SetPassword()
        //{
        //    string query = string.Format("Please enter the password for {0}: ", EnvVar.AsString("BoM_DLUsername"));
        //    Console.Write(query);
        //    var pwd = new SecureString();
        //    while (true)
        //    {
        //        ConsoleKeyInfo i = Console.ReadKey(true);
        //        if (i.Key == ConsoleKey.Enter)
        //        {
        //            break;
        //        }
        //        else if (i.Key == ConsoleKey.Backspace)
        //        {
        //            if (pwd.Length > 0)
        //            {
        //                pwd.RemoveAt(pwd.Length - 1);
        //                Console.Write("\b \b");
        //            }
        //        }
        //        else
        //        {
        //            pwd.AppendChar(i.KeyChar);
        //            Console.Write("*");
        //        }
        //    }
        //    return pwd;
        //}
        //void DownloadBoM() => DownloadBoM(SetPassword());
        //void DownloadBoM(SecureString password) => DownloadBoM(new PSCredential(EnvVar.AsString("BoM_DLUsername"), password));
        //void DownloadBoM(PSCredential pSCredential) => DownloadBoM(pSCredential, EnvVar.AsString("BoM_URL"));
        //void DownloadBoM(PSCredential pSCredential,string uri)
        //{
        //    PowerShell ps = PowerShell.Create()
        //        .AddCommand("invoke-webRequest")
        //        .AddParameter("Uri", uri)
        //        .AddParameter("credential", pSCredential)
        //        .AddParameter("UseBasicParsing", SwitchParameter.Present)
        //        .AddParameter("OutFile", "$env:Temp/BoM.xlsx" );
        //    ps.Invoke();
        //}

        //void ReadBom(string filePath) => ReadBom(filePath, EnvVar.AsString("BoM_WorksheetName"));        
        //void ReadBom(string filePath,string worksheetName,string csvFileName="./Bom.csv")
        //{
        //    var excel = new Application();
        //    var workbook = excel.Workbooks.Open(filePath);
        //    workbook.Worksheets.Item(2);
        //}
    }
}
