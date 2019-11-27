namespace CremeriaVacaFelizMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Venta
    {
        public int Id { get; set; }

        [StringLength(50)]
        public string NumeroVenta { get; set; }

        public int CatProducto { get; set; }

        public int CatCliente { get; set; }

        public int CatEmpleado { get; set; }

        public int TipoPago { get; set; }

        public int Cantidad { get; set; }

        public decimal PrecioUnitario { get; set; }

        public decimal SubTotal { get; set; }

        public decimal Total { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual Empleado Empleado { get; set; }

        public virtual Producto Producto { get; set; }

        public virtual TipoPago TipoPago1 { get; set; }
    }
}
