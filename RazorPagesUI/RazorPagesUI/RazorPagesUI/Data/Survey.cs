namespace RazorPagesUI.Data
{
    public class Survey
    {
        // Unique for each instance of a survey (ie each survey taken)
        public Guid Id { get; set; }
        public DateTime TimeStarted { get; set; }

        // Determined by looking at which URL was used
        public Guid CampaignAssignmentId { get; set; }
        public CampaignAssignment? CampaignAssignment { get; set; }
        public List<SurveyAnswer>? Answers { get; set; }
    }
}
