using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTest.Models
{
    public class AssigmentStudent
    {
        //public int AssigmentStudentId { get; set; }
        public int StudentId { get; set; }
        //[NotMapped]
        public Student Student { get; set; }
        public int AssigmentId { get; set; }
        //[NotMapped]
        public Assigment Assigment { get; set; }
    }
}
