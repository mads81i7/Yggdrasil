using Microsoft.VisualStudio.TestTools.UnitTesting;
using Yggdrasil.Interfaces;

namespace UnitTestYggdrasil
{
    [TestClass]
    public class UsersTest
    {
        private readonly IUserRepository _userRepository;

        public UsersTest(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [TestMethod]
        public void TestRemoveUser()
        {
            // Arrange
            _userRepository.

            // Act

            // Assert
            
        }

        [TestMethod]
        public void TestEditUser()
        {
            // Arrange
            _userRepository.

            // Act

            // Assert

        }
    }
}
