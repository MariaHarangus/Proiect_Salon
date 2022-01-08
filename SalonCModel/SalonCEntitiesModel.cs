using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace SalonCModel
{
    public partial class SalonCEntitiesModel : DbContext
    {
        public SalonCEntitiesModel()
            : base("name=SaloCEntitiesModel")
        {
        }

        public virtual DbSet<Angajati> Angajatis { get; set; }
        public virtual DbSet<Clienti> Clientis { get; set; }
        public virtual DbSet<Inventar> Inventars { get; set; }
        public virtual DbSet<Programare> Programares { get; set; }
        public virtual DbSet<Servicii> Serviciis { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Angajati>()
                .HasMany(e => e.Programares)
                .WithRequired(e => e.Angajati)
                .HasForeignKey(e => e.Id_Angajat);

            modelBuilder.Entity<Clienti>()
                .HasMany(e => e.Programares)
                .WithOptional(e => e.Clienti)
                .HasForeignKey(e => e.Id_Client)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Servicii>()
                .HasMany(e => e.Programares)
                .WithOptional(e => e.Servicii)
                .WillCascadeOnDelete();
        }
    }
}
