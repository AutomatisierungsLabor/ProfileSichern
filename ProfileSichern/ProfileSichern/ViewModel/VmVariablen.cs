using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Media;

namespace ProfileSichern.ViewModel;

public partial class ViewModel
{
    [ObservableProperty] private Brush _brushButtonTemplate;
    [ObservableProperty] private Brush _brushButtonLoeschen;
    [ObservableProperty] private Brush _brushButtonEntpacken;


    [ObservableProperty] private string _stringUserId;
    [ObservableProperty] private string _stringUserName;
    [ObservableProperty] private string _stringUserProfilePath;

}