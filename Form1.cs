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

            Task.Run(() => ConvertToMP3(url));
        }

        private void ConvertToMP3(string url)
        {
            string ytDlpPath = @"D:\D003.exe\Code\CS\Personal\YouTubeToMP3Converter\yt-dlp.exe";
            string outputDirectory = @"C:\Users\Admin\Downloads";

            var processStartInfo = new ProcessStartInfo
            {
                FileName = ytDlpPath,
                Arguments = $"--extract-audio --audio-format mp3 --audio-quality 0 " +
                            "--format bestaudio --concurrent-fragments 32 " +
                            $"-o \"{outputDirectory}\\%(title)s.%(ext)s\" {url}",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = Process.Start(processStartInfo))
            {
                process!.OutputDataReceived += (sender, e) => Console.WriteLine(e.Data);
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