public static class LogAnalysis 
{
    // TODO: define the 'SubstringAfter()' extension method on the `string` type
    public static string SubstringAfter(this string log, string a) => log.Substring(log.IndexOf(a)+a.Length);

    // TODO: define the 'SubstringBetween()' extension method on the `string` type
      public static string SubstringBetween(this string log, string a, string b) => log.Remove(log.IndexOf(b)).Substring(log.IndexOf(a)+a.Length);
    
    // TODO: define the 'Message()' extension method on the `string` type
    public static string Message(this string log) => log.SubstringAfter(": ");

    // TODO: define the 'LogLevel()' extension method on the `string` type
    public static string LogLevel(this string log) => log.SubstringBetween("[", "]");
}