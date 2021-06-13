using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTest.Models
{
    public class Country
    {
        public Country()
        {

            State = new HashSet<State>();

        }
        public int Id { get; set; }
        public string Name { get; set; }

        //[NotMapped]
        public ICollection<State> State { get; set; }
    }
}
