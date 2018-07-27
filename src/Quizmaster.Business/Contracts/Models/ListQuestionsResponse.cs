using Quizmaster.Common.Models;
using Quizmaster.Entities;
using System.Collections.Generic;

namespace Quizmaster.Business.Contracts.Models
{
    public class ListQuestionsResponse : Response<ListQuestionsResult>
    {
        public IEnumerable<Question> Questions { get; set; }
    }
}
