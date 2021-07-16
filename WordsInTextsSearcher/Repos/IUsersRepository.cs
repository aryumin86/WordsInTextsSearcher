using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordsInTextsSearcher.Entities;

namespace WordsInTextsSearcher.Repos
{
    public interface IUsersRepository
    {
        public User GetUser(string login, string password);
    }
}
