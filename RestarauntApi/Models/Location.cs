namespace RestarauntApi.Models
{
    public class Location
    {
        public int Id {get;set;}
        public string City{get;set;}
        public string State{get;set;}
        public string ZipCode{get;set;}
        public ICollection<User> Users {get;set;}
        public ICollection<Restaraunt> Restaraunts {get;set;}
        public Location()
        {
            this.Users = new HashSet<User>();
            this.Restaraunts = new HashSet<Restaraunt>();
        }
    }
}