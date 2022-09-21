namespace ytnet;
using VideoLibrary;

partial class YtNetForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /*
    ============================================
    ============================================
    ============================================
    */

    /* Component Declarations */
    private System.Windows.Forms.Label LabelUrl { get; set; }
    private System.Windows.Forms.TextBox InputUrl { get; set; }
    private System.Windows.Forms.Button ButtonUrl { get; set; }
    private System.Windows.Forms.RadioButton RadioVideo { get; set; }
    private System.Windows.Forms.RadioButton RadioAudio { get; set; }
    private System.Windows.Forms.Label LabelError { get; set; }
    private System.Windows.Forms.Label VideoTitle { get; set; }
    private System.Windows.Forms.Label VideoAuthor { get; set; }
    private System.Windows.Forms.Label VideoDuration { get; set; }
    private System.Windows.Forms.Label DownloadLocation { get; set; }
    private System.Windows.Forms.Label Downloading { get; set; }

    /* ===================== */

    /* Download Format */
    private string format = ".mp4";
    /* =============== */

    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

        // * Client configuration
        this.Text = "YtNet - Youtube Downloader";               //Title
        this.ClientSize = new System.Drawing.Size(650, 250);    //Default Client Size
        this.MaximizeBox = false;                               //Disables maximizing box
        this.StartPosition = FormStartPosition.CenterScreen;    //Sets starting position at center
        this.FormBorderStyle = FormBorderStyle.FixedDialog;     //Define the style of the border (no adjustments)
        this.BackColor = Color.WhiteSmoke;                      //Background color
        this.Icon = new Icon("./Resources/YtNet.ico");

        // * Load Components
        LoadComponents();
    }

    private void LoadComponents()
    {

        // * URL Input Label
        this.LabelUrl = new System.Windows.Forms.Label();
        this.LabelUrl.Text = "Enter your video's URL:";
        this.Controls.Add(LabelUrl);
        this.LabelUrl.Font = new Font("Roboto", 12);
        this.LabelUrl.AutoSize = true;
        this.LabelUrl.Top = 10;
        this.LabelUrl.Left = 10;

        // * URL Input Camp
        this.InputUrl = new System.Windows.Forms.TextBox();
        this.InputUrl.Text = "";
        this.Controls.Add(InputUrl);
        this.InputUrl.Font = new Font("Roboto", 10);
        this.InputUrl.Width = 400;
        this.InputUrl.Top = 40;
        this.InputUrl.Left = 10;

        // * URL Enter Button
        this.ButtonUrl = new System.Windows.Forms.Button();
        this.ButtonUrl.Text = "Download";
        this.Controls.Add(ButtonUrl);
        this.ButtonUrl.Font = new Font("Roboto", 8);
        this.ButtonUrl.AutoSize = true;
        this.ButtonUrl.BackColor = Color.WhiteSmoke;
        this.ButtonUrl.FlatStyle = FlatStyle.Flat;
        this.ButtonUrl.Top = 40;
        this.ButtonUrl.Left = 415;
        this.ButtonUrl.Click += new System.EventHandler(ButtonUrl_Click);

        // * Video Format Radio Button
        this.RadioVideo = new System.Windows.Forms.RadioButton();
        this.RadioVideo.Text = "Video";
        this.Controls.Add(RadioVideo);
        this.RadioVideo.AutoSize = true;
        this.RadioVideo.Checked = true;
        this.RadioVideo.Top = 65;
        this.RadioVideo.Left = 10;
        this.RadioVideo.Click += new System.EventHandler(SetFormat);

        // * Audio Format Radio Button
        this.RadioAudio = new System.Windows.Forms.RadioButton();
        this.RadioAudio.Text = "Audio";
        this.Controls.Add(RadioAudio);
        this.RadioAudio.AutoSize = true;
        this.RadioAudio.Checked = false;
        this.RadioAudio.Top = 65;
        this.RadioAudio.Left = 100;
        this.RadioAudio.Click += new System.EventHandler(SetFormat);

        // * Error Text Label
        this.LabelError = new System.Windows.Forms.Label();
        this.LabelError.Text = "";
        this.Controls.Add(LabelError);
        this.LabelError.Font = new Font("Roboto", 10);
        this.LabelError.AutoSize = true;
        this.LabelError.ForeColor = Color.DarkRed;
        this.LabelError.Top = 95;
        this.LabelError.Left = 10;

        // * Downloading Text Label
        this.Downloading = new System.Windows.Forms.Label();
        this.Downloading.Text = "";
        this.Controls.Add(Downloading);
        this.Downloading.Font = new Font("Roboto", 10);
        this.Downloading.AutoSize = true;
        this.Downloading.ForeColor = Color.FromArgb(50, 150, 50);
        this.Downloading.Top = 115;
        this.Downloading.Left = 10;


        // * Download Confirmation and Location
        this.DownloadLocation = new System.Windows.Forms.Label();
        this.DownloadLocation.Text = "";
        this.Controls.Add(DownloadLocation);
        this.DownloadLocation.Font = new Font("Roboto", 10);
        this.DownloadLocation.AutoSize = true;
        this.DownloadLocation.ForeColor = Color.FromArgb(50, 150, 50);
        this.DownloadLocation.Top = 115;
        this.DownloadLocation.Left = 10;

        // * Video Title Text
        this.VideoTitle = new System.Windows.Forms.Label();
        this.VideoTitle.Text = "";
        this.Controls.Add(VideoTitle);
        this.VideoTitle.Font = new Font("Roboto", 10);
        this.VideoTitle.AutoSize = true;
        this.VideoTitle.ForeColor = Color.Black;
        this.VideoTitle.Top = 140;
        this.VideoTitle.Left = 10;

        // * Video Author Text
        this.VideoAuthor = new System.Windows.Forms.Label();
        this.VideoAuthor.Text = "";
        this.Controls.Add(VideoAuthor);
        this.VideoAuthor.Font = new Font("Roboto", 10);
        this.VideoAuthor.AutoSize = true;
        this.VideoAuthor.ForeColor = Color.FromArgb(48,48,48);
        this.VideoAuthor.Top = 160;
        this.VideoAuthor.Left = 10;

        // * Video Duration Text
        this.VideoDuration = new System.Windows.Forms.Label();
        this.VideoDuration.Text = "";
        this.Controls.Add(VideoDuration);
        this.VideoDuration.Font = new Font("Roboto", 10);
        this.VideoDuration.AutoSize = true;
        this.VideoDuration.ForeColor = Color.FromArgb(48,48,48);
        this.VideoDuration.Top = 180;
        this.VideoDuration.Left = 10;
    }

    private void ButtonUrl_Click(object sender, System.EventArgs e)
    {
        // Checks if a download is already running
        if(this.Downloading.Text != ""){ return; }

        ClearDownloadInfo();                            // Clears any Download Info Displayed

        // Checks if the URL is Invalid
        if(this.InputUrl.Text == "" || !this.InputUrl.Text.Contains("watch?v="))
        { 
            DisplayErrorMessage("• Invalid URL x_x", 2500);
            return; 
        }

        // Select folder dialog
        FolderBrowserDialog fbd = new FolderBrowserDialog();
        fbd.ShowNewFolderButton = true; // Alows user to create a new folder on the spot
        DialogResult result = fbd.ShowDialog();

        // Checks if a folder was not selected
        if(result != DialogResult.OK)
        { 
            DisplayErrorMessage("• Please, remember to select a destination folder ", 3500);
            return; 
        }

        this.Downloading.Text = "• Downloading...";         // Displays "Downloading" Label

        string folderPath = fbd.SelectedPath;               // Selected Folder Path
        var youtube = YouTube.Default;                      // Starting point for YouTube Actions
        var video = youtube.GetVideo(this.InputUrl.Text);   // Gets a Video Object with Info about the video

        // Configures filePath
        string randKey = new Random().Next(1, 200).ToString();
        string fileName = video.FullName.Split(" ")[0] + "_" + randKey + this.format;
        string filePath = Path.Combine(folderPath, fileName);

        File.WriteAllBytes(filePath, video.GetBytes());     // Downloads video at filePath
        this.Downloading.Text = "";                         // Resets Downloading Label
        this.InputUrl.Text = "";                            // Resets URL Input
        DisplayDownloadInfo(video, filePath);               // Display download information at Client
    }

    private async void DisplayErrorMessage(string error, int timeout)
    {
        this.LabelError.Text = error;
        await Task.Delay(timeout);
        this.LabelError.Text = "";
    }

    private void DisplayDownloadInfo(YouTubeVideo video, string path)
    {
        this.DownloadLocation.Text = "✓ Download Complete at " + path;
        this.VideoTitle.Text = "• " + video.Title;
        this.VideoAuthor.Text = "• " + video.Info.Author;
        this.VideoDuration.Text = "• " + video.Info.LengthSeconds/60 + ":" + video.Info.LengthSeconds%60;
    }

    private void ClearDownloadInfo()
    {
        this.DownloadLocation.Text = "";
        this.VideoTitle.Text = "";
        this.VideoAuthor.Text = "";
        this.VideoDuration.Text = "";
    }

    private void SetFormat(object sender, System.EventArgs e)
    {
        if(this.RadioVideo.Checked){ this.format = ".mp4"; }
        else{ this.format = ".mp3"; }  
    }

    #endregion
}
