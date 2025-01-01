using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService : IGenericService<Message>
    {
        public List<Message> TMessageListWithCategoryType();
        public List<Message> TGetMessagesWithCategoryTypeAndAppUserId(int id);
        public List<Message> TGetInboxWithCategory(string email);
        public List<Message> TGetSendboxWithCategory(string email);
        public List<Message> TGetPrimaryWithCategory(string email);
        public List<Message> TGetPromotionsWithCategory(string email);
        public List<Message> TGetSocialWithCategory(string email);
        public List<Message> TGetSpamWithCategory(string email);
        public List<Message> TGetTrashWithCategory(string email);
        public List<Message> TGetDraftWithCategory(string email);
    }
}
