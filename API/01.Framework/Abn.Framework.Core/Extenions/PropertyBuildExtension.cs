using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace Abn.Framework.Core.Extenions
{
    public static class PropertyBuildExtension
    {

        public static PropertyBuilder<TTYpe> HasFormattedColumnName<TTYpe>(this PropertyBuilder<TTYpe> prop, string table)
        {
            prop.HasColumnName(FormatFieldName(table, prop.Metadata.Name));
            return prop;
        }

        private static string FormatFieldName(string table, string fieldName)
        {
            return $"{table}_{fieldName}";
        }

        public static PropertyBuilder<TTYpe> HasFormattedColumnName<TTYpe>(this PropertyBuilder<TTYpe> prop, string table, string parent)
        {
            prop.HasColumnName(FormatFieldName(table, parent, prop.Metadata.Name));
            return prop;
        }
        private static string FormatFieldName(string table, string parent, string fieldName)
        {
            return $"{table}_{parent}_{fieldName}";
        }


    }
}
