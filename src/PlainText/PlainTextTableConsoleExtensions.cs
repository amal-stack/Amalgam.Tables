using Amalgam.Tables.Builders;
using Amalgam.Tables.PlainText.Writers;

namespace Amalgam.Tables.PlainText;

public static class PlainTextTableConsoleExtensions
{
    /// <summary>
    /// Writes the table to the standard output stream or to the specified <paramref name="writer"/>.
    /// </summary>
    /// <typeparam name="TElement">The type of elements in the table.</typeparam>
    /// <param name="table">The table.</param>
    /// <param name="action">An <see cref="Action{ConsoleTableWriter{TElement}.ConsoleColorOptions}"/> to set the <see cref="ConsoleTableWriter{TElement}.ConsoleColorOptions"/>.</param>
    /// <param name="writer">The <see cref="TextWriter"/> where the table will be return. Defaults to the standard output stream</param>
    public static void WriteToConsole<TElement>(
        this Table<TElement, PlainTextTableOptions> table,
        Action<ConsoleTableWriter<TElement>.ConsoleColorOptions>? action = null,
        TextWriter? writer = null)
    {
        ConsoleTableWriter<TElement>.ConsoleColorOptions options = new();
        action?.Invoke(options);
        new ConsoleTableWriter<TElement>(table, options, writer).Write();
    }
}

public static class TextTableOptionsExtensions
{
    /// <summary>
    /// Configures the <see cref="PlainTextTableOptions"/> to use Markdown options.
    /// </summary>
    /// <typeparam name="TElement">The type of elements in the table.</typeparam>
    /// <param name="builder">The table builder.</param>
    /// <returns>The same <see cref="PlainTextTable{TElement}"/>.</returns>
    public static ITableBuilder<TTable, TElement, PlainTextTableOptions> UseMarkdownOptions<TTable, TElement>(
        this ITableBuilder<TTable, TElement, PlainTextTableOptions> builder)
        where TTable : Table<TElement, PlainTextTableOptions>
    {
        builder.UseOptions(TextTableOptionPresets.Markdown);
        return builder;
    }
}

internal static class TextTableOptionPresets
{
    public static PlainTextTableOptions Defaults => new();

    public static PlainTextTableOptions Markdown => new()
    {
        DividerCharacter = '|',
        RuleCharacter = '-',
        RuleDividerCharacter = '|',
        Rule = TableRule.HeaderBottom
    };
}