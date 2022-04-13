using System.Text.RegularExpressions;

namespace OrderApi.Models.Extensions
{
    public static class PhoneNumberValidator
    {
        public static bool IsNumberValid(string phoneNumber)
        {
            var regex = new Regex(@"^\+7\d{3}-\d{3}-\d{2}-\d{2}$");

            if (regex.IsMatch(phoneNumber))
                return true;

            return false;
        }
    }
}