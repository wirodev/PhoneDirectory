using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace PhoneBook.Models
{
    internal class PhoneBookContext : DbContext
    {
        private const string connectionString = "Server=(localdb)\\mssqllocaldb; Database=PhoneDirectory; Trusted_Connection=False; AttachDbFilename=C:\\Users\\robin\\PhoneDirectory.mdf;";

        public DbSet<PhoneBookEntry> Directory { get; set; } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
