using eintech_people_lib;
using NUnit.Framework;
using people_lib;
using System;
using System.Linq;

namespace tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestDbContext()
        {
            using (var db = new PeopleContext())
            {
                // Create
                Guid personId = System.Guid.NewGuid();
                db.Add(new Person { PersonId = personId, Name = "Test", LastUpdatedOn = DateTime.UtcNow });
                db.SaveChanges();

                // Read
                var person = db.Persons.Find(personId);
                Assert.AreEqual("Test", person.Name);
                
                // Remove
                db.Remove(person);
                db.SaveChanges();
            }
        }

        [Test] 
        public void TestSource() {
            IPerson addedPerson;
            using (var source = new PeopleSource()) {
                addedPerson = source.Add("Test two");
            }

            using (var source = new PeopleSource())
            {
                var foundPerson = source.Query.FirstOrDefault(p => p.PersonId == addedPerson.PersonId);
                Assert.AreEqual("Test two", foundPerson.Name, "Person not found via query");
                
                source.Delete(foundPerson.PersonId);
            }
        }
    }
}