using Jogar.Damas.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Jogar.Damas.Domain.Entity
{
    public class User : EntityBase
    {

        public Guid UserId { get; protected set; }
        public string UserName { get; protected set; }
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        public DateTime StartDate { get; protected set; }

        public void CreateUser(string userName, string email, string password)
        {
            if (userName.Length < 3)
            {
                AddRule(nameof(UserName), "O nome de usuario deve ter no mínimo 3 caracteres");
            }

            if (!email.Contains("@"))
            {
                AddRule(nameof(Email), "Email inválido");
            }

            //if (!new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{4,}$").IsMatch(password))
            //{
            //    AddRule(nameof(password), "A senha precisa ter no mínimo 4 caracteres entre letras, símbolos e números");
            //}

            if (rules.Count > 0)
            {
                throw new BusinessException(rules, "Verifique as validações");
            }

            UserName = userName;
            Email = email;
            Password = password;
            StartDate = DateTime.Today;
        }

    }
}

