using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialWebApp.Models
{
    public enum Relations
    {
        Father = 1,
        Mother = 2,
        Brother = 3,
        Sister = 4,
        Uncle = 5,
        Aunt = 6,
        Husband = 7,
        Wife = 8,
        Colleague = 9,
        Son = 10,
        Daughter = 11,
    }

    public class RelationshipType
    {
        public int RelationshipTypeID { get; set; }

        public int PersonID { get; set; }
        public int RelatedID { get; set; }

        public Relations? Relations { get; set; }

        public virtual Person Person { get; set; }
        public virtual Related Related { get; set; }
    }
}