using System.ComponentModel.DataAnnotations;

namespace RazorPagesUI.Data
{
    public class AnswerTemplate
    {
        public Guid Id { get; set; }
        public int DisplayOrder { get; set; }

        [StringLength(50)]  
        public string? Description { get; set; }

        //Question the answer is for 
        public Guid QuestionId { get; set; }
        public Question? Question { get; set; }

        // How many surveys (people) have chosen this answer 
        public List<SurveyAnswer>? SurveyAnswers { get; set; }
    }
}
