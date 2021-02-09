using System;

namespace CleanBlog.Entity
{
    public class BlogPost
    {
        public int BlogPostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
    }
}
