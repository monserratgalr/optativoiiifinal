using ParcialI.Repository.Data.Sucursales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ParcialI.Logica.Services
{
    public class SucursalService
    {
        private bool ValidacionEmail(string email) 
        {
            if (string.IsNullOrEmpty(email))
            {
                return false;
            }

            const string emailPattern = @"^[^\s@]+@[^\s@]+\.[^\s@]+$";
            Regex regex = new Regex(emailPattern);
            return regex.IsMatch(email);
        }

        private bool ValidacionSucursal(SucursalModel sucursal)
        {
            if (sucursal.direccion.Length < 10)
            {
                return false;
            }

            if (!ValidacionEmail(sucursal.email)) 
            {
                return false;
            }

            return true;
        }
    }
}
