using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IAnswerRepository : IGenericRepository<Answer>
    {
        IEnumerable<Answer> GetAnswersForQuestion(int Id);
    }
}
