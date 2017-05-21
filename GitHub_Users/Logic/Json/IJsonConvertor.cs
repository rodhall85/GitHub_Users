namespace GitHub_Users.Logic
{
    public interface IJsonConvertor
    {
        TModel ConvertToModel<TModel>(string jsonString);
    }
}
