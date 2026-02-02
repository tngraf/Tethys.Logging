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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RtfLogView));
            rtfView = new System.Windows.Forms.RichTextBox();
            btnSave = new System.Windows.Forms.Button();
            imageList = new System.Windows.Forms.ImageList(components);
            btnCopy = new System.Windows.Forms.Button();
            btnClear = new System.Windows.Forms.Button();
            lblStatus = new System.Windows.Forms.Label();
            checkDebug = new System.Windows.Forms.CheckBox();
            tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            tableLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // rtfView
            // 
            tableLayoutPanel.SetColumnSpan(rtfView, 5);
            rtfView.Dock = System.Windows.Forms.DockStyle.Fill;
            rtfView.Location = new System.Drawing.Point(4, 30);
            rtfView.Margin = new System.Windows.Forms.Padding(4, 3, 2, 3);
            rtfView.Name = "rtfView";
            rtfView.Size = new System.Drawing.Size(560, 177);
            rtfView.TabIndex = 0;
            rtfView.Text = "";
            // 
            // btnSave
            // 
            btnSave.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnSave.ImageIndex = 0;
            btnSave.ImageList = imageList;
            btnSave.Location = new System.Drawing.Point(539, 0);
            btnSave.Margin = new System.Windows.Forms.Padding(0);
            btnSave.Name = "btnSave";
            btnSave.Size = new System.Drawing.Size(27, 27);
            btnSave.TabIndex = 27;
            btnSave.Click += BtnSaveClick;
            // 
            // imageList
            // 
            imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            imageList.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("imageList.ImageStream");
            imageList.TransparentColor = System.Drawing.Color.Transparent;
            imageList.Images.SetKeyName(0, "Save");
            imageList.Images.SetKeyName(1, "Copy");
            imageList.Images.SetKeyName(2, "Cut");
            imageList.Images.SetKeyName(3, "ClearAll.png");
            imageList.Images.SetKeyName(4, "Filter");
            imageList.Images.SetKeyName(5, "Paste");
            // 
            // btnCopy
            // 
            btnCopy.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnCopy.ImageIndex = 1;
            btnCopy.ImageList = imageList;
            btnCopy.Location = new System.Drawing.Point(512, 0);
            btnCopy.Margin = new System.Windows.Forms.Padding(0);
            btnCopy.Name = "btnCopy";
            btnCopy.Size = new System.Drawing.Size(27, 27);
            btnCopy.TabIndex = 26;
            btnCopy.Click += BtnCopyClick;
            // 
            // btnClear
            // 
            btnClear.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnClear.ImageIndex = 3;
            btnClear.ImageList = imageList;
            btnClear.Location = new System.Drawing.Point(485, 0);
            btnClear.Margin = new System.Windows.Forms.Padding(0);
            btnClear.Name = "btnClear";
            btnClear.Size = new System.Drawing.Size(27, 27);
            btnClear.TabIndex = 25;
            btnClear.Click += BtnClearClick;
            // 
            // lblStatus
            // 
            lblStatus.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            lblStatus.AutoSize = true;
            lblStatus.Location = new System.Drawing.Point(4, 8);
            lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 4);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new System.Drawing.Size(42, 15);
            lblStatus.TabIndex = 28;
            lblStatus.Text = "Status:";
            // 
            // checkDebug
            // 
            checkDebug.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            checkDebug.AutoSize = true;
            checkDebug.Location = new System.Drawing.Point(309, 5);
            checkDebug.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            checkDebug.Name = "checkDebug";
            checkDebug.Size = new System.Drawing.Size(147, 19);
            checkDebug.TabIndex = 29;
            checkDebug.Text = "Show Debug messages";
            checkDebug.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 5;
            tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            tableLayoutPanel.Controls.Add(btnClear, 2, 0);
            tableLayoutPanel.Controls.Add(btnCopy, 3, 0);
            tableLayoutPanel.Controls.Add(btnSave, 4, 0);
            tableLayoutPanel.Controls.Add(rtfView, 0, 1);
            tableLayoutPanel.Controls.Add(lblStatus, 0, 0);
            tableLayoutPanel.Controls.Add(checkDebug, 1, 0);
            tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 2;
            tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tableLayoutPanel.Size = new System.Drawing.Size(566, 210);
            tableLayoutPanel.TabIndex = 30;
            // 
            // RtfLogView
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "RtfLogView";
            Size = new System.Drawing.Size(566, 210);
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtfView;
    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.Button btnCopy;
    private System.Windows.Forms.Button btnClear;
    private System.Windows.Forms.ImageList imageList;
    private System.Windows.Forms.Label lblStatus;
    private System.Windows.Forms.CheckBox checkDebug;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
    }
} // Tethys.Logging.Controls
