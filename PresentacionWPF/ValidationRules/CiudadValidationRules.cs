using System.Globalization;
using System.Windows.Controls;

namespace PresentacionWPF.ValidationRules
{
    class CiudadValidationRules : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string resultado = value as string;
            if (string.IsNullOrEmpty(resultado))
            {
                return new ValidationResult(false, "El campo Ciudad es obligatorio y no puede quedar vacío.");
            }
            if (resultado.Length > 25)
            {
                return new ValidationResult(false, "El campo Ciudad no puede tener más de 25 caracteres.");
            }

            return new ValidationResult(true, null);
        }
    }
}
