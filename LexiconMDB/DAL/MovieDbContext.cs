using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using LexiconMDB.Models;

namespace LexiconMDB.DAL
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext() : base("LMDB")
        {

        }
        public DbSet<Movie> Movies {get;set;}
    }
}