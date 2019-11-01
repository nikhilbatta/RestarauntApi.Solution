using System.Collections.Generic;

namespace RestarauntApi.Models
{
    public class Restaraunt
    {
        public int Id {get;set;}
        public string Name {get;set;}
        public string Description {get;set;}
        public string HoursOfOperation {get;set;}
        public ICollection<Review> Reviews {get;set;}
        
        public Restaraunt()
        {
            this.Reviews = new HashSet<Review>();
        }
    }
}