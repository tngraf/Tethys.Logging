
namespace TestApp.WindowsForms.NET5
{
    partial class MainForm
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupAddEvent = new System.Windows.Forms.GroupBox();
            this.btnAddAllEvents = new System.Windows.Forms.Button();
            this.lblText = new System.Windows.Forms.Label();
            this.btnAddEvent = new System.Windows.Forms.Button();
            this.lblType = new System.Windows.Forms.Label();
            this.txtEventText = new System.Windows.Forms.TextBox();
            this.comboEventType = new System.Windows.Forms.ComboBox();
            this.radioCustomText = new System.Windows.Forms.RadioButton();
            this.radioDefaultText = new System.Windows.Forms.RadioButton();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.rtfLogView = new Tethys.Logging.Controls.RtfLogView();
            this.groupAddEvent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupAddEvent
            // 
            this.groupAddEvent.Controls.Add(this.btnAddAllEvents);
            this.groupAddEvent.Controls.Add(this.lblText);
            this.groupAddEvent.Controls.Add(this.btnAddEvent);
            this.groupAddEvent.Controls.Add(this.lblType);
            this.groupAddEvent.Controls.Add(this.txtEventText);
            this.groupAddEvent.Controls.Add(this.comboEventType);
            this.groupAddEvent.Controls.Add(this.radioCustomText);
            this.groupAddEvent.Controls.Add(this.radioDefaultText);
            this.groupAddEvent.Location = new System.Drawing.Point(4, 3);
            this.groupAddEvent.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupAddEvent.Name = "groupAddEvent";
            this.groupAddEvent.Padding = new System.Windows.Forms.Padding(5);
            this.groupAddEvent.Size = new System.Drawing.Size(560, 197);
            this.groupAddEvent.TabIndex = 0;
            this.groupAddEvent.TabStop = false;
            this.groupAddEvent.Text = " Add Event ";
            // 
            // btnAddAllEvents
            // 
            this.btnAddAllEvents.Location = new System.Drawing.Point(422, 74);
            this.btnAddAllEvents.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnAddAllEvents.Name = "btnAddAllEvents";
            this.btnAddAllEvents.Size = new System.Drawing.Size(117, 46);
            this.btnAddAllEvents.TabIndex = 1;
            this.btnAddAllEvents.Text = "Add all Event Types";
            this.btnAddAllEvents.Click += new System.EventHandler(this.BtnAddAllEventsClick);
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Location = new System.Drawing.Point(14, 143);
            this.lblText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(31, 15);
            this.lblText.TabIndex = 5;
            this.lblText.Text = "Text:";
            // 
            // btnAddEvent
            // 
            this.btnAddEvent.Location = new System.Drawing.Point(422, 21);
            this.btnAddEvent.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnAddEvent.Name = "btnAddEvent";
            this.btnAddEvent.Size = new System.Drawing.Size(117, 46);
            this.btnAddEvent.TabIndex = 8;
            this.btnAddEvent.Text = "Add Events";
            this.btnAddEvent.Click += new System.EventHandler(this.BtnAddEventClick);
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(10, 26);
            this.lblType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(34, 15);
            this.lblType.TabIndex = 7;
            this.lblType.Text = "Type:";
            // 
            // txtEventText
            // 
            this.txtEventText.Location = new System.Drawing.Point(97, 129);
            this.txtEventText.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtEventText.Name = "txtEventText";
            this.txtEventText.Size = new System.Drawing.Size(116, 23);
            this.txtEventText.TabIndex = 4;
            // 
            // comboEventType
            // 
            this.comboEventType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboEventType.Location = new System.Drawing.Point(56, 21);
            this.comboEventType.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboEventType.Name = "comboEventType";
            this.comboEventType.Size = new System.Drawing.Size(140, 23);
            this.comboEventType.TabIndex = 6;
            // 
            // radioCustomText
            // 
            this.radioCustomText.Location = new System.Drawing.Point(13, 87);
            this.radioCustomText.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radioCustomText.Name = "radioCustomText";
            this.radioCustomText.Size = new System.Drawing.Size(174, 28);
            this.radioCustomText.TabIndex = 2;
            this.radioCustomText.TabStop = true;
            this.radioCustomText.Text = "User defined event text:";
            this.radioCustomText.UseVisualStyleBackColor = true;
            // 
            // radioDefaultText
            // 
            this.radioDefaultText.Location = new System.Drawing.Point(13, 52);
            this.radioDefaultText.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radioDefaultText.Name = "radioDefaultText";
            this.radioDefaultText.Size = new System.Drawing.Size(121, 28);
            this.radioDefaultText.TabIndex = 3;
            this.radioDefaultText.TabStop = true;
            this.radioDefaultText.Text = "Use default text";
            this.radioDefaultText.UseVisualStyleBackColor = true;
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.groupAddEvent);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.rtfLogView);
            this.splitContainer.Size = new System.Drawing.Size(568, 404);
            this.splitContainer.SplitterDistance = 203;
            this.splitContainer.TabIndex = 1;
            // 
            // rtfLogView
            // 
            this.rtfLogView.AddAtTail = true;
            this.rtfLogView.LabelText = "Status:";
            this.rtfLogView.Location = new System.Drawing.Point(4, 3);
            this.rtfLogView.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.rtfLogView.MaxLogLength = -1;
            this.rtfLogView.Name = "rtfLogView";
            this.rtfLogView.Padding = new System.Windows.Forms.Padding(3);
            this.rtfLogView.ShowDebugEvents = false;
            this.rtfLogView.Size = new System.Drawing.Size(560, 191);
            this.rtfLogView.TabIndex = 0;
            this.rtfLogView.TextColor = System.Drawing.Color.Black;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 404);
            this.Controls.Add(this.splitContainer);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "MainForm";
            this.Text = "Tethys.Logging TestApp for WinForms";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
            this.Load += new System.EventHandler(this.MainFormLoad);
            this.groupAddEvent.ResumeLayout(false);
            this.groupAddEvent.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupAddEvent;
        private System.Windows.Forms.Button btnAddAllEvents;
        private System.Windows.Forms.RadioButton radioCustomText;
        private System.Windows.Forms.RadioButton radioDefaultText;
        private System.Windows.Forms.TextBox txtEventText;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.ComboBox comboEventType;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Button btnAddEvent;
        private System.Windows.Forms.SplitContainer splitContainer;
        private Tethys.Logging.Controls.RtfLogView rtfLogView;
    }
}

