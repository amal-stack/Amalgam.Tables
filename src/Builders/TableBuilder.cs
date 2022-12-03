namespace Amalgam.Tables.Builders;

public sealed class TableBuilder<TElement>
    : TableBuilderBase<
        Table<TElement, TableColumn<TElement>, TableOptions>,
        TableColumn<TElement>,
        TElement,
        TableOptions>
{
    protected sealed override Table<TElement, TableColumn<TElement>, TableOptions> Build(
        IEnumerable<TElement> elements,
        IReadOnlyList<TableColumn<TElement>> columns,
        TableOptions options) => new(elements, columns, options);

    protected override TableColumn<TElement> CreateColumn(string name, Func<TElement, int, string> selector, TableContentAlignment? alignment = null)
        => new(name, selector, alignment);
}
