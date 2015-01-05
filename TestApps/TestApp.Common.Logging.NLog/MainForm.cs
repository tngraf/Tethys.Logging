#region Header
// --------------------------------------------------------------------------
// TestApplication.Common.Logging.NLog
// ==========================================================================
//
// A portable logging library for .NET Framework 4.5, Silverlight 4 and 
// higher, Windows Phone 7 and higher and .NET for Windows Store apps.
//
// ==========================================================================
// <copyright file="MainForm.cs" company="Tethys">
// Copyright  2013 by Thomas Graf
//            All rights reserved.
//            See the file "License.txt" for information on usage and 
//            redistribution of this file and for a 
//            DISCLAIMER OF ALL WARRANTIES.
// </copyright>
// 
// Version .. 1.00.00.00 of 13Mar26
// System ... .Net Framework 4.0
// Tools .... Microsoft Visual Studio 2012
//
// Change Report
// 13Mar21 1.00.00.00 tg: initial version.
//
// ---------------------------------------------------------------------------
#endregion

#define TEST_EXCEPTIONS

namespace TestApplication.Common.Logging.NLog
{
  using System;
  using System.Collections.Specialized;
  using System.Diagnostics;
  using System.IO;
  using System.Threading;
  using System.Windows.Forms;

  using Tethys.Logging.Controls;
  using Tethys.Logging.NLog;

  /// <summary>
  /// Application main form class.
  /// </summary>
  public partial class MainForm : Form
  {
    /// <summary>
    /// Native Common.Logging logger.
    /// </summary>
    private static global::Common.Logging.ILog _log;

    /// <summary>
    /// Debug trace form.
    /// </summary>
    private readonly DebugLogForm _debugTraceForm;

    /// <summary>
    /// Event type string.
    /// </summary>
    private readonly string[] _eventTypes =
      {
        "Debug", "Info", "Warning", "Error", "Fatal"
      };

    #region CONSTRUCTION
    /// <summary>
    /// Initializes a new instance of the <see cref="MainForm"/> class.
    /// </summary>
    public MainForm()
    {
      InitializeComponent();

      // initializes debug trace window
      _debugTraceForm = new DebugLogForm();

      // initialize logging
      ConfigureLogging();

      comboEventType.Items.AddRange(_eventTypes);

      // test for maximum log display
      rtfLogView.ShowDebugCheckBox = false;

      // Note: without the folloing limitations, the system will after some
      // time take ALL available time only to update the debug trace window
      // and the application will FREEZE!
      rtfLogView.MaxLogLength = 1000000; // 5000;
      rtfLogView.ShowDebugEvents = true;
      tableLogView.MaxLogEntries = 500;
      _debugTraceForm.RtfLogView.MaxLogLength = 5000;
    } // MainForm()

    /// <summary>
    /// Configure logging.
    /// </summary>
    private void ConfigureLogging()
    {
      ConfigureNLogLogging(true, false, true, true, false);

      // ----- Common.Logging logging -----
      // var properties = new Dictionary<string, string>();
      var properties = new NameValueCollection();
      properties["configType"] = "INLINE";

      global::Common.Logging.LogManager.Adapter
        = new global::Common.Logging.NLog.NLogLoggerFactoryAdapter(properties);

      // set logger for this class
      _log = global::Common.Logging.LogManager.GetCurrentClassLogger();
    } // ConfigureLogging()

    /// <summary>
    /// Configure NLog logging.
    /// </summary>
    /// <param name="rtfLog">if set to <c>true</c> use the RTF log.</param>
    /// <param name="consoleLog">if set to <c>true</c> use console log.</param>
    /// <param name="debugTraceLog">if set to <c>true</c> use debug trace log.</param>
    /// <param name="tableLog">if set to <c>true</c> use table log.</param>
    /// <param name="fileLog">if set to <c>true</c> use file log.</param>
    private void ConfigureNLogLogging(bool rtfLog, bool consoleLog, 
      bool debugTraceLog, bool tableLog, bool fileLog)
    {
      // using this line does log all messages
      // NLog.Config.SimpleConfigurator.ConfigureForTargetLogging(target, LogLevel.Debug);
      global::NLog.Config.LoggingConfiguration config
        = global::NLog.LogManager.Configuration ?? new global::NLog.Config.LoggingConfiguration();
      
      // create & add targets
      global::NLog.Targets.FileTarget targetFile = new global::NLog.Targets.FileTarget();
      global::NLog.Config.LoggingRule rule;
      if (rtfLog)
      {
        global::NLog.Targets.TargetWithLayout targetRtf = new NLogTargetToLogViewAdapter(rtfLogView);
        targetRtf.Layout = "${date:format=yyyy-MM-dd,HH\\:mm\\:ss}: ${message}\r\n";
        config.AddTarget("RtfLogView", targetRtf);

        rule = new global::NLog.Config.LoggingRule("*", global::NLog.LogLevel.Debug, targetRtf);
        
        // rule.Filters.Add(new SingleLogLevelFilter(LogLevel.Info));
        config.LoggingRules.Add(rule);
      } // if

      if (consoleLog)
      {
        global::NLog.Targets.TargetWithLayout targetConsole = new global::NLog.Targets.ColoredConsoleTarget();
        targetConsole.Layout = "${date:format=yyyy-MM-dd,HH\\:mm\\:ss}: ${logger} ${message}";
        config.AddTarget("Console", targetConsole);

        rule = new global::NLog.Config.LoggingRule("*", global::NLog.LogLevel.Debug, targetConsole);
        config.LoggingRules.Add(rule);
      } // if

      if (debugTraceLog)
      {
        global::NLog.Targets.TargetWithLayout targetDebugTrace = new NLogTargetToLogViewAdapter(_debugTraceForm.RtfLogView);
        targetDebugTrace.Layout = "${date:format=yyyy-MM-dd,HH\\:mm\\:ss}: ${message}\r\n";
        config.AddTarget("DebugTraceView", targetDebugTrace);

        rule = new global::NLog.Config.LoggingRule("*", global::NLog.LogLevel.Debug, targetDebugTrace);
        config.LoggingRules.Add(rule);
      } // if

      if (tableLog)
      {
        global::NLog.Targets.TargetWithLayout targetLog = new NLogTargetToLogViewAdapter(tableLogView);
        targetLog.Layout = "${message}";
        config.AddTarget("TableLogView", targetLog);

        rule = new global::NLog.Config.LoggingRule("*", global::NLog.LogLevel.Debug, targetLog);
        config.LoggingRules.Add(rule);
      } // if
      
      if (fileLog)
      {
        FileInfo fi = new FileInfo(Application.ExecutablePath);
        string logfolder = string.IsNullOrEmpty(fi.DirectoryName) ? "." 
          : fi.DirectoryName;
        targetFile.FileName = Path.Combine(logfolder, "logfile.txt");
        targetFile.Layout = "${date:format=yyyy-MM-dd,HH\\:mm\\:ss}: ${level} ${message}";
        targetFile.ArchiveFileName = Path.Combine(logfolder, "log.{#####}.txt");
        targetFile.ArchiveAboveSize = 1048576;
        targetFile.ArchiveNumbering = global::NLog.Targets.ArchiveNumberingMode.Rolling;
        targetFile.MaxArchiveFiles = 10;
        targetFile.AutoFlush = true;
        targetFile.Header = "[Tethys.Logging.TestApplication logging started]";
        targetFile.Footer = "[Tethys.Logging.TestApplication logging stopped]\r\n--------------------------------------------------------------";

        rule = new global::NLog.Config.LoggingRule("*", global::NLog.LogLevel.Debug, targetFile);
        config.LoggingRules.Add(rule);
      } // if

      // IMPORTANT
      // You have to get the current NLog configuration, make changes to this
      // LoggingConfiguration object, then assign it back to 
      // LogManager.Configuration. Adding targets and rultes directly to 
      // NLog.LogManager.Configuration does not work!
      global::NLog.LogManager.Configuration = config;
    } // ConfigureNLogLogging()
    #endregion // CONSTRUCTION

    //// ----------------------------------------------------------------------

    #region UI HANDLING
    /// <summary>
    /// Handles the Load event of the MainForm control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance
    /// containing the event data.</param>
    private void MainFormLoad(object sender, EventArgs e)
    {
      comboEventType.SelectedIndex = 0;
      radioDefaultText.Checked = true;
      _debugTraceForm.Show(this);
    } // MainForm_Load()

    /// <summary>
    /// BTNs the add event click.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance
    /// containing the event data.</param>
    private void BtnAddEventClick(object sender, EventArgs e)
    {
      AddEvent();
    } // btnAddEvent_Click()

    /// <summary>
    /// BTNs the add all events click.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance
    /// containing the event data.</param>
    private void BtnAddAllEventsClick(object sender, EventArgs e)
    {
      AddDummyEvents();
    } // btnAddAllEvents_Click()

    /// <summary>
    /// Checks the changed.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance
    /// containing the event data.</param>
    private void CheckChanged(object sender, EventArgs e)
    {
      txtEventText.Enabled = radioCustomText.Checked;
    } // btnAddEvent_Click()

    /// <summary>
    /// Handles the FormClosing event of the MainForm control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Windows.Forms.FormClosingEventArgs"/> 
    /// instance containing the event data.</param>
    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      _debugTraceForm.Close();
      e.Cancel = false;
    } // MainForm_FormClosing()

    /// <summary>
    /// Handles the FormClosed event of the MainForm control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Windows.Forms.FormClosedEventArgs"/>
    /// instance containing the event data.</param>
    private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
    {
      global::NLog.LogManager.DisableLogging();
    } // MainForm_FormClosed()

    /// <summary>
    /// Starts a second thread to add events.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance
    /// containing the event data.</param>
    private void BtnThreadTestClick(object sender, EventArgs e)
    {
      Thread testThread = new Thread(Worker);
      testThread.Start();
    } 
    #endregion // UI HANDLING

    //// ----------------------------------------------------------------------

    #region CORE FUNCTIONALITY
    /// <summary>
    /// A simple worker method to add events.
    /// </summary>
    private static void Worker()
    {
      int count = 0;
      while (count < /*100000*/ 1000)
      {
        AddDummyEvents();
        count++;
        Thread.Sleep(5);

        if ((count % 100) == 0)
        {
          Thread.Sleep(100);
        }
      } // while
    } // Worker()

    /// <summary>
    /// Adds an event.
    /// </summary>
    private void AddEvent()
    {
      string typeStr = (string)comboEventType.SelectedItem;

      string text = radioDefaultText.Checked ? 
       string.Format("This is a {0} message", typeStr) 
                      : txtEventText.Text;

      switch (typeStr)
      {
        case "Debug":
          _log.Debug(text);
          break;
        case "Info":
          _log.Info(text);
          break;
        case "Warning":
          _log.Warn(text);
          break;
        case "Error":
          _log.Error(text);
          break;
        case "Fatal":
          _log.Fatal(text);
          break;
        default:
          Debug.Assert(false, "This must not happen!");
          break;
      } // switch
    } // AddEvent()

    /// <summary>
    /// Adds dummy events.
    /// </summary>
    private static void AddDummyEvents()
    {
      _log.Debug("This is a dummy debug message");
      _log.Info("This is a dummy info message");
      _log.Warn("This is a dummy warning message");
      _log.Error("This is a dummy error message");
      _log.Fatal("This is a dummy fatal message");

#if TEST_EXCEPTIONS
      // log exception
      int x = 0;
      try
      {
        // force exception
// ReSharper disable RedundantAssignment
        x = 1 / x;
// ReSharper restore RedundantAssignment
      }
      catch (Exception ex)
      {
        _log.Error("Exception: ", ex);
      } // catch
#endif
    } // AddDummyEvents()
    #endregion // CORE FUNCTIONALITY
  } // MainForm
} // TestApplication.Common.Logging.NLog
