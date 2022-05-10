using Jogar.Damas.Data.Context;
using Jogar.Damas.Domain.Entity;
using Jogar.Damas.Domain.Interface;

namespace Jogar.Damas.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly CheckersGameContext _context;

        public UserRepository(CheckersGameContext context)
        {
            _context = context;
        }

        public Task<User> FindUserByName(string name)
        {
            throw new NotImplementedException();
        }

        public async Task SaveUserAsync(User user)
        {
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();  
        }
    }
}
