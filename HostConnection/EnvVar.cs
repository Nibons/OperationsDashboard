using System;

namespace OperationsDashboard.Common
{
    class EnvVar
    {
        public static string AsString(string key)
        {
            string environmentVariableValue = Environment.GetEnvironmentVariable(key);
            return environmentVariableValue;
        }
        public static int AsInt(string key)
        {
            int environmentVariableValue = int.Parse(EnvVar.AsString(key));
            return environmentVariableValue;
        }
    }
}
