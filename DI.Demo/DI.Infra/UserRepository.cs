using DI.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI.Infra
{
    public class UserRepository : IUserRepository
    {
        public string GetUserName(int userId)
        {
            return "User name from Infra";
        }
    }
}
