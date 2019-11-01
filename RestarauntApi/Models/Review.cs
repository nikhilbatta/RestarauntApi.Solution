namespace RestarauntApi.Models
{
    public class Review
    {
        public int Id {get;set;}
        public int RestarauntId {get;set;}
        public Restaraunt RestaruntV {get;set;}
        public int UserId {get;set;}
        public User User {get;set;}
        public string Title {get;set;}
        public string Body {get;set;}
    }
}