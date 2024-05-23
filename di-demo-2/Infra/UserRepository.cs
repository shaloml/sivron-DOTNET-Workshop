using Domain;

namespace Infra
{
    public class UserRepository : IUserRepository
    {
        public UserRepository()
        {
         
            
        }
        public User GetUser(int id)
        {
            return new User { Id = id, Name = "John Doe" };
        }
    }
}
