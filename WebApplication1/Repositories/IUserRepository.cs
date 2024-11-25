using ABCMoneyTransfer.Models;

namespace ABCMoneyTransfer.Repositories
{
    public interface IUserRepository
    {
        void AddUser(User user); // For Signup
        User GetUserByEmail(string email); // For Login
    }
}
