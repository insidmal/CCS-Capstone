using CCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


// CREATIVE CYBER SOLUTIONS
// 04/10/2018
// JOHN BELL contact@conquest-marketing.com
// Messaging system repo

namespace CCS.Repositories
{
    public interface IMessageRepository
    {
        List<Message> ShowAllMessages();
        Message GetMessage(int id);
        List<Message> GetMessagesByUser(int id);
        List<Message> GetMessagesToUser(int id);
        List<Message> GetMessagesToAndFromUser(int id);
        int Add(Message m);
        int Remove(Message m);
        int Remove(int MessID);
        Message Update(Message m);
    }
}
