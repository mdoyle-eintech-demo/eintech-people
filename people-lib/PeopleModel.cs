using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace eintech_people_lib
{
    /// <summary>An entity dbContext for the people database (Uses SQLLite).</summary>
    public class PeopleContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(@"Data Source=D:\Work\eintech-people\people-lib\people.db");
    }

    /// <summary>An concrete class that implments IPerson, used as the enetity model type.</summary>
    public class Person : IPerson
    {
        [Key]
        public Guid PersonId { get; set; }
        public string Name { get; set; }
        public DateTime LastUpdatedOn { get; set; }
    }
}
