namespace Training.Api.DataLayer.Models
{
    using Microsoft.EntityFrameworkCore;

    public partial class ApiTrainingContext : DbContext
    {
        public virtual DbSet<Pet> Pet { get; set; }
        public virtual DbSet<User> User { get; set; }

        public ApiTrainingContext(DbContextOptions options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pet>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Mobile).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);
            });
        }
    }
}