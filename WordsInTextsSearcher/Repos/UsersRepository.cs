using Microsoft.Extensions.Logging;
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
        private ILogger<UsersRepository> _logger;
        public UsersRepository(AppConf appConf, ILogger<UsersRepository> logger)
        {
            _appConf = appConf;
            _logger = logger;
        }
        public User GetUser(string login, string password)
        {
            // dummy implementation...
            return _appConf.Users.FirstOrDefault(u => u.Login == login && u.Password == password);
        }
    }
}
