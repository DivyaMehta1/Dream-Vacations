using DataAccessLayer.Models;
using System.Data.Entity;

namespace DataAccessLayer.Repository
{
    public class MyContext:DbContext
    {
        public void FixEfProviderServicesProblem()
        {
            //The Entity Framework provider type 'System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer'
            //for the 'System.Data.SqlClient' ADO.NET provider could not be loaded. 
            //Make sure the provider assembly is available to the running application. 
            //See http://go.microsoft.com/fwlink/?LinkId=260882 for more information.

            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
        public DbSet<Camps> Camps { get; set; }
        public DbSet<Bookings> Bookings { get; set; }
        public DbSet<Admins> Users { get; set; }
    }
}