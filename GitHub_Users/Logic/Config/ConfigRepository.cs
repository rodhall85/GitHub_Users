using System;
using System.Configuration;

namespace GitHub_Users.Logic.Config
{
    public class ConfigRepository : IConfigRepository
    {
        public T GetConfig<T>(string configName)
        {
	        var configValue = ConfigurationManager.AppSettings.GetValues(configName);

            return (T)Convert.ChangeType(configValue, typeof(T));
        }
    }
}