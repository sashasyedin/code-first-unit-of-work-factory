using System.Collections.Generic;

namespace Quizmaster.Entities
{
    public class Section : Entity<int>
    {
        public virtual ICollection<Question> Questions { get; set; }
    }
}
