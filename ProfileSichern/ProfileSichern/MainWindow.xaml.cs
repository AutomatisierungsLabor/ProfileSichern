namespace ProfileSichern;

public partial class MainWindow
{
    private ViewModel.ViewModel ViewModel { get; }
    public Model.Model Model { get; }

    public MainWindow()
    {
        Model = new Model.Model();
        ViewModel = new ViewModel.ViewModel(this);

        InitializeComponent();
        DataContext = ViewModel;
    }
}