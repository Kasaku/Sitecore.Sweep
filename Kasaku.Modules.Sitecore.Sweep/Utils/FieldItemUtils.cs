using Sitecore.Data.Fields;

namespace Kasaku.Sitecore.Modules.Sweep.Utils
{
    public static class FieldItemUtils
    {
        public static bool IsRichTextField(this Field field)
        {
            return field.TypeKey == "rich text";
        }
    }
}
