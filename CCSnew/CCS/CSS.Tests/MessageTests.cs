using System;
using System.Collections.Generic;
using System.Text;
using CCS.Models;
using CCS.Repositories;
using Xunit;

// CREATIVE CYBER SOLUTIONS
// 04/10/2018
// JOHN BELL contact@conquest-marketing.com

namespace CCS.Tests
{
    public class MessageTests
    {
        IMessageRepository repo;
        public MessageTests()
        {
            repo = new TestMessageRepository();
        }

        [Fact]
        public void MessageAddTest()
        {
            Assert.Empty(repo.ShowAllMessages());
            Message m = new Message() { FromID = 3, ToID = 4, ID = 1, Status = Read.Unread, Text = "Test Message 2 Text" };
            repo.Add(m);
            Assert.Single(repo.ShowAllMessages());
        }

        [Fact]
        public void MessageRemoveTest()
        {
            Assert.Empty(repo.ShowAllMessages());
            Message m = new Message() { FromID = 3, ToID = 4, ID = 1, Status = Read.Unread, Text = "Test Message 2 Text" };
            repo.Add(m);
            Assert.Single(repo.ShowAllMessages());
            repo.Remove(m);
        }

        [Fact]
        public void MessageRemoveByIDTest()
        {
            Assert.Empty(repo.ShowAllMessages());
            Message m = new Message() { FromID = 3, ToID = 4, ID = 1, Status = Read.Unread, Text = "Test Message 2 Text" };
            repo.Add(m);
            Assert.Single(repo.ShowAllMessages());
            repo.Remove(1);
            Assert.Empty(repo.ShowAllMessages());

        }

        [Fact]
        public void MessageGetByFromIDTest()
        {
            Assert.Empty(repo.ShowAllMessages());
            Message m = new Message() { FromID = 1, ToID = 2, ID = 1, Status = Read.Unread, Text = "Test Message Text" };
            repo.Add(m);
            m = new Message() { FromID = 3, ToID = 4, ID = 2, Status = Read.Unread, Text = "Test Message 2 Text" };
            repo.Add(m);
            Assert.Equal(1, repo.GetMessagesByUser(1)[0].ID);

        }

        [Fact]
        public void MessageGetByToIDTest()
        {
            Assert.Empty(repo.ShowAllMessages());
            Message m = new Message() { FromID = 1, ToID = 2, ID = 1, Status = Read.Unread, Text = "Test Message Text" };
            repo.Add(m);
            m = new Message() { FromID = 3, ToID = 4, ID = 2, Status = Read.Unread, Text = "Test Message 2 Text" };
            repo.Add(m);
            Assert.Equal(2, repo.GetMessagesToUser(4)[0].ID);
        }

        [Fact]
        public void MessageGetByToAndFromIDTest()
        {
            Assert.Empty(repo.ShowAllMessages());
            Message m = new Message() { FromID = 1, ToID = 2, ID = 1, Status = Read.Unread, Text = "Test Message Text" };
            repo.Add(m);
            m = new Message() { FromID = 2, ToID = 3, ID = 2, Status = Read.Unread, Text = "Test Message 2 Text" };
            repo.Add(m);
            m = new Message() { FromID = 3, ToID = 4, ID = 2, Status = Read.Unread, Text = "Test Message 2 Text" };
            repo.Add(m);
            Assert.Equal(2, repo.GetMessagesToAndFromUser(3).Count);
        }

        [Fact]
        public void MessageShowAllTest()
        {
            Assert.Empty(repo.ShowAllMessages());
            Message m = new Message() { FromID = 1, ToID = 2, ID = 1, Status = Read.Unread, Text = "Test Message Text" };
            repo.Add(m);
            m = new Message() { FromID = 2, ToID = 3, ID = 2, Status = Read.Unread, Text = "Test Message 2 Text" };
            repo.Add(m);
            m = new Message() { FromID = 3, ToID = 4, ID = 2, Status = Read.Unread, Text = "Test Message 2 Text" };
            repo.Add(m);
            Assert.Equal(3, repo.ShowAllMessages().Count);

        }

        [Fact]
        public void MessageUpdate()
        {
            Assert.Empty(repo.ShowAllMessages());
            Message m = new Message() { FromID = 1, ToID = 2, ID = 1, Status = Read.Unread, Text = "Test Message Text" };
            repo.Add(m);
            m.Text = "Updated Text";
            repo.Update(m);
            Assert.Equal("Updated Text", repo.ShowAllMessages()[0].Text);

        }
    }
}
