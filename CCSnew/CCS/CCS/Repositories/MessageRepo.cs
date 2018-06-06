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
        private ISettingRepository sets;
        private Settings settings;

        public MessageRepo(AppIdentityDbContext ctx, ISettingRepository set)
        {
            sets = set;
            context = ctx;
            settings = sets.GetSettings();
        }

        public int Add(Message m)
        {
            
            context.Message.Add(m);
            if (m.Parent <= 0) {
                context.SaveChanges();
                m.Parent = m.ID;
                context.Message.Update(m);
            }

            return context.SaveChanges();
        }

        public Message GetMessage(int id) => context.Message.FirstOrDefault(a => a.ID == id);
        public List<Message> GetMessages(int id, string userId)
        {
            List<Message> messages = new List<Message>();
            if (context.Message.FirstOrDefault(a => a.ID == id && (a.FromID == userId || a.ToID == userId)) != null) {
                int parent = context.Message.FirstOrDefault(a => a.ID == id).Parent;
                messages = context.Message.Where(a => (a.ID == parent || a.Parent == parent) && a.Date>=DateTime.Now.AddDays(settings.MsgDays*-1)).OrderBy(a => a.Date).ToList();
                foreach (Message m in messages)
                {
                    if (m.ToID == userId) m.Status = Read.Read;
                    Update(m);
                }
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

        public int UnreadMessageCount(string id) => context.Message.Count(a => a.ToID == id && a.Status == Read.Unread);

        public Message Update(Message m)
        {
            context.Message.Update(m);
            context.SaveChanges();
            return m;
        }
    }
}
