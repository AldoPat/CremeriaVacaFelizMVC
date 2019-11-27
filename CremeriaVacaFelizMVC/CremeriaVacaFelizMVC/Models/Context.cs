namespace CremeriaVacaFelizMVC.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Context : DbContext
    {
        public Context()
            : base("name=Context")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Empleado> Empleados { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<TipoPago> TipoPagoes { get; set; }
        public virtual DbSet<Venta> Ventas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<Categoria>()
                .Property(e => e.StrValor)
                .IsUnicode(false);

            modelBuilder.Entity<Categoria>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Categoria>()
                .HasMany(e => e.Productos)
                .WithRequired(e => e.Categoria)
                .HasForeignKey(e => e.CatCategoria)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.APaterno)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.AMaterno)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .Property(e => e.Direccion)
                .IsUnicode(false);

            modelBuilder.Entity<Cliente>()
                .HasMany(e => e.Ventas)
                .WithRequired(e => e.Cliente)
                .HasForeignKey(e => e.CatCliente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Empleado>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Empleado>()
                .Property(e => e.APaterno)
                .IsUnicode(false);

            modelBuilder.Entity<Empleado>()
                .Property(e => e.AMaterno)
                .IsUnicode(false);

            modelBuilder.Entity<Empleado>()
                .Property(e => e.Direccion)
                .IsUnicode(false);

            modelBuilder.Entity<Empleado>()
                .Property(e => e.Puesto)
                .IsUnicode(false);

            modelBuilder.Entity<Empleado>()
                .HasMany(e => e.Ventas)
                .WithRequired(e => e.Empleado)
                .HasForeignKey(e => e.CatEmpleado)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Producto>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Producto>()
                .HasMany(e => e.Ventas)
                .WithRequired(e => e.Producto)
                .HasForeignKey(e => e.CatProducto)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TipoPago>()
                .Property(e => e.strValor)
                .IsUnicode(false);

            modelBuilder.Entity<TipoPago>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<TipoPago>()
                .HasMany(e => e.Ventas)
                .WithRequired(e => e.TipoPago1)
                .HasForeignKey(e => e.TipoPago)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Venta>()
                .Property(e => e.NumeroVenta)
                .IsUnicode(false);
        }
    }
}
