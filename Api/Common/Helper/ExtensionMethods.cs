using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Common.Helper
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