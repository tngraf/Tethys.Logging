namespace Tethys.Logging.Controls
{
  partial class RtfLogView
  {
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Clean up any resources being used.
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RtfLogView));
      this.rtfView = new System.Windows.Forms.RichTextBox();
      this.btnSave = new System.Windows.Forms.Button();
      this.imageList = new System.Windows.Forms.ImageList(this.components);
      this.btnCopy = new System.Windows.Forms.Button();
      this.btnClear = new System.Windows.Forms.Button();
      this.lblStatus = new System.Windows.Forms.Label();
      this.checkDebug = new System.Windows.Forms.CheckBox();
      this.SuspendLayout();
      // 
      // rtfView
      // 
      this.rtfView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.rtfView.Location = new System.Drawing.Point(0, 31);
      this.rtfView.Margin = new System.Windows.Forms.Padding(4);
      this.rtfView.Name = "rtfView";
      this.rtfView.Size = new System.Drawing.Size(620, 237);
      this.rtfView.TabIndex = 0;
      this.rtfView.Text = "";
      // 
      // btnSave
      // 
      this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnSave.ImageIndex = 0;
      this.btnSave.ImageList = this.imageList;
      this.btnSave.Location = new System.Drawing.Point(588, 1);
      this.btnSave.Margin = new System.Windows.Forms.Padding(4);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new System.Drawing.Size(32, 28);
      this.btnSave.TabIndex = 27;
      this.btnSave.Click += new System.EventHandler(this.BtnSaveClick);
      // 
      // imageList
      // 
      this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
      this.imageList.TransparentColor = System.Drawing.Color.Transparent;
      this.imageList.Images.SetKeyName(0, "Save");
      this.imageList.Images.SetKeyName(1, "Copy");
      this.imageList.Images.SetKeyName(2, "Cut");
      this.imageList.Images.SetKeyName(3, "ClearAll.png");
      this.imageList.Images.SetKeyName(4, "Filter");
      this.imageList.Images.SetKeyName(5, "Paste");
      // 
      // btnCopy
      // 
      this.btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnCopy.ImageIndex = 1;
      this.btnCopy.ImageList = this.imageList;
      this.btnCopy.Location = new System.Drawing.Point(556, 1);
      this.btnCopy.Margin = new System.Windows.Forms.Padding(4);
      this.btnCopy.Name = "btnCopy";
      this.btnCopy.Size = new System.Drawing.Size(32, 28);
      this.btnCopy.TabIndex = 26;
      this.btnCopy.Click += new System.EventHandler(this.BtnCopyClick);
      // 
      // btnClear
      // 
      this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnClear.ImageIndex = 3;
      this.btnClear.ImageList = this.imageList;
      this.btnClear.Location = new System.Drawing.Point(524, 1);
      this.btnClear.Margin = new System.Windows.Forms.Padding(4);
      this.btnClear.Name = "btnClear";
      this.btnClear.Size = new System.Drawing.Size(32, 28);
      this.btnClear.TabIndex = 25;
      this.btnClear.Click += new System.EventHandler(this.BtnClearClick);
      // 
      // lblStatus
      // 
      this.lblStatus.AutoSize = true;
      this.lblStatus.Location = new System.Drawing.Point(4, 7);
      this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblStatus.Name = "lblStatus";
      this.lblStatus.Size = new System.Drawing.Size(52, 17);
      this.lblStatus.TabIndex = 28;
      this.lblStatus.Text = "Status:";
      // 
      // checkDebug
      // 
      this.checkDebug.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.checkDebug.AutoSize = true;
      this.checkDebug.Location = new System.Drawing.Point(336, 6);
      this.checkDebug.Margin = new System.Windows.Forms.Padding(4);
      this.checkDebug.Name = "checkDebug";
      this.checkDebug.Size = new System.Drawing.Size(178, 21);
      this.checkDebug.TabIndex = 29;
      this.checkDebug.Text = "Show Debug messages";
      this.checkDebug.UseVisualStyleBackColor = true;
      this.checkDebug.CheckedChanged += new System.EventHandler(this.OnDebugCheckedChanged);
      // 
      // RtfLogView
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.checkDebug);
      this.Controls.Add(this.lblStatus);
      this.Controls.Add(this.btnSave);
      this.Controls.Add(this.btnCopy);
      this.Controls.Add(this.btnClear);
      this.Controls.Add(this.rtfView);
      this.Margin = new System.Windows.Forms.Padding(4);
      this.Name = "RtfLogView";
      this.Size = new System.Drawing.Size(621, 265);
      this.Resize += new System.EventHandler(this.RtfLogView_Resize);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.RichTextBox rtfView;
    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.Button btnCopy;
    private System.Windows.Forms.Button btnClear;
    private System.Windows.Forms.ImageList imageList;
    private System.Windows.Forms.Label lblStatus;
    private System.Windows.Forms.CheckBox checkDebug;
  }
} // Tethys.Logging.Controls
