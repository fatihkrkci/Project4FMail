using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IMessageDal : IGenericDal<Message>
    {
        List<Message> MessageListWithCategoryType();
        List<Message> GetMessagesWithCategoryTypeAndAppUserId(int id);
        List<Message> GetInboxWithCategory(string email);
        List<Message> GetSendboxWithCategory(string email);
        List<Message> GetPrimaryWithCategory(string email);
        List<Message> GetPromotionsWithCategory(string email);
        List<Message> GetSocialWithCategory(string email);
        List<Message> GetSpamWithCategory(string email);
        List<Message> GetTrashWithCategory(string email);
        List<Message> GetDraftWithCategory(string email);
    }
}
