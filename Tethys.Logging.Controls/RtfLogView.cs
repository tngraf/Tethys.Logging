// -------------------------------------------------------------------------------
// <copyright file="RtfLogView.cs" company="Tethys">
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
        /// other threads
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
        [Description("Text color to be used for default text output."),
        Category("Appearance")]
        public Color TextColor
        {
            get
            {
                return this.defaultTextColor;
            }

            set
            {
                this.defaultTextColor = value;
                this.rtfView.SelectionColor = this.defaultTextColor;
            }
        } // TextColor

        /// <summary>
        /// Gets or sets a value indicating whether to enable the tool buttons.
        /// </summary>
        [Description("Enables/disable the tool buttons"),
        Category("Appearance"), DefaultValue(true)]
        public bool ShowToolButtons
        {
            get
            {
                return this.toolbarVisible;
            }

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
        [Description("The text contained in the control."),
        Category("Appearance")]
        public override string Text
        {
            get
            {
                return this.rtfView.Text;
            }
        } // Text

        /// <summary>
        /// Gets the underlying RichTextBox control.
        /// </summary>
        [Browsable(false),
        DesignerSerializationVisibilityAttribute(DesignerSerializationVisibility.Hidden)]
        public RichTextBox RtfControl
        {
            get
            {
                return this.rtfView;
            }
        } // RtfControl

        /// <summary>
        /// Gets or sets a value indicating whether new event are added at the tail or
        /// at the head of the list.
        /// </summary>
        [Description("Defines whether new event are added at the tail or "
         + "at the head of the list."),
        Category("Logging")]
        public bool AddAtTail { get; set; } = true;

        /// <summary>
        /// Gets or sets the label on the upper left corner of the control.
        /// </summary>
        [Description("Log view label text."),
        Category("Appearance")]
        public string LabelText
        {
            get { return this.lblStatus.Text; }
            set { this.lblStatus.Text = value; }
        } // LabelText

        /// <summary>
        /// Gets or sets the max length of log text displayed.<br/>
        /// A value of -1 means no length check.
        /// </summary>
        /// <value>The length of the max log.</value>
        [Description("Gets or sets the max length of log text displayed. "
         + "A value of -1 means no length check."),
        Category("Logging")]
        public int MaxLogLength { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to enable the 'show debug' checkbox.
        /// </summary>
        [Description("Enables/disable the 'show debug' checkbox"),
        Category("Appearance"), DefaultValue(true)]
        public bool ShowDebugCheckBox
        {
            get
            {
                return this.checkDebug.Visible && this.toolbarVisible;
            }

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
        [Description("Enables/disable the debug log display"),
        Category("Appearance"), DefaultValue(true)]
        public bool ShowDebugEvents
        {
            get { return this.checkDebug.Checked; }
            set { this.checkDebug.Checked = value; }
        } // ShowDebugCheckBox
        #endregion PUBLIC PROPERTIES

        //// ---------------------------------------------------------------------

        #region CONSTRUCTION
        /// <summary>
        /// Initializes a new instance of the <see cref="RtfLogView"/> class.
        /// </summary>
        public RtfLogView()
        {
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

        /// <summary>
        /// Handles the Layout event of the RtfLogView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="LayoutEventArgs"/> instance containing 
        /// the event data.</param>
        private void RtfLogViewOnLayout(object sender, LayoutEventArgs e)
        {
            var width = this.btnSave.Width;
            var height = this.btnSave.Height;

            this.btnSave.Location = new Point(this.Width - width, 1);
            this.btnCopy.Location = new Point(this.Width - (2 * width), 1);
            this.btnClear.Location = new Point(this.Width - (3 * width), 1);

            this.checkDebug.Location = new Point(this.Width -
              ((3 * width) + 6 + this.checkDebug.Width), 5);

            // manual layout of all child controls
            this.rtfView.Bounds = new Rectangle(1, height + 1, this.Width - 1,
                this.Height - height - 2);
        } // RtfLogViewOnLayout()
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
            this.defaultTextColor = this.rtfView.SelectionColor;

            this.rtfView.ContextMenu = new ContextMenu();
            var mi = new MenuItem("Clear All");
            mi.Name = "menuContextClearAll";
            mi.Click += this.BtnClearClick;
            this.rtfView.ContextMenu.MenuItems.Add(mi);

            mi = new MenuItem("Copy");
            mi.Name = "menuContextCopy";
            mi.Click += this.BtnCopyClick;
            this.rtfView.ContextMenu.MenuItems.Add(mi);

            mi = new MenuItem("Save");
            mi.Name = "menuContextSave";
            mi.Click += this.BtnSaveClick;
            this.rtfView.ContextMenu.MenuItems.Add(mi);

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
                this.rtfView.Top = 0;
                this.rtfView.Height = this.Height;
            }
            else
            {
                // default size
                this.rtfView.Top = ToolbarHeight;
                this.rtfView.Height = this.Height - ToolbarHeight;
            } // if
        } // CheckListHeight()

        /// <summary>
        /// Copies the contents of the event log to the clipboard.
        /// </summary>
        private void CopyToClipboard()
        {
            this.rtfView.SelectAll();
            this.rtfView.Copy();

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
            using (var sw = new StreamWriter(fileName))
            {
                foreach (string line in this.rtfView.Lines)
                {
                    sw.WriteLine(line);
                } // foreach
                sw.Flush();
            } // using
        } // WriteTextFile()

        /// <summary>
        /// Write the log window contents to a RTF file.
        /// </summary>
        /// <param name="fileName">Name of the file to write to.</param>
        private void WriteRichTextFile(string fileName)
        {
            using (var sw = new StreamWriter(fileName))
            {
                sw.Write(this.rtfView.Rtf);
                sw.Flush();
            } // using
        } // WriteRichTextFile()

        /// <summary>
        /// Checks for the maximum text display size.
        /// </summary>
        private void CheckForMaxSize()
        {
            if ((this.MaxLogLength > 0) &&
              (this.rtfView.TextLength > this.MaxLogLength + MaxLogLengthChunk))
            {
                this.rtfView.SelectionStart = 0;
                this.rtfView.Select(0, MaxLogLengthChunk);
                this.rtfView.SelectedText = string.Empty;
            } // if
        } // CheckForMaxSize()

        /// <summary>
        /// Appends text to the current text of status view.
        /// </summary>
        /// <param name="text">text to add</param>
        /// <param name="color">color of the text</param>
        private void AppendTextInternal(string text, Color color)
        {
            this.CheckForMaxSize();

            if (!this.AddAtTail)
            {
                this.rtfView.SelectionStart = 0;
                this.rtfView.SelectionColor = color;
                this.rtfView.SelectedText = text;
            }
            else
            {
                this.rtfView.SelectionStart = 2000000000;
                this.rtfView.SelectionColor = color;
                this.rtfView.SelectedText = text;
            } // if

            this.rtfView.SelectionColor = this.defaultTextColor;

            if (this.AddAtTail)
            {
                this.rtfView.Select(this.rtfView.TextLength, 0);
                this.rtfView.ScrollToCaret();
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
            this.rtfView.Text = string.Empty;
        } // Clear()

        /// <summary>
        /// Appends text to the current text of status view.
        /// </summary>
        /// <param name="text">text to add</param>
        /// <param name="color">color of the text</param>
        public void AppendText(string text, Color color)
        {
            if (this.IsDisposed ||
              (!this.InvokeRequired && (this.Handle == IntPtr.Zero)))
            {
                return;
            } // if

            // use BeginInvoke to execute the method asynchronously on the thread
            // that the control's underlying handle was created on.
            this.BeginInvoke(new AppendTextDelegate(this.AppendTextInternal),
                text, color);
        } // AppendText()
        #endregion // PUBLIC METHODS
    } // RtfLogView
} // Tethys.Logging.Controls

// ============================================
// TgLib.Logging.Controls: end of RtfLogView.cs
// ============================================
