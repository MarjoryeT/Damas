using Jogar.Damas.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jogar.Damas.Domain.Entity
{
    public class EntityBase
    {
        protected List<BrokenRule> rules = new List<BrokenRule>();

        protected void AddRule(string field, string message)
        {
            rules.Add(new BrokenRule(field, message));
        }
    }
}
