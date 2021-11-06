using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public  class Question
    {
        public int Id {  get; set; }
        public string Title { get; set; }
        public string AddedBy { get; set; } = "Admin";
        public DateTime LastModified { get; set; }
    }
}
