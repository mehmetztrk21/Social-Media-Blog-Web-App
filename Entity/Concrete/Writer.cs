using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Writer
    {
        [Key]
        public int Id { get; set; }
        public string name { get; set; }
        public string about { get; set; }
        public string image { get; set; }
        public string mail { get; set; }
        public string password { get; set; }
        public bool status { get; set; }
        public List<Blog> Blogs { get; set; }
    }
}
