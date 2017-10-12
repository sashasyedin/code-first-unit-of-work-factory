using System.ComponentModel.DataAnnotations.Schema;

namespace Quizmaster.Common.Entities
{
    [Table("Quiz")]
    public class Quiz : Entity<int>
    {
        public int QuestionsQuantity { get; set; }

        public int MinutesAllotted { get; set; }
    }
}
