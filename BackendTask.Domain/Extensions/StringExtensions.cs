using System.Text.RegularExpressions;

namespace BackendTask.Domain.Extensions
{
    public static class StringExtensions
    {
        public static string KeepAlphanumerics(this string str)
        {
            Regex rgx = new Regex("[^a-zA-Z0-9]");
            return rgx.Replace(str, "");
        }
    }
}
