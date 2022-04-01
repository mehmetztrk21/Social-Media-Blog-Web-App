using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        public string name { get; set; }
        public string mail { get; set; }
        public string subject { get; set; }
        public string message { get; set; }
        public DateTime date { get; set; }
        public bool status { get; set; }
    }
}
