using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class About
    {
        [Key]
        public int Id { get; set; }
        public string details1 { get; set; }
        public string details2 { get; set; }
        public string image1 { get; set; }
        public string image2 { get; set; }
        public string mapLocation { get; set; }
        public bool status { get; set; }
    }
}
