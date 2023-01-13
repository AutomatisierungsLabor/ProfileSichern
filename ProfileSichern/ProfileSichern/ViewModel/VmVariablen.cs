using CommunityToolkit.Mvvm.ComponentModel;

namespace ProfileSichern.ViewModel;

public partial class ViewModel
{
    [ObservableProperty] private bool _boolBackupDesktop;
    [ObservableProperty] private bool _boolBackupFavoriten;
    [ObservableProperty] private bool _boolBackupSignatur;
    [ObservableProperty] private bool _boolBackupAlles;
    
    [ObservableProperty] private string _stringUserId;
    [ObservableProperty] private string _stringUserName;
    [ObservableProperty] private string _stringUserProfilePath;
    [ObservableProperty] private string _stringTextBox;
}