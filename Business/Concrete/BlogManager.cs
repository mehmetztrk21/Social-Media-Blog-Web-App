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
    public class BlogManager : IBlogService
    {
        IBlogDal _blogDal;
        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }
        public void Add(Blog blog)
        {
            throw new NotImplementedException();
        }

        public void Delete(Blog blog)
        {
            throw new NotImplementedException();
        }

        public List<Blog> GetAll()
        {
            return _blogDal.GetAll();
        }

        public List<Blog> GetLast3Blog()
        {
            return _blogDal.GetAll().Take(3).ToList();
        }

        public List<Blog> GetBlogsWithCategoryName()
        {
            return _blogDal.GetBlogsWithCategoryName();
        }

        public Blog GetById(int id)
        {
            return _blogDal.GetById(id);
        }
        public List<Blog> GetBlogById(int id)
        {
            return _blogDal.List(x => x.Id == id);
        }


        public void Update(Blog blog)
        {
            throw new NotImplementedException();
        }

        public List<Blog> GetBlogListByWriter(int id)
        {
            return _blogDal.List(x => x.WriterId == id);
        }
    }
}
