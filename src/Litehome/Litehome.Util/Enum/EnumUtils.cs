using System.ComponentModel.DataAnnotations;

namespace Litehome.Util.Enum;

public static class EnumUtils
{
	public static string GetDisplayName<T>(this T enumValue) where T: System.Enum
	{
		var attribute = enumValue.GetType().GetField(enumValue.ToString()).GetCustomAttributes(typeof(DisplayAttribute), false).FirstOrDefault();

		if (attribute is DisplayAttribute displayAttribute)
			return displayAttribute.Name ?? enumValue.ToString();

		return enumValue.ToString();
	}
}