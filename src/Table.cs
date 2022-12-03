namespace Amalgam.Tables;

/// <summary>
/// Represents the configuration for creating a table from an <see cref="IEnumerable{TElement}"/>.
/// </summary>
/// <typeparam name="TElement">The type of elements in the enumerable.</typeparam>
/// <typeparam name="TColumn">The type of the columns in the table.</typeparam>
/// <typeparam name="TOptions">The type of the options object to configure the table creation.</typeparam>
public class Table<TElement, TColumn, TOptions>
    where TColumn : TableColumn<TElement>
    where TOptions : TableOptions
{
    /// <summary>
    /// A list of column configurations for each column of the table.
    /// </summary>
    public IReadOnlyList<TColumn> Columns { get; }

    /// <summary>
    /// The data source for the table.
    /// </summary>
    public IEnumerable<TElement> Elements { get; }

    /// <summary>
    /// The table options object.
    /// </summary>
    public TOptions Options { get; }

    /// <summary>
    /// Computes the number of the elements in the enumerable <see cref="Elements"/>.
    /// </summary>
    /// <remarks>
    /// The count is calculated by calling <see cref="Enumerable.Count{TSource}(IEnumerable{TSource})"/>.
    /// </remarks>
    /// <returns>The number of elements in <see cref="Elements"/>.</returns>
    public int GetRowCount() => Elements.Count();

    public Table(
        IEnumerable<TElement> elements,
        IReadOnlyList<TColumn> columns,
        TOptions options)
    {
        Elements = elements;
        Columns = columns;
        Options = options;
    }
}


