// -------------------------------------------------------------------------------
// <copyright file="RtfLogView.cs" company="Tethys">
//   Copyright (C) 2009-2026 Thomas Graf
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
// ReSharper disable once CheckNamespace
namespace Tethys.Logging.Controls
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    /// <summary>
    /// User control to display logging information.
    /// </summary>
    [ComVisible(false)]
    [Description("RtfLogView control")]
    [ToolboxBitmap(typeof(RtfLogView), "RtfLogViewToolBoxBitmap")]
    public partial class RtfLogView : UserControl, ILogView
    {
        // delegate to be used in case of callbacks coming from
        // other threads

        /// <summary>
        /// Delegate to be used in case of callbacks coming from
        /// other threads.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="color">The color.</param>
        private delegate void AppendTextDelegate(string text, Color color);

        #region PRIVATE PROPERTIES
        /// <summary>
        /// Height of the toolbar.
        /// </summary>
        private const int ToolbarHeight = 25;

        /// <summary>
        /// Maximum length of a chunk.
        /// </summary>
        private const int MaxLogLengthChunk = 5000;

        /// <summary>
        /// Default color for text output.
        /// </summary>
        private Color defaultTextColor;

        /// <summary>
        /// Flag 'toolbar and caption visible'.
        /// </summary>
        private bool toolbarVisible;
        #endregion PRIVATE PROPERTIES

        //// ---------------------------------------------------------------------

        #region PUBLIC PROPERTIES
        /// <summary>
        /// Gets or sets the text color to be used for default text output.
        /// </summary>
        [Description("Text color to be used for default text output.")]
        [Category("Appearance")]
        [DefaultValue(typeof(Color), "0x000000")]
        public Color TextColor
        {
            get => this.defaultTextColor;

            set
            {
                this.defaultTextColor = value;
                this.RtfControl.SelectionColor = this.defaultTextColor;
            }
        } // TextColor

        /// <summary>
        /// Gets or sets a value indicating whether to enable the tool buttons.
        /// </summary>
        [Description("Enables/disable the tool buttons")]
        [Category("Appearance")]
        [DefaultValue(true)]
        public bool ShowToolButtons
        {
            get => this.toolbarVisible;

            set
            {
                this.toolbarVisible = value;
                this.btnClear.Visible = value;
                this.btnCopy.Visible = value;
                this.btnSave.Visible = value;
                this.btnClear.Enabled = value;
                this.btnCopy.Enabled = value;
                this.btnSave.Enabled = value;
                this.lblStatus.Visible = value;
                this.lblStatus.Enabled = value;
                this.checkDebug.Visible = value;
                this.checkDebug.Enabled = value;

                this.CheckListHeight();
            }
        } // ShowToolButtons

        /// <summary>
        /// Gets the current text in the status view.
        /// </summary>
        [Description("The text contained in the control.")]
        [Category("Appearance")]
        public override string Text => this.RtfControl.Text;

        /// <summary>
        /// Gets the underlying RichTextBox control.
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public RichTextBox RtfControl { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether new event are added at the tail or
        /// at the head of the list.
        /// </summary>
        [Description("Defines whether new event are added at the tail or "
         + "at the head of the list.")]
        [Category("Logging")]
        [DefaultValue(true)]
        public bool AddAtTail { get; set; } = true;

        /// <summary>
        /// Gets or sets the label on the upper left corner of the control.
        /// </summary>
        [Description("Log view label text.")]
        [Category("Appearance")]
        [DefaultValue("Status:")]
        public string LabelText
        {
            get => this.lblStatus.Text;
            set => this.lblStatus.Text = value;
        } // LabelText

        /// <summary>
        /// Gets or sets the max length of log text displayed.<br/>
        /// A value of -1 means no length check.
        /// </summary>
        /// <value>The length of the max log.</value>
        [Description("Gets or sets the max length of log text displayed. "
         + "A value of -1 means no length check.")]
        [Category("Logging")]
        [DefaultValue(-1)]
        public int MaxLogLength { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to enable the 'show debug' checkbox.
        /// </summary>
        [Description("Enables/disable the 'show debug' checkbox")]
        [Category("Appearance")]
        [DefaultValue(true)]
        public bool ShowDebugCheckBox
        {
            get => this.checkDebug.Visible && this.toolbarVisible;

            set
            {
                if (this.toolbarVisible)
                {
                    this.checkDebug.Visible = value;
                } // if
            }
        } // ShowDebugCheckBox

        /// <summary>
        /// Gets or sets a value indicating whether to Enable the debug log display.
        /// </summary>
        [Description("Enables/disable the debug log display")]
        [Category("Appearance")]
        [DefaultValue(true)]
        public bool ShowDebugEvents
        {
            get => this.checkDebug.Checked;
            set => this.checkDebug.Checked = value;
        } // ShowDebugCheckBox
        #endregion PUBLIC PROPERTIES

        //// ---------------------------------------------------------------------

        #region CONSTRUCTION
        /// <summary>
        /// Initializes a new instance of the <see cref="RtfLogView"/> class.
        /// </summary>
        public RtfLogView()
        {
            this.RtfControl = new RichTextBox();
            this.InitControl();
            this.MaxLogLength = -1;
        } // RtfLogView()
        #endregion // CONSTRUCTION

        //// ---------------------------------------------------------------------

        #region UI MANAGEMENT
        /// <summary>
        /// Clears the event log view.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing
        /// the event data.</param>
        private void BtnClearClick(object sender, EventArgs e)
        {
            this.Clear();
        } // btnClear_Click()

        /// <summary>
        /// Copies the contents of the event log to the clipboard.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing
        /// the event data.</param>
        private void BtnCopyClick(object sender, EventArgs e)
        {
            this.CopyToClipboard();
        } // btnCopy_Click()

        /// <summary>
        /// Saves the contents of the event log to a text file.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing
        /// the event data.</param>
        private void BtnSaveClick(object sender, EventArgs e)
        {
            this.SaveToTextFile();
        } // btnSave_Click()
        #endregion // UI MANAGEMENT

        //// ---------------------------------------------------------------------

        #region PRIVATE METHODS
        /// <summary>
        /// Initializes this control.
        /// </summary>
        private void InitControl()
        {
            this.InitializeComponent();

            // store default text color
            this.defaultTextColor = this.RtfControl.SelectionColor;
            this.AddAtTail = true;
            this.toolbarVisible = true;
        } // InitControl()

        /// <summary>
        /// Adapts the list height to current property settings.
        /// </summary>
        private void CheckListHeight()
        {
            if (!this.toolbarVisible)
            {
                // enlarge table
                this.RtfControl.Top = 0;
                this.RtfControl.Height = this.Height;
            }
            else
            {
                // default size
                this.RtfControl.Top = ToolbarHeight;
                this.RtfControl.Height = this.Height - ToolbarHeight;
            } // if
        } // CheckListHeight()

        /// <summary>
        /// Copies the contents of the event log to the clipboard.
        /// </summary>
        private void CopyToClipboard()
        {
            this.RtfControl.SelectAll();
            this.RtfControl.Copy();

            // add to clipboard as normal text
            // Clipboard.SetData(DataFormats.Text, rtfView.Text);

            // add to clipboard as rich text
            // If we'd do this, we can't copy to notepad....
            // Clipboard.SetData(DataFormats.Rtf, rtfView.Rtf);
        } // CopyToClipBoard()

        /// <summary>
        /// Saves the contents of the event log to a text file.
        /// </summary>
        private void SaveToTextFile()
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.CheckFileExists = false;
            saveFileDialog.CheckPathExists = true;
            saveFileDialog.InitialDirectory = ".";
            saveFileDialog.Filter = @"Rich Text Files (*.rtf)|*.rtf|"
              + @"Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            var dialogResult = saveFileDialog.ShowDialog(this);
            if (dialogResult != DialogResult.OK)
            {
                // aborted by user
                return;
            } // if

            if (saveFileDialog.FilterIndex == 1)
            {
                this.WriteRichTextFile(saveFileDialog.FileName);
            }
            else
            {
                this.WriteTextFile(saveFileDialog.FileName);
            } // if
        } // SaveToTextFile()

        /// <summary>
        /// Write the log window contents to a plain text file.
        /// </summary>
        /// <param name="fileName">Name of the file to write to.</param>
        private void WriteTextFile(string fileName)
        {
            using var sw = new StreamWriter(fileName);
            foreach (var line in this.RtfControl.Lines)
            {
                sw.WriteLine(line);
            } // foreach

            sw.Flush();
        } // WriteTextFile()

        /// <summary>
        /// Write the log window contents to an RTF file.
        /// </summary>
        /// <param name="fileName">Name of the file to write to.</param>
        private void WriteRichTextFile(string fileName)
        {
            using var sw = new StreamWriter(fileName);
            sw.Write(this.RtfControl.Rtf);
            sw.Flush();
        } // WriteRichTextFile()

        /// <summary>
        /// Checks for the maximum text display size.
        /// </summary>
        private void CheckForMaxSize()
        {
            if ((this.MaxLogLength > 0) &&
              (this.RtfControl.TextLength > this.MaxLogLength + MaxLogLengthChunk))
            {
                this.RtfControl.SelectionStart = 0;
                this.RtfControl.Select(0, MaxLogLengthChunk);
                this.RtfControl.SelectedText = string.Empty;
            } // if
        } // CheckForMaxSize()

        /// <summary>
        /// Appends text to the current text of status view.
        /// </summary>
        /// <param name="text">text to add.</param>
        /// <param name="color">color of the text.</param>
        private void AppendTextInternal(string text, Color color)
        {
            this.CheckForMaxSize();

            if (!this.AddAtTail)
            {
                this.RtfControl.SelectionStart = 0;
                this.RtfControl.SelectionColor = color;
                this.RtfControl.SelectedText = text;
            }
            else
            {
                this.RtfControl.SelectionStart = 2000000000;
                this.RtfControl.SelectionColor = color;
                this.RtfControl.SelectedText = text;
            } // if

            this.RtfControl.SelectionColor = this.defaultTextColor;

            if (this.AddAtTail)
            {
                this.RtfControl.Select(this.RtfControl.TextLength, 0);
                this.RtfControl.ScrollToCaret();
            } // if
        } // AppendTextInternal()
        #endregion // PRIVATE METHODS

        //// ---------------------------------------------------------------------

        #region PUBLIC METHODS
        /// <summary>
        /// Adds a log event.
        /// </summary>
        /// <param name="logEvent">The log event.</param>
        public void AddLogEvent(ILogEvent logEvent)
        {
            if (logEvent.Level == LogLevel.Debug)
            {
                if (!this.checkDebug.Checked)
                {
                    return;
                } // if

                this.AppendText(logEvent.Message, Color.Blue);
            }
            else if ((logEvent.Level == LogLevel.Error)
              || (logEvent.Level == LogLevel.Fatal))
            {
                this.AppendText(logEvent.Message, Color.Red);
            }
            else if (logEvent.Level == LogLevel.Warn)
            {
                this.AppendText(logEvent.Message, Color.Orange);
            }
            else
            {
                this.AppendText(logEvent.Message, Color.Black);
            } // if
        } // AddLogEvent()

        /// <summary>
        /// Clears the status view.
        /// </summary>
        public void Clear()
        {
            this.RtfControl.Text = string.Empty;
        } // Clear()

        /// <summary>
        /// Appends text to the current text of status view.
        /// </summary>
        /// <param name="text">text to add.</param>
        /// <param name="color">color of the text.</param>
        public void AppendText(string text, Color color)
        {
            if (this.IsDisposed ||
              (!this.InvokeRequired && (this.Handle == IntPtr.Zero)))
            {
                return;
            } // if

            // use BeginInvoke to execute the method asynchronously on the thread
            // that the control's underlying handle was created on.
            this.BeginInvoke(
                new AppendTextDelegate(this.AppendTextInternal),
                text,
                color);
        } // AppendText()
        #endregion // PUBLIC METHODS
    } // RtfLogView
} // Tethys.Logging.Controls

// ============================================
// TgLib.Logging.Controls: end of RtfLogView.cs
// ============================================
