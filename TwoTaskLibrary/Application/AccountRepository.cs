using Dapper;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoTaskLibrary.Models;
using TwoTaskLibrary.Services;

namespace TwoTaskLibrary.Application
{
    public interface IAccountRepository
    {
        bool Register(UserRegisterModel register);
        bool IsUserNameIsTaken(string username);
        IEnumerable<UserModel> GetAllUsers();
    }
    public class AccountRepository : IAccountRepository
    {
        private readonly SqlDataFactory _sqlDataFactory;
        public AccountRepository(SqlDataFactory sqlDataFactory)
        {
            _sqlDataFactory = sqlDataFactory;
        }
        public bool Register(UserRegisterModel register)
        {
            var connection = _sqlDataFactory.GetOpenConnection();

            var sql = "	INSERT INTO dbo.[User](Id, UserName, Email, [Password], PasswordSalt) VALUES(@Id, @UserName, @Email, @Password, @PasswordSalt); ";

            connection.Execute(sql, new { Id = Guid.NewGuid(), UserName = register.Username.ToLower(), email = register.Email });
            return true;
        }        
        public bool IsUserNameIsTaken(string username)
        {
            var connection = _sqlDataFactory.GetOpenConnection();

            var sql = "	SELECT Id, UserName, Email, [Password], PasswordSalt FROM[dbo].[User] WHERE UserName = @UserName; ";

            var user = connection.Query(sql, new { UserName = username.ToLower() });

            return user != null;
        }
        public IEnumerable<UserModel> GetAllUsers()
        {
            var connection = _sqlDataFactory.GetOpenConnection();
            var sql = " SELECT Id, UserName, Email, [Password], PasswordSalt FROM[dbo].[User] ORDER BY Id; ";

            IEnumerable<UserModel> users = connection.Query<UserModel>(sql);

            return users;
        }
      
    }
}
