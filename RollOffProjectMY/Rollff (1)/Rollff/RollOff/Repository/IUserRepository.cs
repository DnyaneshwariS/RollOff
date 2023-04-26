using System.Threading.Tasks;
using RollOff.Models.Domain;

namespace RollOff.Repository
{
    public interface IUserRepository
    {
        Task<bool> SaveUser(UserDetails userMaster);
        Task<UserDetails> AuthenticateUser(string username);
    }
}
