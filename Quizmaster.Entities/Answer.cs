namespace Quizmaster.Entities
{
    public class Answer : Entity<int>
    {
        public bool Value { get; set; }

        public int QuestionId { get; set; }

        public virtual Question Question { get; set; }
    }
}
