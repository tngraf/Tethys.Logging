// -------------------------------------------------------------------------------
// <copyright file="MainForm.Designer.cs" company="Tethys">
//   Copyright (C) 2009-2023 Thomas Graf
//   All Rights Reserved.
// </copyright>
//
// Licensed under the Apache License, Version 2.0.
// Unless required by applicable law or agreed to in writing,
// software distributed under the License is distributed on an
// "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
// either express or implied.
// SPDX-License-Identifier: Apache-2.0
// -------------------------------------------------------------------------------

namespace TestApp.NLog310
{
    using Tethys.Logging.Controls;

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
      if (disposing && (this.components != null))
      {
        this.components.Dispose();
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
      this.groupAddEvent.Location = new System.Drawing.Point(12, 12);
      this.groupAddEvent.Name = "groupAddEvent";
      this.groupAddEvent.Size = new System.Drawing.Size(532, 133);
      this.groupAddEvent.TabIndex = 15;
      this.groupAddEvent.TabStop = false;
      this.groupAddEvent.Text = " Add Event ";
      // 
      // btnThreadTest
      // 
      this.btnThreadTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnThreadTest.Location = new System.Drawing.Point(324, 16);
      this.btnThreadTest.Name = "btnThreadTest";
      this.btnThreadTest.Size = new System.Drawing.Size(96, 48);
      this.btnThreadTest.TabIndex = 22;
      this.btnThreadTest.Text = "Thread-Test";
      this.btnThreadTest.Click += new System.EventHandler(this.BtnThreadTestClick);
      // 
      // btnAddAllEvents
      // 
      this.btnAddAllEvents.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnAddAllEvents.Location = new System.Drawing.Point(426, 74);
      this.btnAddAllEvents.Name = "btnAddAllEvents";
      this.btnAddAllEvents.Size = new System.Drawing.Size(96, 48);
      this.btnAddAllEvents.TabIndex = 21;
      this.btnAddAllEvents.Text = "Add All Events";
      this.btnAddAllEvents.Click += new System.EventHandler(this.BtnAddAllEventsClick);
      // 
      // radioCustomText
      // 
      this.radioCustomText.AutoSize = true;
      this.radioCustomText.Location = new System.Drawing.Point(19, 66);
      this.radioCustomText.Name = "radioCustomText";
      this.radioCustomText.Size = new System.Drawing.Size(123, 17);
      this.radioCustomText.TabIndex = 20;
      this.radioCustomText.TabStop = true;
      this.radioCustomText.Text = "Use customized text:";
      this.radioCustomText.UseVisualStyleBackColor = true;
      this.radioCustomText.CheckedChanged += new System.EventHandler(this.CheckChanged);
      // 
      // radioDefaultText
      // 
      this.radioDefaultText.AutoSize = true;
      this.radioDefaultText.Location = new System.Drawing.Point(19, 43);
      this.radioDefaultText.Name = "radioDefaultText";
      this.radioDefaultText.Size = new System.Drawing.Size(99, 17);
      this.radioDefaultText.TabIndex = 19;
      this.radioDefaultText.TabStop = true;
      this.radioDefaultText.Text = "Use default text";
      this.radioDefaultText.UseVisualStyleBackColor = true;
      this.radioDefaultText.CheckedChanged += new System.EventHandler(this.CheckChanged);
      // 
      // txtEventText
      // 
      this.txtEventText.Location = new System.Drawing.Point(78, 89);
      this.txtEventText.Name = "txtEventText";
      this.txtEventText.Size = new System.Drawing.Size(232, 20);
      this.txtEventText.TabIndex = 18;
      // 
      // lblText
      // 
      this.lblText.Location = new System.Drawing.Point(38, 89);
      this.lblText.Name = "lblText";
      this.lblText.Size = new System.Drawing.Size(32, 20);
      this.lblText.TabIndex = 17;
      this.lblText.Text = "Text:";
      this.lblText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // comboEventType
      // 
      this.comboEventType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.comboEventType.Location = new System.Drawing.Point(56, 16);
      this.comboEventType.Name = "comboEventType";
      this.comboEventType.Size = new System.Drawing.Size(121, 21);
      this.comboEventType.TabIndex = 16;
      // 
      // lblType
      // 
      this.lblType.Location = new System.Drawing.Point(16, 16);
      this.lblType.Name = "lblType";
      this.lblType.Size = new System.Drawing.Size(32, 24);
      this.lblType.TabIndex = 15;
      this.lblType.Text = "Type:";
      this.lblType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // btnAddEvent
      // 
      this.btnAddEvent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnAddEvent.Location = new System.Drawing.Point(426, 16);
      this.btnAddEvent.Name = "btnAddEvent";
      this.btnAddEvent.Size = new System.Drawing.Size(96, 48);
      this.btnAddEvent.TabIndex = 3;
      this.btnAddEvent.Text = "Add New Event";
      this.btnAddEvent.Click += new System.EventHandler(this.BtnAddEventClick);
      // 
      // rtfLogView
      // 
      this.rtfLogView.AddAtTail = true;
      this.rtfLogView.LabelText = "Status:";
      this.rtfLogView.Location = new System.Drawing.Point(12, 152);
      this.rtfLogView.Margin = new System.Windows.Forms.Padding(4);
      this.rtfLogView.MaxLogLength = -1;
      this.rtfLogView.Name = "rtfLogView";
      this.rtfLogView.ShowDebugEvents = false;
      this.rtfLogView.Size = new System.Drawing.Size(528, 150);
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
      this.tableLogView.Location = new System.Drawing.Point(12, 310);
      this.tableLogView.Margin = new System.Windows.Forms.Padding(4);
      this.tableLogView.MaxLogEntries = -1;
      this.tableLogView.MessageColumnHeader = "Message";
      this.tableLogView.Name = "tableLogView";
      this.tableLogView.ShowCategoryButtons = true;
      this.tableLogView.ShowDebugButtonText = "Debug";
      this.tableLogView.ShowErrorButtonText = "Errors";
      this.tableLogView.ShowInfoButtonText = "Info";
      this.tableLogView.ShowToolButtons = true;
      this.tableLogView.ShowWarningButtonText = "Warnings";
      this.tableLogView.Size = new System.Drawing.Size(532, 160);
      this.tableLogView.TabIndex = 17;
      this.tableLogView.TimeColumnHeader = "Time";
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(556, 479);
      this.Controls.Add(this.tableLogView);
      this.Controls.Add(this.rtfLogView);
      this.Controls.Add(this.groupAddEvent);
      this.Name = "MainForm";
      this.Text = "Logging Tests for NLog";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
      this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainFormFormClosed);
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

