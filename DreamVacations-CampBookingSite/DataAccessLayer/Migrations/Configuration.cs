namespace DataAccessLayer.Migrations
{
    using SharedProject.Models;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<DataAccessLayer.Repository.MyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataAccessLayer.Repository.MyContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        //    IList<Camps> camps = new List<Camps>();
        //    camps.Add(new Camps()
        //    {
        //        Title = "Angel's Rest",
        //        Description = "Located on the edge of a Beautiful Valley in Ooty",
        //        Amount = 10000,
        //        Capacity=4,
        //        IsBooked=false
        //    });
        //    camps.Add(new Camps()
        //    {
        //        Title = "Nature Drops",
        //        Description = "Nature Drops is located in Nainital, 15 km from Naini Lake.All units feature a seating area.There is a private bathroom with slippers and free toiletries in each unit. Towels are offered.Nature Drops also includes a sun terrace.Guests can enjoy the on - site restaurant",
        //        Amount = 20000,
        //        Capacity = 2,
        //        IsBooked = false
        //});
        //    camps.Add(new Camps()
        //    {
        //        Title = "Nature Drops",
        //        Description = "Set in Gupta Kāshi, Kedar camp resorts features all vegetarian accommodation with access to a garden.Guests at the tented camp can enjoy a buffet or a vegetarian breakfast.Guests can grab a bite to eat in the in-house restaurant,which specialises in Indian cuisine.",
        //        Amount = 10000,
        //        Capacity = 2,
        //        IsBooked = false
        //    });
        //    camps.Add(new Camps()
        //    {
        //        Title = "Ramganga RiverCamp Jim Corbett(Meals & Gypsys Included)",
        //        Description = "Situated in Rāmnagar in the Uttarakhand region, Ramganga River Camp Jim Corbett ( Meals & Gypsy Included ) has a garden.A vegetarian breakfast is available each morning at the tented camp.The nearest airport is Pantnagar Airport,84 km from Ramganga River Camp Jim Corbett(Meals & Gypsy Included).",
        //        Amount = 1000,
        //        Capacity = 4,
        //        IsBooked = false
        //    });
        //    foreach (Camps camp in camps)
        //        context.Camps.Add(camp);
        //    base.Seed(context);

        }
    }
}
