using CleanBlog.Entity;
using Microsoft.EntityFrameworkCore;

namespace CleanBlog.Data
{
    public class HomeContext : DbContext
    {
        public HomeContext(DbContextOptions<HomeContext> options) : base(options) { }


        public DbSet<Author> Authors { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }

        public DbSet<Contact> Contacts {get; set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogPost>().HasKey(bp => bp.BlogPostId);
            modelBuilder.Entity<BlogPost>().Property(bp => bp.BlogPostId).IsRequired();
            modelBuilder.Entity<BlogPost>().Property(bp => bp.Title).IsRequired();
            modelBuilder.Entity<BlogPost>().Property(bp => bp.Content).IsRequired();

            modelBuilder.Entity<Author>().HasKey(a => a.AuthorId);
            modelBuilder.Entity<Author>().Property(a => a.FullName).IsRequired();

            modelBuilder.Entity<Contact>().HasKey(ct => ct.ContactID);
            modelBuilder.Entity<Contact>().Property(ct => ct.ContactFullName).IsRequired();
            modelBuilder.Entity<Contact>().Property(ct=> ct.ContactEmail).IsRequired();
            modelBuilder.Entity<Contact>().Property(ct => ct.ContactNumber).IsRequired();
            modelBuilder.Entity<Contact>().Property(ct => ct.Message).IsRequired();


            modelBuilder.Entity<Author>()
                .HasMany(a => a.BlogPosts)
                .WithOne(bp => bp.Author);


            modelBuilder.Entity<Author>()
            .HasData(new Author
            {
                AuthorId = 1,
                FullName = "Serdar"
            });

            modelBuilder.Entity<Author>()
            .HasData(new Author
            {
                AuthorId = 2,
                FullName = "Gürleyen"
            });

            modelBuilder.Entity<BlogPost>()
                .HasData(new BlogPost
                {

                    BlogPostId = 1,
                    AuthorId = 1,
                    Title = "Blog Post 01",
                    Content = "Content"
                });

            modelBuilder.Entity<BlogPost>()
            .HasData(new BlogPost
            {

                BlogPostId = 2,
                AuthorId = 1,
                Title = "Blog Post 02",
                Content = "Content"
            });

            modelBuilder.Entity<BlogPost>()
            .HasData(new BlogPost
            {

                BlogPostId = 3,
                AuthorId = 2,
                Title = "Blog Post 03",
                Content = "Content"
            });

            modelBuilder.Entity<BlogPost>()
           .HasData(new BlogPost
           {

               BlogPostId = 4,
               AuthorId = 2,
               Title = "Blog Post 04",
               Content = "Content"
           });

            modelBuilder.Entity<Contact>()
                .HasData(new Contact
                {
                    ContactID = 1,
                    ContactFullName = "Serdar Gürleyen",
                    ContactEmail = "serdar.gurleyen@siemens.com",
                    ContactNumber="572892797",
                    Message = "her sey cok guzel calisiyor."
                });

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
