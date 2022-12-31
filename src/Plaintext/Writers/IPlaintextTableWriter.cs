namespace Amalgam.Tables.Plaintext.Writers;

/// <summary>
/// Defines the members for a writer that materializes a <see cref="Table{TElement, TOptions}"/> object by writing the table to an output destination.
/// </summary>
/// <typeparam name="TElement">The type of elements in the table.</typeparam>
public interface IPlaintextTableWriter<TElement>
    : ITableWriter<PlaintextTable<TElement>, TElement, PlaintextTableColumn<TElement>, PlaintextTableOptions>
{
    /// <summary>
    /// Writes the content of a single cell.
    /// </summary>
    /// <param name="alignedValue">The content of the cell after alignment.</param>
    void WriteCell(string alignedValue);

    /// <summary>
    /// Writes the divider.
    /// </summary>
    void WriteDivider();

    /// <summary>
    /// Writes the entire header row.
    /// </summary>
    void WriteHeader();

    /// <summary>
    /// Writes the content of a single header cell.
    /// </summary>
    /// <param name="alignedValue">The content of the cell after alignment.</param>
    void WriteHeaderCell(string alignedValue);

    /// <summary>
    /// Writes an entire row (for a single element of the table) using the <see cref="TableColumn{TElement}.Selector"/> for each column in <see cref="Table.Columns"/>.
    /// </summary>
    /// <param name="element">The element for which the row has to be written.</param>
    /// <param name="index">The index of the element being written</param>
    void WriteRowForElement(TElement element, int index);

    /// <summary>
    /// Writes a horizontal rule.
    /// </summary>
    void WriteRule();

    /// <summary>
    /// Writes the rule divider.
    /// </summary>
    /// <param name="initial">A flag indicating if this is the inital divider for the row.</param>
    void WriteRuleDivider(bool initial = false);

    /// <summary>
    /// Adds a horizontal rule for one column.
    /// </summary>
    /// <param name="column">The column for which the rule characters has to be written.</param>
    void WriteRuleForColumn(PlaintextTableColumn<TElement> column);
}