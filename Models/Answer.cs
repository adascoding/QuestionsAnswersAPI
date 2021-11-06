using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Answer
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AnsweredBy { get; set; }
        public DateTime LastModified { get; set; }
        public int QuestionId { get; set; }
    }
}
