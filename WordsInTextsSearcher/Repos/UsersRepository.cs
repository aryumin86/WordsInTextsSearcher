using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordsInTextsSearcher.Entities;

namespace WordsInTextsSearcher.Repos
{
    public class UsersRepository : IUsersRepository
    {
        private AppConf _appConf;

        public UsersRepository(AppConf appConf)
        {
            _appConf = appConf;
        }
        public User GetUser(string login, string password)
        {
            // dummy implementation...
            return _appConf.Users.FirstOrDefault(u => u.Login == login && u.Password == password);
        }
    }
}
