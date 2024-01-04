using EasyJamDAL.Configurations;
using EasyJamDAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EasyJamDAL.Context
{
    public class EasyJamContext : DbContext
    {
        public DbSet<Musicien> Musiciens { get { return Set<Musicien>(); } }
        public DbSet<JamSession> Jams { get { return Set<JamSession>(); } }
        public DbSet<Admin> Admins { get { return Set<Admin>(); } }
        public DbSet<ChordProgression> Chords { get { return Set<ChordProgression>(); } }

        public EasyJamContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AdminConfig());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("DefaultConnection");
            }
        }
    }
}
