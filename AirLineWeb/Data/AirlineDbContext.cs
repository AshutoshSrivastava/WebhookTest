using AirLineWeb.Models;
using Microsoft.EntityFrameworkCore;


namespace AirLineWeb.Data
{
    public class AirlineDbContext : DbContext
    {
        public AirlineDbContext(DbContextOptions<AirlineDbContext> opt) :base(opt)
        {
            
        }        
    
        public DbSet<WebhookSubscription> WebhookSubscriptions { get; set; }
    }
}