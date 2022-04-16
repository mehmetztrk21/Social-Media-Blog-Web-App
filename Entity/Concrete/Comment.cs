using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public string name { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public DateTime date { get; set; }
        public int score { get; set; }
        public bool status { get; set; }
        public int BlogId { get; set; }
        public Blog blog { get; set; }

    }
}

