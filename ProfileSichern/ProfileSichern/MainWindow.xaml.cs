namespace ProfileSichern;

// ReSharper disable once UnusedMember.Global
public partial class MainWindow
{
    public MainWindow()
    {
        var model = new Model.Model();
        var viewModel = new ViewModel.ViewModel(model);

        InitializeComponent();
        DataContext = viewModel;
    }
}
