﻿namespace Amalgam.Tables;

/// <summary>
/// Defines the members for a writer that materializes a <see cref="Table{TElement, TOptions}"/> object by writing the table to an output destination.
/// </summary>
/// <typeparam name="TTable">The type of the table object.</typeparam>
/// <typeparam name="TElement">The type of elements in the table.</typeparam>
/// <typeparam name="TOptions">The type of the table options.</typeparam>
public interface ITableWriter<TTable, TElement, TOptions>
    where TTable : Table<TElement, TOptions>
    where TOptions : TableOptions
{
    TTable Table { get; }

    /// <summary>
    /// Writes the entire table to an output destination.
    /// </summary>
    void Write();
}