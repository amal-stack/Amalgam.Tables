

namespace Amalgam.Tables.Builders;

public interface ITableBuilder<out TBuilder, out TTable, in TColumn, TElement, TOptions>
    where TBuilder : ITableBuilder<TBuilder, TTable, TColumn, TElement, TOptions>
    where TTable : Table<TElement, TColumn, TOptions>
    where TColumn : TableColumn<TElement>
    where TOptions : TableOptions, new()
{
    TBuilder This { get; }

    /// <summary>
    /// Adds a column to the table.
    /// </summary>
    /// <param name="column">The column to be added.</param>
    /// <returns>A reference to this instance after adding the column.</returns>
    TBuilder AddColumn(TColumn column);

    /// <inheritdoc cref="AddColumn(TColumn)" path="/summary"/>
    /// <typeparam name="TColumn"></typeparam>
    /// <param name="name">The name/header text for the column.</param>
    /// <param name="selector">The </param>
    /// <param name="alignment"></param>
    /// <returns></returns>
    TBuilder AddColumn<TColumnData>(
        string name,
        Func<TElement, TColumnData> selector,
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


public interface ITableBuilder<out TTable, in TColumn, TElement, TOptions>
    where TTable : Table<TElement, TColumn, TOptions>
    where TColumn : TableColumn<TElement>
    where TOptions : TableOptions, new()
{
    ITableBuilder<TTable, TColumn, TElement, TOptions> AddColumn(TColumn column);

    ITableBuilder<TTable, TColumn, TElement, TOptions> AddColumn<TColumnData>(
        string name,
        Func<TElement, TColumnData> selector,
        TableContentAlignment? alignment = null);

    ITableBuilder<TTable, TColumn, TElement, TOptions> AddNumbering(
        Action<TableOptions.NumberingOptions>? action = null,
        TableContentAlignment? alignment = null);

    ITableBuilder<TTable, TColumn, TElement, TOptions> Configure(Action<TOptions> action);

    ITableBuilder<TTable, TColumn, TElement, TOptions> ConfigureNumbering(
        Action<TableOptions.NumberingOptions> action);

    ITableBuilder<TTable, TColumn, TElement, TOptions> For(IEnumerable<TElement> items);

    ITableBuilder<TTable, TColumn, TElement, TOptions> UseOptions(TOptions options);

    TTable Build();
}

public interface ITableBuilder<TColumn, TElement, TOptions>
    : ITableBuilder<Table<TElement, TColumn, TOptions>, TColumn, TElement, TOptions>
    where TColumn : TableColumn<TElement>
    where TOptions : TableOptions, new()
{
}

public interface ITableBuilder<TColumn, TElement>
    : ITableBuilder<TColumn, TElement, TableOptions>
    where TColumn : TableColumn<TElement>
{
}

public interface ITableBuilder<TElement>
    : ITableBuilder<TableColumn<TElement>, TElement>
{

}