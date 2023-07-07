using System.ComponentModel.DataAnnotations;

namespace RazorPagesUI.Data
{
    public class SurveyAnswer
    {
        public Guid SurveyId { get; set; }
        public Survey? Survey { get; set; }

        //Answer that was displayed in question
        public Guid AnswerTemplateId { get; set; }
        public AnswerTemplate? AnswerTemplate { get; set; }

        //Selection that is stored in the database base
        [StringLength(250)]
        public string? UserAnswer { get; set; }

        public DateTime? TimeEntered { get; set; }
    }
}
