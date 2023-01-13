using CommunityToolkit.Mvvm.ComponentModel;

namespace ProfileSichern.ViewModel;

public partial class ViewModel : ObservableObject
{
    private readonly MainWindow _mainWindow;
 
    public ViewModel(MainWindow mainWindow)
    {
        _mainWindow = mainWindow;

        StringUserId = $"ID: {_mainWindow.Model.UserId}";
        StringUserName = $"Name: {_mainWindow.Model.UserName}";
        StringUserProfilePath = $"Profilordner: {_mainWindow.Model.UserProfilePath}";

        StringTextBox = _mainWindow.Model.GetProfilInfo();

        BoolBackupDesktop = _mainWindow.Model.SizePfadDesktop > 0;
        BoolBackupFavoriten = _mainWindow.Model.SizePfadFavoriten > 0;
        BoolBackupSignatur = _mainWindow.Model.SizePfadSignatur > 0;
    }
}