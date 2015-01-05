using Tethys.Logging.Controls;

namespace TestApplication.Common.Logging.NLog
{
  partial class MainForm
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

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.groupAddEvent = new System.Windows.Forms.GroupBox();
      this.btnThreadTest = new System.Windows.Forms.Button();
      this.btnAddAllEvents = new System.Windows.Forms.Button();
      this.radioCustomText = new System.Windows.Forms.RadioButton();
      this.radioDefaultText = new System.Windows.Forms.RadioButton();
      this.txtEventText = new System.Windows.Forms.TextBox();
      this.lblText = new System.Windows.Forms.Label();
      this.comboEventType = new System.Windows.Forms.ComboBox();
      this.lblType = new System.Windows.Forms.Label();
      this.btnAddEvent = new System.Windows.Forms.Button();
      this.rtfLogView = new Tethys.Logging.Controls.RtfLogView();
      this.tableLogView = new Tethys.Logging.Controls.TableLogView();
      this.groupAddEvent.SuspendLayout();
      this.SuspendLayout();
      // 
      // groupAddEvent
      // 
      this.groupAddEvent.Controls.Add(this.btnThreadTest);
      this.groupAddEvent.Controls.Add(this.btnAddAllEvents);
      this.groupAddEvent.Controls.Add(this.radioCustomText);
      this.groupAddEvent.Controls.Add(this.radioDefaultText);
      this.groupAddEvent.Controls.Add(this.txtEventText);
      this.groupAddEvent.Controls.Add(this.lblText);
      this.groupAddEvent.Controls.Add(this.comboEventType);
      this.groupAddEvent.Controls.Add(this.lblType);
      this.groupAddEvent.Controls.Add(this.btnAddEvent);
      this.groupAddEvent.Location = new System.Drawing.Point(16, 15);
      this.groupAddEvent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.groupAddEvent.Name = "groupAddEvent";
      this.groupAddEvent.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.groupAddEvent.Size = new System.Drawing.Size(709, 164);
      this.groupAddEvent.TabIndex = 15;
      this.groupAddEvent.TabStop = false;
      this.groupAddEvent.Text = " Add Event ";
      // 
      // btnThreadTest
      // 
      this.btnThreadTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnThreadTest.Location = new System.Drawing.Point(432, 20);
      this.btnThreadTest.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.btnThreadTest.Name = "btnThreadTest";
      this.btnThreadTest.Size = new System.Drawing.Size(128, 59);
      this.btnThreadTest.TabIndex = 22;
      this.btnThreadTest.Text = "Thread-Test";
      this.btnThreadTest.Click += new System.EventHandler(this.BtnThreadTestClick);
      // 
      // btnAddAllEvents
      // 
      this.btnAddAllEvents.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnAddAllEvents.Location = new System.Drawing.Point(568, 91);
      this.btnAddAllEvents.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.btnAddAllEvents.Name = "btnAddAllEvents";
      this.btnAddAllEvents.Size = new System.Drawing.Size(128, 59);
      this.btnAddAllEvents.TabIndex = 21;
      this.btnAddAllEvents.Text = "Add All Events";
      this.btnAddAllEvents.Click += new System.EventHandler(this.BtnAddAllEventsClick);
      // 
      // radioCustomText
      // 
      this.radioCustomText.AutoSize = true;
      this.radioCustomText.Location = new System.Drawing.Point(25, 81);
      this.radioCustomText.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.radioCustomText.Name = "radioCustomText";
      this.radioCustomText.Size = new System.Drawing.Size(159, 21);
      this.radioCustomText.TabIndex = 20;
      this.radioCustomText.TabStop = true;
      this.radioCustomText.Text = "Use customized text:";
      this.radioCustomText.UseVisualStyleBackColor = true;
      this.radioCustomText.CheckedChanged += new System.EventHandler(this.CheckChanged);
      // 
      // radioDefaultText
      // 
      this.radioDefaultText.AutoSize = true;
      this.radioDefaultText.Location = new System.Drawing.Point(25, 53);
      this.radioDefaultText.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.radioDefaultText.Name = "radioDefaultText";
      this.radioDefaultText.Size = new System.Drawing.Size(127, 21);
      this.radioDefaultText.TabIndex = 19;
      this.radioDefaultText.TabStop = true;
      this.radioDefaultText.Text = "Use default text";
      this.radioDefaultText.UseVisualStyleBackColor = true;
      this.radioDefaultText.CheckedChanged += new System.EventHandler(this.CheckChanged);
      // 
      // txtEventText
      // 
      this.txtEventText.Location = new System.Drawing.Point(104, 110);
      this.txtEventText.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.txtEventText.Name = "txtEventText";
      this.txtEventText.Size = new System.Drawing.Size(308, 22);
      this.txtEventText.TabIndex = 18;
      // 
      // lblText
      // 
      this.lblText.Location = new System.Drawing.Point(51, 110);
      this.lblText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblText.Name = "lblText";
      this.lblText.Size = new System.Drawing.Size(43, 25);
      this.lblText.TabIndex = 17;
      this.lblText.Text = "Text:";
      this.lblText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // comboEventType
      // 
      this.comboEventType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.comboEventType.Location = new System.Drawing.Point(75, 20);
      this.comboEventType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.comboEventType.Name = "comboEventType";
      this.comboEventType.Size = new System.Drawing.Size(160, 24);
      this.comboEventType.TabIndex = 16;
      // 
      // lblType
      // 
      this.lblType.Location = new System.Drawing.Point(21, 20);
      this.lblType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblType.Name = "lblType";
      this.lblType.Size = new System.Drawing.Size(43, 30);
      this.lblType.TabIndex = 15;
      this.lblType.Text = "Type:";
      this.lblType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // btnAddEvent
      // 
      this.btnAddEvent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnAddEvent.Location = new System.Drawing.Point(568, 20);
      this.btnAddEvent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.btnAddEvent.Name = "btnAddEvent";
      this.btnAddEvent.Size = new System.Drawing.Size(128, 59);
      this.btnAddEvent.TabIndex = 3;
      this.btnAddEvent.Text = "Add New Event";
      this.btnAddEvent.Click += new System.EventHandler(this.BtnAddEventClick);
      // 
      // rtfLogView
      // 
      this.rtfLogView.AddAtTail = true;
      this.rtfLogView.LabelText = "Status:";
      this.rtfLogView.Location = new System.Drawing.Point(16, 188);
      this.rtfLogView.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
      this.rtfLogView.MaxLogLength = -1;
      this.rtfLogView.Name = "rtfLogView";
      this.rtfLogView.ShowDebugEvents = false;
      this.rtfLogView.Size = new System.Drawing.Size(709, 185);
      this.rtfLogView.TabIndex = 16;
      this.rtfLogView.TextColor = System.Drawing.Color.Black;
      // 
      // tableLogView
      // 
      this.tableLogView.AddAtTail = true;
      this.tableLogView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.tableLogView.CategoryColumnHeader = "Category";
      this.tableLogView.ColumnCategory = true;
      this.tableLogView.ColumnDate = true;
      this.tableLogView.ColumnTime = true;
      this.tableLogView.Culture = new System.Globalization.CultureInfo("de-DE");
      this.tableLogView.DateColumnHeader = "Date";
      this.tableLogView.Location = new System.Drawing.Point(16, 391);
      this.tableLogView.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
      this.tableLogView.MaxLogEntries = -1;
      this.tableLogView.MessageColumnHeader = "Message";
      this.tableLogView.Name = "tableLogView";
      this.tableLogView.ShowCategoryButtons = true;
      this.tableLogView.ShowDebugButtonText = "Debug";
      this.tableLogView.ShowErrorButtonText = "Errors";
      this.tableLogView.ShowInfoButtonText = "Info";
      this.tableLogView.ShowToolButtons = true;
      this.tableLogView.ShowWarningButtonText = "Warnings";
      this.tableLogView.Size = new System.Drawing.Size(709, 185);
      this.tableLogView.TabIndex = 17;
      this.tableLogView.TimeColumnHeader = "Time";
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(741, 590);
      this.Controls.Add(this.tableLogView);
      this.Controls.Add(this.rtfLogView);
      this.Controls.Add(this.groupAddEvent);
      this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
      this.Name = "MainForm";
      this.Text = "Logging Tests for NLog via Common.Logging";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
      this.Load += new System.EventHandler(this.MainFormLoad);
      this.groupAddEvent.ResumeLayout(false);
      this.groupAddEvent.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox groupAddEvent;
    private System.Windows.Forms.TextBox txtEventText;
    private System.Windows.Forms.Label lblText;
    private System.Windows.Forms.ComboBox comboEventType;
    private System.Windows.Forms.Label lblType;
    private System.Windows.Forms.Button btnAddEvent;
    private System.Windows.Forms.RadioButton radioCustomText;
    private System.Windows.Forms.RadioButton radioDefaultText;
    private System.Windows.Forms.Button btnAddAllEvents;
    private RtfLogView rtfLogView;
    private TableLogView tableLogView;
    private System.Windows.Forms.Button btnThreadTest;
  }
}

// LoggingTest

