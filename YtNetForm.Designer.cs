namespace ytnet;

partial class YtNetForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    // * Test Button Declaration
    private System.Windows.Forms.Button TestButton { get; set; }

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(800, 450);
        this.Text = "YtNet - Youtube Downloader";

        // * Test Button Instatiating
        this.TestButton = new System.Windows.Forms.Button();

        // * Test Button Property Change
        this.TestButton.Text = "Test Me";

        // * Test Button Event Handler assign
        this.TestButton.Click += new System.EventHandler(TestButton_Click);

        // * Add button to the Control ControlCollection
        this.Controls.Add(this.TestButton);
    }

    // * Test Button Event Handler
    private void TestButton_Click(object sender, System.EventArgs e)
    {
        if(this.TestButton.BackColor == Color.FromArgb(255, 0, 0))
            this.TestButton.BackColor = Color.FromArgb(255, 255, 255);
        else
            this.TestButton.BackColor = Color.FromArgb(255, 0, 0);

    }

    #endregion
}
