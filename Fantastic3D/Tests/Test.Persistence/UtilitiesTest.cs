using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using Fantastic3D.Persistence.Entities;

namespace Test.Persistence
{
    [TestClass]
    public class UtilitiesTest
    {
        [TestMethod]
        public void HashSaltAndSaltOutTest()
        {
            var passwordToHash = "C}Xu`37]{n7B4@xd";

            // Act
            var hashedPasswordA = Utilities.PasswordHash(passwordToHash, out string hashsaltA);
            var hashedPasswordB = Utilities.PasswordHash(passwordToHash, out string hashsaltB);

            // Assert
            hashedPasswordA.Should().NotBe(passwordToHash);
            hashedPasswordB.Should().NotBe(passwordToHash);
            hashsaltA.Should().NotBe(hashsaltB);
            hashedPasswordA.Should().NotBe(hashedPasswordB);
        }

        [TestMethod]
        public void HashWithGivenSaltIsIdenticalToHashWithRandomSalt()
        {
            var passwordToHash = "C}Xu`37]{n7B4@xd";
            var hashedPassword = Utilities.PasswordHash(passwordToHash, out string hashSalt);

            // Act
            var hashedPasswordGivenKey = Utilities.PasswordHash(passwordToHash, hashSalt);

            // Assert
            hashedPasswordGivenKey.Should().BeEquivalentTo(hashedPassword);
        }
    }
}