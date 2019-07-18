using System.Collections.Generic;
using System.Threading.Tasks;
using OrderApi.Entities;

namespace OrderApi.Service
{
    public interface IUserService
    {
        /// <summary>
        /// Check the supplied username and password against the "DB"
        /// </summary>
        /// <param name="username">The username</param>
        /// <param name="password">The password</param>
        /// <returns>A User instance, if found, otherwise null</returns>
        Task<User> Authenticate(string username, string password);
    }
}