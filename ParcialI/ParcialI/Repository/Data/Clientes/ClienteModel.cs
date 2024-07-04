using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcialI.Repository.Data.Clientes
{
    public class ClienteModel
    {
        public int idCliente { get; set; }
        public int idBanco { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string documento { get; set; }
        public string direccion { get; set; }
        public string email { get; set; }
        public string celular { get; set; }
        public string estado { get; set; }

        public ClienteModel(int idCliente, int idBanco, string nombre, string apellido, string documento, string direccion, string email,
        string celular, string estado)
        {
            this.idCliente = idCliente;
            this.idBanco = idBanco;
            this.nombre = nombre;
            this.apellido = apellido;
            this.documento = documento;
            this.direccion = direccion;
            this.email = email;
            this.celular = celular;
            this.estado = estado;
        }

    }
}
