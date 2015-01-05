#region Header
// ---------------------------------------------------------------------------
// Tethys.Logging.NLog
// ===========================================================================
//
// This library contains common code of .Net projects of Thomas Graf.
//
// ===========================================================================
// <copyright file="RtfLogView.xaml.cs" company="Tethys">
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
// 10Oct18 1.00.00.00 tg: initial version of the NLog support libray.
// 12Jul20 1.00.01.00 tg: update for NLog 2.0.
//
// ---------------------------------------------------------------------------
#endregion

namespace Tethys.Logging.Controls.Wpf
{
  using System.Diagnostics.CodeAnalysis;
  using System.IO;
  using System.Windows;
  using System.Windows.Documents;
  using System.Windows.Media;

  /// <summary>
  /// Interaction logic for the Rtf log view.
  /// </summary>
  // ReSharper disable RedundantExtendsListEntry
  public sealed partial class RtfLogView : System.Windows.Controls.UserControl, ILogView
  // ReSharper restore RedundantExtendsListEntry
  {
    #region PRIVATE PROPERTIES
    /// <summary>
    /// The maximum chunk length.
    /// </summary>
    private const int MaxLogLengthChunk = 5000;
    #endregion PRIVATE PROPERTIES

    //// ---------------------------------------------------------------------

    #region DEPENDENCY PROPERTIES
    /// <summary>
    /// Dependency property for ShowToolButtons.
    /// </summary>
    public static readonly DependencyProperty ShowToolButtonsProperty =
      DependencyProperty.Register("ShowToolButtons", typeof(bool),
      typeof(RtfLogView),
      new PropertyMetadata(false, OnShowToolButtonsChanged));

    /// <summary>
    /// Gets or sets a value indicating whether to show the tool buttons.
    /// </summary>
    /// <value><c>true</c> if tool buttons are shown; otherwise, 
    /// <c>false</c>.</value>
    public bool ShowToolButtons
    {
      get { return (bool)GetValue(ShowToolButtonsProperty); }
      set { SetValue(ShowToolButtonsProperty, value); }
    }

    /// <summary>
    /// Called when the <see cref="ShowToolButtonsProperty"/> property has
    /// been changed.
    /// </summary>
    /// <param name="dependencyObject">The dependency object.</param>
    /// <param name="args">The
    /// <see cref="System.Windows.DependencyPropertyChangedEventArgs"/>
    /// instance containing the event data.</param>
    private static void OnShowToolButtonsChanged(DependencyObject dependencyObject,
      DependencyPropertyChangedEventArgs args)
    {
      RtfLogView view = dependencyObject as RtfLogView;
      if (view == null)
      {
        return;
      } // if

      view._checkShowDebugMessages.Visibility
        = (view.ShowDebugCheckBox && view.ShowToolButtons) ? Visibility.Visible
        : Visibility.Collapsed;
      view._btnClear.Visibility = view.ShowToolButtons ? Visibility.Visible
        : Visibility.Collapsed;
      view._btnCopy.Visibility = view.ShowToolButtons ? Visibility.Visible
        : Visibility.Collapsed;
      view._btnSave.Visibility = view.ShowToolButtons ? Visibility.Visible
        : Visibility.Collapsed;
      view._lblLabelText.Visibility = view.ShowToolButtons ? Visibility.Visible
        : Visibility.Collapsed;
    } // OnShowToolButtonsChanged()

    /// <summary>
    /// Dependency property for <c>AddAtTail</c>.
    /// </summary>
    public static readonly DependencyProperty AddAtTailProperty =
      DependencyProperty.Register("AddAtTail", typeof(bool), 
      typeof(RtfLogView));

    /// <summary>
    /// Gets or sets a value indicating whether to add new event at the end.
    /// </summary>
    public bool AddAtTail
    {
      get { return (bool)GetValue(AddAtTailProperty); }
      set { SetValue(AddAtTailProperty, value); }
    }

    /// <summary>
    /// Dependency property for <c>LabelText</c>.
    /// </summary>
    public static readonly DependencyProperty LabelTextProperty =
      DependencyProperty.Register("LabelText", typeof(string),
      typeof(RtfLogView));

    /// <summary>
    /// Gets or sets the label text.
    /// </summary>
    public string LabelText
    {
      get { return (string)GetValue(LabelTextProperty); }
      set { SetValue(LabelTextProperty, value); }
    }

    /// <summary>
    /// Dependency property for <c>MaxLogLength</c>.
    /// </summary>
    public static readonly DependencyProperty MaxLogLengthProperty =
      DependencyProperty.Register("MaxLogLength", typeof(int),
      typeof(RtfLogView));

    /// <summary>
    /// Gets or sets the maximum log length.
    /// </summary>
    public int MaxLogLength
    {
      get { return (int)GetValue(MaxLogLengthProperty); }
      set { SetValue(MaxLogLengthProperty, value); }
    }

    /// <summary>
    /// Dependency property for <c>ShowDebugCheckBox</c>.
    /// </summary>
    public static readonly DependencyProperty ShowDebugCheckBoxProperty =
      DependencyProperty.Register("ShowDebugCheckBox", typeof(bool),
      typeof(RtfLogView),
      new PropertyMetadata(false, OnShowDebugCheckBoxChanged));

    /// <summary>
    /// Gets or sets a value indicating whether to show the 'show debug'
    /// check box.
    /// </summary>
    public bool ShowDebugCheckBox
    {
      get { return (bool)GetValue(ShowDebugCheckBoxProperty); }
      set { SetValue(ShowDebugCheckBoxProperty, value); }
    }

    /// <summary>
    /// Called when the <see cref="ShowDebugCheckBoxProperty"/> property has
    /// been changed.
    /// </summary>
    /// <param name="dependencyObject">The dependency object.</param>
    /// <param name="args">The
    /// <see cref="System.Windows.DependencyPropertyChangedEventArgs"/>
    /// instance containing the event data.</param>
    private static void OnShowDebugCheckBoxChanged(DependencyObject dependencyObject,
      DependencyPropertyChangedEventArgs args)
    {
      RtfLogView view = dependencyObject as RtfLogView;
      if (view == null)
      {
        return;
      } // if

      view._checkShowDebugMessages.Visibility
        = (view.ShowDebugCheckBox && view.ShowToolButtons) ? Visibility.Visible
        : Visibility.Collapsed;
    } // OnShowDebugCheckBoxChanged()

    /// <summary>
    /// Dependency property for <c>ShowDebugEvents</c>.
    /// </summary>
    public static readonly DependencyProperty ShowDebugEventsProperty =
      DependencyProperty.Register("ShowDebugEvents", typeof(bool),
      typeof(RtfLogView),
      new PropertyMetadata(false, OnShowDebugEventsChanged));

    /// <summary>
    /// Gets or sets a value indicating whether to show debug events.
    /// </summary>
    public bool ShowDebugEvents
    {
      get { return (bool)GetValue(ShowDebugEventsProperty); }
      set { SetValue(ShowDebugEventsProperty, value); }
    }

    /// <summary>
    /// Called when the <see cref="ShowDebugEventsProperty"/> property has
    /// been changed.
    /// </summary>
    /// <param name="dependencyObject">The dependency object.</param>
    /// <param name="args">The
    /// <see cref="System.Windows.DependencyPropertyChangedEventArgs"/>
    /// instance containing the event data.</param>
    private static void OnShowDebugEventsChanged(DependencyObject dependencyObject,
      DependencyPropertyChangedEventArgs args)
    {
      RtfLogView view = dependencyObject as RtfLogView;
      if (view == null)
      {
        return;
      } // if

      view._checkShowDebugMessages.IsChecked = view.ShowDebugEvents;
    } // OnShowDebugEventsChanged()
    #endregion // DEPENDENCY PROPERTIES

    //// ---------------------------------------------------------------------

    #region CONSTRUCTION
    /// <summary>
    /// Initializes a new instance of the <see cref="RtfLogView"/> class.
    /// </summary>
    public RtfLogView()
    {
      InitializeComponent();
      MaxLogLength = -1;
      AddAtTail = true;
      LabelText = "Status:";
    } // RtfLogView()
    #endregion // CONSTRUCTION

    //// ---------------------------------------------------------------------

    #region UI HANDLING
    /// <summary>
    /// Handles the Loaded event of the UserControl control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> 
    /// instance containing the event data.</param>
    private void UserControlLoaded(object sender, RoutedEventArgs e)
    {
      this._checkShowDebugMessages.Visibility 
        = (this.ShowDebugCheckBox && ShowToolButtons) ? Visibility.Visible 
        : Visibility.Collapsed;
      this._checkShowDebugMessages.IsChecked = ShowDebugEvents;
      this._btnClear.Visibility = ShowToolButtons ? Visibility.Visible 
        : Visibility.Collapsed;
      this._btnCopy.Visibility = ShowToolButtons ? Visibility.Visible
        : Visibility.Collapsed;
      this._btnSave.Visibility = ShowToolButtons ? Visibility.Visible 
        : Visibility.Collapsed;
      this._lblLabelText.Visibility = ShowToolButtons ? Visibility.Visible
        : Visibility.Collapsed;
      this._lblLabelText.Text = LabelText;
    }
    
    /// <summary>
    /// Handles the Click event of the 'save button' control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/>
    /// instance containing the event data.</param>
    private void BtnSaveClick(object sender, RoutedEventArgs e)
    {
      SaveToTextFile();
    } // BtnSave_Click()

    /// <summary>
    /// Handles the Click event of the 'copy button' control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> 
    /// instance containing the event data.</param>
    private void BtnCopyClick(object sender, RoutedEventArgs e)
    {
      CopyToClipboard();
    } // BtnCopy_Click()

    /// <summary>
    /// Handles the Click event of the 'clear button' control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> 
    /// instance containing the event data.</param>
    private void BtnClearClick(object sender, RoutedEventArgs e)
    {
      Clear();
    } // BtnClear_Click
    #endregion // UI HANDLING

    //// ---------------------------------------------------------------------

    #region PUBLIC METHODS
    /// <summary>
    /// Adds a log event.
    /// </summary>
    /// <param name="logEvent">The log event.</param>
    public void AddLogEvent(ILogEvent logEvent)
    {
      Dispatcher.Invoke(
           System.Windows.Threading.DispatcherPriority.Normal,
           new System.Action(() => AddLogEventInternal(logEvent)));
    } // AddLogEvent()

    /// <summary>
    /// Adds a log event.
    /// </summary>
    /// <param name="logEvent">The log event.</param>
    private void AddLogEventInternal(ILogEvent logEvent)
    {
      if (logEvent.Level == LogLevel.Debug)
      {
        if ((this._checkShowDebugMessages.IsChecked == null)
          || (!(bool)this._checkShowDebugMessages.IsChecked))
        {
          return;
        } // if
        AppendText(logEvent.Message, Brushes.Blue);
      }
      else if ((logEvent.Level == LogLevel.Error)
        || (logEvent.Level == LogLevel.Fatal))
      {
        AppendText(logEvent.Message, Brushes.Red);
      }
      else if (logEvent.Level == LogLevel.Warn)
      {
        AppendText(logEvent.Message, Brushes.Orange);
      }
      else
      {
        AppendText(logEvent.Message, Brushes.Black);
      } // if
    } // AddLogEventInternal()

    /// <summary>
    /// Clears the status view.
    /// </summary>
    public void Clear()
    {
      this._rtfBox.SelectAll();
      this._rtfBox.Selection.ClearAllProperties();
      this._rtfBox.Selection.Text = string.Empty;
    } // Clear()

    /// <summary>
    /// Gets the text.
    /// </summary>
    /// <returns>The text.</returns>
    [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate",
      Justification = "This is ok here.")]
    public string GetText()
    {
      TextRange textRange = new TextRange(this._rtfBox.Document.ContentStart, 
        this._rtfBox.Document.ContentEnd);
      return textRange.Text.Replace("\r", "\r\n");
    } // GetText()

    /// <summary>
    /// Appends text to the current text of status view.
    /// </summary>
    /// <param name="text">text to add</param>
    /// <param name="color">color of the text</param>
    public void AppendText(string text, Brush color)
    {
      AppendTextInternal(text, color);
      
      // if ((IsDisposed) ||
      //  (!InvokeRequired && (Handle == IntPtr.Zero)))
      // {
      //  return;
      // } // if
      // // use BeginInvoke to execute the method asynchronously on the thread
      // // that the control's underlying handle was created on.
      // BeginInvoke(new AppendTextDelegate(AppendTextInternal),
      //  new object[] { text, color });
    } // AppendText()
    #endregion // PUBLIC METHODS

    //// ---------------------------------------------------------------------

    #region PRIVATE METHODS
    /// <summary>
    /// Copies the contents of the event log to the clipboard.
    /// </summary>
    private void CopyToClipboard()
    {
#if false
      // version 1 - without line breaks
      RtfBox.SelectAll();
      RtfBox.Copy();
#else
      // add to clipboard as normal text
      Clipboard.SetData(DataFormats.Text,
        GetText());
#endif
    } // CopyToClipBoard()

    /// <summary>
    /// Saves the contents of the event log to a text file.
    /// </summary>
    private void SaveToTextFile()
    {
      Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
      dlg.DefaultExt = ".txt";
      dlg.CheckFileExists = false;
      dlg.CheckPathExists = true;
      dlg.InitialDirectory = ".";
      dlg.Filter = @"Rich Text Files (*.rtf)|*.rtf|"
        + @"Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
      dlg.FilterIndex = 1;
      dlg.RestoreDirectory = true;

      bool? result = dlg.ShowDialog();
      if (!result.GetValueOrDefault(false))
      {
        // aborted by user
        return;
      } // if

      if (dlg.FilterIndex == 1)
      {
        WriteRichTextFile(dlg.FileName);
      }
      else
      {
        WriteTextFile(dlg.FileName);
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
        sw.WriteLine(GetText());
        sw.Flush();
      } // using
    } // WriteTextFile()

    /// <summary>
    /// Write the log window contents to a RTF file.
    /// </summary>
    /// <param name="fileName">Name of the file to write to.</param>
    private void WriteRichTextFile(string fileName)
    {
      using (FileStream fs = new FileStream(fileName,
      FileMode.OpenOrCreate, FileAccess.Write))
      {
        TextRange textRange = new TextRange(this._rtfBox.Document.ContentStart,
          this._rtfBox.Document.ContentEnd);
        textRange.Text = textRange.Text.Replace("\r", "\r\n");
        textRange.Save(fs, DataFormats.Rtf);
      } // using
    } // WriteRichTextFile()

    /// <summary>
    /// Checks for the maximum text display size.
    /// </summary>
    private void CheckForMaxSize()
    {
      if (MaxLogLength > 0)
      {
        TextPointer pointerStart = this._rtfBox.Document.ContentStart;
        if (pointerStart.GetOffsetToPosition(this._rtfBox.Document.ContentEnd) > 
          MaxLogLength + MaxLogLengthChunk)
        {
          TextPointer pointerEnd = pointerStart.GetPositionAtOffset(MaxLogLengthChunk);
          if (pointerEnd != null)
          {
            this._rtfBox.Selection.Select(pointerStart, pointerEnd);
            this._rtfBox.Selection.Text = string.Empty;
          } // if
        } // if
      } // if
    } // CheckForMaxSize()

    /// <summary>
    /// Appends text to the current text of status view.
    /// </summary>
    /// <param name="text">text to add</param>
    /// <param name="color">color of the text</param>
    private void AppendTextInternal(string text, Brush color)
    {
      CheckForMaxSize();

      TextRange tr;
      if (AddAtTail)
      {
        tr = new TextRange(this._rtfBox.Document.ContentEnd,
                           this._rtfBox.Document.ContentEnd);
      }
      else
      {
        tr = new TextRange(this._rtfBox.Document.ContentStart,
                           this._rtfBox.Document.ContentStart);
      } // if

      tr.Text = text + "\r";
      tr.ApplyPropertyValue(TextElement.ForegroundProperty, color);

      if (AddAtTail)
      {
        this._rtfBox.ScrollToEnd();
      } // if
    } // AppendTextInternal()
    #endregion // PRIVATE METHODS
  } // RtfLogView
} // Tethys.Logging.Controls.Wpf
