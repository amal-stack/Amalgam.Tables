using Amalgam.Tables.Builders;

namespace Amalgam.Tables.Plaintext;

public class PlaintextTableBuilder<TElement>
    : TableBuilderBase<PlaintextTableBuilder<TElement>,
        PlaintextTable<TElement>,
        PlaintextTableColumn<TElement>,
        TElement,
        PlaintextTableOptions>
{
    protected override PlaintextTable<TElement> Build(
        IEnumerable<TElement> elements,
        IReadOnlyList<PlaintextTableColumn<TElement>> columns,
        PlaintextTableOptions options)
        => new(elements, columns, options);

    protected override PlaintextTableColumn<TElement> CreateColumn(
        string name, 
        Func<TElement, int, string> selector, 
        TableContentAlignment? alignment = null)
        => new(name, selector, alignment);
}
