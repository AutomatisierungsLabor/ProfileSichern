using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;

namespace ProfileSichern.Model;

public partial class Model
{
    private static string? GetUserProfilePath(string? userName, string? userSid)
    {
        if (userName is null || userSid == null) return null;
        try
        {
            userSid ??= GetUserSid(userName);

            var keyPath = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\ProfileList\" + userSid;
            var key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(keyPath);
            var profilePath = key?.GetValue("ProfileImagePath") as string;

            return profilePath;
        }
        catch (Exception e)
        {
            Debug.Write(e);
            return null;
        }
    }
    private static string? GetUserSid(string? userName)
    {
        try
        {
            var f = new NTAccount(userName);
            var s = (SecurityIdentifier)f.Translate(typeof(SecurityIdentifier));
            return s.ToString();
        }
        catch (Exception e)
        {
            Debug.Write(e);
            return null;
        }
    }
    public string? GetProfilInfo()
    {
        SizePfadDesktop = OrdnerGroesseLesen($"{Path.Combine(UserProfilePath, PfadDesktop)}");
        SizePfadFavoriten = OrdnerGroesseLesen($"{Path.Combine(UserProfilePath, PfadFavoriten)}");
        SizePfadSignatur = OrdnerGroesseLesen($"{Path.Combine(UserProfilePath, PfadSignatur)}");

        var text = new StringBuilder();
        text.Clear();

        text.Append("Aktuell belegter Speicherplatz:\n");
        text.Append($"Desktop: {SizeSuffix(SizePfadDesktop)} \n");
        text.Append($"Favoriten: {SizeSuffix(SizePfadFavoriten)} \n");
        text.Append($"Signatur: {SizeSuffix(SizePfadSignatur)} \n");

        return text.ToString();
    }
    private static long OrdnerGroesseLesen(string? pfad)
    {
        if (pfad is null || !Directory.Exists(pfad)) return 0;
        return Directory.EnumerateFiles(pfad, "*", SearchOption.AllDirectories).Sum(fileInfo => new FileInfo(fileInfo).Length);
    }
    private static readonly string[]? SizeSuffixes = { "Byte", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
    private static string? SizeSuffix(long value, int decimalPlaces = 1)
    {
        if (value < 0) { return "-" + SizeSuffix(-value, decimalPlaces); }

        var i = 0;
        var dValue = (decimal)value;
        while (Math.Round(dValue, decimalPlaces) >= 1000)
        {
            dValue /= 1024;
            i++;
        }
        return $"{dValue:F1} {SizeSuffixes[i]}";
    }
}
