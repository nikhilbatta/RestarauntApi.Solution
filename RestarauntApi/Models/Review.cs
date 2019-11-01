namespace RestarauntApi.Models
{
    public class Review
    {
        public int Id {get;set;}
        public int RestarauntId {get;set;}
        public Restarunt RestaruntV {get;set;}
        public int userId {get;set;}
        public User User {get;set;}
        public string Title {get;set;}
        public string Body {get;set;}
    }
}