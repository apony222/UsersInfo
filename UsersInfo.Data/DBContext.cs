using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersInfo.Core;

namespace UsersInfo.Data
{
    public class DBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-K8KU634\SQLEXPRESS;Initial Catalog=WPFDB;Integrated Security=True;Encrypt=False");
        }

        public DbSet<User> Users { get; set; }

    }
}
