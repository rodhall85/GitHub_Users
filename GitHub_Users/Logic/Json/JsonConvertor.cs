using System;
using System.Threading.Tasks;

namespace GitHub_Users.Logic
{
    /// <summary>
    /// Convert Json
    /// </summary>
    public class JsonConvertor : IJsonConvertor
    {
        public TModel ConvertToModel<TModel>(Task<string> jsonString)
        {
            //convert the jsonString into the model that has been passed in

            throw new NotImplementedException();
        }
    }
}