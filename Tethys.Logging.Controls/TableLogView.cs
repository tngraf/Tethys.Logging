#region Header
// --------------------------------------------------------------------------
// Tethys.Logging.Controls
// ==========================================================================
//
// A logging library for .NET Framework 4.
//
// ===========================================================================
//
// <copyright file="TableLogView.cs" company="Tethys">
// Copyright  2009-2015 by Thomas Graf
//            All rights reserved.
//            Licensed under the Apache License, Version 2.0.
//            Unless required by applicable law or agreed to in writing, 
//            software distributed under the License is distributed on an
//            "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
//            either express or implied. 
// </copyright>
//
// System ... Microsoft .Net Framework 4
// Tools .... Microsoft Visual Studio 2013
//
// ---------------------------------------------------------------------------
#endregion

namespace Tethys.Logging.Controls
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Globalization;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Windows.Forms;

    /// <summary>
    /// TableLogView implements a list view to show log4net
    /// logging events in a table.
    /// </summary>
    [ComVisible(false)]
    [Description("TableLogView control")]
    [ToolboxBitmap(typeof(TableLogView), "TableLogViewToolBoxBitmap")]
    public sealed partial class TableLogView : UserControl, ILogView
    {
        /// <summary>
        /// Delegate to be used in case of callbacks coming from
        /// other threads.
        /// </summary>
        /// <param name="logevent">Log event.</param>
        private delegate void AppendLogEventDelegate(ILogEvent logevent);

        #region PRIVATE PROPERTIES
        /// <summary>
        /// Default width of the icon column.
        /// </summary>
        private const int ColWidthIcon = 32;

        /// <summary>
        /// Default width of the date column.
        /// </summary>
        private const int ColWidthDate = 70;

        /// <summary>
        /// Default width of the time column.
        /// </summary>
        private const int ColWidthTime = 70;

        /// <summary>
        /// Default width of the type column.
        /// </summary>
        private const int ColWidthType = 60;

        /// <summary>
        /// Default height of the tool bar.
        /// </summary>
        private const int ToolbarHeight = 26;

        /// <summary>
        /// Date column header.
        /// </summary>
        private ColumnHeader colDate;

        /// <summary>
        /// Time column header.
        /// </summary>
        private ColumnHeader colTime;

        /// <summary>
        /// Type column header.
        /// </summary>
        private ColumnHeader colType;

        /// <summary>
        /// Icon column header.
        /// </summary>
        private ColumnHeader colIcon;

        /// <summary>
        /// Message column header.
        /// </summary>
        private ColumnHeader colMessage;

        /// <summary>
        /// Flag 'we have a date column'.
        /// </summary>
        private bool hasColDate = true;

        /// <summary>
        /// Flag 'we have a time column'.
        /// </summary>
        private bool hasColTime = true;

        /// <summary>
        /// Flag 'we have a type column'.
        /// </summary>
        private bool hasColType = true;

        /// <summary>
        /// Flag 'show category button.'.
        /// </summary>
        private bool showCategoryButtons = true;

        /// <summary>
        /// Flag 'we have a date column'.
        /// </summary>
        private bool showToolButtons = true;

        /// <summary>
        /// Culture to use.
        /// </summary>
        private CultureInfo culture;
        #endregion PRIVATE PROPERTIES

        //// ---------------------------------------------------------------------

        #region PUBLIC PROPERTIES
        /// <summary>
        /// Vertical base height on 100% scaled display.
        /// </summary>
        public const float AutoScaleBaseHeight = 13.0F;

        /// <summary>
        /// Gets or sets the _culture for this control.
        /// </summary>
        public CultureInfo Culture
        {
            get { return this.culture; }
            set { this.culture = value; }
        } // Culture

        /// <summary>
        /// Gets or sets a value indicating whether to enable the Category column.
        /// </summary>
        [Description("Enables/disable the Category column"),
        Category("Appearance")]
        public bool ColumnCategory
        {
            get
            {
                return this.hasColType;
            }

            set
            {
                if (value)
                {
                    if (!this.listView.Columns.Contains(this.colType))
                    {
                        this.listView.Columns.Add(this.colType);
                    } // if
                    this.hasColType = true;
                }
                else
                {
                    this.listView.Columns.Remove(this.colType);
                    this.CheckTableWidth();
                    this.hasColType = false;
                } // if
            }
        } // ColumnIcon

        /// <summary>
        /// Gets or sets a value indicating whether to enable the date column.
        /// </summary>
        [Description("Enables/disable the Date column"),
        Category("Appearance")]
        public bool ColumnDate
        {
            get
            {
                return this.hasColDate;
            }

            set
            {
                if (value)
                {
                    if (!this.listView.Columns.Contains(this.colDate))
                    {
                        this.listView.Columns.Add(this.colDate);
                    } // if
                    this.hasColDate = true;
                }
                else
                {
                    this.listView.Columns.Remove(this.colDate);
                    this.CheckTableWidth();
                    this.hasColDate = false;
                } // if
            }
        } // ColumnDate

        /// <summary>
        /// Gets or sets a value indicating whether to enable the time column.
        /// </summary>
        [Description("Enables/disable the Time column"),
        Category("Appearance")]
        public bool ColumnTime
        {
            get
            {
                return this.hasColTime;
            }

            set
            {
                if (value)
                {
                    if (!this.listView.Columns.Contains(this.colTime))
                    {
                        this.listView.Columns.Add(this.colTime);
                    } // if
                    this.hasColTime = true;
                }
                else
                {
                    this.listView.Columns.Remove(this.colTime);
                    this.CheckTableWidth();
                    this.hasColTime = false;
                } // if
            }
        } // ColumnTime

        /// <summary>
        /// Gets or sets a value indicating whether to enable the Category buttons.
        /// </summary>
        [Description("Enables/disable the Category buttons"),
        Category("Appearance")]
        public bool ShowCategoryButtons
        {
            get
            {
                return this.showCategoryButtons;
            }

            set
            {
                this.showCategoryButtons = value;
                this.checkShowDebug.Visible = value;
                this.checkShowErrors.Visible = value;
                this.checkShowInfo.Visible = value;
                this.checkShowWarnings.Visible = value;
                this.checkShowDebug.Enabled = value;
                this.checkShowErrors.Enabled = value;
                this.checkShowInfo.Enabled = value;
                this.checkShowWarnings.Enabled = value;

                this.CheckListHeight();
            }
        } // ShowCategoryButtons

        /// <summary>
        /// Gets or sets a value indicating whether to enable the tool buttons.
        /// </summary>
        [Description("Enables/disable the tool buttons"),
        Category("Appearance")]
        public bool ShowToolButtons
        {
            get
            {
                return this.showToolButtons;
            }

            set
            {
                this.showToolButtons = value;
                this.btnClear.Visible = value;
                this.btnCopy.Visible = value;
                this.btnSave.Visible = value;
                this.btnExportExcel.Visible = value;
                this.btnClear.Enabled = value;
                this.btnCopy.Enabled = value;
                this.btnSave.Enabled = value;
                this.btnExportExcel.Enabled = value;

                this.CheckListHeight();
            }
        } // ShowToolButtons

        /// <summary>
        /// Gets or sets the date column header text.
        /// </summary>
        [Description("The date column header text"),
        Category("Appearance")]
        public string DateColumnHeader
        {
            get { return this.colDate.Text; }
            set { this.colDate.Text = value; }
        } // DateColumnHeader

        /// <summary>
        /// Gets or sets the time column header text.
        /// </summary>
        [Description("The time column header text"),
        Category("Appearance")]
        public string TimeColumnHeader
        {
            get { return this.colTime.Text; }
            set { this.colTime.Text = value; }
        } // TimeColumnHeader

        /// <summary>
        /// Gets or sets the category column header text.
        /// </summary>
        [Description("The category column header text"),
        Category("Appearance")]
        public string CategoryColumnHeader
        {
            get { return this.colType.Text; }
            set { this.colType.Text = value; }
        } // CategoryColumnHeader

        /// <summary>
        /// Gets or sets the message column header text.
        /// </summary>
        [Description("The message column header text"),
        Category("Appearance")]
        public string MessageColumnHeader
        {
            get { return this.colMessage.Text; }
            set { this.colMessage.Text = value; }
        } // MessageColumnHeader

        /// <summary>
        /// Gets or sets the 'show debug events' button text.
        /// </summary>
        [Description("the 'show debug events' button text"),
        Category("Appearance")]
        public string ShowDebugButtonText
        {
            get { return this.checkShowDebug.Text; }
            set { this.checkShowDebug.Text = value; }
        } // ShowDebugButtonText

        /// <summary>
        /// Gets or sets the 'show error events' button text.
        /// </summary>
        [Description("the 'show error events' button text"),
        Category("Appearance")]
        public string ShowErrorButtonText
        {
            get { return this.checkShowErrors.Text; }
            set { this.checkShowErrors.Text = value; }
        } // ShowErrorButtonText

        /// <summary>
        /// Gets or sets the 'show info events' button text.
        /// </summary>
        [Description("the 'show info events' button text"),
        Category("Appearance")]
        public string ShowInfoButtonText
        {
            get { return this.checkShowInfo.Text; }
            set { this.checkShowInfo.Text = value; }
        } // ShowInfoButtonText

        /// <summary>
        /// Gets or sets the 'show debug events' button text.
        /// </summary>
        [Description("the 'show warning events' button text"),
        Category("Appearance")]
        public string ShowWarningButtonText
        {
            get { return this.checkShowWarnings.Text; }
            set { this.checkShowWarnings.Text = value; }
        } // ShowWarningButtonText

        /// <summary>
        /// Gets or sets a value indicating whether new events are added at the tail or
        /// at the head of the list.
        /// </summary>
        [Description("Defines whether new event are added at the tail or "
         + "at the head of the list."),
        Category("Logging")]
        public bool AddAtTail { get; set; } = true;

        /// <summary>
        /// Gets or sets the max length of log text displayed.<br/>
        /// A value of -1 means no length check.
        /// </summary>
        /// <value>The length of the max log.</value>
        [Description("Gets or sets the max number of log entries displayed. "
         + "A value of -1 means no length check."),
        Category("Logging")]
        public int MaxLogEntries { get; set; }
        #endregion PUBLIC PROPERTIES

        //// ---------------------------------------------------------------------

        #region CONSTRUCTOR
        /// <summary>
        /// Initializes a new instance of the <see cref="TableLogView"/> class.
        /// </summary>
        public TableLogView()
        {
            this.InitializeComponent();
            this.InitControl();

            this.culture = CultureInfo.CurrentCulture;
            this.MaxLogEntries = -1;
        } // TableLogView()
        #endregion CONSTRUCTOR

        //// ---------------------------------------------------------------------

        #region UI MANAGEMENT
        /// <summary>
        /// Clears the event log view.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance
        /// containing the event data.</param>
        private void BtnClearClick(object sender, EventArgs e)
        {
            this.ClearList();
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
        /// Saves the contents of the event log to a csv file.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing
        /// the event data.</param>
        private void BtnExportExcelClick(object sender, EventArgs e)
        {
            this.SaveToCsvFile();
        } // btnExportExcel_Click()

        /// <summary>
        /// Handles the Layout event of the TableLogView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="LayoutEventArgs"/> instance containing 
        /// the event data.</param>
        private void TableLogViewOnLayout(object sender, LayoutEventArgs e)
        {
            var width = this.btnSave.Width;
            var height = this.btnSave.Height;

            this.btnExportExcel.Location = new Point(this.Width - width, 1);
            this.btnSave.Location = new Point(this.Width - (2 * width), 1);
            this.btnCopy.Location = new Point(this.Width - (3 * width), 1);
            this.btnClear.Location = new Point(this.Width - (4 * width), 1);

            // manual layout of all child controls
            this.listView.Bounds = new Rectangle(1, height + 1, this.Width - 1,
                this.Height - height - 2);
        } // TableLogViewOnLayout()
        #endregion // UI MANAGEMENT

        //// ---------------------------------------------------------------------

        #region PRIVATE METHODS
        /// <summary>
        /// Initializes this control.
        /// </summary>
        private void InitControl()
        {
            // create columns
            this.colIcon = new ColumnHeader();
            this.colIcon.Text = string.Empty;
            this.colIcon.Width = ColWidthIcon;
            this.colIcon.TextAlign = HorizontalAlignment.Left;

            this.colDate = new ColumnHeader();
            this.colDate.Text = @"Date";
            this.colDate.Width = ColWidthDate;
            this.colDate.TextAlign = HorizontalAlignment.Left;

            this.colTime = new ColumnHeader();
            this.colTime.Text = @"Time";
            this.colTime.Width = ColWidthTime;
            this.colTime.TextAlign = HorizontalAlignment.Left;

            this.colType = new ColumnHeader();
            this.colType.Text = @"Category";
            this.colType.Width = ColWidthType;
            this.colType.TextAlign = HorizontalAlignment.Left;

            this.colMessage = new ColumnHeader();
            this.colMessage.Text = @"Message";
            this.colMessage.Width = 255;
            this.colMessage.TextAlign = HorizontalAlignment.Left;

            this.listView.Columns.Add(this.colIcon);
            this.listView.Columns.Add(this.colDate);
            this.listView.Columns.Add(this.colTime);
            this.listView.Columns.Add(this.colType);
            this.listView.Columns.Add(this.colMessage);

            this.CheckTableWidth();
        } // InitControl()

        /// <summary>
        /// Transforms the event log to a text file.
        /// </summary>
        /// <param name="separator">The separator.</param>
        /// <returns>
        /// A log string.
        /// </returns>
        private string LogEventListToText(char separator)
        {
            var sb = new StringBuilder(this.listView.Items.Count * 200);
            foreach (ListViewItem item in this.listView.Items)
            {
                var first = true;
                foreach (ListViewItem.ListViewSubItem subitem in item.SubItems)
                {
                    if (first)
                    {
                        // skip first item (= icon)
                        first = false;
                        continue;
                    } // if
                    sb.AppendFormat("{0}{1}", subitem.Text, separator);
                } // foreach
                sb.Append("\r\n");
            } // foreach

            return sb.ToString();
        } // LogEventListToText()

        /// <summary>
        /// Adapts the list height to current property settings.
        /// </summary>
        private void CheckListHeight()
        {
            // ? toolbarVisible ?
            if ((!this.showCategoryButtons) && (!this.showToolButtons))
            {
                // enlarge table
                this.listView.Top = 0;
                this.listView.Height = this.Height;
            }
            else
            {
                // default size
                var height = (int)((ToolbarHeight * this.AutoScaleDimensions.Height) / AutoScaleBaseHeight);

                this.listView.Top = height;
                this.listView.Height = this.Height - height;
            } // if
        } // CheckListHeight()

        /// <summary>
        /// Adapts the size of the message column when the list size
        /// has changed.
        /// </summary>
        private void CheckTableWidth()
        {
            var width = this.Width - ColWidthIcon - 4;
            if (this.hasColDate)
            {
                width -= ColWidthDate;
            } // if
            if (this.hasColTime)
            {
                width -= ColWidthTime;
            } // if
            if (this.hasColType)
            {
                width -= ColWidthType;
            } // if

            if (this.colMessage != null)
            {
                this.colMessage.Width = width;
            } // if
        } // CheckListHeight()

        /// <summary>
        /// Adapts the size of the message column when the list size
        /// has changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing
        /// the event data.</param>
        private void ListViewResize(object sender, EventArgs e)
        {
            this.CheckTableWidth();
        } // listView_Resize()

        /// <summary>
        /// Returns the index in the image list of the image for
        /// this log event level.
        /// </summary>
        /// <param name="eventLevel">log event level</param>
        /// <returns>index of the image for this level</returns>
        private static int GetImageIndex(LogLevel eventLevel)
        {
            var index = 0;

            if (eventLevel == LogLevel.Debug)
            {
                index = 3;
            }
            else if (eventLevel == LogLevel.Info)
            {
                index = 0;
            }
            else if (eventLevel == LogLevel.Warn)
            {
                index = 4;
            }
            else if (eventLevel == LogLevel.Error)
            {
                index = 1;
            }
            else if (eventLevel == LogLevel.Fatal)
            {
                index = 1;
            } // if

            return index;
        } // GetImageIndex()

        /// <summary>
        /// Checks for the maximum length.
        /// </summary>
        private void CheckMaxLength()
        {
            if ((this.MaxLogEntries > 0) &&
              (this.listView.Items.Count > this.MaxLogEntries))
            {
                this.listView.Items.RemoveAt(0);
            } // if
        } // CheckMaxLength()
        #endregion // PRIVATE METHODS

        //// ---------------------------------------------------------------------

        #region PUBLIC METHODS
        /// <summary>
        /// Adds a log event.
        /// </summary>
        /// <param name="logEvent">The log event.</param>
        public void AddLogEvent(ILogEvent logEvent)
        {
            this.AppendLogEvent(logEvent);
        } // AddLogEvent

        /// <summary>
        /// Clears the event log view.
        /// </summary>
        public void ClearList()
        {
            this.listView.Items.Clear();
        } // ClearList()

        /// <summary>
        /// Copies the contents of the event log to the clipboard.
        /// </summary>
        public void CopyToClipboard()
        {
            Clipboard.SetDataObject(this.LogEventListToText(' '));
        } // CopyToClipBoard()

        /// <summary>
        /// Saves the contents of the event log to a text file.
        /// </summary>
        public void SaveToTextFile()
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.CheckFileExists = false;
            saveFileDialog.CheckPathExists = true;
            saveFileDialog.InitialDirectory = ".";
            saveFileDialog.Filter = @"Text Files (*.txt)|*.txt|"
              + @"All Files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            var dialogResult = saveFileDialog.ShowDialog(this);
            if (dialogResult != DialogResult.OK)
            {
                // aborted by user
                return;
            } // if

            using (var sw = new StreamWriter(saveFileDialog.FileName))
            {
                var sb = new StringBuilder(200);
                foreach (ListViewItem item in this.listView.Items)
                {
                    var first = true;
                    foreach (ListViewItem.ListViewSubItem subitem in item.SubItems)
                    {
                        if (first)
                        {
                            // skip first item (= icon)
                            first = false;
                            continue;
                        } // if
                        sb.AppendFormat("{0}{1}", subitem.Text, ' ');
                    } // foreach
                    sw.WriteLine(sb.ToString());
                    sb.Length = 0;
                } // foreach
            } // using
        } // SaveToTextFile()

        /// <summary>
        /// Saves the contents of the event log to a CSV file.
        /// </summary>
        public void SaveToCsvFile()
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.CheckPathExists = true;
            saveFileDialog.InitialDirectory = ".";
            saveFileDialog.Filter = @"CSV Files (*.csv)|*.csv|"
              + @"All Files (*.*)|*.*";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            var dialogResult = saveFileDialog.ShowDialog(this);
            if (dialogResult != DialogResult.OK)
            {
                // aborted by user
                return;
            } // if

            using (var sw = new StreamWriter(saveFileDialog.FileName))
            {
                sw.Write(this.LogEventListToText(';'));
            } // using
        } // SaveToCsvFile()

        /// <summary>
        /// Appends the specified event to the log view.
        /// </summary>
        /// <param name="logEvent">The log event.</param>
        public void AppendLogEvent(ILogEvent logEvent)
        {
            if (!this.InvokeRequired)
            {
                if (((logEvent.Level == LogLevel.Debug) && (!this.checkShowDebug.Checked))
                 || ((logEvent.Level == LogLevel.Error) && (!this.checkShowErrors.Checked))
                 || ((logEvent.Level == LogLevel.Fatal) && (!this.checkShowErrors.Checked))
                 || ((logEvent.Level == LogLevel.Info) && (!this.checkShowInfo.Checked))
                 || ((logEvent.Level == LogLevel.Warn) && (!this.checkShowWarnings.Checked)))
                {
                    // do not display
                    return;
                } // if

                if (this.IsDisposed || (this.Handle == IntPtr.Zero))
                {
                    return;
                } // if

                this.CheckMaxLength();

                var item = new ListViewItem();
                item.ImageIndex = GetImageIndex(logEvent.Level);
                if (this.hasColDate)
                {
                    item.SubItems.Add(logEvent.Timestamp.ToShortDateString());
                } // if
                if (this.hasColTime)
                {
                    item.SubItems.Add(logEvent.Timestamp.ToString("T", this.culture));
                } // if
                if (this.hasColType)
                {
                    item.SubItems.Add(logEvent.Level.ToString());
                } // if
                item.SubItems.Add(logEvent.Message);
                if (this.AddAtTail)
                {
                    this.listView.Items.Add(item);
                    this.listView.EnsureVisible(this.listView.Items.Count - 1);
                }
                else
                {
                    // add at top of the list      
                    this.listView.Items.Insert(0, item);
                } // if
            }
            else
            {
                // use BeginInvoke to execute the method asynchronously on the thread
                // that the control's underlying handle was created on.
                this.BeginInvoke(new AppendLogEventDelegate(this.AppendLogEvent),
                    logEvent);
            } // if
        } // AppendLogEvent()
        #endregion // PUBLIC METHODS
    } // TableLogView
} // Tethys.Logging.Controls

// ===============================================
// Tethys.Logging.Controls: end of TableLogView.cs
// ===============================================
