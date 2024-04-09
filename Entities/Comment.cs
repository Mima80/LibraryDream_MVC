using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string? UserName { get; set; }
        public string? Text { get; set; }

        public int BookId { get; set; }
        public Book? Book { get; set; }
    }
}
