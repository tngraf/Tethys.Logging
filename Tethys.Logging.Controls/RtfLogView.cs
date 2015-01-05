#region Header
// ---------------------------------------------------------------------------
// TgLib.Logging.Controls
// ===========================================================================
//
// This library contains common code of .Net projects of Thomas Graf.
//
// ===========================================================================
// <copyright file="RtfLogView.cs" company="Thomas Graf">
// Copyright  2003 - 2013 by Thomas Graf
//            See the file "License.txt" for information on usage and 
//            redistribution of this file and for a DISCLAIMER OF ALL WARRANTIES.
// </copyright>
// 
// Version .. 1.00.00.00 of 13Mar09
// Project .. TgLib.Logging.NLog
// Creater .. Thomas Graf (tg)
// System ... Microsoft .Net Framework 4
// Tools .... Microsoft Visual Studio 2010
//
// Change Report
// 09Nov29 1.00.00.00 tg: initial version of the tglib.logging.controls libray.
// 09Dec22 1.00.00.01 tg: bugfix in SaveToTextFile().
//
// ---------------------------------------------------------------------------
#endregion

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
    // delegate to be used in case of callbacks comming from
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
    private Color _defaultTextColor;

    /// <summary>
    /// Defines whether new event are added at the tail or
    /// at the head of the list.
    /// </summary>
    private bool _addAtTail = true;

    /// <summary>
    /// Flag 'toolbar and caption visible'.
    /// </summary>
    private bool _toolbarVisible;
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
        return _defaultTextColor;
      }

      set
      {
        _defaultTextColor = value;
        rtfView.SelectionColor = _defaultTextColor;
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
        return _toolbarVisible;
      }

      set
      {
        _toolbarVisible = value;
        btnClear.Visible = value;
        btnCopy.Visible = value;
        btnSave.Visible = value;
        btnClear.Enabled = value;
        btnCopy.Enabled = value;
        btnSave.Enabled = value;
        lblStatus.Visible = value;
        lblStatus.Enabled = value;
        checkDebug.Visible = value;
        checkDebug.Enabled = value;

        CheckListHeight();
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
        return rtfView.Text;
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
        return rtfView;
      }
    } // RtfControl

    /// <summary>
    /// Gets or sets a value indicating whether new event are added at the tail or
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
    /// Gets or sets the label on the upper left corner of the control.
    /// </summary>
    [Description("Log view label text."),
    Category("Appearance")]
    public string LabelText
    {
      get { return lblStatus.Text; }
      set { lblStatus.Text = value; }
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
        return checkDebug.Visible && _toolbarVisible;
      }

      set 
      {
        if (_toolbarVisible)
        {
          checkDebug.Visible = value;
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
      get { return checkDebug.Checked; }
      set { checkDebug.Checked = value; }
    } // ShowDebugCheckBox
    #endregion PUBLIC PROPERTIES

    //// ---------------------------------------------------------------------

    #region CONSTRUCTION
    /// <summary>
    /// Initializes a new instance of the <see cref="RtfLogView"/> class.
    /// </summary>
    public RtfLogView()
    {
      InitControl();
      MaxLogLength = -1;
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
      Clear();
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
    /// Handles the Layout event of the RtfLogView control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="LayoutEventArgs"/> instance containing 
    /// the event data.</param>
    private void RtfLogViewOnLayout(object sender, LayoutEventArgs e)
    {
      int width = btnSave.Width;
      int height = btnSave.Height;

      btnSave.Location = new Point(Width - width, 1);
      btnCopy.Location = new Point(Width - (2 * width), 1);
      btnClear.Location = new Point(Width - (3 * width), 1);

      checkDebug.Location = new Point(Width - 
        ((3 * width) + 6 + checkDebug.Width), 5);
      
      // manual layout of all child controls
      rtfView.Bounds = new Rectangle(1, height + 1, Width - 1, 
        Height - height - 2);
    } // RtfLogViewOnLayout()
    #endregion // UI MANAGEMENT

    //// ---------------------------------------------------------------------

    #region PRIVATE METHODS
    /// <summary>
    /// Initializes this control.
    /// </summary>
    private void InitControl()
    {
      InitializeComponent();

      // store default text color
      _defaultTextColor = rtfView.SelectionColor;

      rtfView.ContextMenu = new ContextMenu();
      MenuItem mi = new MenuItem("Clear All");
      mi.Name = "menuContextClearAll";
      mi.Click += BtnClearClick;
      rtfView.ContextMenu.MenuItems.Add(mi);

      mi = new MenuItem("Copy");
      mi.Name = "menuContextCopy";
      mi.Click += BtnCopyClick;
      rtfView.ContextMenu.MenuItems.Add(mi);

      mi = new MenuItem("Save");
      mi.Name = "menuContextSave";
      mi.Click += BtnSaveClick;
      rtfView.ContextMenu.MenuItems.Add(mi);

      _addAtTail = true;
      _toolbarVisible = true;
    } // InitControl()

    /// <summary>
    /// Adapts the list height to current property settings.
    /// </summary>
    private void CheckListHeight()
    {
      if (!_toolbarVisible)
      {
        // enlarge table
        rtfView.Top = 0;
        rtfView.Height = Height;
      }
      else
      {
        // default size
        rtfView.Top = ToolbarHeight;
        rtfView.Height = Height - ToolbarHeight;
      } // if
    } // CheckListHeight()

    /// <summary>
    /// Copies the contents of the event log to the clipboard.
    /// </summary>
    private void CopyToClipboard()
    {
      rtfView.SelectAll();
      rtfView.Copy();
      
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
      SaveFileDialog saveFileDialog = new SaveFileDialog();
      saveFileDialog.CheckFileExists = false;
      saveFileDialog.CheckPathExists = true;
      saveFileDialog.InitialDirectory = ".";
      saveFileDialog.Filter = @"Rich Text Files (*.rtf)|*.rtf|"
        + @"Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
      saveFileDialog.FilterIndex = 1;
      saveFileDialog.RestoreDirectory = true;

      DialogResult dialogResult = saveFileDialog.ShowDialog(this);
      if (dialogResult != DialogResult.OK)
      {
        // aborted by user
        return;
      } // if

      if (saveFileDialog.FilterIndex == 1)
      {
        WriteRichTextFile(saveFileDialog.FileName);
      }
      else
      {
        WriteTextFile(saveFileDialog.FileName);
      } // if
    } // SaveToTextFile()

    /// <summary>
    /// Write the log window contents to a plain text file.
    /// </summary>
    /// <param name="fileName">Name of the file to write to.</param>
    private void WriteTextFile(string fileName)
    {
      using (StreamWriter sw = new StreamWriter(fileName))
      {
        foreach (string line in rtfView.Lines)
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
      using (StreamWriter sw = new StreamWriter(fileName))
      {
        sw.Write(rtfView.Rtf);
        sw.Flush();
      } // using
    } // WriteRichTextFile()

    /// <summary>
    /// Checks for the maximum text display size.
    /// </summary>
    private void CheckForMaxSize()
    {
      if ((MaxLogLength > 0) && 
        (rtfView.TextLength > MaxLogLength + MaxLogLengthChunk))
      {
        rtfView.SelectionStart = 0;
        rtfView.Select(0, MaxLogLengthChunk);
        rtfView.SelectedText = string.Empty;
      } // if
    } // CheckForMaxSize()

    /// <summary>
    /// Appends text to the current text of status view.
    /// </summary>
    /// <param name="text">text to add</param>
    /// <param name="color">color of the text</param>
    private void AppendTextInternal(string text, Color color)
    {
      CheckForMaxSize();

      if (!_addAtTail)
      {
        rtfView.SelectionStart = 0;
        rtfView.SelectionColor = color;
        rtfView.SelectedText = text;
      }
      else
      {
        rtfView.SelectionStart = 2000000000;
        rtfView.SelectionColor = color;
        rtfView.SelectedText = text;
      } // if

      rtfView.SelectionColor = _defaultTextColor;

      if (_addAtTail)
      {
        rtfView.Select(rtfView.TextLength, 0);
        rtfView.ScrollToCaret();
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
        if (!checkDebug.Checked)
        {
          return;
        } // if
        AppendText(logEvent.Message, Color.Blue);
      }
      else if ((logEvent.Level == LogLevel.Error)
        || (logEvent.Level == LogLevel.Fatal))
      {
        AppendText(logEvent.Message, Color.Red);
      }
      else if (logEvent.Level == LogLevel.Warn)
      {
        AppendText(logEvent.Message, Color.Orange);
      }
      else
      {
        AppendText(logEvent.Message, Color.Black);
      } // if
    } // AddLogEvent()

    /// <summary>
    /// Clears the status view.
    /// </summary>
    public void Clear()
    {
      rtfView.Text = string.Empty;
    } // Clear()

    /// <summary>
    /// Appends text to the current text of status view.
    /// </summary>
    /// <param name="text">text to add</param>
    /// <param name="color">color of the text</param>
    public void AppendText(string text, Color color)
    {
      if (IsDisposed ||
        (!InvokeRequired && (Handle == IntPtr.Zero)))
      {
        return;
      } // if

      // use BeginInvoke to execute the method asynchronously on the thread
      // that the control's underlying handle was created on.
      BeginInvoke(new AppendTextDelegate(AppendTextInternal),
        new object[] { text, color });
    } // AppendText()
    #endregion // PUBLIC METHODS
  } // RtfLogView
} // Tethys.Logging.Controls

// ============================================
// TgLib.Logging.Controls: end of RtfLogView.cs
// ============================================
