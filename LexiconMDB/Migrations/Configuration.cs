using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using LexiconMDB.DAL;
using LexiconMDB.Models;

namespace LexiconMDB.Migrations
{


    internal sealed class Configuration : DbMigrationsConfiguration<LexiconMDB.DAL.MovieDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;//if true then you're done with Update-Database. If false you have to type add migration every time you change the model.
        }

        protected override void Seed(LexiconMDB.DAL.MovieDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            context.Movies.AddOrUpdate(
                p => p.Title,
                           new Movie
                           {
                               Title = "Return of the killing tomatoes",
                               Genre = Genre.DramaComedy,
                               AgeLimit = 15,
                               Length = 90,
                               MetaScore = 7
                           },
                           new Movie
                           {
                               Title = "Something",
                               Genre = Genre.Comedy,
                               AgeLimit = 12,
                               Length = 110,
                               MetaScore = 16
                           },
                           new Movie
                           {
                               Title = "Finalizer 7",
                               Genre = Genre.Horror,
                               AgeLimit = 15,
                               Length = 95,
                               MetaScore = 57
                           },
                           new Movie
                           {
                               Title = "The Lord of the Earrings",
                               Genre = Genre.Drama,
                               AgeLimit = 15,
                               Length = 96,
                               MetaScore = 58
                           }
                           );



        }
    }
}
