using System;

namespace OperationsDashboard.Common
{
    class EnvVar
    {
        public static string AsString(string key)
        {
            return Environment.GetEnvironmentVariable(key);
        }
        public static int AsInt(string key)
        {
            return int.Parse(EnvVar.AsString(key));
        }
    }
}
