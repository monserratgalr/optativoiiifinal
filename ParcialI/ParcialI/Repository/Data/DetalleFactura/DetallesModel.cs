using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcialI.Repository.Data.DetalleFactura
{
    public class DetallesModel
    {
        public int idDetalle { get; set; }
        public int idFactura { get; set; }
        public int idProducto { get; set; }
        public string cantProducto { get; set; }
        public string subTotal { get; set; }

        public DetallesModel(int idDetalle, int idFactura, int idProducto, string cantProducto, string subTotal)
        {
            this.idDetalle = idDetalle;
            this.idFactura = idFactura;
            this.idProducto = idProducto;
            this.cantProducto = cantProducto;
            this.subTotal = subTotal;
        
        }

    }
}
