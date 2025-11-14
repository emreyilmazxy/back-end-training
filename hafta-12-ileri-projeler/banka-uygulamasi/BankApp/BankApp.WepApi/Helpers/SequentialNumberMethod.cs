using System;

namespace BankApp.WepApi.Helpers
{
    public static class SequentialNumberMethod // this class checks for sequential numbers in a string
    {
        public static bool ContainsSequentialNumbers(string input, int length = 4)
        {
            for (int i = 0; i <= input.Length - length; i++)
            {
                var digits = input.Skip(i).Take(length).ToArray();

                if (!digits.All(char.IsDigit))
                    continue;

                bool isAscending = true;
                bool isDescending = true;

                for (int j = 1; j < length; j++)
                {
                    int prev = digits[j - 1] - '0';
                    int curr = digits[j] - '0';

                    if (curr != prev + 1) isAscending = false;
                    if (curr != prev - 1) isDescending = false;
                }

                if (isAscending || isDescending)
                    return true;
            }

            return false;
        }
    }
}
