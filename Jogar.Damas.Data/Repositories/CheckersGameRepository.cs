using Jogar.Damas.Domain.Entity;
using Jogar.Damas.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jogar.Damas.Data.Repositories
{
    internal class CheckersGameRepository : ICheckersGameRepository
    {
        public Task<CheckersGame> FindById(Guid guid)
        {
            throw new NotImplementedException();
        }

        public Task SaveCheckersGameAsync(CheckersGame checkersGame)
        {
            throw new NotImplementedException();
        }
    }
}
