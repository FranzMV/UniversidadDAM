using System;
using System.Globalization;
using System.Windows.Controls;

namespace PresentacionWPF.ValidationRules
{
    public class NifValidationRules : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string resultado = value as string;
            int numero;
            string letra = "";
            string letraAux;

            if (resultado.Length <= 0 || resultado.Length > 9)
                return new ValidationResult(false, "El campo NIF no puede quedar vacío.");

            try
            {
                //NIE Extranjeros
                if (resultado.Substring(0, 1) == "X")
                    numero = Convert.ToInt32("0" + resultado.Substring(1, 8));
                else if (resultado.Substring(0, 1) == "Y")
                    numero = Convert.ToInt32("1" + resultado.Substring(1, 8));
                else if (resultado.Substring(0, 1) == "Z")
                    numero = Convert.ToInt32("2" + resultado.Substring(1, 8));
                else
                    numero = Convert.ToInt32(resultado.Substring(0, 8));

                letraAux = resultado.Substring(8).ToUpper();
              
                switch (numero % 23)
                {
                    case 0: letra = "T"; break;
                    case 1: letra = "R"; break;
                    case 2: letra = "W"; break;
                    case 3: letra = "A"; break;
                    case 4: letra = "G"; break;
                    case 5: letra = "M"; break;
                    case 6: letra = "Y"; break;
                    case 7: letra = "F"; break;
                    case 8: letra = "P"; break;
                    case 9: letra = "D"; break;
                    case 10: letra = "X"; break;
                    case 11: letra = "B"; break;
                    case 12: letra = "N"; break;
                    case 13: letra = "J"; break;
                    case 14: letra = "Z"; break;
                    case 15: letra = "S"; break;
                    case 16: letra = "Q"; break;
                    case 17: letra = "V"; break;
                    case 18: letra = "H"; break;
                    case 19: letra = "L"; break;
                    case 20: letra = "C"; break;
                    case 21: letra = "K"; break;
                    case 22: letra = "E"; break;
                }
            }
            catch (Exception)
            {
                return new ValidationResult(false, "El formato de NIF no es váido.");
            }

            return !letra.Equals(letraAux) ? new ValidationResult(false, "El formato de NIF no es váido.") : new ValidationResult(true, null);
        }
    }
}
