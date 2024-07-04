using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcialI.Repository.Data.Sucursales
{
    public class SucursalModel
    {
        public int idSucursal { get; set; }
        public string descripcion { get; set; }
        public string direccion { get; set; }
        public int telefono { get; set; }
        public int wsp { get; set; }
        public string email { get; set; }
        public string estado { get; set; }


        public SucursalModel(int idSurcursal, string descripcion, string direccion, int telefono, int wsp, string email, string estado)
        {
            this.idSucursal = idSurcursal;
            this.descripcion = descripcion;
            this.direccion = direccion;
            this.telefono = telefono;
            this.wsp = wsp;
            this.email = email;
            this.estado = estado;
        }
    }
}
