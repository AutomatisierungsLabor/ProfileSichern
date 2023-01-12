using System.IO.Compression;
using Microsoft.Win32;

namespace ProfileSichern.Model;

public class Restore
{
    private string _fileName;

    public bool DateiAuswaehlen()
    {
        var openFileDialog = new OpenFileDialog
        {
            InitialDirectory = "h:\\",
            Filter = "zip Datei |*.zip"
        };

        openFileDialog.ShowDialog();

        if (openFileDialog.FileName == "") return false;

        _fileName = openFileDialog.FileName;
        return true;
    }

    public void RestoreData(string zielPfad)
    {
        if (zielPfad == null) return;
        ZipFile.ExtractToDirectory(_fileName, zielPfad);
    }
}