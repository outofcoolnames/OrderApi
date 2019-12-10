using Microsoft.AspNetCore.Http;
using System;
using System.Net.Http.Headers;
using System.Text;

namespace OrderApi.Utils
{
    public class RequestUtils : IRequestUtils
    {
        /// <summary>
        /// Get the client from the Basic auth supplied
        /// </summary>
        /// <param name="request">The current request</param>
        /// <returns>THe username supplied</returns>
        public string GetClient(HttpRequest request)
        {
            var authHeaderDictionary = request.Headers["Authorization"];
            
            if (authHeaderDictionary.Count >0)
            {
                var authHeader = AuthenticationHeaderValue.Parse(authHeaderDictionary).Parameter;
                string decodedToken = Encoding.UTF8.GetString(Convert.FromBase64String(authHeader));
                return decodedToken.Substring(0, decodedToken.IndexOf(":"));
            }
            return string.Empty;
            
        }
    }
}
