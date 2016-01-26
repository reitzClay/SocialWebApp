using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SocialWebApp.Models;
using System.Data.Entity;


namespace SocialWebApp.DAL
{
    public class RelationInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<RelationContext>
    {
        protected override void Seed(RelationContext context)
        {
            var persons = new List<Person>
            {
                new Person {ID=1, FirstName="Clayton", LastName="Reitz", Age=27, Gender="Male" },
                new Person {ID=2, FirstName="Lauren", LastName="Reitz", Age=21, Gender="Female" },
                new Person {ID=3, FirstName="Marquin", LastName="Reitz", Age=23, Gender="Male" },
                new Person {ID=4, FirstName="Jason", LastName="Gordon", Age=27, Gender="Male" },
                new Person {ID=5, FirstName="Chadwin", LastName="Gordon", Age=25, Gender="Male" },
                new Person {ID=6, FirstName="Wilhelmina", LastName="Reitz", Age=47, Gender="Female" },
                new Person {ID=7, FirstName="Albertus", LastName="Reitz", Age=50, Gender="Male" }                
            };

            persons.ForEach(p => context.Persons.Add(p));
            context.SaveChanges();

            var related = new List<Related>
            {
                new Related {RelatedID=1, FirstName="Jan", LastName="Smith"},
                new Related {RelatedID=2, FirstName="James", LastName="Brown"},
                new Related {RelatedID=3, FirstName="Juniper", LastName="Grey"},
                new Related {RelatedID=4, FirstName="Garth", LastName="Vonkel"},
                new Related {RelatedID=5, FirstName="Ada", LastName="Kaf"},
                new Related {RelatedID=6, FirstName="Kim", LastName="Neil"},
                new Related {RelatedID=7, FirstName="Camofer", LastName="Kino"}                            
            };

            related.ForEach(r => context.Relateds.Add(r));
            context.SaveChanges();

            var relationshiptypes = new List<RelationshipType>
            {
                new RelationshipType {PersonID=1, RelatedID=1, Relations=Relations.Brother },
                new RelationshipType {PersonID=1, RelatedID=2, Relations=Relations.Wife },
                new RelationshipType {PersonID=3, RelatedID=3, Relations=Relations.Aunt},
                new RelationshipType {PersonID=4, RelatedID=4, Relations=Relations.Sister },
                new RelationshipType {PersonID=5, RelatedID=5, Relations=Relations.Colleague },
                new RelationshipType {PersonID=6, RelatedID=6, Relations=Relations.Mother },
                new RelationshipType {PersonID=7, RelatedID=7, Relations=Relations.Father },

            };
        }
    }
}