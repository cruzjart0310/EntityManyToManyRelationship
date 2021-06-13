using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTest.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Country Country { get; set; }
        public State State { get; set; }
        public City City { get; set; }
        public string StrretAdrress { get; set; }
    }
}
