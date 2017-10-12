using System.ComponentModel.DataAnnotations.Schema;

namespace Quizmaster.Common.Entities
{
    [Table("Answer")]
    public class Answer : Entity<int>
    {
        public bool Value { get; set; }

        public int QuestionId { get; set; }

        [ForeignKey("QuestionId")]
        public virtual Question Question { get; set; }
    }
}
