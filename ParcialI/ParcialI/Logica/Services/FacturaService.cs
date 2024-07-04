using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ParcialI.Logica.Services
{
    public class FacturaService
    {

        public int idFactura { get; set; }
        public int idCliente { get; set; }
        public string nroFactura { get; set; }
        public DateTime fechaHora { get; set; }
        public decimal total { get; set; }
        public decimal iva5 { get; set; }
        public decimal iva10 { get; set; }
        public decimal ivaTotal { get; set; }
        public string sucursal { get; set; }
        public string letras { get; set; }

        public bool validacionFactura()
        {
            Regex regexNumeroFactura = new Regex(@"^\d{3}-\d{3}-\d{6}$");
            if (!regexNumeroFactura.IsMatch(nroFactura))
            {
                Console.WriteLine("El numero de factura ingresado no cumple con los requisitos. Favor vuelva a intentar!");
                return false;
            }

            if (string.IsNullOrEmpty(letras) || letras.Length < 6)
            {
                Console.WriteLine("El total de letras debe ser de un minimo de 6 caracteres!!! Volver a intentar");
                return false;
            }

            if (total <= 0 || iva5 < 0 || iva10 < 0) //comprueba que los valores no sean menores a 0 
            {
                Console.WriteLine("Los totales no pueden ser negativos!");
                return false;
            }

            return true;
        }

    }
}

