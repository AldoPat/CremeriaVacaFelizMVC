namespace CremeriaVacaFelizMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Productos")]
    public partial class Producto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Producto()
        {
            Ventas = new HashSet<Venta>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        public int Cantidad { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Fecha_Caducidad { get; set; }

        public int CatCategoria { get; set; }

        public decimal Peso { get; set; }

        public decimal Precio { get; set; }

        public virtual Categoria Categoria { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Venta> Ventas { get; set; }
    }
}
