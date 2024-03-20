namespace SyncCloud
{
  partial class Form1
  {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

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
      label1 = new Label();
      label2 = new Label();
      textBoxCloudFolder = new TextBox();
      textBoxLocalFolder = new TextBox();
      btnBrowseCloudFolder = new Button();
      btnBrowseLocalFolder = new Button();
      label3 = new Label();
      textBoxProgress = new TextBox();
      folderBrowserDialog1 = new FolderBrowserDialog();
      btnExit = new Button();
      btnSync = new Button();
      folderBrowserDialog2 = new FolderBrowserDialog();
      SuspendLayout();
      // 
      // label1
      // 
      label1.AutoSize = true;
      label1.Font = new Font("맑은 고딕", 9F, FontStyle.Bold, GraphicsUnit.Point);
      label1.Location = new Point(17, 27);
      label1.Name = "label1";
      label1.Size = new Size(120, 25);
      label1.TabIndex = 0;
      label1.Text = "Cloud Folder";
      // 
      // label2
      // 
      label2.AutoSize = true;
      label2.Font = new Font("맑은 고딕", 9F, FontStyle.Bold, GraphicsUnit.Point);
      label2.Location = new Point(778, 27);
      label2.Name = "label2";
      label2.Size = new Size(115, 25);
      label2.TabIndex = 1;
      label2.Text = "Local Folder";
      // 
      // textBoxCloudFolder
      // 
      textBoxCloudFolder.Enabled = false;
      textBoxCloudFolder.Location = new Point(25, 69);
      textBoxCloudFolder.Name = "textBoxCloudFolder";
      textBoxCloudFolder.Size = new Size(639, 31);
      textBoxCloudFolder.TabIndex = 2;
      // 
      // textBoxLocalFolder
      // 
      textBoxLocalFolder.Enabled = false;
      textBoxLocalFolder.Location = new Point(782, 70);
      textBoxLocalFolder.Name = "textBoxLocalFolder";
      textBoxLocalFolder.Size = new Size(708, 31);
      textBoxLocalFolder.TabIndex = 3;
      // 
      // btnBrowseCloudFolder
      // 
      btnBrowseCloudFolder.Location = new Point(143, 22);
      btnBrowseCloudFolder.Name = "btnBrowseCloudFolder";
      btnBrowseCloudFolder.Size = new Size(112, 34);
      btnBrowseCloudFolder.TabIndex = 4;
      btnBrowseCloudFolder.Text = "Browse";
      btnBrowseCloudFolder.UseVisualStyleBackColor = true;
      btnBrowseCloudFolder.Click += btnBrowseCloudFolder_Click;
      // 
      // btnBrowseLocalFolder
      // 
      btnBrowseLocalFolder.Location = new Point(899, 22);
      btnBrowseLocalFolder.Name = "btnBrowseLocalFolder";
      btnBrowseLocalFolder.Size = new Size(112, 34);
      btnBrowseLocalFolder.TabIndex = 5;
      btnBrowseLocalFolder.Text = "Browse";
      btnBrowseLocalFolder.UseVisualStyleBackColor = true;
      btnBrowseLocalFolder.Click += btnBrowseLocalFolder_Click;
      // 
      // label3
      // 
      label3.AutoSize = true;
      label3.Location = new Point(25, 146);
      label3.Name = "label3";
      label3.Size = new Size(82, 25);
      label3.TabIndex = 6;
      label3.Text = "Progress";
      // 
      // textBoxProgress
      // 
      textBoxProgress.Location = new Point(27, 194);
      textBoxProgress.Multiline = true;
      textBoxProgress.Name = "textBoxProgress";
      textBoxProgress.ScrollBars = ScrollBars.Both;
      textBoxProgress.Size = new Size(1463, 234);
      textBoxProgress.TabIndex = 7;
      textBoxProgress.WordWrap = false;
      // 
      // folderBrowserDialog1
      // 
      folderBrowserDialog1.Description = "Cloud Folder Selection";
      // 
      // btnExit
      // 
      btnExit.Location = new Point(1378, 141);
      btnExit.Name = "btnExit";
      btnExit.Size = new Size(112, 34);
      btnExit.TabIndex = 8;
      btnExit.Text = "Exit";
      btnExit.UseVisualStyleBackColor = true;
      btnExit.Click += btnExit_Click;
      // 
      // btnSync
      // 
      btnSync.Location = new Point(670, 70);
      btnSync.Name = "btnSync";
      btnSync.Size = new Size(106, 34);
      btnSync.TabIndex = 9;
      btnSync.Text = "<sync>";
      btnSync.UseVisualStyleBackColor = true;
      btnSync.Click += btnSync_Click;
      // 
      // folderBrowserDialog2
      // 
      folderBrowserDialog2.Description = "Local Folder Selection";
      // 
      // Form1
      // 
      AutoScaleDimensions = new SizeF(10F, 25F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(1502, 450);
      Controls.Add(btnSync);
      Controls.Add(btnExit);
      Controls.Add(textBoxProgress);
      Controls.Add(label3);
      Controls.Add(btnBrowseLocalFolder);
      Controls.Add(btnBrowseCloudFolder);
      Controls.Add(textBoxLocalFolder);
      Controls.Add(textBoxCloudFolder);
      Controls.Add(label2);
      Controls.Add(label1);
      Name = "Form1";
      Text = "SyncCloud";
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion

    private Label label1;
    private Label label2;
    private TextBox textBoxCloudFolder;
    private TextBox textBoxLocalFolder;
    private Button btnBrowseCloudFolder;
    private Button btnBrowseLocalFolder;
    private Label label3;
    private TextBox textBoxProgress;
    private FolderBrowserDialog folderBrowserDialog1;
    private Button btnExit;
    private Button btnSync;
    private FolderBrowserDialog folderBrowserDialog2;
  }
}