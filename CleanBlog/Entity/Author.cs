using System.Collections.Generic;

namespace CleanBlog.Entity
{
    public class Author
    {
        public int AuthorId { get; set; }

        public string FullName { get; set; }

        public virtual List<BlogPost> BlogPosts { get; set; }
    }
}
