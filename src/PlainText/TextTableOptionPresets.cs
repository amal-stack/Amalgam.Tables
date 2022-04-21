namespace Amalgam.Tables.PlainText;

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