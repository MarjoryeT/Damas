using Jogar.Damas.Domain.Entity;
using Jogar.Damas.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jogar.Damas.Data.Repositories
{
    internal class UserRepository : IUserRepository
    {
        public Task<CheckersGame> FindUserByName(string name)
        {
            throw new NotImplementedException();
        }

        public Task SaveUserAsync(CheckersGame user)
        {
            throw new NotImplementedException();
        }
    }
}
