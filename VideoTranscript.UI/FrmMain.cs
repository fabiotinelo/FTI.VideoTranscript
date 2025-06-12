using VideoTranscript.Service;
using System.Diagnostics;
using System.Text;
using System.Text.Json;


namespace VideoTranscript.UI
{
    public partial class FrmMain : Form
    {

        private string? videoFile;
        private DateTime countRun;
        private string configFileName= "config.json";

        public FrmMain() => InitializeComponent();

        private void FrmMain_Load(object sender, EventArgs e)
        {
            lblFile.Text = "";
            lblTime.Text = "";
        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            SelectFile();
        }

        private void btnTranscribeVideo_Click(object sender, EventArgs e)
        {
            TranscribeVideo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start("notepad.exe", configFileName);
        }

        private void SelectFile()
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                videoFile=openFileDialog.FileName;
                lblFile.Text = videoFile;
            }

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            countRun = countRun.AddSeconds(1);
            lblTime.Text = countRun.ToString("HH:mm:ss");
        }

        private async void TranscribeVideo()
        {
            if (string.IsNullOrEmpty(videoFile) || !File.Exists(videoFile))
            {
                MessageBox.Show("Arquivo de vídeo/audio não encontrado.", "Arquivo não encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            ClearRichTextBox(rtbText);
            btnTranscribeVideo.Text = "Running ...";
            btnTranscribeVideo.Enabled = false;
            btnSelectFile.Enabled = false;
            timer.Enabled = true;
            countRun = new DateTime(2000, 1, 1, 0, 0, 0);

            await Task.Run(() => Transcribe(videoFile!));

            btnTranscribeVideo.Text = "Transcribe Video";
            btnTranscribeVideo.Enabled = true;
            btnSelectFile.Enabled = true;
            timer.Enabled = false;
        }

        private void Transcribe(string fileName)
        {
            ExtractService extractService = new(GetOpenAIKey());
            UpdateRichTextBox(rtbText, extractService.Transcribe(fileName));
        }

        private string GetOpenAIKey()
        {
            string jsonContent = File.ReadAllText(configFileName);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            Config config = JsonSerializer.Deserialize<Config>(jsonContent, options)!;
            return config.OpenAiKey;
        }

        private void UpdateRichTextBox(RichTextBox richTextBox, StringBuilder text)
        {
            if (richTextBox.InvokeRequired)
                richTextBox.Invoke(new Action(() => UpdateRichTextBox(richTextBox, text)), text);
            else
                richTextBox.Text = text.ToString();
        }

        private void ClearRichTextBox(RichTextBox richTextBox)
        {
            if (richTextBox.InvokeRequired)
                richTextBox.Invoke(new Action(() => ClearRichTextBox(richTextBox)));
            else
                richTextBox.Text = "";
        }

    }
}
