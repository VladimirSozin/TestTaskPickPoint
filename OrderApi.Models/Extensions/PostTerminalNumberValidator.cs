using System.Text.RegularExpressions;

namespace OrderApi.Models.Extensions
{
    public static class PostTerminalNumberValidator
    {
        public static bool IsNumberValid(string postTerminalNumber)
        {
            var regex = new Regex(@"^\d{4}-\d{3}$");

            if (regex.IsMatch(postTerminalNumber))
                return true;

            return false;
        }
    }
}
