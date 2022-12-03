using System.Text;

namespace Amalgam.Tables.Extensions;

internal static class StringExtensions
{
    public static string Align(
        this string value,
        TableContentAlignment alignment,
        int width) => alignment switch
        {
            TableContentAlignment.Right => value.PadLeft(width),
            TableContentAlignment.Center => value.PadCenter(width),
            _ => value.PadRight(width),
        };

    public static string PadCenter(this string str, int width)
    {
        int diff = width - str.Length;
        if (diff < 1)
        {
            return str;
        }

        int half = diff / 2;
        StringBuilder builder = new();

        builder
            .Append(' ', half)
            .Append(str)
            .Append(' ', half);

        if (diff % 2 == 1)
        {
            builder.Append(' ');
        }

        return builder.ToString();
    }
}
