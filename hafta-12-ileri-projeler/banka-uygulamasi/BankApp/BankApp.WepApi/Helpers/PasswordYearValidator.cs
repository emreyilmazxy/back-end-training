using System.Text.RegularExpressions;

namespace BankApp.WepApi.Helpers
{
    public static class PasswordYearValidator
    {

        public static bool ContainsYear(string input) // 1900-2100 between years are not valid
        {
            if (string.IsNullOrEmpty(input))
                return false;

            var matches = Regex.Matches(input, @"\d{4}");

            foreach (Match match in matches)
            {
                if (int.TryParse(match.Value, out int year))
                {
                    
                    if (year >= 1900 && year <= 2100)
                        return true; // Geçersiz şifre!
                }
            }

            return false;
        }
    } // end of class PasswordYearValidator
}