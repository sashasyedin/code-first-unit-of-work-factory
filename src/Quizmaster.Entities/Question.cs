using System.Collections.Generic;

namespace Quizmaster.Entities
{
    public class Question : Entity<int>
    {
        public int? SectionId { get; set; }

        public virtual Section Section { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }
    }
}
