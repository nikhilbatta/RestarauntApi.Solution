namespace RestarauntApi.Models
{
    public class User
    {
        public int Id {get;set;}
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public ICollection<Review> UserReviews {get;set;}
        public User()
        {
            this.UserReviews = new HashSet<Review>();
        }
    }
}