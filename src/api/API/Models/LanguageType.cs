using System.ComponentModel;

namespace Inshapardaz.Desktop.Api.Models
{
    public enum LanguageType
    {
        [Description("نامعلوم")] None,

        [Description("نامعلوم")] Unknown,

        [Description("اردو")] Urdu,

        [Description("سنسکرت")] Sanskrit,

        [Description("ھندی")] Hindi,

        [Description("فارسی")] Persian,

        [Description("عربی")] Arabic,

        [Description("ترک")] Turkish,

        [Description("انگریزی")] English,

        [Description("فرانسیسی")] French,

        [Description("پراکرت")] Prakrit,

        [Description("لاطینی")] Latin,

        [Description("پنجابی")] Punjabi,

        [Description("یونانی")] Greek,

        [Description("عبرانی")] Hebrew,

        [Description("پرتگالی")] Portuguese,

        [Description("اطالوی")] Italian,

        [Description("ھسپانوی")] Spanish,

        [Description("چینی")] Chinese,

        [Description("جاپانی")] Japanese,

        [Description("سندھی")] Sindhi,

        [Description("جرمن")] German,

        [Description("مقامی")] Local,

        [Description("سریانی")] Syriac,

        [Description("اویستا")] Avestan
    }
}