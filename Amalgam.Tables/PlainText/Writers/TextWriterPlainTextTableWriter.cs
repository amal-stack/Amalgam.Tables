using Amalgam.Tables.Extensions;

namespace Amalgam.Tables.PlainText.Writers;

/// <summary>
/// Implements a table writer that writes a <see cref="PlainTextTable{TElement}"/> to a <see cref="TextWriter"/>.
/// </summary>
/// <remarks>This writer does not currently implement numbering specified via <see cref="TableOptions.NumberingOptions"/>. </remarks>
/// <typeparam name="TElement">The type of elements in the table.</typeparam>
public class TextWriterPlainTextTableWriter<TElement> : IPlainTextTableWriter<TElement>
{
    public Table<TElement, PlainTextTableOptions> Table { get; }

    public TextWriter Writer { get; }

    protected string FinalDivider { get; }

    protected string FinalRuleDivider { get; }


    public TextWriterPlainTextTableWriter(
        Table<TElement, PlainTextTableOptions> table,
        TextWriter writer)
    {
        Table = table;
        Writer = writer;
        FinalDivider = $" {Table.Options.DividerCharacter} ";
        FinalRuleDivider = $" {Table.Options.RuleDividerCharacter}";
    }

    /// <summary>
    /// Outputs the entire table to <see cref="Writer"/>.
    /// </summary>
    public virtual void Write()
    {
        if (Table.Options.AutoResizeColumns)
        {
            Table.AutoResizeColumns();
        }

        if (Table.Options.Rule.HasFlag(TableRule.HeaderTop))
        {
            WriteRule();
        }

        WriteHeader();

        if (Table.Options.Rule.HasFlag(TableRule.HeaderBottom))
        {
            WriteRule();
        }

        foreach (var item in Table.Elements.Select((element, index) => (element, index)))
        {
            WriteRowForElement(item.element, item.index);
            if (Table.Options.Rule.HasFlag(TableRule.Body))
            {
                WriteRule();
            }
        }

        if (!Table.Options.Rule.HasFlag(TableRule.Body)
            && Table.Options.Rule.HasFlag(TableRule.Footer))
        {
            WriteRule();
        }
    }

    /// <summary>
    /// Writes the entire header row to <see cref="Writer"/>.
    /// </summary>
    public virtual void WriteHeader()
    {
        WriteDivider();

        foreach (var column in Table.Columns)
        {
            string alignedValue = column.Name.Align(
                Table.GetAlignment(column),
                column.Width);
            WriteHeaderCell(alignedValue);
            WriteDivider();
        }

        Writer.WriteLine();
    }

    /// <summary>
    /// Writes an entire row (for a single element of the table) using using the <see cref="TableColumn{TElement}.Selector"/> for each column in <see cref="Table.Columns"/> to <see cref="Writer"/>
    /// </summary>
    /// <param name="element"></param>
    /// <param name="index"></param>
    public void WriteRowForElement(TElement element, int index)
    {
        WriteDivider();

        foreach (var column in Table.Columns)
        {
            string alignedValue = column.Get(element, index).Align(
                Table.GetAlignment(column),
                column.Width);
            WriteCell(alignedValue);
            WriteDivider();
        }

        Writer.WriteLine();
    }

    /// <summary>
    /// Adds a horizontal rule to <see cref="Writer"/>
    /// </summary>
    public virtual void WriteRule()
    {
        WriteRuleDivider(initial: true);
        foreach (var column in Table.Columns)
        {
            WriteRuleForColumn(column);
            WriteRuleDivider();
        }

        Writer.WriteLine();
    }

    /// <summary>
    /// Writes the content of a single cell to <see cref="Writer"/>.
    /// </summary>
    /// <param name="alignedValue">The content of the cell after alignment.</param>
    public virtual void WriteCell(string alignedValue)
    {
        Writer.Write(alignedValue);
    }

    /// <summary>
    /// Writes the content of a single header cell to <see cref="Writer"/>.
    /// </summary>
    /// <param name="alignedValue">The content of the cell after alignment.</param>
    public virtual void WriteHeaderCell(string alignedValue)
    {
        Writer.Write(alignedValue);
    }

    /// <summary>
    /// Adds a horizontal rule.
    /// </summary>
    /// <param name="column">The column for which the rule characters has to be written.</param>
    public virtual void WriteRuleForColumn(TableColumn<TElement> column)
    {
        Writer.Write(new string(Table.Options.RuleCharacter, column.Width + 2));
    }

    /// <summary>
    /// Writes the divider to <see cref="Writer"/>.
    /// </summary>
    public virtual void WriteDivider()
    {
        Writer.Write(FinalDivider);
    }

    /// <summary>
    /// Writes the rule divider to <see cref="Writer"/>.
    /// </summary>
    public virtual void WriteRuleDivider(bool initial = false)
    {
        Writer.Write(initial ? FinalRuleDivider : FinalRuleDivider.AsSpan(1));
    }
}
