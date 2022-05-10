using Jogar.Damas.Domain.Entity;
using Jogar.Damas.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jogar.Damas.Application.Users.Commands
{
    public class CreateUserCommand
    {
        IUserRepository _repository;

        public CreateUserCommand(IUserRepository repository)
        {
            _repository = repository;
        }

        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Passconfirmation { get; set; }

        public async Task Handler()
        {
            User user = new User();

            user.CreateUser(UserName, Email, Password);

            await _repository.SaveUserAsync(user);

        }
    }
}
