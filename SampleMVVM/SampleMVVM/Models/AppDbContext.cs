using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleMVVM.Models
{
    internal class AppDbContext : DbContext
    {
        public DbSet<Cource> Cources{ get; set; }
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Data Source=(local);Initial Catalog=lab11;Integrated Security=True;TrustServerCertificate=true;");
        }
    
    }
}
