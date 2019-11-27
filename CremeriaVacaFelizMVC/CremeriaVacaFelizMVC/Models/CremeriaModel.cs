namespace CremeriaVacaFelizMVC.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CremeriaModel : DbContext
    {
        public CremeriaModel()
            : base("name=ContextModel")
        {
        }

        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Empleado> Empleados { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<TipoPago> TipoPagoes { get; set; }
        public virtual DbSet<Venta> Ventas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
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
