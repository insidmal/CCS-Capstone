using System;
using System.Collections.Generic;
using System.Text;
using CCS.Models;
using CCS.Repositories;
using Xunit;

namespace CCS.Tests
{
    public class MessageTests
    {
        IMessageRepository repo;
        public MessageTests()
        {
            repo = new TestMessageRepository();
            repo.Add(m);
        }

        [Fact]
        public void MessageAddTest()
        {
            Assert.Empty(repo.ShowAllMessages());
            Message m = new Message() { FromID = 3, ToID = 4, ID = 1, Status = Read.Unread, Text = "Test Message 2 Text" };
            Assert.Single(repo.ShowAllMessages());
        }

    }
}
