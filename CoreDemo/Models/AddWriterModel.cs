using Microsoft.AspNetCore.Http;

namespace CoreDemo.Models
{
    public class AddWriterModel
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string about { get; set; }
        public IFormFile image { get; set; }
        public string mail { get; set; }
        public string password { get; set; }
        public bool status { get; set; }
    }
}
