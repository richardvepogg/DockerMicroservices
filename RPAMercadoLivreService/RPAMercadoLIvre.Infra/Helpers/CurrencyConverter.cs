using System.Globalization;
using System.Text.RegularExpressions;

namespace RPAMercadoLivre.Infra.Helpers
{
    public static class CurrencyConverter
    {
        /// <summary>
        /// Converts a string value to a decimal, automatically detecting Brazilian or US/European formats.
        /// </summary>
        /// <param name="inputValue">The input value as a string.</param>
        /// <returns>The decimal representation of the value.</returns>
        /// <exception cref="ArgumentException">Thrown when the input value is null or empty.</exception>
        /// <exception cref="FormatException">Thrown when the input value cannot be parsed to a decimal.</exception>
        public static decimal ConvertToDecimal(string inputValue)
        {
            if (string.IsNullOrWhiteSpace(inputValue))
                throw new ArgumentException("The provided value is invalid.");

            inputValue = inputValue.Trim();

            // Detect if the format is Brazilian (e.g., 1.234,56)
            bool isBrazilianFormat = Regex.IsMatch(inputValue, @"\d+\.\d{3}(,\d{2})?$");

            if (isBrazilianFormat)
            {
                // In Brazilian format: dot as thousand separator, comma as decimal separator
                inputValue = inputValue.Replace(".", "").Replace(",", ".");
            }
            else
            {
                // In US/European format: comma as thousand separator (optional), dot as decimal separator
                inputValue = inputValue.Replace(",", "");
            }

            if (!decimal.TryParse(inputValue, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal result))
                throw new FormatException($"Error converting the value: '{inputValue}'.");

            return result;
        }
    }
}
