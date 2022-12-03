namespace Amalgam.Tables.Plaintext;


public static class PlaintextTable
{
    /// <summary>
    /// Creates a new plain text table builder for building a table using the items in <paramref name="elements"/>. 
    /// </summary>
    /// <typeparam name="TElement">The type of elements in the table.</typeparam>
    /// <param name="elements">The elements from which the table has to be created.</param>
    /// <returns>The table builder.</returns>
    public static PlaintextTableBuilder<TElement>
        For<TElement>(IEnumerable<TElement> elements)
        => new PlaintextTableBuilder<TElement>()
            .For(elements);

    /// <summary>
    /// Creates a new plain text table builder for building a table with a single row. 
    /// </summary>
    /// <typeparam name="TElement">The type of elements in the table.</typeparam>
    /// <param name="elements">The elements from which the table has to be created.</param>
    /// <returns>The table builder.</returns>
    public static PlaintextTableBuilder<TElement>
        ForSingle<TElement>(
        TElement element)
        => new PlaintextTableBuilder<TElement>()
            .For(new[] { element });
}


public class PlaintextTable<TElement> : Table<TElement,
    PlaintextTableColumn<TElement>,
    PlaintextTableOptions>
{
    public PlaintextTable(
        IEnumerable<TElement> elements,
        IReadOnlyList<PlaintextTableColumn<TElement>> columns,
        PlaintextTableOptions options)
        : base(elements, columns, options)
    {
    }

    /// <summary>
    /// Expands the width of each column so that it is wide enough to fit the widest cell in the column.
    /// </summary>
    public void AutoResizeColumns()
    {
        foreach (var item in Elements.Select((element, index) => (element, index)))
        {
            foreach (var column in Columns)
            {
                int width = column.Get(item.element, item.index)?.Length ?? 0;
                if (column.Width < width)
                {
                    column.Width = width;
                }
            }
        }
    }
}