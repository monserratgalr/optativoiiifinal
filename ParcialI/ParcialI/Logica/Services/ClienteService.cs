using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using ParcialI.Repository.Data.Clientes;

namespace ParcialI.Logica.Services
{
    public class ClienteService
    {
        public ClienteRepository ClienteRepository;

        public ClienteService(string connection)
        {
            ClienteRepository = new ClienteRepository(connection);
        }

        public void Agregar(ClienteModel cliente)
        {
            if (validacionCliente(cliente))
            {
                ClienteRepository.agregarCliente(cliente);
            }
            else
            {
                throw new Exception("Ha ocurrido un error! Vuelva a intentar...");
            }
        }

        private bool validacionCliente(ClienteModel cliente)
        {
            if (cliente == null)
            {
                return false;
            }

            if (string.IsNullOrEmpty(cliente.nombre) || cliente.nombre.Length < 3)
            {
                return false;
            }
            if (string.IsNullOrEmpty(cliente.apellido) || cliente.apellido.Length < 3)
            {
                return false;
            }
            if (string.IsNullOrEmpty(cliente.documento) || cliente.documento.Length < 3)
            {
                return false;
            }

            if (string.IsNullOrEmpty(cliente.celular))
            {
                return false;
            }

            Regex regex = new Regex(@"^\d{10}$");
            if (!regex.IsMatch(cliente.celular))
            {
                return false;
            }

            return true;
        }
    }
}
