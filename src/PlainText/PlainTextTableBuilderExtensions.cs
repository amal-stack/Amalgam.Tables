using Amalgam.Tables.Builders;

namespace Amalgam.Tables.PlainText;

public static class PlainTextTableBuilderExtensions
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
