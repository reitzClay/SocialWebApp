using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SocialWebApp.Models
{
    public class Related
    {
       //[DatabaseGenerated(DatabaseGeneratedOption.None)]

        public int RelatedID { get; set; }
        
        public int PersonID { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public string Relation { get; set; }
        

        public virtual ICollection<RelationshipType> RelationshipTypes { get; set; }
        
        
    }
}