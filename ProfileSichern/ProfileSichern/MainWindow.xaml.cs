namespace ProfileSichern;

public partial class MainWindow
{
    public ViewModel.ViewModel ViewModel { get; set; }
    public Model.Model Model { get; set; }

    public MainWindow()
    {
        Model = new Model.Model();
        ViewModel = new ViewModel.ViewModel(this);

        InitializeComponent();
        DataContext = ViewModel;
    }
}