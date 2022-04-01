using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public string ThumbnailImage { get; set; }
        public string image { get; set; }
        public DateTime date { get; set; }
        public bool status { get; set; }
        public int CategoryId { get; set; }
        public Category category { get; set; }
        public List<Comment> commnets { get; set; }
        public Writer writer { get; set; }
        public int WriterId { get; set; }

    }
}
