using System;
using System.Collections.Generic;
using System.Text;

namespace OrderApi.Entities
{
    /// <summary>
    /// The user using the API
    /// </summary>
    public class User : IUser
    {
        /// <summary>
        /// The user id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The users first name
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// The users lastname
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// The username
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// The password
        /// </summary>
        public string Password { get; set; }
    }
}
