using System;
using System.Configuration;
using System.Linq;

namespace GitHub_Users.Logic.Config
{
    public class ConfigRepository : IConfigRepository
    {
        public T GetConfig<T>(string configName)
        {
	        var configValue = ConfigurationManager.AppSettings.GetValues(configName).FirstOrDefault();

            return (T)Convert.ChangeType(configValue, typeof(T));
        }
    }
}