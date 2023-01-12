using System;
using System.Diagnostics;
using System.Security.Principal;

namespace ProfileSichern.Model;



public class Model
{

    public string UserName { get; set; }
    public string UserId { get; set; }
    public string UserProfilePath { get; set; }

    public Model()
    {
        UserName = Environment.UserName;
        UserId = GetUserSid(UserName);
        UserProfilePath = GetUserProfilePath(UserName, UserId);
    }



    private static string GetUserProfilePath(string userName, string userSid = null)
    {
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

    private static string GetUserSid(string userName)
    {
        try
        {
            var f = new NTAccount(userName);
            var s = (SecurityIdentifier)f.Translate(typeof(SecurityIdentifier));
            return s.ToString();
        }
        catch
        {
            return null;
        }
    }
}
