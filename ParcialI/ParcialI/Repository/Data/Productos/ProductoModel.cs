using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcialI.Repository.Data.Productos
{
    public class ProductoModel
    {
        public int idProducto { get; set; }
        public string descripcion { get; set; }
        public string cantMinima { get; set; }
        public string cantStock { get; set; }
        public string precioCompra { get; set; }
        public string precioVenta { get; set; }
        public string categoria { get; set; }
        public string marca { get; set; }
        public string estado { get; set; }

    public ProductoModel(int idProducto, string descripcion, string cantMinima, string cantStock, string precioCompra, string precioVenta, string categoria, string marca, string estado)
    {
        this.idProducto = idProducto;
        this.descripcion = descripcion;
        this.cantMinima = cantMinima;
        this.cantStock = cantStock;
        this.precioCompra = precioCompra;
        this.precioVenta = precioVenta;
        this.categoria = categoria;
        this.marca = marca;
        this.estado = estado;
        }
}
      
}



