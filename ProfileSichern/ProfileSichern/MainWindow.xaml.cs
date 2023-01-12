using System.Diagnostics;
using System.IO;

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

    private static void InhaltAnzeigen(string path)
    {
        foreach (var file in Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories))
        {
            Debug.WriteLine(file);
        }
    }

}