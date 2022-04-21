using Amalgam.Tables.Extensions;

namespace Amalgam.Tables.Builders;

public abstract class TableBuilderBase<TTable, TElement, TOptions>
    : ITableBuilder<TTable, TElement, TOptions>
    where TTable : Table<TElement, TOptions>
    where TOptions : TableOptions, new()
{
    private IEnumerable<TElement> Elements { get; set; } = Enumerable.Empty<TElement>();

    private List<TableColumn<TElement>> Columns { get; } = new();

    private TOptions Options { get; set; } = new();

    public ITableBuilder<TTable, TElement, TOptions> For(IEnumerable<TElement> items)
    {
        Elements = items;
        return this;
    }

    public ITableBuilder<TTable, TElement, TOptions> AddColumn<TColumn>(
        string name,
        Func<TElement, TColumn> selector,
        TableContentAlignment? alignment = null)
    {
        Columns.Add(new TableColumn<TElement>(
            name,
            (value, index) => selector?.Invoke(value)?.ToString() ?? string.Empty,
            alignment));
        return this;
    }

    public ITableBuilder<TTable, TElement, TOptions> AddColumn<TColumn>(
        string name,
        Func<TElement, int, TColumn> selector,
        TableContentAlignment? alignment = null)
    {
        Columns.Add(new TableColumn<TElement>(
            name,
            (value, index) => selector?.Invoke(value, index)?.ToString() ?? string.Empty,
            alignment));
        return this;
    }

    public ITableBuilder<TTable, TElement, TOptions> AddNumbering(
        Action<TableOptions.NumberingOptions>? action = null,
        TableContentAlignment? alignment = null)
    {
        action?.Invoke(Options.Numbering);
        TableColumn<TElement> column = Options.Numbering.GenerateEnumeratedColumn<TElement>(alignment);
        Columns.Add(column);
        return this;
    }

    public ITableBuilder<TTable, TElement, TOptions> AddColumn(TableColumn<TElement> column)
    {
        Columns.Add(column);
        return this;
    }

    public ITableBuilder<TTable, TElement, TOptions> Configure(Action<TOptions> action)
    {
        action(Options);
        return this;
    }

    public ITableBuilder<TTable, TElement, TOptions> ConfigureNumbering(Action<TableOptions.NumberingOptions> action)
    {
        action(Options.Numbering);
        return this;
    }

    public ITableBuilder<TTable, TElement, TOptions> UseOptions(TOptions options)
    {
        Options = options;
        return this;
    }

    public TTable Build() => Build(
        Elements,
        Columns.AsReadOnly(),
        Options);

    protected abstract TTable Build(
        IEnumerable<TElement> elements,
        IReadOnlyList<TableColumn<TElement>> columns,
        TOptions options);

}

public abstract class TableBuilderBase<TBuilder, TTable, TElement, TOptions>
    : ITableBuilder<TBuilder, TTable, TElement, TOptions>
    where TBuilder : TableBuilderBase<TBuilder, TTable, TElement, TOptions>
    where TTable : Table<TElement, TOptions>
    where TOptions : TableOptions, new()
{
    private IEnumerable<TElement> Elements { get; set; } = Enumerable.Empty<TElement>();

    private List<TableColumn<TElement>> Columns { get; } = new();

    private TOptions Options { get; set; } = new();

    private readonly TBuilder _this;

    public TBuilder This => _this;

    public TableBuilderBase()
    {
        _this = (TBuilder)this;
    }

    public TBuilder For(IEnumerable<TElement> items)
    {
        Elements = items;
        return This;
    }

    public TBuilder AddColumn<TColumn>(
        string name,
        Func<TElement, TColumn> selector,
        TableContentAlignment? alignment = null)
    {
        Columns.Add(new TableColumn<TElement>(
            name,
            (value, index) => selector?.Invoke(value)?.ToString() ?? string.Empty,
            alignment));
        return This;
    }

    public TBuilder AddColumn<TColumn>(
        string name,
        Func<TElement, int, TColumn> selector,
        TableContentAlignment? alignment = null)
    {
        Columns.Add(new TableColumn<TElement>(
            name,
            (value, index) => selector?.Invoke(value, index)?.ToString() ?? string.Empty,
            alignment));
        return This;
    }

    public TBuilder AddColumn(TableColumn<TElement> column)
    {
        Columns.Add(column);
        return This;
    }

    public TBuilder AddNumbering(
        Action<TableOptions.NumberingOptions>? action,
        TableContentAlignment? alignment = null)
    {
        action?.Invoke(Options.Numbering);
        TableColumn<TElement> column = Options.Numbering.GenerateEnumeratedColumn<TElement>(alignment);
        Columns.Add(column);
        return This;
    }

    public TBuilder Configure(Action<TOptions> action)
    {
        action(Options);
        return This;
    }

    public TBuilder ConfigureNumbering(Action<TableOptions.NumberingOptions> action)
    {
        action(Options.Numbering);
        return This;
    }

    public TBuilder UseOptions(TOptions options)
    {
        Options = options;
        return This;
    }

    public TTable Build() => Build(
        Elements,
        Columns.AsReadOnly(),
        Options);

    protected abstract TTable Build(
        IEnumerable<TElement> elements,
        IReadOnlyList<TableColumn<TElement>> columns,
        TOptions options);
}
