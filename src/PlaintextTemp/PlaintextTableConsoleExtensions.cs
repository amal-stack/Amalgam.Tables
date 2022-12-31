using Amalgam.Tables.Plaintext.Writers;

namespace Amalgam.Tables.Plaintext;

public static class PlaintextTableConsoleExtensions
{
    /// <summary>
    /// Writes the table to the standard output stream or to the specified <paramref name="writer"/>.
    /// </summary>
    /// <typeparam name="TElement">The type of elements in the table.</typeparam>
    /// <param name="table">The table.</param>
    /// <param name="action">An <see cref="Action{ConsoleTableWriter{TElement}.ConsoleColorOptions}"/> to set the <see cref="ConsoleTableWriter{TElement}.ConsoleColorOptions"/>.</param>
    /// <param name="writer">The <see cref="TextWriter"/> where the table will be return. Defaults to the standard output stream</param>
    public static void WriteToConsole<TElement>(
        this PlaintextTable<TElement> table,
        Action<ConsoleTableWriter<TElement>.ConsoleColorOptions>? action = null,
        TextWriter? writer = null)
    {
        ConsoleTableWriter<TElement>.ConsoleColorOptions options = new();
        action?.Invoke(options);
        new ConsoleTableWriter<TElement>(table, options, writer).Write();
    }
}
