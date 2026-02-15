public static class HighSchoolSweethearts
{
    public static string DisplaySingleLine(string studentA, string studentB) =>
        $"{studentA.PadLeft(29)} ♡ {studentB.PadRight(29)}";

    public static string DisplayBanner(string studentA, string studentB) 
        => $@"     ******       ******
   **      **   **      **
 **         ** **         **
**            *            **
**                         **
**     {studentA} +  {studentB}    **
 **                       **
   **                   **
     **               **
       **           **
         **       **
           **   **
             ***
              *";

    public static string DisplayGermanExchangeStudents(string studentA
        , string studentB, DateTime start, float hours) => $"{studentA} and {studentB} have been dating since {start.ToString("d", new System.Globalization.CultureInfo("de-DE"))} - that's {hours.ToString("#,0.00", new System.Globalization.CultureInfo("de-DE"))} hours";
}
