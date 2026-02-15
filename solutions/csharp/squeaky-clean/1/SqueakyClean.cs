public static class Identifier
{
    public static string Clean(string identifier) => string.Concat(identifier.Select<char, string>(c =>
                                                                                     {
                                                                                         if (c == ' ')
                                                                                             return 
                                                                                                 "_";
                                                                                         else if (c == '-')
                                                                                             return 
                                                                                                 "";
                                                                                         else if (char.IsControl(c))
                                                                                             return "CTRL";
                                                                                         else if (identifier.IndexOf(c) > 0 
                                                                                                  && identifier[identifier.IndexOf(c) - 1] == '-')
                                                                                             return char.ToUpper(c).ToString();
                                                                                         else if (c >= 'α' && c <= 'ω')
                                                                                                    return "";   
                                                                                         else if (!char.IsLetter(c))
                                                                                                     return "";
                                                                                         else return c.ToString();
                                                                                     }));
}
