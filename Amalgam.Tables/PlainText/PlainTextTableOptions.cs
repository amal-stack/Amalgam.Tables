﻿namespace Amalgam.Tables.PlainText;


/// <summary>
/// Defines more specific options to configure the creation of plain text tables (<see cref="PlainTextTable{T}"/>). 
/// </summary>
public class PlainTextTableOptions : TableOptions
{
    /// <summary>
    /// Gets or sets the character that will be used to divide the columns.
    /// </summary>
    public char DividerCharacter { get; set; } = '|';

    /// <summary>
    /// Gets or sets the character that will be used to draw a horizontal rule in the specified areas of the table.
    /// </summary>
    public char RuleCharacter { get; set; } = '-';

    /// <summary>
    /// Gets or sets the character that will be used to divide the horizontal rule at the beginning and end of a column.
    /// </summary>
    public char RuleDividerCharacter { get; set; } = '+';

    /// <summary>
    /// Gets or sets the value that specifies the areas where a horizontal rule is desired in the table.
    /// </summary>
    ///<value>The default value is <see cref="TableRule.HeaderFooter"/>.</value>
    public TableRule Rule { get; set; } = TableRule.HeaderFooter;

}


