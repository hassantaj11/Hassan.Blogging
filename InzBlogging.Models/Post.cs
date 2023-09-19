using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InzBlogging.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public DateTime PostedOn { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get;set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public PostStatus PostStatus { get; set; }
        public int PostStatusId { get; set; }

    }
}
