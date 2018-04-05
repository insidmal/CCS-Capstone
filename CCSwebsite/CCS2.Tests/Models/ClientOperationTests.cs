using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CCS2.Tests.Models
{
    [TestClass]
    public class ClientOperationTests
    {
        [TestMethod]
        public void AddClient()
        {
            // Arrange
            CCS2.Models.UserProfile client = new CCS2.Models.UserProfile() { UserName = "Charlie", Email = "email1@email.com" };
            // Set email to username in accounts
            // Set Password

            // Act
            // Link with Accounts class

            // Assert
            // Assert that We have a handle and can 
        }

        [TestMethod]
        public void SubmitRequest()
        { 
            // Arrange
            
            // Act

            // Assert
        }

        [TestMethod]
        public void LoginTest()
        { 
        
        }
    }
}
