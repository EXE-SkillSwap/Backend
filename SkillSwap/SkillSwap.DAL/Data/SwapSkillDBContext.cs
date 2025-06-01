using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SkillSwap.DAL.Model;

namespace SkillSwap.DAL.Data
{
    public class SwapSkillDBContext : DbContext
    {
        public SwapSkillDBContext() { }
        public SwapSkillDBContext(DbContextOptions<SwapSkillDBContext> options) : base(options) { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Conversation> Conversations { get; set; }
        public DbSet<ConversationPartners> Partners { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<MembershipSubscription> MembershipSubscriptions { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<PartnerShip> PartnersShip { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Review> Reviews { get; set; }  
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<UserCourse> UserCourses { get; set;}
        public DbSet<UserMembership> userMemberships { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-0BFN572\\PIEDTEAM;database=SwapSkillDB;uid=sa;pwd=12345;TrustServerCertificate=True;MultipleActiveResultSets=True;");
        }

    }
}
