using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTest.Models
{
    public class Question
    {
        public Question()
        {
            Answer = new HashSet<Answer>();
        }
        public int Id { get; set; }
        public String Title { get; set; }

        public ICollection<Answer> Answer { get; set; }
    }
}
