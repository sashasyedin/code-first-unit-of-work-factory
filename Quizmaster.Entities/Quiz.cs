namespace Quizmaster.Entities
{
    public class Quiz : Entity<int>
    {
        public int QuestionsQuantity { get; set; }

        public int MinutesAllotted { get; set; }
    }
}
