// TODO: define the 'AccountType' enum
enum AccountType
{
    Guest,
    User,
    Moderator
}

// TODO: define the 'Permission' enum

[Flags]
enum Permission
{
    Read = 1,
    Write = 2,
    Delete = 4,
    All = 7,
    None = 0
}

static class Permissions
{
    public static Permission Default(AccountType accountType)  => 
    accountType == AccountType.Guest ? Permission.Read :
    accountType == AccountType.User ? Permission.Read | Permission.Write :
    accountType == AccountType.Moderator ? Permission.Read | Permission.Write | Permission.Delete :
    Permission.None;

    public static Permission Grant(Permission current, Permission grant) => current | grant;

    public static Permission Revoke(Permission current, Permission revoke)  => current & (current ^ revoke);

    public static bool Check(Permission current, Permission check) => (current & check) >= check;
}
