using System.Text;
using System.Text.RegularExpressions;

namespace MediaMonitoringWeb.Helpers
{
    public static class StringExtension
    {
        public static string StripPunctuation(this string s)
        {
            var sb = new StringBuilder();
            foreach (char c in s)
            {
                if (!char.IsPunctuation(c))
                    sb.Append(c);
            }
            return sb.ToString();
        } 
        
        public static string RemoveLink(this string s)
        {
            string cleanedText = Regex.Replace(s, @"http[^\s]+", ""); 
            return cleanedText;
        }  
        
        public static string CleanTwitterString(this string s)
        {
            string cleanedText = s.Replace("rt ",String.Empty,StringComparison.InvariantCultureIgnoreCase); 
            return cleanedText;
        }
    }

}
