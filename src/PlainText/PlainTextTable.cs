using Amalgam.Tables.Builders;

namespace Amalgam.Tables.PlainText;


public static class PlainTextTable
{
    /// <summary>
    /// Creates a new plain text table builder for building a table using the items in <paramref name="elements"/>. 
    /// </summary>
    /// <typeparam name="TElement">The type of elements in the table.</typeparam>
    /// <param name="elements">The elements from which the table has to be created.</param>
    /// <returns>The table builder.</returns>
    public static ITableBuilder<Table<TElement, PlainTextTableOptions>, TElement, PlainTextTableOptions> For<TElement>(IEnumerable<TElement> elements)
        => new TableBuilder<TElement, PlainTextTableOptions>()
            .For(elements);

    /// <summary>
    /// Creates a new plain text table builder for building a table with a single row. 
    /// </summary>
    /// <typeparam name="TElement">The type of elements in the table.</typeparam>
    /// <param name="elements">The elements from which the table has to be created.</param>
    /// <returns>The table builder.</returns>
    public static ITableBuilder<Table<TElement, PlainTextTableOptions>, TElement, PlainTextTableOptions> ForSingle<TElement>(
        TElement element)
        => new TableBuilder<TElement, PlainTextTableOptions>()
            .For(new[] { element });
}
