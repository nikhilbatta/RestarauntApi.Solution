namespace RestarauntApi.Models
{
    public class Restarunt
    {
        public int Id {get;set;}
        public string Name {get;set;}
        public string Description {get;set;}
        public string HoursOfOperation {get;set;}
        public ICollection<Review> Reviews {get;set;}
        
        public Restarunt()
        {
            this.Reviews = new HashSet<Review>();
        }
    }
}