using System.ComponentModel.DataAnnotations;

namespace RazorPagesUI.Data
{
    public enum AnswerType
    {
        Dropdown,
        SelectOne,
        SelectMany,
        Ranking,
        EnterValue
    }

    public class Question
    {
        public Guid Id { get; set; }
        [StringLength(250)]
        public string? QuestionField { get; set; }
        public int DisplayOrder { get; set; }
        public Guid? FollowsAnswerId { get; set; }
        public AnswerTemplate? FollowsAnswer { get; set; }

        //helps with frontend to display answers easily
        public AnswerType AnswerType { get; set; }

        public Guid CampaignId { get; set; }
        public Campaign? Campaign { get; set; }
        public List<AnswerTemplate>? AnswerTemplates { get; set; }
    }
}
