static class Badge
{
    public static string Print(int? id, string name, string? department)
    {
        string idstring = id == null ? "" : ($"[{id}] - ");
        department = department?.ToUpper() ?? "OWNER";
        return ($"{idstring}{name} - {department}");
    }
}
