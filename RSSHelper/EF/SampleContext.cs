using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace RSSHelper.Models
{
    public class SampleContext : DbContext
    {
        public SampleContext() : base("News")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<SampleContext>());
        }

        public DbSet<News> News { get; set; }
        public DbSet<Source> Sources { get; set; }
    }
}
