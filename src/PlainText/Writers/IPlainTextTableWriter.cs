namespace Amalgam.Tables.PlainText.Writers;

/// <summary>
/// Defines the members for a writer that materializes a <see cref="Table{TElement, TOptions}"/> object by writing the table to an output destination.
/// </summary>
/// <typeparam name="TElement">The type of elements in the table.</typeparam>
public interface IPlainTextTableWriter<TElement>
    : ITableWriter<Table<TElement, PlainTextTableOptions>, TElement, PlainTextTableOptions>
{
    void WriteCell(string alignedValue);
    void WriteDivider();
    void WriteHeader();
    void WriteHeaderCell(string alignedValue);
    void WriteRowForElement(TElement element, int index);
    void WriteRule();
    void WriteRuleDivider(bool initial = false);
    void WriteRuleForColumn(TableColumn<TElement> column);
}