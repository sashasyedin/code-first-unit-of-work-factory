using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quizmaster.Entities
{
    [Table("Question")]
    public class Question : Entity<int>
    {
        public int SectionId { get; set; }

        [ForeignKey("SectionId")]
        public Section Section { get; set; }

        public ICollection<Answer> Answers { get; set; }
    }
}
