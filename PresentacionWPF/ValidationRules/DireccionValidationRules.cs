using System;
using System.Globalization;
using System.Windows.Controls;

namespace PresentacionWPF.ValidationRules
{
    class DireccionValidationRules : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string resultado = value as string;
            if (resultado.Length == 0)
            {
                return new ValidationResult(false, "El campo Dirección no puede quedar vacío.");

            }
            else if (resultado.Length > 50)
            {
                return new ValidationResult(false, "La Dirección no puede contener más de 50 caracteres.");
            }

            return new ValidationResult(true, null);
        }
    }
}
