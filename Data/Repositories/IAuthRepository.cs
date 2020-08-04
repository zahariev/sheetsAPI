using System;
namespace sheetsApi.Data
{
    using System.Threading.Tasks;
    using sheetsApi.Models;

    public interface IAuthRepository
    {
        Task<User> Register(User user, string password);
        Task<User> Login(string user, string password);

        Task<bool> UserExists(string username);
    }
}