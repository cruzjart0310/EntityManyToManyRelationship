using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTest.Models
{
    public class StudentAnswer
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int SurveyId { get; set; }
        public ICollection<Survey> Survey { get; set; }
        public int QuestionId { get; set; }
        public Question Question { get; set; }
        public int AswerId { get; set; }
        public Answer Answer { get; set; }

    }
}
