namespace Litehome.Util.Format;

public static class DecimalFormatter
{
	public static string AsCurrency(this decimal value)
	{
		return $"{value:F2} €";
	}	
}