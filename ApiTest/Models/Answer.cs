using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTest.Models
{
    public class Answer
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public Question Question { get; set; }
    }
}
