namespace RazorPagesUI.Data
{
    public class UserRight
    {
        public Guid UserId { get; set; }
        public User? User { get; set; }

        public int RightId { get; set; }
        public Right? Right { get; set; }
    }
}
