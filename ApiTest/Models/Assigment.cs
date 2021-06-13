using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTest.Models
{
    public class Assigment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //[NotMapped]
        public ICollection<Student> Students { get; set; }
    }
}
