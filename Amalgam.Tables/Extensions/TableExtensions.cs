namespace Amalgam.Tables.Extensions;

public static class TableExtensions
{
    /// <summary>
    /// Expands the width of each column so that it is wide enough to fit the widest cell in the column.
    /// </summary>
    /// <typeparam name="TElement">The type of elements in the table.</typeparam>
    /// <typeparam name="TOptions">The type of the table options object.</typeparam>
    /// <param name="table">The target table.</param>
    public static void AutoResizeColumns<TElement, TOptions>(
        this Table<TElement, TOptions> table)
        where TOptions : TableOptions
    {
        foreach (var item in table.Elements.Select((element, index) => (element, index)))
        {
            foreach (var column in table.Columns)
            {
                int width = column.Get(item.element, item.index)?.Length ?? 0;
                if (column.Width < width)
                {
                    column.Width = width;
                }
            }
        }
    }

    /// <summary>
    /// Returns the alignment for the specified <paramref name="column"/>.
    /// </summary>
    /// <remarks>
    /// If the <paramref name="column"/>'s <see cref="TableColumn{TElement}.Alignment"/> property is not <see langword="null"/>, it returns this value. Otherwise, it returns the value of the <paramref name="table"/>'s <see cref="TableOptions.Alignment"/>.
    /// </remarks>
    /// <typeparam name="TElement"></typeparam>
    /// <typeparam name="TOptions"></typeparam>
    /// <param name="table">The table.</param>
    /// <param name="column">The <see cref="TableColumn{TElement}"/> </param>
    /// <returns>The alignment for <paramref name="column"/> as a <see cref="TableContentAlignment"/>.</returns>
    public static TableContentAlignment GetAlignment<TElement, TOptions>(
        this Table<TElement, TOptions> table,
        TableColumn<TElement> column)
        where TOptions : TableOptions
        => column.Alignment ?? table.Options.Alignment;
}
