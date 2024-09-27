using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO.Compression;

namespace ProfileSichern.Model;

public class Restore
{
    private string? _fileName;

    public bool DateiAuswaehlen()
    {
        var openFileDialog = new OpenFileDialog
        {
            InitialDirectory = "h:\\",
            Filter = "zip Datei |*.zip"
        };

        openFileDialog.ShowDialog();

        _fileName = openFileDialog.FileName;
        return !string.IsNullOrEmpty(_fileName);
    }

    public void RestoreData(string? zielPfad)
    {
        if (zielPfad is null || _fileName is null) { return; }

        try
        {
            ZipFile.ExtractToDirectory(_fileName, zielPfad);
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
            throw;
        }
    }
}
