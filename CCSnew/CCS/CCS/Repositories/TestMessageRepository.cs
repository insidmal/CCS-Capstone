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


        public int Add(Message m)
        {
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
            Message m = Messages.Where(a => a.ID == MessID).ToList<Message>()[0];
            Messages.Remove(m);
            return 1;
        }

        public List<Message> ShowAllMessages() => Messages;


        public Message Update(Message m)
        {
            Message oldMess = Messages.Where(a => a.ID == m.ID).ToList<Message>()[0];
            Messages.Remove(oldMess);
            oldMess.Text = m.Text;
            oldMess.Status = Read.Unread;
            oldMess.Text = m.Text;
            Messages.Add(oldMess);

            return oldMess;
        }
    }
}
