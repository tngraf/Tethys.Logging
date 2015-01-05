namespace Tethys.Logging.Controls
{
  sealed partial class TableLogView
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components;

    #region Component Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TableLogView));
      this.listView = new System.Windows.Forms.ListView();
      this.imageList = new System.Windows.Forms.ImageList(this.components);
      this.checkShowDebug = new System.Windows.Forms.CheckBox();
      this.checkShowInfo = new System.Windows.Forms.CheckBox();
      this.checkShowWarnings = new System.Windows.Forms.CheckBox();
      this.btnExportExcel = new System.Windows.Forms.Button();
      this.btnSave = new System.Windows.Forms.Button();
      this.btnCopy = new System.Windows.Forms.Button();
      this.checkShowErrors = new System.Windows.Forms.CheckBox();
      this.btnClear = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // listView
      // 
      this.listView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.listView.FullRowSelect = true;
      this.listView.GridLines = true;
      this.listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
      this.listView.Location = new System.Drawing.Point(0, 30);
      this.listView.Margin = new System.Windows.Forms.Padding(4);
      this.listView.MultiSelect = false;
      this.listView.Name = "listView";
      this.listView.Size = new System.Drawing.Size(685, 208);
      this.listView.SmallImageList = this.imageList;
      this.listView.TabIndex = 0;
      this.listView.UseCompatibleStateImageBehavior = false;
      this.listView.View = System.Windows.Forms.View.Details;
      this.listView.Resize += new System.EventHandler(this.ListViewResize);
      // 
      // imageList
      // 
      this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
      this.imageList.TransparentColor = System.Drawing.Color.Magenta;
      this.imageList.Images.SetKeyName(0, "");
      this.imageList.Images.SetKeyName(1, "");
      this.imageList.Images.SetKeyName(2, "");
      this.imageList.Images.SetKeyName(3, "");
      this.imageList.Images.SetKeyName(4, "");
      this.imageList.Images.SetKeyName(5, "");
      this.imageList.Images.SetKeyName(6, "");
      this.imageList.Images.SetKeyName(7, "");
      this.imageList.Images.SetKeyName(8, "");
      this.imageList.Images.SetKeyName(9, "Copy_modern.png");
      this.imageList.Images.SetKeyName(10, "Paste_modern.png");
      this.imageList.Images.SetKeyName(11, "Delete_modern.png");
      // 
      // checkShowDebug
      // 
      this.checkShowDebug.Appearance = System.Windows.Forms.Appearance.Button;
      this.checkShowDebug.Checked = true;
      this.checkShowDebug.CheckState = System.Windows.Forms.CheckState.Checked;
      this.checkShowDebug.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.checkShowDebug.ImageIndex = 3;
      this.checkShowDebug.ImageList = this.imageList;
      this.checkShowDebug.Location = new System.Drawing.Point(360, 0);
      this.checkShowDebug.Margin = new System.Windows.Forms.Padding(4);
      this.checkShowDebug.Name = "checkShowDebug";
      this.checkShowDebug.Size = new System.Drawing.Size(120, 30);
      this.checkShowDebug.TabIndex = 29;
      this.checkShowDebug.Text = "Debug";
      this.checkShowDebug.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // checkShowInfo
      // 
      this.checkShowInfo.Appearance = System.Windows.Forms.Appearance.Button;
      this.checkShowInfo.Checked = true;
      this.checkShowInfo.CheckState = System.Windows.Forms.CheckState.Checked;
      this.checkShowInfo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.checkShowInfo.ImageIndex = 0;
      this.checkShowInfo.ImageList = this.imageList;
      this.checkShowInfo.Location = new System.Drawing.Point(240, 0);
      this.checkShowInfo.Margin = new System.Windows.Forms.Padding(4);
      this.checkShowInfo.Name = "checkShowInfo";
      this.checkShowInfo.Size = new System.Drawing.Size(120, 30);
      this.checkShowInfo.TabIndex = 28;
      this.checkShowInfo.Text = "Info";
      this.checkShowInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // checkShowWarnings
      // 
      this.checkShowWarnings.Appearance = System.Windows.Forms.Appearance.Button;
      this.checkShowWarnings.Checked = true;
      this.checkShowWarnings.CheckState = System.Windows.Forms.CheckState.Checked;
      this.checkShowWarnings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.checkShowWarnings.ImageIndex = 4;
      this.checkShowWarnings.ImageList = this.imageList;
      this.checkShowWarnings.Location = new System.Drawing.Point(120, 0);
      this.checkShowWarnings.Margin = new System.Windows.Forms.Padding(4);
      this.checkShowWarnings.Name = "checkShowWarnings";
      this.checkShowWarnings.Size = new System.Drawing.Size(120, 30);
      this.checkShowWarnings.TabIndex = 27;
      this.checkShowWarnings.Text = "Warnings";
      this.checkShowWarnings.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // btnExportExcel
      // 
      this.btnExportExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnExportExcel.ImageIndex = 8;
      this.btnExportExcel.ImageList = this.imageList;
      this.btnExportExcel.Location = new System.Drawing.Point(655, 0);
      this.btnExportExcel.Margin = new System.Windows.Forms.Padding(4);
      this.btnExportExcel.Name = "btnExportExcel";
      this.btnExportExcel.Size = new System.Drawing.Size(32, 28);
      this.btnExportExcel.TabIndex = 26;
      this.btnExportExcel.Click += new System.EventHandler(this.BtnExportExcelClick);
      // 
      // btnSave
      // 
      this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnSave.ImageIndex = 5;
      this.btnSave.ImageList = this.imageList;
      this.btnSave.Location = new System.Drawing.Point(623, 0);
      this.btnSave.Margin = new System.Windows.Forms.Padding(4);
      this.btnSave.Name = "btnSave";
      this.btnSave.Size = new System.Drawing.Size(32, 28);
      this.btnSave.TabIndex = 25;
      this.btnSave.Click += new System.EventHandler(this.BtnSaveClick);
      // 
      // btnCopy
      // 
      this.btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnCopy.ImageIndex = 9;
      this.btnCopy.ImageList = this.imageList;
      this.btnCopy.Location = new System.Drawing.Point(591, 0);
      this.btnCopy.Margin = new System.Windows.Forms.Padding(4);
      this.btnCopy.Name = "btnCopy";
      this.btnCopy.Size = new System.Drawing.Size(32, 28);
      this.btnCopy.TabIndex = 24;
      this.btnCopy.Click += new System.EventHandler(this.BtnCopyClick);
      // 
      // checkShowErrors
      // 
      this.checkShowErrors.Appearance = System.Windows.Forms.Appearance.Button;
      this.checkShowErrors.Checked = true;
      this.checkShowErrors.CheckState = System.Windows.Forms.CheckState.Checked;
      this.checkShowErrors.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.checkShowErrors.ImageIndex = 1;
      this.checkShowErrors.ImageList = this.imageList;
      this.checkShowErrors.Location = new System.Drawing.Point(0, 0);
      this.checkShowErrors.Margin = new System.Windows.Forms.Padding(4);
      this.checkShowErrors.Name = "checkShowErrors";
      this.checkShowErrors.Size = new System.Drawing.Size(120, 30);
      this.checkShowErrors.TabIndex = 23;
      this.checkShowErrors.Text = "Errors";
      this.checkShowErrors.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // btnClear
      // 
      this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnClear.ImageIndex = 11;
      this.btnClear.ImageList = this.imageList;
      this.btnClear.Location = new System.Drawing.Point(559, 0);
      this.btnClear.Margin = new System.Windows.Forms.Padding(4);
      this.btnClear.Name = "btnClear";
      this.btnClear.Size = new System.Drawing.Size(32, 28);
      this.btnClear.TabIndex = 22;
      this.btnClear.Click += new System.EventHandler(this.BtnClearClick);
      // 
      // TableLogView
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.checkShowDebug);
      this.Controls.Add(this.checkShowInfo);
      this.Controls.Add(this.checkShowWarnings);
      this.Controls.Add(this.btnExportExcel);
      this.Controls.Add(this.btnSave);
      this.Controls.Add(this.btnCopy);
      this.Controls.Add(this.checkShowErrors);
      this.Controls.Add(this.btnClear);
      this.Controls.Add(this.listView);
      this.Margin = new System.Windows.Forms.Padding(4);
      this.Name = "TableLogView";
      this.Size = new System.Drawing.Size(686, 239);
      this.Resize += new System.EventHandler(this.TableLogView_Resize);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ListView listView;
    private System.Windows.Forms.CheckBox checkShowDebug;
    private System.Windows.Forms.CheckBox checkShowInfo;
    private System.Windows.Forms.CheckBox checkShowWarnings;
    private System.Windows.Forms.Button btnExportExcel;
    private System.Windows.Forms.Button btnSave;
    private System.Windows.Forms.Button btnCopy;
    private System.Windows.Forms.CheckBox checkShowErrors;
    private System.Windows.Forms.Button btnClear;
    private System.Windows.Forms.ImageList imageList;

  }
}
