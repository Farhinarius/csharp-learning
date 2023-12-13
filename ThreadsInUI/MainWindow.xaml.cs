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
    private CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();

    public MainWindow()
    {
        InitializeComponent();
    }

    private void cmdCancelFlipImages_Click(object sender, EventArgs e)
    {
        _cancellationTokenSource.Cancel();
    }

    // Parallel handling of files by click version
    private void cmdFlipImagesParallel_Click(object sender, EventArgs e)
    {
        Task.Factory.StartNew(ProcessFilesParallel);
    }

    // Async handling of files by click version
    private async void cmdFlipImagesAsync_Click(object sender, EventArgs e)
    {
        await ProcessFilesAsync();
    }

    private void ProcessFilesParallel()
    {
        _cancellationTokenSource = new CancellationTokenSource();
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
                    this.Title = $"Processing {fileName}";
                });

                using (var bitmap = new Bitmap(currentFile))
                {
                    bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    bitmap.Save(Path.Combine(outputDirectory, fileName));
                }
            });

            Dispatcher?.Invoke(() =>
            {
                this.Title = $"Processing completed!";
            });
        }
        catch (Exception ex)
        {
            Dispatcher?.Invoke(() => this.Title = ex.Message);
        }
    }

    private async Task ProcessFilesAsync()
    {
        _cancellationTokenSource = new CancellationTokenSource();

        try
        {
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

            foreach (var file in files)
            {
                await ProcessFileAsync(file, outputDirectory,
                    _cancellationTokenSource.Token);                        // remove await operator and replace Task return value to void
                                                                            // to see parallel execution of file processing
            }

            Dispatcher?.Invoke(() =>
            {
                this.Title = $"Processing completed!";
            });
        }
        catch (Exception ex)
        {
            Dispatcher?.Invoke(() => this.Title = ex.Message);
        }
    }

    private async Task ProcessFileAsync(string file, string outputDirectory,
        CancellationToken token)
    {
        try
        {
            string fileName = Path.GetFileName(file);
            await Task.Run(() =>
            {
                Dispatcher?.Invoke(() =>
                {
                    this.Title = $"Processing {fileName}";
                });

                using var bitmap = new Bitmap(file);
                bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                bitmap.Save(Path.Combine(outputDirectory, fileName));
            }, token);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}


