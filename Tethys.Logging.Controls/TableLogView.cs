#region Header
// ---------------------------------------------------------------------------
// Tethys.Logging.Controls
// ===========================================================================
//
// This library contains common code of .Net projects of Thomas Graf.
//
// ===========================================================================
// <copyright file="TableLogView.cs" company="Tethys">
// Copyright  2003 - 2013 by Thomas Graf
//            All rights reserved.
//            See the file "License.txt" for information on usage and 
//            redistribution of this file and for a 
//            DISCLAIMER OF ALL WARRANTIES.
// </copyright>
// 
// Version .. 1.00.00.00 of 13Mar09
// Project .. TgLib.Logging.NLog
// Creater .. Thomas Graf (tg)
// System ... Microsoft .Net Framework 4
// Tools .... Microsoft Visual Studio 2010
//
// Change Report
// 09Nov29 1.00.00.00 tg: initial version of the tglib.logging.controls library.
// 09Dec22 1.00.00.01 tg: bugfix in SaveToTextFile().
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
    /// Defines whether new event are added at the tail or
    /// at the head of the list.
    /// </summary>
    private bool _addAtTail = true;

    /// <summary>
    /// Date column header.
    /// </summary>
    private ColumnHeader _colDate;

    /// <summary>
    /// Time column header.
    /// </summary>
    private ColumnHeader _colTime;

    /// <summary>
    /// Type column header.
    /// </summary>
    private ColumnHeader _colType;

    /// <summary>
    /// Icon column header.
    /// </summary>
    private ColumnHeader _colIcon;

    /// <summary>
    /// Message column header.
    /// </summary>
    private ColumnHeader _colMessage;

    /// <summary>
    /// Flag 'we have a date column'.
    /// </summary>
    private bool _hasColDate = true;

    /// <summary>
    /// Flag 'we have a time column'.
    /// </summary>
    private bool _hasColTime = true;

    /// <summary>
    /// Flag 'we have a type column'.
    /// </summary>
    private bool _hasColType = true;

    /// <summary>
    /// Flag 'show category button.'.
    /// </summary>
    private bool _showCategoryButtons = true;

    /// <summary>
    /// Flag 'we have a date column'.
    /// </summary>
    private bool _showToolButtons = true;

    /// <summary>
    /// Culture to use.
    /// </summary>
    private CultureInfo _culture;
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
      get { return _culture; }
      set { _culture = value; }
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
        return _hasColType;
      }

      set
      {
        if (value)
        {
          if (!listView.Columns.Contains(_colType))
          {
            listView.Columns.Add(_colType);
          } // if
          _hasColType = true;
        }
        else
        {
          listView.Columns.Remove(_colType);
          CheckTableWidth();
          _hasColType = false;
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
        return _hasColDate;
      }

      set
      {
        if (value)
        {
          if (!listView.Columns.Contains(_colDate))
          {
            listView.Columns.Add(_colDate);
          } // if
          _hasColDate = true;
        }
        else
        {
          listView.Columns.Remove(_colDate);
          CheckTableWidth();
          _hasColDate = false;
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
        return _hasColTime;
      }

      set
      {
        if (value)
        {
          if (!listView.Columns.Contains(_colTime))
          {
            listView.Columns.Add(_colTime);
          } // if
          _hasColTime = true;
        }
        else
        {
          listView.Columns.Remove(_colTime);
          CheckTableWidth();
          _hasColTime = false;
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
        return _showCategoryButtons;
      }

      set
      {
        _showCategoryButtons = value;
        checkShowDebug.Visible = value;
        checkShowErrors.Visible = value;
        checkShowInfo.Visible = value;
        checkShowWarnings.Visible = value;
        checkShowDebug.Enabled = value;
        checkShowErrors.Enabled = value;
        checkShowInfo.Enabled = value;
        checkShowWarnings.Enabled = value;

        CheckListHeight();
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
        return _showToolButtons;
      }

      set
      {
        _showToolButtons = value;
        btnClear.Visible = value;
        btnCopy.Visible = value;
        btnSave.Visible = value;
        btnExportExcel.Visible = value;
        btnClear.Enabled = value;
        btnCopy.Enabled = value;
        btnSave.Enabled = value;
        btnExportExcel.Enabled = value;

        CheckListHeight();
      }
    } // ShowToolButtons

    /// <summary>
    /// Gets or sets the date column header text.
    /// </summary>
    [Description("The date column header text"),
    Category("Appearance")]
    public string DateColumnHeader
    {
      get { return _colDate.Text; }
      set { _colDate.Text = value; }
    } // DateColumnHeader

    /// <summary>
    /// Gets or sets the time column header text.
    /// </summary>
    [Description("The time column header text"),
    Category("Appearance")]
    public string TimeColumnHeader
    {
      get { return _colTime.Text; }
      set { _colTime.Text = value; }
    } // TimeColumnHeader

    /// <summary>
    /// Gets or sets the category column header text.
    /// </summary>
    [Description("The category column header text"),
    Category("Appearance")]
    public string CategoryColumnHeader
    {
      get { return _colType.Text; }
      set { _colType.Text = value; }
    } // CategoryColumnHeader

    /// <summary>
    /// Gets or sets the message column header text.
    /// </summary>
    [Description("The message column header text"),
    Category("Appearance")]
    public string MessageColumnHeader
    {
      get { return _colMessage.Text; }
      set { _colMessage.Text = value; }
    } // MessageColumnHeader

    /// <summary>
    /// Gets or sets the 'show debug events' button text.
    /// </summary>
    [Description("the 'show debug events' button text"),
    Category("Appearance")]
    public string ShowDebugButtonText
    {
      get { return checkShowDebug.Text; }
      set { checkShowDebug.Text = value; }
    } // ShowDebugButtonText

    /// <summary>
    /// Gets or sets the 'show error events' button text.
    /// </summary>
    [Description("the 'show error events' button text"),
    Category("Appearance")]
    public string ShowErrorButtonText
    {
      get { return checkShowErrors.Text; }
      set { checkShowErrors.Text = value; }
    } // ShowErrorButtonText

    /// <summary>
    /// Gets or sets the 'show info events' button text.
    /// </summary>
    [Description("the 'show info events' button text"),
    Category("Appearance")]
    public string ShowInfoButtonText
    {
      get { return checkShowInfo.Text; }
      set { checkShowInfo.Text = value; }
    } // ShowInfoButtonText

    /// <summary>
    /// Gets or sets the 'show debug events' button text.
    /// </summary>
    [Description("the 'show warning events' button text"),
    Category("Appearance")]
    public string ShowWarningButtonText
    {
      get { return checkShowWarnings.Text; }
      set { checkShowWarnings.Text = value; }
    } // ShowWarningButtonText

    /// <summary>
    /// Gets or sets a value indicating whether new events are added at the tail or
    /// at the head of the list.
    /// </summary>
    [Description("Defines whether new event are added at the tail or "
     + "at the head of the list."),
    Category("Logging")]
    public bool AddAtTail
    {
      get { return _addAtTail; }
      set { _addAtTail = value; }
    } // AddAtTail

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
      InitializeComponent();
      InitControl();

      _culture = CultureInfo.CurrentCulture;
      MaxLogEntries = -1;
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
      ClearList();
    } // btnClear_Click()

    /// <summary>
    /// Copies the contents of the event log to the clipboard.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing
    /// the event data.</param>
    private void BtnCopyClick(object sender, EventArgs e)
    {
      CopyToClipboard();
    } // btnCopy_Click()

    /// <summary>
    /// Saves the contents of the event log to a text file.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing
    /// the event data.</param>
    private void BtnSaveClick(object sender, EventArgs e)
    {
      SaveToTextFile();
    } // btnSave_Click()

    /// <summary>
    /// Saves the contents of the event log to a csv file.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing
    /// the event data.</param>
    private void BtnExportExcelClick(object sender, EventArgs e)
    {
      SaveToCsvFile();
    } // btnExportExcel_Click()

    /// <summary>
    /// Handles the Layout event of the TableLogView control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="LayoutEventArgs"/> instance containing 
    /// the event data.</param>
    private void TableLogViewOnLayout(object sender, LayoutEventArgs e)
    {
      int width = btnSave.Width;
      int height = btnSave.Height;

      btnExportExcel.Location = new Point(Width - width, 1);
      btnSave.Location = new Point(Width - (2 * width), 1);
      btnCopy.Location = new Point(Width - (3 * width), 1);
      btnClear.Location = new Point(Width - (4 * width), 1);

      // manual layout of all child controls
      listView.Bounds = new Rectangle(1, height + 1, Width - 1,
        Height - height - 2);
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
      _colIcon = new ColumnHeader();
      _colIcon.Text = string.Empty;
      _colIcon.Width = ColWidthIcon;
      _colIcon.TextAlign = HorizontalAlignment.Left;

      _colDate = new ColumnHeader();
      _colDate.Text = @"Date";
      _colDate.Width = ColWidthDate;
      _colDate.TextAlign = HorizontalAlignment.Left;

      _colTime = new ColumnHeader();
      _colTime.Text = @"Time";
      _colTime.Width = ColWidthTime;
      _colTime.TextAlign = HorizontalAlignment.Left;

      _colType = new ColumnHeader();
      _colType.Text = @"Category";
      _colType.Width = ColWidthType;
      _colType.TextAlign = HorizontalAlignment.Left;

      _colMessage = new ColumnHeader();
      _colMessage.Text = @"Message";
      _colMessage.Width = 255;
      _colMessage.TextAlign = HorizontalAlignment.Left;

      listView.Columns.Add(_colIcon);
      listView.Columns.Add(_colDate);
      listView.Columns.Add(_colTime);
      listView.Columns.Add(_colType);
      listView.Columns.Add(_colMessage);

      CheckTableWidth();
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
      StringBuilder sb = new StringBuilder(listView.Items.Count * 200);
      foreach (ListViewItem item in listView.Items)
      {
        bool first = true;
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
      if ((!_showCategoryButtons) && (!_showToolButtons))
      {
        // enlarge table
        listView.Top = 0;
        listView.Height = Height;
      } 
      else
      {
        // default size
        int height = (int)((ToolbarHeight * this.AutoScaleDimensions.Height) / AutoScaleBaseHeight);

        listView.Top = height;
        listView.Height = Height - height;
      } // if
    } // CheckListHeight()

    /// <summary>
    /// Adapts the size of the message column when the list size
    /// has changed.
    /// </summary>
    private void CheckTableWidth()
    {
      int width = Width - ColWidthIcon - 4;
      if (_hasColDate)
      {
        width -= ColWidthDate;
      } // if
      if (_hasColTime)
      {
        width -= ColWidthTime;
      } // if
      if (_hasColType)
      {
        width -= ColWidthType;
      } // if

      if (_colMessage != null)
      {
        _colMessage.Width = width;
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
      CheckTableWidth();
    } // listView_Resize()

    /// <summary>
    /// Returns the index in the image list of the image for
    /// this log event level.
    /// </summary>
    /// <param name="eventLevel">log event level</param>
    /// <returns>index of the image for this level</returns>
    private static int GetImageIndex(LogLevel eventLevel)
    {
      int index = 0;

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
      if ((MaxLogEntries > 0) &&
        (listView.Items.Count > MaxLogEntries))
      {
        listView.Items.RemoveAt(0);
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
      AppendLogEvent(logEvent);
    } // AddLogEvent

    /// <summary>
    /// Clears the event log view.
    /// </summary>
    public void ClearList()
    {
      listView.Items.Clear();
    } // ClearList()

    /// <summary>
    /// Copies the contents of the event log to the clipboard.
    /// </summary>
    public void CopyToClipboard()
    {
      Clipboard.SetDataObject(LogEventListToText(' '));
    } // CopyToClipBoard()

    /// <summary>
    /// Saves the contents of the event log to a text file.
    /// </summary>
    public void SaveToTextFile()
    {
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.CheckFileExists = false;
      saveFileDialog.CheckPathExists = true;
      saveFileDialog.InitialDirectory = ".";
      saveFileDialog.Filter = @"Text Files (*.txt)|*.txt|"
        + @"All Files (*.*)|*.*";
      saveFileDialog.FilterIndex = 1;
      saveFileDialog.RestoreDirectory = true;

      DialogResult dialogResult = saveFileDialog.ShowDialog(this);
      if (dialogResult != DialogResult.OK) 
      {
        // aborted by user
        return;
      } // if

      using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName)) 
      {
        StringBuilder sb = new StringBuilder(200);
        foreach (ListViewItem item in listView.Items)
        {
          bool first = true;
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
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.CheckPathExists = true;
      saveFileDialog.InitialDirectory = ".";
      saveFileDialog.Filter = @"CSV Files (*.csv)|*.csv|"
        + @"All Files (*.*)|*.*";
      saveFileDialog.FilterIndex = 1;
      saveFileDialog.RestoreDirectory = true;

      DialogResult dialogResult = saveFileDialog.ShowDialog(this);
      if (dialogResult != DialogResult.OK) 
      {
        // aborted by user
        return;
      } // if

      using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName)) 
      {
        sw.Write(LogEventListToText(';'));
      } // using
    } // SaveToCsvFile()

    /// <summary>
    /// Appends the specified event to the log view.
    /// </summary>
    /// <param name="logEvent">The log event.</param>
    public void AppendLogEvent(ILogEvent logEvent)
    {
      if (!InvokeRequired)
      {
        if (((logEvent.Level == LogLevel.Debug) && (!checkShowDebug.Checked))
         || ((logEvent.Level == LogLevel.Error) && (!checkShowErrors.Checked))
         || ((logEvent.Level == LogLevel.Fatal) && (!checkShowErrors.Checked))
         || ((logEvent.Level == LogLevel.Info) && (!checkShowInfo.Checked))
         || ((logEvent.Level == LogLevel.Warn) && (!checkShowWarnings.Checked)))
        {
          // do not display
          return;
        } // if

        if (IsDisposed || (Handle == IntPtr.Zero))
        {
          return;
        } // if

        CheckMaxLength();

        ListViewItem item = new ListViewItem();
        item.ImageIndex = GetImageIndex(logEvent.Level);
        if (_hasColDate)
        {
          item.SubItems.Add(logEvent.Timestamp.ToShortDateString());
        } // if
        if (_hasColTime)
        {
          item.SubItems.Add(logEvent.Timestamp.ToString("T", _culture));
        } // if
        if (_hasColType)
        {
          item.SubItems.Add(logEvent.Level.ToString());
        } // if
        item.SubItems.Add(logEvent.Message);
        if (_addAtTail)
        {
          listView.Items.Add(item);
          listView.EnsureVisible(listView.Items.Count - 1);
        }
        else
        {
          // add at top of the list      
          listView.Items.Insert(0, item);
        } // if
      }
      else
      {
        // use BeginInvoke to execute the method asynchronously on the thread
        // that the control's underlying handle was created on.
        BeginInvoke(new AppendLogEventDelegate(AppendLogEvent),
          new object[] { logEvent });
      } // if
    } // AppendLogEvent()
    #endregion // PUBLIC METHODS
  } // TableLogView
} // Tethys.Logging.Controls

// ===============================================
// Tethys.Logging.Controls: end of TableLogView.cs
// ===============================================
