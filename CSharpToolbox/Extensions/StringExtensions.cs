namespace CSharpToolbox.Extensions
{
    public static class StringExtensions
    {
        public static string Trim(this string text, string trimText)
        {
            return text.TrimStart(trimText).TrimEnd(trimText);
        }

        public static string TrimStart(this string text, string trimText)
        {
            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(trimText))
            {
                return text;
            }
            while (text.StartsWith(trimText))
            {
                text = text.Substring(trimText.Length);
            }
            return text;
        }

        public static string TrimEnd(this string text, string trimText)
        {
            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(trimText))
            {
                return text;
            }
            while (text.EndsWith(trimText))
            {
                text = text.Substring(0, text.Length - trimText.Length);
            }
            return text;
        }
    }
}