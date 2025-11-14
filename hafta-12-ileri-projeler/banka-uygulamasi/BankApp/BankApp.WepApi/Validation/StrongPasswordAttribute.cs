using BankApp.WepApi.Helpers;
using System.ComponentModel.DataAnnotations;

namespace BankApp.WepApi.Validation
{
    public class StrongPasswordAttribute : ValidationAttribute 
    {
        public override bool IsValid(object value) 
        {
            var password = value as string;

            if (string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            bool hasUpper = password.Any(char.IsUpper);
            bool hasSpecial = password.Any(ch=> "!@#$%^&*()_+-=[]{}|\\:;\"'<>,.?/".Contains(ch));
            bool hasMinLength = password.Length >= 6;
            bool hasDigit = password.Any(char.IsDigit);
            bool hasSequential = SequentialNumberMethod.ContainsSequentialNumbers(password);
            bool containsYear = PasswordYearValidator.ContainsYear(password);

            return hasUpper && hasSpecial && hasMinLength && !hasSequential && !containsYear && hasDigit;
        }

        public override string FormatErrorMessage(string name)
        {
            return $"{name} en az 6 karakter uzunluğunda, en az bir büyük harf, en az bir özel karakter ve en az bir rakam içermelidir. Ayrıca ardışık sayılar (örn. 1234, 9876) ve yıl bilgileri (1900–2100) içeremez.";
        }
    } // end of class StrongPasswordAttribute
}
