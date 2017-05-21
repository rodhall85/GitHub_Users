using System;

namespace GitHub_Users.Logic.Config
{
    public class ConfigRepository : IConfigRepository
    {
        public T GetConfig<T>(string configName)
        {
            //TODO:- get the config from the web.config
            var configValue = "https://api.github.com/users/";

            return (T)Convert.ChangeType(configValue, typeof(T));
        }
    }
}