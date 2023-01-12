using System.IO;
using CommunityToolkit.Mvvm.Input;

namespace ProfileSichern.ViewModel;

public partial class ViewModel
{
    [RelayCommand]
    private void ButtonBackup(string todo)
    {
        var erfolgreich = _mainWindow.Model.Backup.DateiAuswaehlen(todo);
        if (erfolgreich) _mainWindow.Model.Backup.BackupData(PfadBestimmen(todo));
    }


    [RelayCommand]
    private void ButtonRestore(string todo)
    {
        var erfolgreich = _mainWindow.Model.Restore.DateiAuswaehlen();
        if (erfolgreich) _mainWindow.Model.Restore.RestoreData(PfadBestimmen(todo));
    }


    private string PfadBestimmen(string todo)
    {
        var quellpfad = todo switch
        {
            "Desktop" => Path.Combine(_mainWindow.Model.UserProfilePath, _mainWindow.Model.PfadDesktop),
            "Favoriten" => Path.Combine(_mainWindow.Model.UserProfilePath, _mainWindow.Model.PfadFavoriten),
            "Signatur" => Path.Combine(_mainWindow.Model.UserProfilePath, _mainWindow.Model.PfadSignatur),
            _ => ""
        };
        return quellpfad;
    }
}