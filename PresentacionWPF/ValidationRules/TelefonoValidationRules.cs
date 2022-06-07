using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace PresentacionWPF.ValidationRules
{
    class TelefonoValidationRules : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
           
            string telefono = value as string;
            string formato = "^[0-9]{9,15}$";
            return !Regex.IsMatch(telefono, formato)
                ? new ValidationResult(false, "El formato de teléfono no es válido.")
                : new ValidationResult(true, null);
        }
    }
}
