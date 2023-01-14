using Amalgam.Tables.Plaintext;
using System.Globalization;

var en = Console.OutputEncoding;
Console.WriteLine(en);
Console.OutputEncoding = System.Text.Encoding.UTF8;
var items = new List<string>()
{
    "Public",
    "Static",
    "Void",
    "Main",
    "測試" // width issue with some characters
};

PlaintextTable.For(items)
    .AddNumbering()
    //.AddColumn("Text", i => i)
    //.AddColumn("Uppercase Text", i => i.ToUpperInvariant())
    .AddColumn("Length TE", i => new StringInfo(i).LengthInTextElements)
    .AddColumn("Length", i => i.Length)
    .AddColumn("First Two Letters", i => i[..2])
    .Build()
    .WriteToConsole(options =>
    {
        options.HeaderColor = ConsoleColor.Red;
        options.RuleColor = ConsoleColor.Green;
        options.RuleDividerColor = ConsoleColor.Blue;
        options.DividerColor = ConsoleColor.Yellow;
        options.ContentColor = ConsoleColor.White;
    });


Console.OutputEncoding = en;