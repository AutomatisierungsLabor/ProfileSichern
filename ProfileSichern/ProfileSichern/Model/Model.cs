using System;

namespace ProfileSichern.Model;

public partial class Model
{
    public long SizePfadDesktop { get; private set; }
    public long SizePfadFavoriten { get; private set; }
    public long SizePfadSignatur { get; private set; }
    public string? UserName { get; }
    public string? UserId { get; }
    public string? UserProfilePath { get; }
    public Backup? Backup { get; }
    public Restore? Restore { get; }
    public static string PfadDesktop => "Desktop";
    public static string PfadFavoriten => "Favorites";
    public static string PfadSignatur => @"AppData\Roaming\Microsoft\Signatures";

    public Model()
    {
        UserName = Environment.UserName;
        UserId = GetUserSid(UserName);
        UserProfilePath = GetUserProfilePath(UserName, UserId);

        Backup = new Backup();
        Restore = new Restore();
    }
}
