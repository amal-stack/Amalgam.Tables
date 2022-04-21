namespace Amalgam.Tables.Extensions;

public static class NumberingOptionsExtensions
{
    public static string GetNumberForIndex(this TableOptions.NumberingOptions options, int index)
    {
        int i = options.StartFrom + options.IncrementBy * index;
        return options.Values?[i % options.Values.Count] ?? i.ToString();
    }

    public static TableColumn<TElement> GenerateEnumeratedColumn<TElement>(
        this TableOptions.NumberingOptions options,
        TableContentAlignment? alignment = null)
        => new(options.HeaderText,
            (element, index) => options.GetNumberForIndex(index),
            alignment);
}
