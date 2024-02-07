using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace SignalRChat.Data
{
    public class AppContext : IdentityDbContext
    {
        // コンストラクタ
        //public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        //{

        //}        

        //public DbSet<IdentityUser> coaches { get; set; }
        //public DbSet<Player> players { get; set; }
        //public DbSet<Staff> staffs { get; set; }
        //public DbSet<Status> statuses { get; set; }
        //public DbSet<User> users { get; set; }
        //public DbSet<UserCode> userCodes { get; set; }
        //public DbSet<Event> events { get; set; }
        //public DbSet<EventType> eventTypes { get; set; }
    }
}
