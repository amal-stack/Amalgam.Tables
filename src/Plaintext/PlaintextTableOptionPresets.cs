namespace Amalgam.Tables.Plaintext;

internal static class PlaintextTableOptionPresets
{
    public static PlaintextTableOptions Defaults => new();

    public static PlaintextTableOptions Markdown => new()
    {
        DividerCharacter = '|',
        RuleCharacter = '-',
        RuleDividerCharacter = '|',
        Rule = TableRule.HeaderBottom
    };
}