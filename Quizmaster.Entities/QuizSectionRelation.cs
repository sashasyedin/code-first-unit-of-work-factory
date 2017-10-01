using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quizmaster.Entities
{
    [Table("TestSectionRelation")]
    public class TestSectionRelation
    {
        [Key, Column(Order = 0)]
        public int QuizId { get; set; }

        [Key, Column(Order = 1)]
        public int SectionId { get; set; }

        public double CommonPercent { get; set; }

        [ForeignKey("QuizId")]
        public Quiz Quiz { get; set; }

        [ForeignKey("SectionId")]
        public Section Section { get; set; }
    }
}
