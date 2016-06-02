namespace Godun
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model : DbContext
    {
        public Model()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Organisations> Organisations { get; set; }
        public virtual DbSet<PCs> PCs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Organisations>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Organisations>()
                .HasMany(e => e.PCs)
                .WithRequired(e => e.Organisations)
                .HasForeignKey(e => e.Org_Id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PCs>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<PCs>()
                .Property(e => e.CPU)
                .IsUnicode(false);

            modelBuilder.Entity<PCs>()
                .Property(e => e.RAM)
                .IsUnicode(false);

            modelBuilder.Entity<PCs>()
                .Property(e => e.OZU)
                .IsUnicode(false);

            modelBuilder.Entity<PCs>()
                .Property(e => e.HDD)
                .IsUnicode(false);

            modelBuilder.Entity<PCs>()
                .Property(e => e.User)
                .IsUnicode(false);

            modelBuilder.Entity<PCs>()
                .Property(e => e.OS)
                .IsUnicode(false);

            modelBuilder.Entity<PCs>()
                .Property(e => e.IP)
                .IsUnicode(false);

            modelBuilder.Entity<PCs>()
                .Property(e => e.MothersPlate)
                .IsUnicode(false);
        }
    }
}
