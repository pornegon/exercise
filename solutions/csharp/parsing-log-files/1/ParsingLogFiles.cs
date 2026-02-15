
using System.Text.RegularExpressions;

public enum Code
{
    TRC,
    DBG,
    INF,
    WRN,
    ERR,
    FTL
}

public class LogParser
{
    public bool IsValidLine(string text) =>
        !string.IsNullOrWhiteSpace(text) && 
        Regex.Match(text, @"^\[?(\w+)\]?") is Match m && 
        m.Success && 
        Enum.TryParse<Code>(m.Groups[1].Value, out _);


    public string[] SplitLogLine(string text) => text.Split('<').Select(s => s.Trim(new[] {'=', '-', '>', '^'})).ToArray();

    public int CountQuotedPasswords(string lines) => Regex.Matches(lines, "\".*password.*\"", RegexOptions.IgnoreCase).Count();

    public string RemoveEndOfLineText(string line) => Regex.Replace(line, @"end-of-line\d*", "");

    public string[] ListLinesWithPasswords(string[] lines) =>
        lines.Select(line => 
            Regex.Match(line, @"password\S+", RegexOptions.IgnoreCase) is Match m && m.Success
                ? $"{m.Value}: {line}"
                : $"--------: {line}").ToArray();
}
