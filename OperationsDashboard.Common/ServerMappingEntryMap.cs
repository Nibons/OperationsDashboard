using CsvHelper.Configuration;

namespace OperationsDashboard.Common
{
    public sealed class ServerMappingEntryMap : CsvClassMap<ServerMappingEntry>
    {
        public ServerMappingEntryMap()
        {
            Map(m => m.Environment).Name("Environment");
            Map(m => m.FriendlyName).Name("Physical Server");
            Map(m => m.Servername).Name("Servername");
            Map(m => m.LogicalEnvironment).Name("Logical Environment Abbiv.");
            Map(m => m.IPAddress).Name("IP Address / Ports for Database");
            Map(m => m.dnsHost).Name("DNS Name");
        }
    }
}
