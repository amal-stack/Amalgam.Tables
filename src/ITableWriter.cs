namespace Amalgam.Tables;

/// <summary>
/// Defines the members for a writer that materializes a <see cref="Table{TElement, TOptions}"/> object by writing the table to an output destination.
/// </summary>
/// <typeparam name="TTable">The type of the table object.</typeparam>
/// <typeparam name="TElement">The type of elements in the table.</typeparam>
/// <typeparam name="TColumn">The type of the columns in the table.</typeparam>
/// <typeparam name="TOptions">The type of the table options.</typeparam>
public interface ITableWriter<TTable, TElement, TColumn, TOptions>
    where TTable : Table<TElement, TColumn, TOptions>
    where TColumn : TableColumn<TElement>
    where TOptions : TableOptions
{
    /// <summary>
    /// The table which will be written.
    /// </summary>
    TTable Table { get; }

    /// <summary>
    /// Writes the entire table to an output destination.
    /// </summary>
    void Write();
}