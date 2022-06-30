using reWrite.DTOs.Character;
using reWrite.Models;
using System.Threading.Tasks;

namespace reWrite.Data
{
    public interface IAuthRepository
    {
        public Task<ResponseService<string>> Login(string username, string password);
        public Task<ResponseService<int>> Register(User user, string password);
        public Task<bool> UserExist(string username);
    }
}