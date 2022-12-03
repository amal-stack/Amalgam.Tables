namespace Amalgam.Tables.Plaintext;

/// <summary>
/// Defines flags that specify the areas within a plain text table where a horizontal rule is desired.
/// </summary>
[Flags]
public enum TableRule
{
    None = 0,
    HeaderTop = 1,
    HeaderBottom = 1 << 1,
    Body = 1 << 2,
    Footer = 1 << 3,
    Header = HeaderTop | HeaderBottom,
    HeaderFooter = Header | Footer,
    All = Header | Body | Footer,
}