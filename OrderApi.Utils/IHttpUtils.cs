using System.Collections.Generic;

namespace OrderApi.Utils
{
    public interface IHttpUtils
    {
        KeyValuePair<string, string> GetUserNameAndPassword(string authToken);
    }
}