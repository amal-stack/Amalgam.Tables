namespace Amalgam.Tables.Builders;

public sealed class TableBuilder<TElement, TOptions>
    : TableBuilderBase<
        Table<TElement, TOptions>,
        TElement,
        TOptions>
    where TOptions : TableOptions, new()
{
    protected sealed override Table<TElement, TOptions> Build(
        IEnumerable<TElement> elements,
        IReadOnlyList<TableColumn<TElement>> columns,
        TOptions options) => new(elements, columns, options);
}

public sealed class TableBuilder<TElement>
    : TableBuilderBase<
        Table<TElement, TableOptions>,
        TElement,
        TableOptions>
{
    protected sealed override Table<TElement, TableOptions> Build(
        IEnumerable<TElement> elements,
        IReadOnlyList<TableColumn<TElement>> columns,
        TableOptions options) => new(elements, columns, options);
}
