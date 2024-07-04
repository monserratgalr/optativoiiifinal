using ParcialI.Repository.Data.Proveedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParcialI.Logica.Services
{
    public class ProveedorService
    {
        private bool ValidarProveedor(ProveedorModel proveedor)
        {
            if (string.IsNullOrWhiteSpace(proveedor.razonSocial) || proveedor.razonSocial.Length < 3)
            {
                throw new ArgumentException("La razon social debe contener al menos 3 caracteres y no puede estar vacia...");
            }

            if (string.IsNullOrWhiteSpace(proveedor.tipoDocumento) || proveedor.tipoDocumento.Length < 3)
            {
                throw new ArgumentException("El tipo de documento debe contener al menos 3 caracteres y no puede estar vacio...");
            }

            if (string.IsNullOrWhiteSpace(proveedor.numeroDocumento) || proveedor.numeroDocumento.Length < 3)
            {
                throw new ArgumentException("El número de documento debe contener al menos 3 caracteres y no puede estar vacio...");
            }

            if (!long.TryParse(proveedor.celular, out long celularNum) || proveedor.celular.Length != 10)
            {
                throw new ArgumentException("El número de celular debe ser numerico y contener 10 dígitos...");
            }

            return true;
        }
    }
}