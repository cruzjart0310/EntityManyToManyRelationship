using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTest.Models
{
    public class State
    {
        public State()
        {
            City = new HashSet<City>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<City> City { get; set; }
    }
}
