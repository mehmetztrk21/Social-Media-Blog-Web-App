﻿using BusinessLayer.Abstract;
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
        public void Add(Blog entity)
        {
            _blogDal.Add(entity);
        }

        public void Delete(Blog entity)
        {
            _blogDal.Delete(entity);
        }
        public List<Blog> GetListWithCategoryByWriter(int id)
        {
            return _blogDal.GetListWithCategoryByWriter(id);
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


        public void Update(Blog entity)
        {
            _blogDal.Update(entity);
        }

        public List<Blog> GetBlogListByWriter(int id)
        {
            return _blogDal.List(x => x.WriterId == id);
        }
    }
}
