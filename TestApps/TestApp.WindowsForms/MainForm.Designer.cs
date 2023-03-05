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

namespace TestApp.WindowsForms
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
            this.btnAddAllEvents = new System.Windows.Forms.Button();
            this.lblText = new System.Windows.Forms.Label();
            this.btnAddEvent = new System.Windows.Forms.Button();
            this.lblType = new System.Windows.Forms.Label();
            this.txtEventText = new System.Windows.Forms.TextBox();
            this.comboEventType = new System.Windows.Forms.ComboBox();
            this.radioCustomText = new System.Windows.Forms.RadioButton();
            this.radioDefaultText = new System.Windows.Forms.RadioButton();
            this.groupAddEvent.SuspendLayout();
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
            this.groupAddEvent.Location = new System.Drawing.Point(12, 12);
            this.groupAddEvent.Name = "groupAddEvent";
            this.groupAddEvent.Size = new System.Drawing.Size(468, 138);
            this.groupAddEvent.TabIndex = 0;
            this.groupAddEvent.TabStop = false;
            this.groupAddEvent.Text = " Add Event ";
            // 
            // btnAddAllEvents
            // 
            this.btnAddAllEvents.Location = new System.Drawing.Point(362, 64);
            this.btnAddAllEvents.Name = "btnAddAllEvents";
            this.btnAddAllEvents.Size = new System.Drawing.Size(100, 40);
            this.btnAddAllEvents.TabIndex = 1;
            this.btnAddAllEvents.Text = "Add all Event Types";
            this.btnAddAllEvents.Click += new System.EventHandler(this.BtnAddAllEventsClick);
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Location = new System.Drawing.Point(11, 122);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(31, 13);
            this.lblText.TabIndex = 5;
            this.lblText.Text = "Text:";
            // 
            // btnAddEvent
            // 
            this.btnAddEvent.Location = new System.Drawing.Point(362, 18);
            this.btnAddEvent.Name = "btnAddEvent";
            this.btnAddEvent.Size = new System.Drawing.Size(100, 40);
            this.btnAddEvent.TabIndex = 8;
            this.btnAddEvent.Text = "Add Events";
            this.btnAddEvent.Click += new System.EventHandler(this.BtnAddEventClick);
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(8, 21);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(34, 13);
            this.lblType.TabIndex = 7;
            this.lblType.Text = "Type:";
            // 
            // txtEventText
            // 
            this.txtEventText.Location = new System.Drawing.Point(83, 112);
            this.txtEventText.Name = "txtEventText";
            this.txtEventText.Size = new System.Drawing.Size(100, 20);
            this.txtEventText.TabIndex = 4;
            // 
            // comboEventType
            // 
            this.comboEventType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboEventType.Location = new System.Drawing.Point(48, 18);
            this.comboEventType.Name = "comboEventType";
            this.comboEventType.Size = new System.Drawing.Size(121, 21);
            this.comboEventType.TabIndex = 6;
            // 
            // radioCustomText
            // 
            this.radioCustomText.Location = new System.Drawing.Point(11, 75);
            this.radioCustomText.Name = "radioCustomText";
            this.radioCustomText.Size = new System.Drawing.Size(149, 24);
            this.radioCustomText.TabIndex = 2;
            this.radioCustomText.TabStop = true;
            this.radioCustomText.Text = "User defined event text:";
            this.radioCustomText.UseVisualStyleBackColor = true;
            // 
            // radioDefaultText
            // 
            this.radioDefaultText.Location = new System.Drawing.Point(11, 45);
            this.radioDefaultText.Name = "radioDefaultText";
            this.radioDefaultText.Size = new System.Drawing.Size(104, 24);
            this.radioDefaultText.TabIndex = 3;
            this.radioDefaultText.TabStop = true;
            this.radioDefaultText.Text = "Use default text";
            this.radioDefaultText.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 170);
            this.Controls.Add(this.groupAddEvent);
            this.Name = "MainForm";
            this.Text = "Tethys.Logging TestApp for WinForms";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
            this.Load += new System.EventHandler(this.MainFormLoad);
            this.groupAddEvent.ResumeLayout(false);
            this.groupAddEvent.PerformLayout();
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
    }
}

