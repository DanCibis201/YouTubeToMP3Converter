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

            try
            {
                lblStatus.Text = "Status: Downloading...";
                ConvertToMP3(url);
                lblStatus.Text = "Status: Conversion Completed!";
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Status: Error!";
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void ConvertToMP3(string url)
        {
            string ytDlpPath = @"D:\D003.exe\Code\CS\Personal\YouTubeToMP3Converter\yt-dlp.exe";
            string outputDirectory = @"D:\D003.exe\Code\CS\Personal\YouTubeToMP3Converter\MP3ConvertedMusic";

            var processStartInfo = new ProcessStartInfo
            {
                FileName = ytDlpPath,
                Arguments = $"-x --audio-format mp3 --audio-quality 0 -o \"{outputDirectory}\\%(title)s.%(ext)s\" {url}",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            Process process = Process.Start(processStartInfo);
            process.WaitForExit();
        }
    }
}
