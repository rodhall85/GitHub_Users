using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GitHub_Users.Logic
{
    /// <summary>
    /// Convert Json
    /// </summary>
    public class JsonConvertor : IJsonConvertor
    {
        public TModel ConvertToModel<TModel>(string jsonString)
        {
            return JsonConvert.DeserializeObject<TModel>(jsonString);
        }
    }
}