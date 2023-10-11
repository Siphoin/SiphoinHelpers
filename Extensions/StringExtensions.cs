using System.Linq;

namespace System.Extensions
{
    public static class StringExtensions
    {
        public static string FirstCharToUpper(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input));
            }

            return input[0].ToString().ToUpper() + input.Substring(1);
        }
    }
}
