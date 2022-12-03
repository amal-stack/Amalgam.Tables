namespace Amalgam.Tables.Plaintext;

public static class PlaintextTableBuilderExtensions
{
    /// <summary>
    /// Configures the <see cref="PlaintextTableOptions"/> to use Markdown options.
    /// </summary>
    /// <typeparam name="TElement">The type of elements in the table.</typeparam>
    /// <param name="builder">The table builder.</param>
    /// <returns>The same <see cref="PlainTextTable{TElement}"/>.</returns>
    public static PlaintextTableBuilder<TElement> UseMarkdownOptions<TElement>(
        this PlaintextTableBuilder<TElement> builder)
    {
        builder.UseOptions(PlaintextTableOptionPresets.Markdown);
        return builder;
    }
}

