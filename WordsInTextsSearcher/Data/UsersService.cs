using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WordsInTextsSearcher.Entities;
using WordsInTextsSearcher.Repos;

namespace WordsInTextsSearcher.Data
{
    public class UsersService
    {
        private IUsersRepository _usersRepository;
        public event Action OnCurrentUserLoggedIn;

        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        private User _currentUser;
        public User CurrentUser { 
            get => _currentUser; 
            set {
                _currentUser = value;
                OnCurrentUserLoggedIn?.Invoke();
            }
        }

        public User GetUser(string login, string password)
        {
            return _usersRepository.GetUser(login, password);
        }
    }
}
