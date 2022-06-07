using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PresentacionWPF.ValidationRules
{
    class NombreValidationRules : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string resultado = value as string;
            if (string.IsNullOrEmpty(resultado))
            {
                return new ValidationResult(false, "El campo Nombre es obligatorio y no puede quedar vacío.");
            }
            if(resultado.Length > 25)
            {
                return new ValidationResult(false, "El campo Nombre no puede tener más de 25 caracteres.");
            }

            return new ValidationResult(true, null);
        }
    }
}
