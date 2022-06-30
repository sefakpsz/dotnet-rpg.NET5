using dotnet_rpg.Models;
using System.Threading.Tasks;

namespace dotnet_rpg.Data
{
    public interface IAuthRepository
    {
        public Task<ServiceResponse<string>> Login(string username, string password);
        public Task<ServiceResponse<int>> Register(User user, string password);
        public Task<bool> UserExists(string username);
    }
}