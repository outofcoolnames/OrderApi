using System;
using System.Collections.Generic;
using System.Text;

namespace OrderApi.Utils
{
    /// <summary>
    /// Class containing methods used for processing the HTTP request
    /// </summary>
    public class HttpUtils : IHttpUtils
    {
        /// <summary>
        /// Get the username and password from the HTTP Header. 
        /// </summary>
        /// <param name="authToken">The auth token from the http header</param>
        /// <returns>A keyvalue pair containing the username and password</returns>
        public KeyValuePair<string, string> GetUserNameAndPassword(string authToken)
        {
            string decodedToken = Encoding.UTF8.GetString(Convert.FromBase64String(authToken));

            string username = decodedToken.Substring(0, decodedToken.IndexOf(":"));
            string password = decodedToken.Substring(decodedToken.IndexOf(":") + 1);

            KeyValuePair<string, string> credentials = new KeyValuePair<string, string>(username, password);
            return credentials;
        }
    }
}
