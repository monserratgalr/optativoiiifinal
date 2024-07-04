using ParcialI.Repository.Data.Productos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcialI.Logica.Services
{
    public class ProductoService
    {
        public ProductoRepository ProductoRepository;

        public ProductoService(string connection)
        {
            if (connection == null)
            {
                throw new ArgumentNullException("connection");
            }

            ProductoRepository = new ProductoRepository(connection);
        }

        private bool validarProducto(ProductoModel producto) //dentro de aqui ya se hacen las validaciones de los precios de compra y venta
        {
            if (string.IsNullOrEmpty(producto.descripcion) ||
                string.IsNullOrEmpty(producto.cantMinima) ||
                string.IsNullOrEmpty(producto.cantStock) ||
                !int.TryParse(producto.precioCompra, out int precioCompra) || precioCompra <= 0 || 
                !int.TryParse(producto.precioVenta, out int precioVenta) || precioVenta <= 0 || 
                string.IsNullOrEmpty(producto.categoria) ||
                string.IsNullOrEmpty(producto.marca) ||
                string.IsNullOrEmpty(producto.estado))
            {
                return false;
            }

            if (!int.TryParse(producto.cantMinima, out int cantMinima) && cantMinima <= 1)
            {
                throw new ArgumentException("La cantidad mínima debe ser un número entero mayor que 1.");
            }

            return true;
        }
    
        
public void AddProducto(ProductoModel producto)
        {
            if (producto == null)
            {
                throw new ArgumentNullException("producto");
            }

            if (!validarProducto(producto))
            {
                throw new ArgumentException("El producto no cumple con los requisitos...");
            }
        }

    }
}
