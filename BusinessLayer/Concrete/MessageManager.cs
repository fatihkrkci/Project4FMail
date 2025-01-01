using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        private readonly IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void TDelete(int id)
        {
            _messageDal.Delete(id);
        }

        public List<Message> TGetAll()
        {
            return _messageDal.GetAll();
        }

        public Message TGetById(int id)
        {
            return _messageDal.GetById(id);
        }

        public List<Message> TGetDraftWithCategory(string email)
        {
            return _messageDal.GetDraftWithCategory(email);
        }

        public List<Message> TGetInboxWithCategory(string email)
        {
            return _messageDal.GetInboxWithCategory(email);
        }

        public List<Message> TGetMessagesWithCategoryTypeAndAppUserId(int id)
        {
            return _messageDal.GetMessagesWithCategoryTypeAndAppUserId(id);
        }

        public List<Message> TGetPrimaryWithCategory(string email)
        {
            return _messageDal.GetPrimaryWithCategory(email);
        }

        public List<Message> TGetPromotionsWithCategory(string email)
        {
            return _messageDal.GetPromotionsWithCategory(email);
        }

        public List<Message> TGetSendboxWithCategory(string email)
        {
            return _messageDal.GetSendboxWithCategory(email);
        }

        public List<Message> TGetSocialWithCategory(string email)
        {
            return _messageDal.GetSocialWithCategory(email);
        }

        public List<Message> TGetSpamWithCategory(string email)
        {
            return _messageDal.GetSpamWithCategory(email);
        }

        public List<Message> TGetTrashWithCategory(string email)
        {
            return _messageDal.GetTrashWithCategory(email);
        }

        public void TInsert(Message entity)
        {
            _messageDal.Insert(entity);
        }

        public List<Message> TMessageListWithCategoryType()
        {
            return _messageDal.MessageListWithCategoryType();
        }

        public void TUpdate(Message entity)
        {
            _messageDal.Update(entity);
        }
    }
}
