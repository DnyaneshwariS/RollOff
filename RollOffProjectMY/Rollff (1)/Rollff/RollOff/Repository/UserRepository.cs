using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RollOff.Data;
using RollOff.Models.Domain;

namespace RollOff.Repository
{
    public class UserRepository : IUserRepository
    {
        private IDbContextFactory<RollOffDBContext> _factory;

        public UserRepository(IDbContextFactory<RollOffDBContext> factory)
        {
            _factory = factory;
        }

        public async Task<bool> SaveUser(UserDetails userDetails)
        {
            using (var context = _factory.CreateDbContext())
            {
                var isExist = await context.UserDetails.Where(u => u.Email == userDetails.Email).FirstOrDefaultAsync().ConfigureAwait(false);
                if (isExist != null)
                    return false;

                context.UserDetails.Add(userDetails);
                return await context.SaveChangesAsync().ConfigureAwait(false) > 0;
            }
        }

        public async Task<UserDetails> AuthenticateUser(string username)
        {
            using (var context = _factory.CreateDbContext())
            {
                return await context.UserDetails.Where(u => u.Email == username).FirstOrDefaultAsync().ConfigureAwait(false);
            }
        }
    }
}
