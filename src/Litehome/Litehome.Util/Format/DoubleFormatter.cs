namespace Litehome.Util.Format;

public static class DoubleFormatter
{
	public static string AsMeterConsumption(this double value)
	{
		return value.ToString("0.###");
	}
}