using Models;
using Repositories.Interfaces;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repositories
{
    public class AnswerRepository : GenericRepository<Answer>, IAnswerRepository
    {
        public AnswerRepository(ApplicationContext context) : base(context)
        {
        }
        public IEnumerable<Answer> GetAnswersForQuestion(int Id)
        {
            return _context.Set<Answer>().Where(x=> x.QuestionId == Id).ToList();
        }
    }
}
