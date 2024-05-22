using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI.App
{
    public interface IUserRepository
    {
        public string GetUserName(int userId);
    }
}
