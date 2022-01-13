using Microsoft.EntityFrameworkCore;

#nullable disable

namespace DemoRepository.Models
{
    public partial class masterContext : DbContext
    {
        public masterContext()
        {
        }

        public masterContext(DbContextOptions<masterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CustomerAddress> CustomerAddresses { get; set; }
        public virtual DbSet<CustomerInformation> CustomerInformations { get; set; }
        public virtual DbSet<CustomerProfession> CustomerProfessions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=master;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<CustomerAddress>(entity =>
            {
                entity.ToTable("CustomerAddress");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.StreetNo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("StreetNo.");

                entity.Property(e => e.ZipCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CustomerInformation>(entity =>
            {
                entity.ToTable("CustomerInformation");

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.FirstName).HasMaxLength(100);

                entity.Property(e => e.LastName).HasMaxLength(100);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.CustomerAddress)
                    .WithMany(p => p.CustomerInformations)
                    .HasForeignKey(d => d.CustomerAddressId)
                    .HasConstraintName("FK_CustomerInformation_CustomerAddress");

                entity.HasOne(d => d.CustomerProfession)
                    .WithMany(p => p.CustomerInformations)
                    .HasForeignKey(d => d.CustomerProfessionId)
                    .HasConstraintName("FK_CustomerInformation_CustomerProfession");
            });

            modelBuilder.Entity<CustomerProfession>(entity =>
            {
                entity.ToTable("CustomerProfession");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.EmployeeId)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.JobDetail)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.JobTitle)
                    .IsRequired()
                    .HasMaxLength(1000);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
