using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CCS.Models;


// CREATIVE CYBER SOLUTIONS
// 04/10/2018
// JOHN BELL contact@conquest-marketing.com

namespace CCS.Repositories
{
    public class TestMessageRepository : IMessageRepository
    {
        private List<Message> Messages = new List<Message>();

        //public TestMessageRepository()
        //{
        //    Add(new Message() { FromID = 1, ToID = 2, ID = 0, Status = Read.Unread, Text = "Test Message 1 Text", Date=DateTime.Now, Subject="Test Message 1" });
        //    Add(new Message() { FromID = 1, ToID = 3, ID = 1, Status = Read.Read, Text = "Test Message 2 Text", Date = DateTime.Now, Subject = "Test Message 2" });
        //    Add(new Message() { FromID = 1, ToID = 4, ID = 2, Status = Read.Unread, Text = "Test Message 3 Text", Date = DateTime.Now, Subject = "Test Message 3" });
        //    Add(new Message() { FromID = 1, ToID = 5, ID = 3, Status = Read.Unread, Text = "Test Message 4 Text", Date = DateTime.Now, Subject = "Test Message 4" });
        //}

        public int Add(Message m)
        {
            m.Date = DateTime.Now;
            m.Status = Read.Unread;
            Messages.Add(m);
            return 1;
        }

        public List<Message> GetMessagesByUser(int id) => Messages.Where(a => a.FromID == id).ToList<Message>();
        
        public List<Message> GetMessagesToAndFromUser(int id) => Messages.Where(a => a.ToID == id || a.FromID == id).ToList<Message>();

        public List<Message> GetMessagesToUser(int id) => Messages.Where(a => a.ToID == id).ToList<Message>();

        public int Remove(Message m)
        {
            Messages.Remove(m);
            return 1;
        }

        public int Remove(int MessID)
        {
            Message m = Messages.FirstOrDefault(a => a.ID == MessID);
            Messages.Remove(m);
            return 1;
        }

        public List<Message> ShowAllMessages() => Messages;


        public Message Update(Message m)
        {
            Message oldMess = Messages.FirstOrDefault(a => a.ID == m.ID);
            Messages.Remove(oldMess);
            oldMess.Text = m.Text;
            oldMess.Status = Read.Unread;
            oldMess.Text = m.Text;
            Messages.Add(oldMess);

            return oldMess;
        }

        public Message GetMessage(int id) =>Messages.FirstOrDefault(a => a.ID == id);

    }
}
