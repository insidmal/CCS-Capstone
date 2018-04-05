using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CCS2.Models;

namespace CCS2.Tests.Models
{
    [TestClass]
    public class EmailSenderTests
    {
        [TestMethod]
        public void SendEmailTest()
        {
            // Arrange
            IEmailSender sender = new Email();

            // Act & Assert
            Assert.IsTrue(sender.SendEmail("Testing our email sender", "chnance87@gmail.com", "Chuck Niddy", "Test 1"));
        }
    }
}
