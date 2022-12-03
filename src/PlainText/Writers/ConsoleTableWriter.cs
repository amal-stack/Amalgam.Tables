using static System.Console;

namespace Amalgam.Tables.Plaintext.Writers;

/// <summary>
/// Implements a table writer that writes a table to the standard output stream or to the specified <see cref="TextWriter"/> as per the  <see cref="ConsoleColor"/> options in <see cref="ColorOptions"/> .
/// </summary>
/// <typeparam name="TElement"></typeparam>
/// <inheritdoc/>
public class ConsoleTableWriter<TElement> : TextWriterPlaintextTableWriter<TElement>
{
    /// <inheritdoc cref="ConsoleColorOptions"/>
    public ConsoleColorOptions ColorOptions { get; }

    public ConsoleTableWriter(
        PlaintextTable<TElement> table,
        ConsoleColorOptions? options = null,
        TextWriter? writer = null)
        : base(table, writer ?? Out)
    {
        ColorOptions = options ?? new();
    }

    /// <summary>
    /// Allows modifying the writer's <see cref="ColorOptions"/> through an <see cref="Action{ConsoleColorOptions}"/>.
    /// </summary>
    /// <param name="action"></param>
    /// <seealso cref="ConsoleColorOptions"/>
    public void ConfigureColorOptions(Action<ConsoleColorOptions> action)
        => action?.Invoke(ColorOptions);

    /// <summary>
    /// Defines the <see cref="ConsoleColor"/> constants for elements of the plain text table.
    /// </summary>
    public class ConsoleColorOptions
    {
        public ConsoleColor RuleColor { get; set; }

        public ConsoleColor RuleDividerColor { get; set; }

        public ConsoleColor DividerColor { get; set; }

        public ConsoleColor HeaderColor { get; set; }

        public ConsoleColor ContentColor { get; set; }

        public ConsoleColorOptions()
        {
            ContentColor
                = DividerColor
                = HeaderColor
                = RuleColor
                = RuleDividerColor
                = ConsoleColor.Gray;
        }
    }

    public override void WriteCell(string alignedValue)
    {
        WriteColored(ColorOptions.ContentColor, base.WriteCell, alignedValue);
    }

    public override void WriteDivider()
    {
        WriteColored(ColorOptions.DividerColor, base.WriteDivider);
    }

    public override void WriteHeaderCell(string alignedValue)
    {
        WriteColored(ColorOptions.HeaderColor, base.WriteHeaderCell, alignedValue);
    }

    public override void WriteRule()
    {
        WriteColored(ColorOptions.RuleColor, base.WriteRule);
    }

    public override void WriteRuleDivider(bool initial = false)
    {
        WriteColored(ColorOptions.RuleDividerColor, base.WriteRuleDivider, initial);
    }

    private static void WriteColored(ConsoleColor color, Action action)
    {
        var previousColor = ForegroundColor;
        ForegroundColor = color;
        action();
        ForegroundColor = previousColor;
    }

    private static void WriteColored<TIn>(ConsoleColor color, Action<TIn> action, TIn param)
    {
        var previousColor = ForegroundColor;
        ForegroundColor = color;
        action(param);
        ForegroundColor = previousColor;
    }
}
