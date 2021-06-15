using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTest.Models
{
    public class Question
    {
        //    public Question()
        //    {
        //        Answer = new HashSet<Answer>();
        //    }

        public int Id { get; set; }
        public string Title { get; set; }
        public Type Type { get; set; }

        public ICollection<Answer> Answers { get; set; }

        
    }
}
