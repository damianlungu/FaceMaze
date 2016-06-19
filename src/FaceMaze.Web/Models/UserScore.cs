namespace FaceMaze.Web.Models
{
    public class UserScore
    {
        public int Id { get; set; }
        public virtual User User { get; set; }
        public int Score { get; set; }
    }
}