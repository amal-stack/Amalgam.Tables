namespace Amalgam.Tables.Extensions;

public static class NumberingOptionsExtensions
{
    public static string GetNumberForIndex(this TableOptions.NumberingOptions options, int index)
    {
        int i = options.StartFrom + options.IncrementBy * index;
        return options.Values?[i % options.Values.Count] ?? i.ToString();
    }

    public static TColumn GenerateEnumeratedColumn<TElement, TColumn>(
        this TableOptions.NumberingOptions options,
        Func<string, Func<TElement, int, string>, TableContentAlignment?, TColumn> columnFactory,
        TableContentAlignment? alignment = null)
        => columnFactory(options.HeaderText,
            (element, index) => options.GetNumberForIndex(index),
            alignment);
}
