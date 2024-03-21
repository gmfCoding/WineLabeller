using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.IO;
using WineLabeller.Helpers;
using WineLabeller.Services;

namespace WineLabeller.ViewModels;

public class MainViewModel : ObservableObject, IFileDragDropTarget
{
    private class Errors
    {
        public const string NoFile = "You have to drag in a image file. supported: ({0})";
        public const string TooManyFiles = "You can only Analyse one image at a time.";
        public const string UnsupportFile = "You cannot analyse {0} type supported: ({1})";
    }

    IOCRService OCRService;

    string error;

    public string Error { get => Error; set
        {
            error = value;
            OnPropertyChanged(nameof(Error));
        }}

    public void OnFileDrop(string[] filepaths)
    {
        string[] supportedTypes = { "jpeg", "png", "jpg", "bmp", "webp" };
        if (filepaths.Length == 0)
        {
            Error = string.Format(Errors.NoFile, string.Join(", ", supportedTypes).Trim(' ').Trim(','));
            return;
        }
        if (filepaths.Length > 1)
        {
            Error = Errors.TooManyFiles;
            return;
        }
        string path = filepaths[0];
        string ext = Path.GetExtension(path).TrimStart('.');
        if (supportedTypes.Contains(ext) == false)
        {
            Error = string.Format(Errors.UnsupportFile, ext, string.Join(", ", supportedTypes).Trim(' ').Trim(','));
            return;
        }
        using FileStream stream = new FileStream(path, FileMode.Open);
        OCRService.Analyse(stream);
    }

    public MainViewModel(IOCRService ocrService)
    {
        OCRService = ocrService;
    }
}
