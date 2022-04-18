using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Message
    {
        public int Id { get; set; }
        public int? SenderId { get; set; }
        public int? ReciverId { get; set; }
        public string Subject { get; set; }
        public string Detais { get; set; }
        public DateTime Date { get; set; }
        public bool Status { get; set; }
        public Writer  SenderUser { get; set; }
        public Writer ReciverUser { get; set; }

    }
}
