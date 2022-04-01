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
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public void Add(Comment comment)
        {
            _commentDal.Add(comment);
        }

        public void Delete(Comment comment)
        {
            throw new NotImplementedException();
        }

        public List<Comment> GetAll(int id)
        {
            return _commentDal.List(x => x.BlogId == id);
        }

        public Comment GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Comment comment)
        {
            throw new NotImplementedException();
        }
    }
}
