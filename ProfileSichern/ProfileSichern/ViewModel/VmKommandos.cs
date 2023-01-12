using CommunityToolkit.Mvvm.Input;
using System.Windows.Media;

namespace ProfileSichern.ViewModel;

public partial class ViewModel
{
    [RelayCommand]
    private void ButtonBackup(string todo)
    {


        BrushButtonLoeschen = Brushes.LawnGreen;
        BrushButtonTemplate = Brushes.LightGray;
    }


    [RelayCommand]
    private void ButtonRestore(string todo)
    {


        BrushButtonLoeschen = Brushes.LawnGreen;
        BrushButtonTemplate = Brushes.LightGray;
    }



}