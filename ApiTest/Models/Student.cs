using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTest.Models
{
    public class Student
    {
         public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateBirth { get; set; }

        //[NotMapped]
        public ICollection<Assigment> Assigments { get; set; }

        public Profile Profile { get; set; }

        public ICollection<Address> Address { get; set; }
    }
}
