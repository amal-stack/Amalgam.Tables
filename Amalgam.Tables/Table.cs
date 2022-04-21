﻿namespace Amalgam.Tables;

/// <summary>
/// Represents the configuration for creating a table from an <see cref="IEnumerable{TElement}"/>.
/// </summary>
/// <typeparam name="TElement">The type of elements in the enumerable.</typeparam>
/// <typeparam name="TOptions">The type of the options object to configure the table creation.</typeparam>
public class Table<TElement, TOptions>
    where TOptions : TableOptions
{
    public IReadOnlyList<TableColumn<TElement>> Columns { get; }

    public IEnumerable<TElement> Elements { get; }

    /// <summary>
    /// Computes the number of the elements in the enumerable <see cref="Elements"/>.
    /// </summary>
    /// <remarks>
    /// The count is calculated by calling <see cref="Enumerable.Count{TSource}(IEnumerable{TSource})"/>.
    /// </remarks>
    /// <returns>The number of elements in <see cref="Elements"/>.</returns>
    public int GetRowCount() => Elements.Count();

    public TOptions Options { get; }

    public Table(
        IEnumerable<TElement> elements,
        IReadOnlyList<TableColumn<TElement>> columns,
        TOptions options)
    {
        Elements = elements;
        Columns = columns;
        Options = options;
    }
}
