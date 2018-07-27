using System.ComponentModel.DataAnnotations;

namespace Quizmaster.Business.Contracts.Models
{
    /// <summary>
    /// The result of the ListQuestions operation.
    /// </summary>
    public enum ListQuestionsResult
    {
        /// <summary>
        /// The result is not set.
        /// </summary>
        [Display(Name = "System error.")]
        None = 0,

        /// <summary>
        /// No question found.
        /// </summary>
        [Display(Name = "No question found.")]
        QuestionNotFound,

        /// <summary>
        /// A list of questions was retrieved successfully.
        /// </summary>
        [Display(Name = "A list of questions has been retrieved successfully.")]
        Success,
    }
}
