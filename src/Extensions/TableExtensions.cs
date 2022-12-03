namespace Amalgam.Tables.Extensions;

public static class TableExtensions
{
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
    public static TableContentAlignment GetAlignment<TElement, TColumn, TOptions>(
        this Table<TElement, TColumn, TOptions> table,
        TableColumn<TElement> column)
        where TColumn : TableColumn<TElement>
        where TOptions : TableOptions
        => column.Alignment ?? table.Options.Alignment;
}
