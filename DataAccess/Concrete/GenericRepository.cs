using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        public void Add(T entity)
        {
            using var db = new Context();
            db.Add(entity);
            db.SaveChanges();
        }

        public void Delete(T entity)
        {
            using var db = new Context();
            db.Remove(entity);
            db.SaveChanges();
        }

        public List<T> GetAll()
        {
            using var db = new Context();
            return db.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            using var db = new Context();
            return db.Set<T>().Find(id);
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            List<T> temp = new List<T>();
            using(var db=new Context())
            {
                temp=db.Set<T>().Where(filter).ToList();
            }
            return temp;
        }

        public void Update(T entity)
        {
            using var db = new Context();
            db.Update(entity);
            db.SaveChanges();
        }
    }
}
