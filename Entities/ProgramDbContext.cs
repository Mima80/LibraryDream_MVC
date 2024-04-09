using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Enums;
using Entities.IdentityEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class ProgramDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public ProgramDbContext(DbContextOptions<ProgramDbContext> contextOptions) : base(contextOptions) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookCheckout> BookCheckouts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Book)
                .WithMany(b => b.Comments)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);

            

            // Seed Users
            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, Email = "user1@example.com", Password = "password", UserName = "user1", UserType = UserType.User },
                new User { UserId = 2, Email = "user2@example.com", Password = "password", UserName = "user2", UserType = UserType.Admin }
            );


            // Seed Books
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    BookId = 1,
                    Name = "Book1",
                    Description = "Description1",
                    Reserved = false,
                    Tags = new List<string> { "Tag1", "Tag2" },
                    Author = "Author1",
                },
                new Book
                {
                    BookId = 2,
                    Name = "Book2",
                    Description = "Description2",
                    Reserved = false,
                    Tags = new List<string> { "Tag3", "Tag4" }, 
                    Author = "Author2",
                }
            );


            // Seed Comments
            modelBuilder.Entity<Comment>().HasData(
                new Comment { CommentId = 1, UserName = "user1", Text = "Great book!", BookId = 1 },
                new Comment { CommentId = 2, UserName = "user2", Text = "Interesting read.", BookId = 2 }
            );

            // Seed BookCheckouts
            modelBuilder.Entity<BookCheckout>().HasData(
                new BookCheckout
                {
                    CheckoutId = 1,
                    BookId = 1,
                    UserName = "user1",
                    CheckoutDate = new DateOnly(2023, 1, 1),
                    FullName = "John Doe",
                    PhoneNumber = "123456789",
                    PostalCode = "12345"
                },
                new BookCheckout
                {
                    CheckoutId = 2,
                    BookId = 2,
                    UserName = "user2",
                    CheckoutDate = new DateOnly(2023, 1, 2),
                    FullName = "Nick Pro",
                    PhoneNumber = "987654321",
                    PostalCode = "54321"
                }
            );
        }
    }
}
