using Moq;
using Newtonsoft.Json;
using TwoTaskLibrary.Application;
using TwoTaskLibrary.Models;
using TwoTaskLibrary.Services;
using Xunit;

namespace TwoTaskWebAPI.UnitTests
{
    public class AccountServiceTests
    {
        private Mock<IAccountRepository> _accountRepository;
        private Mock<ISecurityService> _securityService;
        private AccountService _accountService;
        
        public AccountServiceTests()
        {
            this._accountRepository = new Mock<IAccountRepository>();
            this._accountRepository.Setup(x => x.Register(It.IsAny<UserRegisterModel>())).Returns(true);
            this._accountRepository.Setup(x => x.IsUserNameIsTaken(It.IsAny<string>())).Returns(false);

            this._securityService = new Mock<ISecurityService>();
            this._securityService.Setup(x => x.ComputeHash(It.IsAny<string>())).Returns(new byte[] { 1, 2, 3 });
            this._securityService.Setup(x => x.GetKey()).Returns(new byte[] { 1, 2, 3 });

            _accountService = new AccountService(this._accountRepository.Object, this._securityService.Object);
        }

        [Fact]
        public void RegisterUser_UsernameIsAlreadyTaken_False()
        {
            UserRegisterModel model = new UserRegisterModel()
                { Email = "test@test.com", Password = "12345", Username = "testUsername" };
            this._accountRepository.Setup(x => x.IsUserNameIsTaken(It.IsAny<string>())).Returns(true);

            var result = _accountService.RegisterUser(model);
            
            Assert.Null(result);
        }

        [Fact]
        public void RegisterUser_True()
        {
            this._accountRepository.Setup(x => x.IsUserNameIsTaken(It.IsAny<string>())).Returns(false);

            UserRegisterModel model = new UserRegisterModel()
                { Email = "test@test.com", Password = "12345", Username = "testUsername" };

            var finalModel = new UserModel()
            {
                Email = "test@test.com", Password = new byte[] { 1, 2, 3 }, UserName = "testusername",
                PasswordSalt = new byte[] { 1, 2, 3 }
            };

            var result = _accountService.RegisterUser(model);
            finalModel.Id = result.Id;
            
            Assert.Equal(JsonConvert.SerializeObject(finalModel), JsonConvert.SerializeObject(result));
        }

        [Fact]
        public void RegisterUser_False()
        {
            this._accountRepository.Setup(x => x.IsUserNameIsTaken(It.IsAny<string>())).Returns(false);

            UserRegisterModel model = new UserRegisterModel()
            { Email = "test@test.com", Password = "12345", Username = "testUsername" };

            var finalModel = new UserModel();

            var result = _accountService.RegisterUser(model);
            finalModel.Id = result.Id;

            Assert.NotEqual(JsonConvert.SerializeObject(finalModel), JsonConvert.SerializeObject(result));
        }
    }
}