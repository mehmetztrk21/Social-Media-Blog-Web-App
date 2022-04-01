using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public bool status { get; set; }   //görünürlük.

        public List<Blog> blogs { get; set; }

    }
}
