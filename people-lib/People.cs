using eintech_people_lib;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;

namespace people_lib
{
    /// <summary>
    /// Simple library to access the people database.
    /// </summary>
    public class PeopleSource : IDisposable
    {
        private PeopleContext db = new PeopleContext();

        /// <summary>Add a person.</summary>
        /// <param name="name">The perons's name.</param>
        /// <returns>An IPerson of the person.</returns>
        public virtual IPerson Add(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name must not be empty.");
            Person person = new Person { PersonId = Guid.NewGuid(), Name = name, LastUpdatedOn = DateTime.UtcNow };
            db.Persons.Add(person);
            db.SaveChanges();
            return person;
        }
        
        /// <summary>Get an IQueryable of People.</summary>
        public virtual IQueryable<IPerson> Query => db.Persons;

        /// <summary>Delete a person by personId.</summary>
        public void Delete(Guid personId)
        {
            var person = db.Persons.Find(personId);
            db.Persons.Remove(person);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
