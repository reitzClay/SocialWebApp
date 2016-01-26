using SocialWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialWebApp.ViewModels
{
    public class PersonDetailsData
    {
        public IEnumerable<Person> Persons { get; set; }
        public IEnumerable<Related> Relateds { get; set; }
        public IEnumerable<RelationshipType> RelationshipType { get; set; }
    }
}