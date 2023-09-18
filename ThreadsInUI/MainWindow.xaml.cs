using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace ThreadsInUI;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private CancellationTokenSource _cancellationTokenSource 
        = new CancellationTokenSource();

    public MainWindow()
    {
        InitializeComponent();
    }

    private void cmdCancel_Click(object sender, EventArgs e)
    {
        _cancellationTokenSource.Cancel();
    }

    private void cmdProcess_Click(object sender, EventArgs e)
    {
        Task.Factory.StartNew(() => ProcessFiles());
        this.Title = "Processing Complete";
    }

    private void ProcessFiles()
    {
        ParallelOptions parallelOptions = new ParallelOptions();
        parallelOptions.CancellationToken = _cancellationTokenSource.Token;
        parallelOptions.MaxDegreeOfParallelism = System.Environment.ProcessorCount;

        var basePath = Directory.GetCurrentDirectory();
        var pictureDirectory = Path.Combine(basePath, "TestPictures");
        var outputDirectory = Path.Combine(basePath, "ModifiedPictures");

        if (Directory.Exists(outputDirectory))
        {
            Directory.Delete(outputDirectory, true);
        }
        Directory.CreateDirectory(outputDirectory);

        string[] files = Directory.GetFiles(pictureDirectory, "*.png",
            SearchOption.AllDirectories);

        try
        {
            Parallel.ForEach(files, parallelOptions, currentFile =>
            {
                parallelOptions.CancellationToken.ThrowIfCancellationRequested();
                string fileName = Path.GetFileName(currentFile);

                // Cannot modify UI elements from non primary thread, use Dispatcher instead
                //this.Title = $"Processing {fileName} " +
                //    $"on thread {Thread.CurrentThread.ManagedThreadId}";

                Dispatcher?.Invoke(() =>
                {

                    this.Title += $"Processing {fileName}";
                });

                using (var bitmap = new Bitmap(currentFile))
                {
                    bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    bitmap.Save(Path.Combine(outputDirectory, fileName));
                }

                Dispatcher?.Invoke(() => this.Title = "Done!");
            });
        }
        catch (Exception ex)
        {
            Dispatcher?.Invoke(() => this.Title = ex.Message);
        }
        

    }

}


