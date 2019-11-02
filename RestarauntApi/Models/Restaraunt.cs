using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;


namespace RestarauntApi.Models
{

   
    public class Restaraunt
    {
        public int Id {get;set;}
        public string Name {get;set;}
        public string Description {get;set;}
        public string HoursOfOperation {get;set;}
        public virtual ICollection<Review> Reviews {get;set;}
        
        public Restaraunt()
        {
            this.Reviews = new HashSet<Review>();
        }
    }
}