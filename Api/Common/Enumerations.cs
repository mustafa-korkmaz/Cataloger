using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Common
{
    public class Enumerations
    {
    }

    public enum IntegrationType
    {
        Opencart = 0,
        Magento,
        NopCommerce
    }

    public enum ExportType
    {
        Undefined = -1,
        Product = 0,
        Category = 1
    }

    public enum Status
    {
        Active,
        Passive,
        Suspended,
        Deleted
    }

    public enum CatalogVersion
    {
        Demo,
        Standart,
        Professional
    }

    public enum TemplateType
    {
        Default,
        Food,
        WhiteAppliances // beyaz esya
    }

    public enum Key
    {
        Tag,
        Discount,
        Image,
        Video
    }

    public enum ResponseCode
    {
        Fail = 0,
        Success,
        Warning,
        Info,
        NoEffect
    }
}