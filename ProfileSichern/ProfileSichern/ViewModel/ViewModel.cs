using CommunityToolkit.Mvvm.ComponentModel;

namespace ProfileSichern.ViewModel;

public partial class ViewModel : ObservableObject
{
    private readonly Model.Model _model;

    public ViewModel(Model.Model model)
    {
        _model = model;

        StringUserId = $"ID: {_model.UserId}";
        StringUserName = $"Name: {_model.UserName}";
        StringUserProfilePath = $"Profilordner: {_model.UserProfilePath}";

        StringTextBox = _model.GetProfilInfo();

        BoolBackupDesktop = _model.SizePfadDesktop > 0;
        BoolBackupFavoriten = _model.SizePfadFavoriten > 0;
        BoolBackupSignatur = _model.SizePfadSignatur > 0;
    }
}
