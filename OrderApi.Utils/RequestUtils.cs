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
            var authHeader = AuthenticationHeaderValue.Parse(request.Headers["Authorization"]).Parameter;
            string decodedToken = Encoding.UTF8.GetString(Convert.FromBase64String(authHeader));
            return decodedToken.Substring(0, decodedToken.IndexOf(":"));
        }
    }
}
