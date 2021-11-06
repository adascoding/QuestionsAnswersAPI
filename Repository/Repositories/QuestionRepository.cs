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
    public class QuestionRepository : GenericRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(ApplicationContext context) : base(context)
        {
        }

        public Question GetRandomQuestion()
        {
            Random rand = new Random();
            int toSkip = rand.Next(0, _context.Questions.Count());
            return _context.Questions.Skip(toSkip).Take(1).First();
        }
    }
}
