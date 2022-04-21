namespace Amalgam.Tables;

/// <summary>
/// Represents a single column for a table whose value is computed by passing the element to the <see cref="Selector"/> delegate.
/// </summary>
/// <typeparam name="TElement">The type of elements in the parent table.</typeparam>
public class TableColumn<TElement>
{
    /// <summary>
    /// Gets the header text of the column.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets the column projection function, which returns the value of the column as a <see cref="string"? />, for an element of type <typeparamref name="TElement"/>
    /// </summary>
    public Func<TElement, int, string> Selector { get; }

    public int Width { get; set; }

    /// <summary>
    /// Gets or sets the alignment for the column.
    /// </summary>
    /// <remarks>If this value is <see langword="null"/>, the alignment specified in <see cref="TableOptions.Alignment"/> will be used. </remarks>
    public TableContentAlignment? Alignment { get; set; }

    public TableColumn(
        string name,
        Func<TElement, int, string> selector,
        TableContentAlignment? alignment = null)
    {
        Name = name;
        Selector = selector;
        Width = Name.Length;
        Alignment = alignment;
    }

    /// <summary>
    /// Applies the projection function and returns the cell value of an element for this column.
    /// </summary>
    /// <param name="element">The element whose cell value has to be computed.</param>
    /// <param name="index">The index of the element in the table.</param>
    /// <returns>The cell value of this column for <paramref name="element"/> by applying the projection function.</returns>
    public string Get(TElement element, int index) => Selector.Invoke(element, index);
}

