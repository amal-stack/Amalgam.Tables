using Amalgam.Tables.Builders;

namespace Amalgam.Tables.PlainText;


public static class PlainTextTable
{
    public static ITableBuilder<Table<TElement, PlainTextTableOptions>, TElement, PlainTextTableOptions> For<TElement>(IEnumerable<TElement> elements)
        => new TableBuilder<TElement, PlainTextTableOptions>()
            .For(elements);

    public static ITableBuilder<Table<TElement, PlainTextTableOptions>, TElement, PlainTextTableOptions> ForSingle<TElement>(
        TElement element)
        => new TableBuilder<TElement, PlainTextTableOptions>()
            .For(new[] { element });
}
