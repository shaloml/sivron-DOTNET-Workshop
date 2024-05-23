using Domain;

namespace App
{
    public interface IUserService
    {
        User GetUser(int id);
    }
}