

namespace Amalgam.Tables.Builders;

public interface ITableBuilder<out TBuilder, out TTable, TElement, TOptions>
    where TBuilder : ITableBuilder<TBuilder, TTable, TElement, TOptions>
    where TTable : Table<TElement, TOptions>
    where TOptions : TableOptions, new()
{
    TBuilder This { get; }

    /// <summary>
    /// Adds a column to the table.
    /// </summary>
    /// <param name="column">The column to be added.</param>
    /// <returns>A reference to this instance after adding the column.</returns>
    TBuilder AddColumn(TableColumn<TElement> column);

    /// <inheritdoc cref="AddColumn(TableColumn{TElement})" path="/summary"/>
    /// <typeparam name="TColumn"></typeparam>
    /// <param name="name">The name/header text for the column.</param>
    /// <param name="selector">The </param>
    /// <param name="alignment"></param>
    /// <returns></returns>
    TBuilder AddColumn<TColumn>(
        string name,
        Func<TElement, TColumn> selector,
        TableContentAlignment? alignment = null);

    TBuilder AddNumbering(
        Action<TableOptions.NumberingOptions>? action = null,
        TableContentAlignment? alignment = null);

    TBuilder Configure(Action<TOptions> action);

    TBuilder ConfigureNumbering(
        Action<TableOptions.NumberingOptions> action);

    TBuilder For(IEnumerable<TElement> items);

    TBuilder UseOptions(TOptions options);

    TTable Build();
}


public interface ITableBuilder<out TTable, TElement, TOptions>
    where TTable : Table<TElement, TOptions>
    where TOptions : TableOptions, new()
{
    ITableBuilder<TTable, TElement, TOptions> AddColumn(TableColumn<TElement> column);

    ITableBuilder<TTable, TElement, TOptions> AddColumn<TColumn>(
        string name,
        Func<TElement, TColumn> selector,
        TableContentAlignment? alignment = null);

    ITableBuilder<TTable, TElement, TOptions> AddNumbering(
        Action<TableOptions.NumberingOptions>? action = null,
        TableContentAlignment? alignment = null);

    ITableBuilder<TTable, TElement, TOptions> Configure(Action<TOptions> action);

    ITableBuilder<TTable, TElement, TOptions> ConfigureNumbering(
        Action<TableOptions.NumberingOptions> action);

    ITableBuilder<TTable, TElement, TOptions> For(IEnumerable<TElement> items);

    ITableBuilder<TTable, TElement, TOptions> UseOptions(TOptions options);

    TTable Build();
}

public interface ITableBuilder<TElement, TOptions>
    : ITableBuilder<Table<TElement, TOptions>, TElement, TOptions>
    where TOptions : TableOptions, new()
{
}

public interface ITableBuilder<TElement>
    : ITableBuilder<TElement, TableOptions>
{
}