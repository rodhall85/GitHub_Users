namespace GitHub_Users.Logic.Config
{
    public interface IConfigRepository
    {
        T GetConfig<T>(string configName);
    }
}
