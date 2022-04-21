namespace Amalgam.Tables;

/// <summary>
/// Encapsulates the options to configure the table creation.
/// </summary>
public class TableOptions
{
    /// <summary>
    /// Gets or sets the value that specifies the alignment of the values of each column in the table cells.
    /// </summary>
    /// <value>The default value is <see cref="TableContentAlignment.Right"/></value>
    /// <remarks>This value will be overriden for any column if the <see cref="TableColumn{TElement}.Alignment" /> for that column is not <see langword="null" />. </remarks>
    public TableContentAlignment Alignment { get; set; } = TableContentAlignment.Right;

    /// <summary>
    /// Gets or sets the value that specifies if the width of each column must expand to fit the widest cell in the column.
    /// </summary>
    /// <value><see langword="true"/> is the default value.</value>
    public bool AutoResizeColumns { get; set; } = true;

    /// <summary>
    /// Gets or sets a value representing the numbering column configuration for the table.
    /// </summary>
    public NumberingOptions Numbering { get; set; } = new();

    /// <summary>
    /// Encapsulates the numbering options for the table.
    /// </summary>
    public class NumberingOptions
    {

        /// <summary>
        /// Gets or sets the value specifying the index of the enumeration column.
        /// </summary>
        /// <value>The default is <c>0</c>.</value>
        public int Position { get; set; } = 0;

        /// <summary>
        /// Gets or sets the value specifying the header text of the enumeration column.
        /// </summary>
        /// <value>The default text is <c>"#"</c>.</value>
        public string HeaderText { get; set; } = "#";

        /// <summary>
        /// Gets or sets the value specifying the initial value of the enumeration column.
        /// </summary>
        /// <value>The default value is </value>
        public int StartFrom { get; set; } = 0;

        /// <summary>
        /// Gets or sets the value specifying the step value of the enumeration column.
        /// </summary>
        public int IncrementBy { get; set; } = 1;

        /// <summary>
        /// Gets or sets the value that allows specifying a custom sequence for the enumeration column.
        /// </summary>
        /// <value>The default value is <see langword="null"/> which implies that there is no custom sequence used for enumeration.</value>
        /// <example>
        /// To number the table items as <c>a, b, c, d</c>, set <see cref="Values"/> to something like:
        /// <code>
        /// NumberingOptions options = new NumberingOptions();
        /// options.Values = Enumerable.Range('a', 26).Select(x => ((char)x).ToString()).ToArray();
        /// </code>
        /// </example>
        /// <remarks>
        /// <para>If this value is not <see langword="null"/>, the values of <see cref="StartFrom"/> and <see cref="IncrementBy"/> are used to calculate the indexes to this sequence.</para>
        /// <para>If the number of rows in the table is more than the number of items in this value, enumeration restarts from the first item in this value. </para>
        /// </remarks>

        public IList<string>? Values { get; set; }
    }
}
