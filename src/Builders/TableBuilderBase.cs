using Amalgam.Tables.Extensions;

namespace Amalgam.Tables.Builders;

public abstract class TableBuilderBase<TTable, TColumn, TElement, TOptions>
    : ITableBuilder<TTable, TColumn, TElement, TOptions>
    where TTable : Table<TElement, TColumn, TOptions>
    where TColumn : TableColumn<TElement>
    where TOptions : TableOptions, new()
{
    private IEnumerable<TElement> Elements { get; set; } = Enumerable.Empty<TElement>();

    private List<TColumn> Columns { get; } = new();

    private TOptions Options { get; set; } = new();

    public virtual ITableBuilder<TTable, TColumn, TElement, TOptions> For(IEnumerable<TElement> items)
    {
        Elements = items;
        return this;
    }

    public virtual ITableBuilder<TTable, TColumn, TElement, TOptions> AddColumn<TColumnData>(
        string name,
        Func<TElement, TColumnData> selector,
        TableContentAlignment? alignment = null)
    {
        Columns.Add(CreateColumn(
            name,
            (value, index) => selector?.Invoke(value)?.ToString() ?? string.Empty,
            alignment));
        return this;
    }

    public ITableBuilder<TTable, TColumn, TElement, TOptions> AddColumn<TColumnData>(
        string name,
        Func<TElement, int, TColumnData> selector,
        TableContentAlignment? alignment = null)
    {
        Columns.Add(CreateColumn(
            name,
            (value, index) => selector?.Invoke(value, index)?.ToString() ?? string.Empty,
            alignment));
        return this;
    }

    public ITableBuilder<TTable, TColumn, TElement, TOptions> AddNumbering(
        Action<TableOptions.NumberingOptions>? action = null,
        TableContentAlignment? alignment = null)
    {
        action?.Invoke(Options.Numbering);
        TColumn column = Options.Numbering
            .GenerateEnumeratedColumn<TElement, TColumn>(CreateColumn, alignment);
        Columns.Add(column);
        return this;
    }

    public ITableBuilder<TTable, TColumn, TElement, TOptions> AddColumn(TColumn column)
    {
        Columns.Add(column);
        return this;
    }

    public ITableBuilder<TTable, TColumn, TElement, TOptions> Configure(Action<TOptions> action)
    {
        action(Options);
        return this;
    }

    public ITableBuilder<TTable, TColumn, TElement, TOptions> ConfigureNumbering(
        Action<TableOptions.NumberingOptions> action)
    {
        action(Options.Numbering);
        return this;
    }

    public ITableBuilder<TTable, TColumn, TElement, TOptions> UseOptions(TOptions options)
    {
        Options = options;
        return this;
    }

    public TTable Build() => Build(
        Elements,
        Columns,
        Options);

    protected abstract TColumn CreateColumn(
        string name,
        Func<TElement, int, string> selector,
        TableContentAlignment? alignment = null);

    protected abstract TTable Build(
        IEnumerable<TElement> elements,
        IReadOnlyList<TColumn> columns,
        TOptions options);

}

public abstract class TableBuilderBase<TBuilder, TTable, TColumn, TElement, TOptions>
    : ITableBuilder<TBuilder, TTable, TColumn, TElement, TOptions>
    where TBuilder : TableBuilderBase<TBuilder, TTable, TColumn, TElement, TOptions>
    where TTable : Table<TElement, TColumn, TOptions>
    where TColumn : TableColumn<TElement>
    where TOptions : TableOptions, new()
{
    private IEnumerable<TElement> Elements { get; set; } = Enumerable.Empty<TElement>();

    private List<TColumn> Columns { get; } = new();

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

    public TBuilder AddColumn<TColumnData>(
        string name,
        Func<TElement, TColumnData> selector,
        TableContentAlignment? alignment = null)
    {
        Columns.Add(CreateColumn(
            name,
            (value, index) => selector?.Invoke(value)?.ToString() ?? string.Empty,
            alignment));
        return This;
    }

    public TBuilder AddColumn<TColumnData>(
            string name,
            Func<TElement, int, TColumnData> selector,
            TableContentAlignment? alignment = null)
    {
        Columns.Add(CreateColumn(
            name,
            (value, index) => selector?.Invoke(value, index)?.ToString() ?? string.Empty,
            alignment));
        return This;
    }

    public TBuilder AddColumn(TColumn column)
    {
        Columns.Add(column);
        return This;
    }

    public TBuilder AddNumbering(
        Action<TableOptions.NumberingOptions>? action = null,
        TableContentAlignment? alignment = null)
    {
        action?.Invoke(Options.Numbering);
        TColumn column = Options.Numbering
            .GenerateEnumeratedColumn<TElement, TColumn>(CreateColumn, alignment);
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

    protected abstract TColumn CreateColumn(
        string name,
        Func<TElement, int, string> selector,
        TableContentAlignment? alignment = null);

    protected abstract TTable Build(
        IEnumerable<TElement> elements,
        IReadOnlyList<TColumn> columns,
        TOptions options);
}
