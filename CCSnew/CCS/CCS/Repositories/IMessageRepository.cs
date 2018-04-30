using CCS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


// CREATIVE CYBER SOLUTIONS
// CREATED: 04/10/2018
// CREATED BY: JOHN BELL contact@conquest-marketing.com
// LAST UPDATED ON: 04/30/2018
// LAST UPDATED BY: JOHN BELL contact@conquest-marketing.com

namespace CCS.Repositories
{
    public interface IMessageRepository
    {
        List<Message> ShowAllMessages();
        Message GetMessage(int id);
        List<Message> GetMessages(int id, string userId);
        List<Message> GetMessagesByUser(string id);
        List<Message> GetMessagesToUser(string id);
        List<Message> GetMessagesToAndFromUser(string id);
        int Add(Message m);
        int Remove(Message m);
        int Remove(int MessID);
        Message Update(Message m);
    }
}
