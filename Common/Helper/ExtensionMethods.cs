using System;

namespace Common.Helper
{
    public static class ExtensionMethods
    {
        public static int WordCount(this String str)
        {
            return str.Split(new char[] { ' ', '.', '?' },
                             StringSplitOptions.RemoveEmptyEntries).Length;
        }

        public static string ToText(this Enum myEnum)
        {
            return myEnum.ToString("G");
        }
    }
}