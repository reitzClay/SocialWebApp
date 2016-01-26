using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SocialWebApp.Models
{
    public class Person
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int ID { get; set; }
        public string FirstName{ get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        

        public virtual ICollection<RelationshipType> RelationshipTypes { get; set; }
    }
}