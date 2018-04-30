using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CCS.Models;

namespace CCS.Repositories
{
    public class MessageRepo : IMessageRepository
    {

        private readonly AppIdentityDbContext context;

        public MessageRepo(AppIdentityDbContext ctx)
        {
            context = ctx;
        }

        public int Add(Message m)
        {
            context.Message.Add(m);
            return context.SaveChanges();
        }

        public Message GetMessage(int id) => context.Message.FirstOrDefault(a => a.ID == id);
        public List<Message> GetMessages(int parent, string userId)
        {
           List<Message> messages = context.Message.Where(a => a.ID == parent || a.Parent == parent).OrderByDescending(a => a.Date).ToList();
            foreach (Message m in messages)
            {
                if (m.ToID == userId) m.Status = Read.Read;
                Update(m);
             }
            return messages;
        }
        public List<Message> GetMessagesByUser(string id) => context.Message.Where(a=>a.FromID == id).ToList<Message>();

        public List<Message> GetMessagesToAndFromUser(string id) => context.Message.Where(a => a.FromID == id || a.ToID==id).ToList<Message>();

        public List<Message> GetMessagesToUser(string id) => context.Message.Where(a => a.ToID == id).ToList<Message>();


        public int Remove(Message m)
        {
            context.Message.Remove(m);
            return context.SaveChanges();
        }

        public int Remove(int MessID)
        {
            context.Message.Remove(context.Message.FirstOrDefault(a=>a.ID==MessID));
            return context.SaveChanges();

        }

        public List<Message> ShowAllMessages() => context.Message.ToList<Message>();

        public Message Update(Message m)
        {
            context.Message.Update(m);
            context.SaveChanges();
            return m;
        }
    }
}
