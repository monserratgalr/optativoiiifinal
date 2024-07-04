using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcialI.Repository.Data.DetallesPedidos
{
    public class DetallePedidoModel
    {
        public int idDetallePedido { get; set; }
        public int idPedido { get; set; }
        public int idProducto { get; set; }
        public string cantProducto { get; set; }
        public float subTotal { get; set; }

        public DetallePedidoModel(int idDetallePedido, int idPedido, int idProducto, string cantProducto, float subTotal)
        {
            this.idDetallePedido = idDetallePedido;
            this.idPedido = idPedido;
            this.idProducto = idProducto;
            this.cantProducto = cantProducto;
            this.subTotal = subTotal;

        }
    }
}
