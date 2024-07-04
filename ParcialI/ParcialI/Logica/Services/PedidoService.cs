using ParcialI.Repository.Data.DetalleFactura;
using ParcialI.Repository.Data.Facturas;
using ParcialI.Repository.Data.Productos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace ParcialI.Logica.Services
{
    public class PedidoService
    {
        public FacturaModel FacturaConDetalles(int idFactura)
        {
            FacturaModel factura;
            string queryFactura = "SELECT * FROM Factura WHERE idFactura = @idFactura";
            string queryDetalles = @"SELECT df.*, p.* 
                                     FROM DetalleFactura df
                                     JOIN Producto p ON df.idProducto = p.idProducto
                                     WHERE df.idFactura = @idFactura";

            using (var multi = connection.QueryMultiple(queryFactura + ";" + queryDetalles, new { idFactura }))
            {
                factura = multi.Read<FacturaModel>().FirstOrDefault();
                var detalles = multi.Read<DetallesModel, ProductoModel, DetallesModel>((df, p) =>
                {
                    df.producto = p;
                    return df;
                }, splitOn: "idProducto").ToList();

                if (factura != null)
                {
                    factura.Detalles = detalles;
                    factura.total = detalles.sum(df => df.producto.precioCompra * df.cantidad);
                }
            }

            return factura;
        }
    }
}

   
