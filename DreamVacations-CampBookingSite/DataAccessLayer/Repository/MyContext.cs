using SharedProject.Models;
using System.Data.Entity;

namespace DataAccessLayer.Repository
{
    public class MyContext:DbContext
    {
        public DbSet<Camps> Camps { get; set; }
        public DbSet<Bookings> Bookings { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}