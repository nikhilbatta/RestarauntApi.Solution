using Microsoft.EntityFrameworkCore;

namespace RestarauntApi.Models
{
    public class RestarauntApiContext : DbContext 
    {
        public RestarauntApiContext(DbContextOptions<RestarauntApiContext> options) : base (options)
        {

        }
        public DbSet<Restaraunt> Restraunts {get;set;}
        public DbSet<Review> Reviews {get;set;}
        public DbSet<User> Users {get;set;}
    }
}