using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CCS.Models;

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


        public List<Message> GetMessagesToAndFromUser(int id)
        {
            throw new NotImplementedException();
        }

        public List<Message> GetMessagesToUser(int id) => Messages.Where(a => a.ToID == id).ToList<Message>();

        public int Remove(Message m)
        {
            Messages.Remove(m);
            return 1;
        }

        public int Remove(int MessID)
        {
            throw new NotImplementedException();
        }

        public List<Message> ShowAllMessages()
        {
            return Messages;
        }

        public int Update(Message m)
        {
            return 1;
        }
    }
}
