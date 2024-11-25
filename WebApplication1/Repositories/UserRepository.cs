using System.Data;
using Dapper;
using ABCMoneyTransfer.Models;

namespace ABCMoneyTransfer.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnection _dbConnection;

        public UserRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        // Add a new user (Signup)
        public void AddUser(User user)
        {
            var query = @"
                INSERT INTO sc_user (FirstName, MiddleName, LastName, Address, Email, Password, Salt, EnteredDate) 
                VALUES (@FirstName, @MiddleName, @LastName, @Address, @Email, @Password, @Salt, @EnteredDate)";
            _dbConnection.Execute(query, user);
        }

        // Get user by email (Login)
        public User GetUserByEmail(string email)
        {
            var query = "SELECT * FROM sc_user WHERE Email = @Email";
            return _dbConnection.QuerySingleOrDefault<User>(query, new { Email = email });
        }
    }
}
