using System.ComponentModel.DataAnnotations.Schema;

namespace Quizmaster.Entities
{
    [Table("Answer")]
    public class Answer : Entity<int>
    {
        public bool Value { get; set; }

        public int QuestionId { get; set; }

        [ForeignKey("QuestionId")]
        public Question Question { get; set; }
    }
}
