using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

using Microsoft.Extensions.Configuration;

namespace Lab9_test
{
    public class AppDbContext : DbContext
    {


        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {


            optionsBuilder.UseSqlServer("Data Source=(local);Initial Catalog=TrueEntyti;Integrated Security=True;TrustServerCertificate=true;");
        }

        public void UpdateUserAndComment(int userId, string newLogin, string newPassword, string newText, DateTime date)
        {
            var user = Users.FirstOrDefault(u => u.Id == userId);
            if (user != null)
            {
                user.Login = newLogin;
                user.Password = newPassword;
                SaveChanges(); 
            }

            var comment = Comments.FirstOrDefault(c => c.UserId == userId && c.DateTime == date);
            if (comment != null)
            {
                comment.Text = newText;
                SaveChanges(); 
            }
        }

    }
}
