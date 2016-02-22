using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace Api.Common
{
    public class ExportTypeText
    {
        public const string Category = "category";
        public const string Product = "product";
    }

    public class SettingKey
    {
        public const string ImagePath = "imagePath";
        public const string FullPath = "{fullPath}";
        public const string Extension = "{extension}";
    }

    public static class App
    {
        public const string IntegrationKeyHeaderName = "IntegrationKey";
        public const string IntegrationKeyValue = "MustafaTaylanAlican";
        public static string IntegrationKeyHash = Helper.IntegrationKey.Instance.GetHashValue(IntegrationKeyValue);
    }
}