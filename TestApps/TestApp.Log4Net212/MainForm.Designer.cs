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

namespace TestApp.Log4Net212
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      this.tabControl = new System.Windows.Forms.TabControl();
      this.tabPageRtf = new System.Windows.Forms.TabPage();
      this.groupControlRtf = new System.Windows.Forms.GroupBox();
      this.simpleRtfLogView = new Tethys.Logging.Controls.RtfLogView();
      this.groupPropertiesRtf = new System.Windows.Forms.GroupBox();
      this.propertyGridRtf = new System.Windows.Forms.PropertyGrid();
      this.tabPageTable = new System.Windows.Forms.TabPage();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.tableLogView = new Tethys.Logging.Controls.TableLogView();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.propertyGridTable = new System.Windows.Forms.PropertyGrid();
      this.tabPageLogForm = new System.Windows.Forms.TabPage();
      this.checkShowDebugLogForm = new System.Windows.Forms.CheckBox();
      this.groupAddEvent = new System.Windows.Forms.GroupBox();
      this.lblLanguage = new System.Windows.Forms.Label();
      this.btnAddAllEvents = new System.Windows.Forms.Button();
      this.radioCustomText = new System.Windows.Forms.RadioButton();
      this.radioDefaultText = new System.Windows.Forms.RadioButton();
      this.txtEventText = new System.Windows.Forms.TextBox();
      this.lblText = new System.Windows.Forms.Label();
      this.comboEventType = new System.Windows.Forms.ComboBox();
      this.lblType = new System.Windows.Forms.Label();
      this.btnAddEvent = new System.Windows.Forms.Button();
      this.tabControl.SuspendLayout();
      this.tabPageRtf.SuspendLayout();
      this.groupControlRtf.SuspendLayout();
      this.groupPropertiesRtf.SuspendLayout();
      this.tabPageTable.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.tabPageLogForm.SuspendLayout();
      this.groupAddEvent.SuspendLayout();
      this.SuspendLayout();
      // 
      // tabControl
      // 
      resources.ApplyResources(this.tabControl, "tabControl");
      this.tabControl.Controls.Add(this.tabPageRtf);
      this.tabControl.Controls.Add(this.tabPageTable);
      this.tabControl.Controls.Add(this.tabPageLogForm);
      this.tabControl.Name = "tabControl";
      this.tabControl.SelectedIndex = 0;
      // 
      // tabPageRtf
      // 
      resources.ApplyResources(this.tabPageRtf, "tabPageRtf");
      this.tabPageRtf.BackColor = System.Drawing.Color.Transparent;
      this.tabPageRtf.Controls.Add(this.groupControlRtf);
      this.tabPageRtf.Controls.Add(this.groupPropertiesRtf);
      this.tabPageRtf.Name = "tabPageRtf";
      this.tabPageRtf.UseVisualStyleBackColor = true;
      // 
      // groupControlRtf
      // 
      resources.ApplyResources(this.groupControlRtf, "groupControlRtf");
      this.groupControlRtf.Controls.Add(this.simpleRtfLogView);
      this.groupControlRtf.Name = "groupControlRtf";
      this.groupControlRtf.TabStop = false;
      // 
      // simpleRtfLogView
      // 
      resources.ApplyResources(this.simpleRtfLogView, "simpleRtfLogView");
      this.simpleRtfLogView.AddAtTail = true;
      this.simpleRtfLogView.LabelText = "Status:";
      this.simpleRtfLogView.MaxLogLength = -1;
      this.simpleRtfLogView.Name = "simpleRtfLogView";
      this.simpleRtfLogView.ShowDebugEvents = false;
      this.simpleRtfLogView.TextColor = System.Drawing.Color.Black;
      // 
      // groupPropertiesRtf
      // 
      resources.ApplyResources(this.groupPropertiesRtf, "groupPropertiesRtf");
      this.groupPropertiesRtf.Controls.Add(this.propertyGridRtf);
      this.groupPropertiesRtf.Name = "groupPropertiesRtf";
      this.groupPropertiesRtf.TabStop = false;
      // 
      // propertyGridRtf
      // 
      resources.ApplyResources(this.propertyGridRtf, "propertyGridRtf");
      this.propertyGridRtf.LineColor = System.Drawing.SystemColors.ScrollBar;
      this.propertyGridRtf.Name = "propertyGridRtf";
      // 
      // tabPageTable
      // 
      resources.ApplyResources(this.tabPageTable, "tabPageTable");
      this.tabPageTable.BackColor = System.Drawing.Color.Transparent;
      this.tabPageTable.Controls.Add(this.groupBox2);
      this.tabPageTable.Controls.Add(this.groupBox1);
      this.tabPageTable.Name = "tabPageTable";
      this.tabPageTable.UseVisualStyleBackColor = true;
      // 
      // groupBox2
      // 
      resources.ApplyResources(this.groupBox2, "groupBox2");
      this.groupBox2.Controls.Add(this.tableLogView);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.TabStop = false;
      // 
      // tableLogView
      // 
      resources.ApplyResources(this.tableLogView, "tableLogView");
      this.tableLogView.AddAtTail = true;
      this.tableLogView.CategoryColumnHeader = "Kategorie";
      this.tableLogView.ColumnCategory = true;
      this.tableLogView.ColumnDate = true;
      this.tableLogView.ColumnTime = true;
      this.tableLogView.Culture = new System.Globalization.CultureInfo("de-DE");
      this.tableLogView.DateColumnHeader = "Datum";
      this.tableLogView.MaxLogEntries = -1;
      this.tableLogView.MessageColumnHeader = "Ereignistext";
      this.tableLogView.Name = "tableLogView";
      this.tableLogView.ShowCategoryButtons = true;
      this.tableLogView.ShowDebugButtonText = "Debug";
      this.tableLogView.ShowErrorButtonText = "Fehler";
      this.tableLogView.ShowInfoButtonText = "Info";
      this.tableLogView.ShowToolButtons = true;
      this.tableLogView.ShowWarningButtonText = "Warnungen";
      this.tableLogView.TimeColumnHeader = "Zeit";
      // 
      // groupBox1
      // 
      resources.ApplyResources(this.groupBox1, "groupBox1");
      this.groupBox1.Controls.Add(this.propertyGridTable);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.TabStop = false;
      // 
      // propertyGridTable
      // 
      resources.ApplyResources(this.propertyGridTable, "propertyGridTable");
      this.propertyGridTable.LineColor = System.Drawing.SystemColors.ScrollBar;
      this.propertyGridTable.Name = "propertyGridTable";
      // 
      // tabPageLogForm
      // 
      resources.ApplyResources(this.tabPageLogForm, "tabPageLogForm");
      this.tabPageLogForm.BackColor = System.Drawing.SystemColors.Control;
      this.tabPageLogForm.Controls.Add(this.checkShowDebugLogForm);
      this.tabPageLogForm.Name = "tabPageLogForm";
      // 
      // checkShowDebugLogForm
      // 
      resources.ApplyResources(this.checkShowDebugLogForm, "checkShowDebugLogForm");
      this.checkShowDebugLogForm.Name = "checkShowDebugLogForm";
      this.checkShowDebugLogForm.UseVisualStyleBackColor = true;
      this.checkShowDebugLogForm.CheckedChanged += new System.EventHandler(this.CheckShowDebugLogFormCheckedChanged);
      // 
      // groupAddEvent
      // 
      resources.ApplyResources(this.groupAddEvent, "groupAddEvent");
      this.groupAddEvent.Controls.Add(this.lblLanguage);
      this.groupAddEvent.Controls.Add(this.btnAddAllEvents);
      this.groupAddEvent.Controls.Add(this.radioCustomText);
      this.groupAddEvent.Controls.Add(this.radioDefaultText);
      this.groupAddEvent.Controls.Add(this.txtEventText);
      this.groupAddEvent.Controls.Add(this.lblText);
      this.groupAddEvent.Controls.Add(this.comboEventType);
      this.groupAddEvent.Controls.Add(this.lblType);
      this.groupAddEvent.Controls.Add(this.btnAddEvent);
      this.groupAddEvent.Name = "groupAddEvent";
      this.groupAddEvent.TabStop = false;
      // 
      // lblLanguage
      // 
      resources.ApplyResources(this.lblLanguage, "lblLanguage");
      this.lblLanguage.Name = "lblLanguage";
      // 
      // btnAddAllEvents
      // 
      resources.ApplyResources(this.btnAddAllEvents, "btnAddAllEvents");
      this.btnAddAllEvents.Name = "btnAddAllEvents";
      this.btnAddAllEvents.Click += new System.EventHandler(this.BtnAddAllEventsClick);
      // 
      // radioCustomText
      // 
      resources.ApplyResources(this.radioCustomText, "radioCustomText");
      this.radioCustomText.Name = "radioCustomText";
      this.radioCustomText.TabStop = true;
      this.radioCustomText.UseVisualStyleBackColor = true;
      // 
      // radioDefaultText
      // 
      resources.ApplyResources(this.radioDefaultText, "radioDefaultText");
      this.radioDefaultText.Name = "radioDefaultText";
      this.radioDefaultText.TabStop = true;
      this.radioDefaultText.UseVisualStyleBackColor = true;
      // 
      // txtEventText
      // 
      resources.ApplyResources(this.txtEventText, "txtEventText");
      this.txtEventText.Name = "txtEventText";
      // 
      // lblText
      // 
      resources.ApplyResources(this.lblText, "lblText");
      this.lblText.Name = "lblText";
      // 
      // comboEventType
      // 
      resources.ApplyResources(this.comboEventType, "comboEventType");
      this.comboEventType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
      this.comboEventType.Name = "comboEventType";
      // 
      // lblType
      // 
      resources.ApplyResources(this.lblType, "lblType");
      this.lblType.Name = "lblType";
      // 
      // btnAddEvent
      // 
      resources.ApplyResources(this.btnAddEvent, "btnAddEvent");
      this.btnAddEvent.Name = "btnAddEvent";
      this.btnAddEvent.Click += new System.EventHandler(this.BtnAddEventClick);
      // 
      // MainForm
      // 
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.groupAddEvent);
      this.Controls.Add(this.tabControl);
      this.Name = "MainForm";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
      this.Load += new System.EventHandler(this.MainFormLoad);
      this.tabControl.ResumeLayout(false);
      this.tabPageRtf.ResumeLayout(false);
      this.groupControlRtf.ResumeLayout(false);
      this.groupPropertiesRtf.ResumeLayout(false);
      this.tabPageTable.ResumeLayout(false);
      this.groupBox2.ResumeLayout(false);
      this.groupBox1.ResumeLayout(false);
      this.tabPageLogForm.ResumeLayout(false);
      this.tabPageLogForm.PerformLayout();
      this.groupAddEvent.ResumeLayout(false);
      this.groupAddEvent.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.TabControl tabControl;
    private System.Windows.Forms.TabPage tabPageRtf;
    private System.Windows.Forms.TabPage tabPageTable;
    private System.Windows.Forms.TabPage tabPageLogForm;
    private System.Windows.Forms.GroupBox groupPropertiesRtf;
    private System.Windows.Forms.GroupBox groupControlRtf;
    private System.Windows.Forms.PropertyGrid propertyGridRtf;
    private System.Windows.Forms.GroupBox groupAddEvent;
    private System.Windows.Forms.Button btnAddAllEvents;
    private System.Windows.Forms.RadioButton radioCustomText;
    private System.Windows.Forms.RadioButton radioDefaultText;
    private System.Windows.Forms.TextBox txtEventText;
    private System.Windows.Forms.Label lblText;
    private System.Windows.Forms.ComboBox comboEventType;
    private System.Windows.Forms.Label lblType;
    private System.Windows.Forms.Button btnAddEvent;
    private Tethys.Logging.Controls.RtfLogView simpleRtfLogView;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.PropertyGrid propertyGridTable;
    private Tethys.Logging.Controls.TableLogView tableLogView;
    private System.Windows.Forms.CheckBox checkShowDebugLogForm;
    private System.Windows.Forms.Label lblLanguage;
  }
}

