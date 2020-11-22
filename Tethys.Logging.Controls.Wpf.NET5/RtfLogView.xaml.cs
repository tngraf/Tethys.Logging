// --------------------------------------------------------------------------
// Tethys.Logging.Controls.WPF
// ==========================================================================
//
// A logging library for .NET Framework 4.5+ and .NET Core.
//
// ===========================================================================
//
// <copyright file="RtfLogView.xaml.cs" company="Tethys">
// Copyright  2009-2017 by Thomas Graf
//            All rights reserved.
//            Licensed under the Apache License, Version 2.0.
//            Unless required by applicable law or agreed to in writing,
//            software distributed under the License is distributed on an
//            "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
//            either express or implied.
// </copyright>
//
// ---------------------------------------------------------------------------

// ReSharper disable once CheckNamespace
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
          DependencyProperty.Register(
              "ShowToolButtons",
              typeof(bool),
              typeof(RtfLogView),
              new PropertyMetadata(false, OnShowToolButtonsChanged));

        /// <summary>
        /// Gets or sets a value indicating whether to show the tool buttons.
        /// </summary>
        /// <value><c>true</c> if tool buttons are shown; otherwise,
        /// <c>false</c>.</value>
        public bool ShowToolButtons
        {
            get { return (bool)this.GetValue(ShowToolButtonsProperty); }
            set { this.SetValue(ShowToolButtonsProperty, value); }
        }

        /// <summary>
        /// Called when the <see cref="ShowToolButtonsProperty"/> property has
        /// been changed.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <param name="args">The
        /// <see cref="System.Windows.DependencyPropertyChangedEventArgs"/>
        /// instance containing the event data.</param>
        private static void OnShowToolButtonsChanged(
            DependencyObject dependencyObject,
            DependencyPropertyChangedEventArgs args)
        {
            var view = dependencyObject as RtfLogView;
            if (view == null)
            {
                return;
            } // if

            view.CheckShowDebugMessages.Visibility
              = (view.ShowDebugCheckBox && view.ShowToolButtons) ? Visibility.Visible
              : Visibility.Collapsed;
            view.BtnClear.Visibility = view.ShowToolButtons ? Visibility.Visible
              : Visibility.Collapsed;
            view.BtnCopy.Visibility = view.ShowToolButtons ? Visibility.Visible
              : Visibility.Collapsed;
            view.BtnSave.Visibility = view.ShowToolButtons ? Visibility.Visible
              : Visibility.Collapsed;
            view.LblLabelText.Visibility = view.ShowToolButtons ? Visibility.Visible
              : Visibility.Collapsed;
        } // OnShowToolButtonsChanged()

        /// <summary>
        /// Dependency property for <c>AddAtTail</c>.
        /// </summary>
        public static readonly DependencyProperty AddAtTailProperty =
          DependencyProperty.Register(
              "AddAtTail",
              typeof(bool),
              typeof(RtfLogView));

        /// <summary>
        /// Gets or sets a value indicating whether to add new event at the end.
        /// </summary>
        public bool AddAtTail
        {
            get { return (bool)this.GetValue(AddAtTailProperty); }
            set { this.SetValue(AddAtTailProperty, value); }
        }

        /// <summary>
        /// Dependency property for <c>LabelText</c>.
        /// </summary>
        public static readonly DependencyProperty LabelTextProperty =
          DependencyProperty.Register(
              "LabelText",
              typeof(string),
              typeof(RtfLogView));

        /// <summary>
        /// Gets or sets the label text.
        /// </summary>
        public string LabelText
        {
            get { return (string)this.GetValue(LabelTextProperty); }
            set { this.SetValue(LabelTextProperty, value); }
        }

        /// <summary>
        /// Dependency property for <c>MaxLogLength</c>.
        /// </summary>
        public static readonly DependencyProperty MaxLogLengthProperty =
          DependencyProperty.Register(
              "MaxLogLength",
              typeof(int),
              typeof(RtfLogView));

        /// <summary>
        /// Gets or sets the maximum log length.
        /// </summary>
        public int MaxLogLength
        {
            get { return (int)this.GetValue(MaxLogLengthProperty); }
            set { this.SetValue(MaxLogLengthProperty, value); }
        }

        /// <summary>
        /// Dependency property for <c>ShowDebugCheckBox</c>.
        /// </summary>
        public static readonly DependencyProperty ShowDebugCheckBoxProperty =
          DependencyProperty.Register(
              "ShowDebugCheckBox",
              typeof(bool),
              typeof(RtfLogView),
              new PropertyMetadata(false, OnShowDebugCheckBoxChanged));

        /// <summary>
        /// Gets or sets a value indicating whether to show the 'show debug'
        /// check box.
        /// </summary>
        public bool ShowDebugCheckBox
        {
            get { return (bool)this.GetValue(ShowDebugCheckBoxProperty); }
            set { this.SetValue(ShowDebugCheckBoxProperty, value); }
        }

        /// <summary>
        /// Called when the <see cref="ShowDebugCheckBoxProperty"/> property has
        /// been changed.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <param name="args">The
        /// <see cref="System.Windows.DependencyPropertyChangedEventArgs"/>
        /// instance containing the event data.</param>
        private static void OnShowDebugCheckBoxChanged(
            DependencyObject dependencyObject,
            DependencyPropertyChangedEventArgs args)
        {
            var view = dependencyObject as RtfLogView;
            if (view == null)
            {
                return;
            } // if

            view.CheckShowDebugMessages.Visibility
              = (view.ShowDebugCheckBox && view.ShowToolButtons) ? Visibility.Visible
              : Visibility.Collapsed;
        } // OnShowDebugCheckBoxChanged()

        /// <summary>
        /// Dependency property for <c>ShowDebugEvents</c>.
        /// </summary>
        public static readonly DependencyProperty ShowDebugEventsProperty =
          DependencyProperty.Register(
              "ShowDebugEvents",
              typeof(bool),
              typeof(RtfLogView),
              new PropertyMetadata(false, OnShowDebugEventsChanged));

        /// <summary>
        /// Gets or sets a value indicating whether to show debug events.
        /// </summary>
        public bool ShowDebugEvents
        {
            get { return (bool)this.GetValue(ShowDebugEventsProperty); }
            set { this.SetValue(ShowDebugEventsProperty, value); }
        }

        /// <summary>
        /// Called when the <see cref="ShowDebugEventsProperty"/> property has
        /// been changed.
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <param name="args">The
        /// <see cref="System.Windows.DependencyPropertyChangedEventArgs"/>
        /// instance containing the event data.</param>
        private static void OnShowDebugEventsChanged(
            DependencyObject dependencyObject,
            DependencyPropertyChangedEventArgs args)
        {
            var view = dependencyObject as RtfLogView;
            if (view == null)
            {
                return;
            } // if

            view.CheckShowDebugMessages.IsChecked = view.ShowDebugEvents;
        } // OnShowDebugEventsChanged()
        #endregion // DEPENDENCY PROPERTIES

        //// ---------------------------------------------------------------------

        #region CONSTRUCTION
        /// <summary>
        /// Initializes a new instance of the <see cref="RtfLogView"/> class.
        /// </summary>
        public RtfLogView()
        {
            this.InitializeComponent();
            this.MaxLogLength = -1;
            this.AddAtTail = true;
            this.LabelText = "Status:";
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
            this.CheckShowDebugMessages.Visibility
              = (this.ShowDebugCheckBox && this.ShowToolButtons) ? Visibility.Visible
              : Visibility.Collapsed;
            this.CheckShowDebugMessages.IsChecked = this.ShowDebugEvents;
            this.BtnClear.Visibility = this.ShowToolButtons ? Visibility.Visible
              : Visibility.Collapsed;
            this.BtnCopy.Visibility = this.ShowToolButtons ? Visibility.Visible
              : Visibility.Collapsed;
            this.BtnSave.Visibility = this.ShowToolButtons ? Visibility.Visible
              : Visibility.Collapsed;
            this.LblLabelText.Visibility = this.ShowToolButtons ? Visibility.Visible
              : Visibility.Collapsed;
            this.LblLabelText.Text = this.LabelText;
        }

        /// <summary>
        /// Handles the Click event of the 'save button' control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/>
        /// instance containing the event data.</param>
        private void BtnSaveClick(object sender, RoutedEventArgs e)
        {
            this.SaveToTextFile();
        } // BtnSave_Click()

        /// <summary>
        /// Handles the Click event of the 'copy button' control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/>
        /// instance containing the event data.</param>
        private void BtnCopyClick(object sender, RoutedEventArgs e)
        {
            this.CopyToClipboard();
        } // BtnCopy_Click()

        /// <summary>
        /// Handles the Click event of the 'clear button' control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/>
        /// instance containing the event data.</param>
        private void BtnClearClick(object sender, RoutedEventArgs e)
        {
            this.Clear();
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
            this.Dispatcher.Invoke(
                 System.Windows.Threading.DispatcherPriority.Normal,
                 new System.Action(() => this.AddLogEventInternal(logEvent)));
        } // AddLogEvent()

        /// <summary>
        /// Adds a log event.
        /// </summary>
        /// <param name="logEvent">The log event.</param>
        private void AddLogEventInternal(ILogEvent logEvent)
        {
            if (logEvent.Level == LogLevel.Debug)
            {
                if ((this.CheckShowDebugMessages.IsChecked == null)
                  || (!(bool)this.CheckShowDebugMessages.IsChecked))
                {
                    return;
                } // if

                this.AppendText(logEvent.Message, Brushes.Blue);
            }
            else if ((logEvent.Level == LogLevel.Error)
              || (logEvent.Level == LogLevel.Fatal))
            {
                this.AppendText(logEvent.Message, Brushes.Red);
            }
            else if (logEvent.Level == LogLevel.Warn)
            {
                this.AppendText(logEvent.Message, Brushes.Orange);
            }
            else
            {
                this.AppendText(logEvent.Message, Brushes.Black);
            } // if
        } // AddLogEventInternal()

        /// <summary>
        /// Clears the status view.
        /// </summary>
        public void Clear()
        {
            this.RtfBox.SelectAll();
            this.RtfBox.Selection.ClearAllProperties();
            this.RtfBox.Selection.Text = string.Empty;
        } // Clear()

        /// <summary>
        /// Gets the text.
        /// </summary>
        /// <returns>The text.</returns>
        [SuppressMessage(
            "Microsoft.Design",
            "CA1024:UsePropertiesWhereAppropriate",
            Justification = "This is ok here.")]
        public string GetText()
        {
            var textRange = new TextRange(
                this.RtfBox.Document.ContentStart,
                this.RtfBox.Document.ContentEnd);
            return textRange.Text.Replace("\r", "\r\n");
        } // GetText()

        /// <summary>
        /// Appends text to the current text of status view.
        /// </summary>
        /// <param name="text">text to add.</param>
        /// <param name="color">color of the text.</param>
        public void AppendText(string text, Brush color)
        {
            this.AppendTextInternal(text, color);
        } // AppendText()
        #endregion // PUBLIC METHODS

        //// ---------------------------------------------------------------------

        #region PRIVATE METHODS
        /// <summary>
        /// Copies the contents of the event log to the clipboard.
        /// </summary>
        private void CopyToClipboard()
        {
            // add to clipboard as normal text
            Clipboard.SetData(
                DataFormats.Text,
                this.GetText());
        } // CopyToClipBoard()

        /// <summary>
        /// Saves the contents of the event log to a text file.
        /// </summary>
        private void SaveToTextFile()
        {
            var dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.DefaultExt = ".txt";
            dlg.CheckFileExists = false;
            dlg.CheckPathExists = true;
            dlg.InitialDirectory = ".";
            dlg.Filter = @"Rich Text Files (*.rtf)|*.rtf|"
              + @"Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            dlg.FilterIndex = 1;
            dlg.RestoreDirectory = true;

            var result = dlg.ShowDialog();
            if (!result.GetValueOrDefault(false))
            {
                // aborted by user
                return;
            } // if

            if (dlg.FilterIndex == 1)
            {
                this.WriteRichTextFile(dlg.FileName);
            }
            else
            {
                this.WriteTextFile(dlg.FileName);
            } // if
        } // SaveToTextFile()

        /// <summary>
        /// Write the log window contents to a plain text file.
        /// </summary>
        /// <param name="fileName">Name of the file to write to.</param>
        private void WriteTextFile(string fileName)
        {
            using var sw = new StreamWriter(fileName);
            sw.WriteLine(this.GetText());
            sw.Flush();
        } // WriteTextFile()

        /// <summary>
        /// Write the log window contents to a RTF file.
        /// </summary>
        /// <param name="fileName">Name of the file to write to.</param>
        private void WriteRichTextFile(string fileName)
        {
            using var fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
            var textRange = new TextRange(
                this.RtfBox.Document.ContentStart,
                this.RtfBox.Document.ContentEnd);
            textRange.Text = textRange.Text.Replace("\r", "\r\n");
            textRange.Save(fs, DataFormats.Rtf);
        } // WriteRichTextFile()

        /// <summary>
        /// Checks for the maximum text display size.
        /// </summary>
        private void CheckForMaxSize()
        {
            if (this.MaxLogLength > 0)
            {
                var pointerStart = this.RtfBox.Document.ContentStart;
                if (pointerStart.GetOffsetToPosition(this.RtfBox.Document.ContentEnd) >
                    this.MaxLogLength + MaxLogLengthChunk)
                {
                    var pointerEnd = pointerStart.GetPositionAtOffset(MaxLogLengthChunk);
                    if (pointerEnd != null)
                    {
                        this.RtfBox.Selection.Select(pointerStart, pointerEnd);
                        this.RtfBox.Selection.Text = string.Empty;
                    } // if
                } // if
            } // if
        } // CheckForMaxSize()

        /// <summary>
        /// Appends text to the current text of status view.
        /// </summary>
        /// <param name="text">text to add.</param>
        /// <param name="color">color of the text.</param>
        private void AppendTextInternal(string text, Brush color)
        {
            this.CheckForMaxSize();

            TextRange tr;
            if (this.AddAtTail)
            {
                tr = new TextRange(
                    this.RtfBox.Document.ContentEnd,
                    this.RtfBox.Document.ContentEnd);
            }
            else
            {
                tr = new TextRange(
                    this.RtfBox.Document.ContentStart,
                    this.RtfBox.Document.ContentStart);
            } // if

            tr.Text = text + "\r";
            tr.ApplyPropertyValue(TextElement.ForegroundProperty, color);

            if (this.AddAtTail)
            {
                this.RtfBox.ScrollToEnd();
            } // if
        } // AppendTextInternal()
        #endregion // PRIVATE METHODS
    } // RtfLogView
} // Tethys.Logging.Controls.Wpf
