using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quizmaster.Entities
{
    [Table("Section")]
    public class Section : Entity<int>
    {
        public virtual ICollection<Question> Questions { get; set; }
    }
}
