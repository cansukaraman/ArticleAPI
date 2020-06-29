using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace Article.Core.Components
{
    public class Enums
    {
        public enum Status
        {
            [Description("Yeni")]
            New = 0,
            [Description("Aktif")]
            Active = 1,
            [Description("Pasif")]
            Passive = 2,
            [Description("Silinmiş")]
            Deleted = -1
        }

        public enum Error
        {
            [Description("GeneralException")]
            GeneralException = 500,
            [Description("MissingData")]
            MissingData = 501
        }


        public static string GetDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }

        public static Dictionary<int, string> GetDescriptions(Type enumType)
        {
            Array enumTypeValues = Enum.GetValues(enumType);

            Dictionary<int, string> descriptions = new Dictionary<int, string>(enumTypeValues.Length);
            for (int i = 0; i <= enumTypeValues.Length - 1; i++)
            {
                descriptions.Add(Convert.ToInt32(enumTypeValues.GetValue(i)), GetDescription((Enum)enumTypeValues.GetValue(i)));
            }
            return descriptions;
        }

    }
}
