// TODO: define the 'LogLevel' enum
enum LogLevel
{
    Trace = 1,
    Debug = 2,
    Info = 4,
    Warning = 5,
    Error = 6,
    Fatal = 42,
    Unknown = 0
}

static class LogLine
{
    public static LogLevel ParseLogLevel(string logLine) => 
    Enum.GetNames(typeof(LogLevel)).FirstOrDefault(name => name[0] == logLine[1]) is string enumName 
        ? (LogLevel)Enum.Parse(typeof(LogLevel), enumName) 
        : LogLevel.Unknown;
    
    public static string OutputForShortLog(LogLevel logLevel, string message) => $"{(int)logLevel}:{message}";
}
