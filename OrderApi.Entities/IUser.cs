namespace OrderApi.Entities
{
    /// <summary>
    /// The user using the API
    /// </summary>
    public interface IUser
    {
        /// <summary>
        /// The user id
        /// </summary>
        int Id { get; set; }
        /// <summary>
        /// The users first name
        /// </summary>
        string FirstName { get; set; }
        /// <summary>
        /// The users lastname
        /// </summary>
        string LastName { get; set; }
        /// <summary>
        /// The username
        /// </summary>
        string Username { get; set; }
        /// <summary>
        /// The password
        /// </summary>
        string Password { get; set; }
    }
}