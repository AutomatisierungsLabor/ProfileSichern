using System;

namespace ProfileSichern.Model;

public partial class Model
{
    public long SizePfadDesktop { get; set; }
    public long SizePfadFavoriten { get; set; }
    public long SizePfadSignatur { get; set; }
    public string UserName { get; set; }
    public string UserId { get; set; }
    public string UserProfilePath { get; set; }
    public Backup Backup { get; set; }
    public Restore Restore { get; set; }
    public string PfadDesktop { get; set; } = "Desktop";
    public string PfadFavoriten { get; set; } = "Favorites";
    public string PfadSignatur { get; set; } = @"AppData\Roaming\Microsoft\Signatures";

    public Model()
    {
        UserName = Environment.UserName;
        UserId = GetUserSid(UserName);
        UserProfilePath = GetUserProfilePath(UserName, UserId);

        Backup = new Backup();
        Restore = new Restore();
    }
}