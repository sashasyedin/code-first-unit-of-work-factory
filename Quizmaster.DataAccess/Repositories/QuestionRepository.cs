using System.Data.Entity;
using Quizmaster.Common.Contracts;
using Quizmaster.Entities;

namespace Quizmaster.DataAccess.Repositories
{
    public class QuestionRepository : BaseRepository<Question>, IQuestionRepository
    {
        public QuestionRepository(DbContext context)
            : base(context)
        {
        }
    }
}
