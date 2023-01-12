using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Media;

namespace ProfileSichern.ViewModel;

public partial class ViewModel : ObservableObject
{
 
    public ViewModel(MainWindow mainWindow)
    {
        BrushButtonLoeschen = Brushes.LightGray;
        BrushButtonTemplate = Brushes.LightGray;
        BrushButtonEntpacken = Brushes.LightGray;


        StringUserId = $"ID: {mainWindow.Model.UserId}";
        StringUserName = $"Name: {mainWindow.Model.UserName}";
        StringUserProfilePath = $"Profilordner: {mainWindow.Model.UserProfilePath}";


    }

}