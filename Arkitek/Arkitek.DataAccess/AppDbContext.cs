using Arkitek.Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace Arkitek.DataAccess
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {

        public DbSet<About> Abouts { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Choose> Chooses { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Social> Socials { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamSocial> TeamSocials { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<UserMessage> UserMessages { get; set; }
    }
}
