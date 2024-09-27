using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO.Compression;

namespace ProfileSichern.Model;

public class Backup
{
    private string? _fileName;

    public bool DateiAuswaehlen(string? todo)
    {
        var defaultName = todo switch
        {
            "Desktop" => $"Desktop_{DateTime.Now:yyyy-MM-dd__HH-mm-ss}",
            "Favoriten" => $"Favoriten_{DateTime.Now:yyyy-MM-dd__HH-mm-ss}",
            "Signatur" => $"Signatur_{DateTime.Now:yyyy-MM-dd__HH-mm-ss}",
            _ => ""
        };

        var saveFileDialog = new SaveFileDialog
        {
            InitialDirectory = "h:\\",
            Filter = "zip Datei |*.zip",
            FileName = defaultName
        };

        saveFileDialog.ShowDialog();

        if (saveFileDialog.FileName == "") { return false; }

        _fileName = saveFileDialog.FileName;
        return true;
    }
    public void BackupData(string? quellpfad)
    {
        if (quellpfad is null) { return; }
        if (quellpfad.Length == 0) { return; }
        if (_fileName is null) { return; }

        try
        {
            ZipFile.CreateFromDirectory(quellpfad, _fileName, CompressionLevel.Optimal, false);
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            throw;
        }
    }
}
