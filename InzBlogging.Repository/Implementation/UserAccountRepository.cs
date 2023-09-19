using InzBlogging.Data;
using InzBlogging.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InzBlogging.Repository.Implementation
{
    public class UserAccountRepository : IUserAccount
    {
        private readonly InzBloggingContext _db;
        public UserAccountRepository(InzBloggingContext db)
        {
            _db = db;
        }
        public string Register(User user)
        {
            user.UserRoleId = 3;
            user.IsConfirmed = false;
            user.JoinedOn = DateTime.UtcNow.AddHours(5);
            user.AccessToken = Guid.NewGuid().ToString() + DateTime.UtcNow.Ticks;

            _db.Users.Add(user);
            _db.SaveChanges();

            return user.AccessToken + user.JoinedOn.Ticks.ToString();
        }
        public User GetUserForLogin(string email, string password)
        {
            return _db.Users.Where(x=>x.EmailAddress.ToLower().Equals(email.ToLower()) && x.Password.Equals(password)).FirstOrDefault();
        }

        
    }
}
