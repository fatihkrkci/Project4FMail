using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfMessageDal : GenericRepository<Message>, IMessageDal
    {
        private readonly FMailContext _context;

        public EfMessageDal(FMailContext context) : base(context)
        {
            _context = context;
        }

        public List<Message> GetDraftWithCategory(string email)
        {
            return _context.Messages.Include(x => x.Category).Where(y => y.ReceiverMail == email && y.Category.CategoryType == CategoryType.Draft).ToList();
        }

        public List<Message> GetInboxWithCategory(string email)
        {
            return _context.Messages.Include(x => x.Category).Where(y => y.ReceiverMail == email && y.Category.CategoryType != CategoryType.Trash).ToList();
        }

        public List<Message> GetMessagesWithCategoryTypeAndAppUserId(int id)
        {
            return _context.Messages.Include(x => x.Category).Where(y => y.AppUserId == id).ToList();
        }

        public List<Message> GetPrimaryWithCategory(string email)
        {
            return _context.Messages.Include(x => x.Category).Where(y => y.ReceiverMail == email && y.Category.CategoryType == CategoryType.Primary).ToList();
        }

        public List<Message> GetPromotionsWithCategory(string email)
        {
            return _context.Messages.Include(x => x.Category).Where(y => y.ReceiverMail == email && y.Category.CategoryType == CategoryType.Promotions).ToList();
        }

        public List<Message> GetSendboxWithCategory(string email)
        {
            return _context.Messages.Include(x => x.Category).Where(y => y.SenderMail == email).ToList();
        }

        public List<Message> GetSocialWithCategory(string email)
        {
            return _context.Messages.Include(x => x.Category).Where(y => y.ReceiverMail == email && y.Category.CategoryType == CategoryType.Social).ToList();
        }

        public List<Message> GetSpamWithCategory(string email)
        {
            return _context.Messages.Include(x => x.Category).Where(y => y.ReceiverMail == email && y.Category.CategoryType == CategoryType.Spam).ToList();
        }

        public List<Message> GetTrashWithCategory(string email)
        {
            return _context.Messages.Include(x => x.Category).Where(y => y.ReceiverMail == email && y.Category.CategoryType == CategoryType.Trash).ToList();
        }

        public List<Message> MessageListWithCategoryType()
        {
            return _context.Messages.Include(x => x.Category).ToList();
        }
    }
}
