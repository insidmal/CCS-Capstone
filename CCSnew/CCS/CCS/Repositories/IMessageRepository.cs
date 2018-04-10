using CCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CCS.Repositories
{
    public interface IMessageRepository
    {
        List<Message> ShowAllMessages();
        List<Message> GetMessagesByUser(int id);
        List<Message> GetMessagesToUser(int id);
        List<Message> GetMessagesToAndFromUser(int id);
        int Add(Message m);
        int Remove(Message m);
        int Remove(int MessID);
        int Update(Message m);
    }
}
