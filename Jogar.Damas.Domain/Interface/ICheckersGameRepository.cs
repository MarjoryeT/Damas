using Jogar.Damas.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jogar.Damas.Domain.Interface
{
    public interface ICheckersGameRepository
    {
        Task<CheckersGame> FindById(Guid guid);

        Task SaveCheckersGameAsync(CheckersGame checkersGame);
    }
}
