using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcialI.Repository.Data.PedidosCompras
{
    public class PedidoCompraModel
    {
        public int idPedidoCompra { get; set; }
        public int idProveedor { get; set; }
        public int idSucursal { get; set; }
        public DateTime fechaHora { get; set; }
        public float total { get; set; }


        public PedidoCompraModel(int idPedidoCompra, int idProveedor, int idSucursal, DateTime fechaHora, float total)
        {
            this.idPedidoCompra = idPedidoCompra;
            this.idProveedor = idProveedor;
            this.idSucursal = idSucursal;
            this.fechaHora = fechaHora;
            this.total = total;

        }
    }
}
