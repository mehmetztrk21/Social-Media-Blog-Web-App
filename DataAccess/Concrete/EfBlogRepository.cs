using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class EfBlogRepository : GenericRepository<Blog>, IBlogDal
    {
        public List<Blog> GetBlogsWithCategoryName()
        {
            using (var db=new Context())
            {
                return db.Blogs.Include(x => x.category).ToList();
            }
        }

        public List<Blog> GetListWithCategoryByWriter(int id)
        {
            using (var db = new Context())
            {
                return db.Blogs.Include(x => x.category).Where(x=>x.WriterId==id).ToList();
            }
        }
    }
}
