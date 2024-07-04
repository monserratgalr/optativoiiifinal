using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcialI.Repository.Data.Proveedores
{
    public class ProveedorModel
    {
        public int idProveedor { get; set; }
        public string razonSocial { get; set; }
        public string tipoDocumento { get; set; }
        public string numeroDocumento { get; set; }
        public string direccion { get; set; }
        public string mail { get; set; }
        public string celular { get; set; }
        public string estado { get; set; }

        public ProveedorModel(int idProveedor, string razonSocial, string tipoDocumento, string numeroDocumento, string direccion, string mail, string celular, string estado)
        {
            this.idProveedor = idProveedor;
            this.razonSocial = razonSocial;
            this.tipoDocumento = tipoDocumento;
            this.numeroDocumento = numeroDocumento;
            this.direccion = direccion;
            this.mail = mail;
            this.celular = celular;
            this.estado = estado;
        }
    }
}
