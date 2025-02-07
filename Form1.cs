using System.Diagnostics;

namespace YouTubeToMP3Converter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            string url = txtURL.Text.Trim();

            if (string.IsNullOrEmpty(url))
            {
                MessageBox.Show("Please enter a YouTube video URL.");
                return;
            }

            lblStatus.Text = "Status: Downloading...";

            Task.Run(() => DownloadAndConvertToMP3(url));
        }

        private void DownloadAndConvertToMP3(string url)
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string projectDirectory = Path.GetFullPath(Path.Combine(baseDirectory, @"..\..\..\"));

            string ytDlpPath = Path.Combine(projectDirectory, "yt-dlp.exe");
            string ffmpegPath = Path.Combine(projectDirectory, "ffmpeg", "bin", "ffmpeg.exe");

            string outputDirectory = @"C:\Users\Admin\Downloads";

            var processStartInfo = new ProcessStartInfo
            {
                FileName = ytDlpPath,
                Arguments = $"--ffmpeg-location \"{ffmpegPath}\" " +
                            $"--extract-audio --audio-format mp3 --audio-quality 0 " +
                            $"--output \"{outputDirectory}\\%(title)s.%(ext)s\" " +
                            $"\"{url}\"",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
            };

            using (Process process = Process.Start(processStartInfo))
            {
                process.OutputDataReceived += (sender, e) => Console.WriteLine(e.Data);
                process.ErrorDataReceived += (sender, e) => Console.WriteLine(e.Data);

                process.BeginOutputReadLine();
                process.BeginErrorReadLine();

                process.WaitForExit();
            }

            Invoke(() =>
            {
                lblStatus.Text = "Status: Conversion Completed!";
                MessageBox.Show("Conversion completed successfully!");
            });
        }
    }
}