using CommunityToolkit.Mvvm.Input;
using System.IO;

namespace ProfileSichern.ViewModel;

public partial class ViewModel
{
    [RelayCommand]
    private void ButtonBackup(string? todo)
    {
        if (todo is null || _model.Backup is null) { return; }

        if (_model.Backup.DateiAuswaehlen(todo)) { _model.Backup.BackupData(PfadBestimmen(todo)); }
    }

    [RelayCommand]
    private void ButtonRestore(string? todo)
    {
        if (todo is null || _model.Restore is null) { return; }

        if (_model.Restore.DateiAuswaehlen()) { _model.Restore.RestoreData(PfadBestimmen(todo)); }
    }

    private string? PfadBestimmen(string? todo)
    {
        if (todo is null || _model.UserProfilePath is null) { return null; }

        return todo switch
        {
            "Desktop" => Path.Combine(_model.UserProfilePath, Model.Model.PfadDesktop),
            "Favoriten" => Path.Combine(_model.UserProfilePath, Model.Model.PfadFavoriten),
            "Signatur" => Path.Combine(_model.UserProfilePath, Model.Model.PfadSignatur),
            _ => ""
        };
    }
}
