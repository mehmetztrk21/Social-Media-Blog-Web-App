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
    public class EfMessageRepository : GenericRepository<Message>, IMessageDal
    {

        public List<Message> GetListMessageByWriter(int id)
        {
            using(var db=new Context())
            {
                return db.Messages.Include(x => x.SenderUser).Where(x => x.ReciverId == id).ToList();
            }
        }
    }
}
