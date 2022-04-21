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

    
    public virtual void WriteCell(string alignedValue)
    {
        Writer.Write(alignedValue);
    }

    
    public virtual void WriteHeaderCell(string alignedValue)
    {
        Writer.Write(alignedValue);
    }

    
    public virtual void WriteRuleForColumn(TableColumn<TElement> column)
    {
        Writer.Write(new string(Table.Options.RuleCharacter, column.Width + 2));
    }

    
    public virtual void WriteDivider()
    {
        Writer.Write(FinalDivider);
    }

    
    public virtual void WriteRuleDivider(bool initial = false)
    {
        Writer.Write(initial ? FinalRuleDivider : FinalRuleDivider.AsSpan(1));
    }
}
