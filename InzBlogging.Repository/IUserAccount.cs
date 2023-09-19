using InzBlogging.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace InzBlogging.Repository
{
    public interface IUserAccount
    {
        User GetUserForLogin(string email, string password);
        string Register(User user);

    }
}
