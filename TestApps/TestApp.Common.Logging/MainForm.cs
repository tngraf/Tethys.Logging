#region Header
// --------------------------------------------------------------------------
// Tethys.Logging
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
// Version .. 1.00.00.00 of 13Mar21
// System ... Portable Library
// Tools .... Microsoft Visual Studio 2012
//
// Change Report
// 13Mar21 1.00.00.00 tg: initial version.
//
// ---------------------------------------------------------------------------
#endregion

namespace TestApplication.Common.Logging
{
  using System;
  using System.Diagnostics;
  using System.Windows.Forms;

  using global::Common.Logging;

  using Tethys.Logging.Common.Logging;

  /// <summary>
  /// Main form of the application.
  /// </summary>
  public partial class MainForm : Form
  {
    /// <summary>
    /// Common.Logging logger (more abstract).
    /// </summary>
    private static ILog log;

    /// <summary>
    /// Event strings.
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

      // initialize logging
      ConfigureLogging();

// ReSharper disable CoVariantArrayConversion
      comboEventType.Items.AddRange(_eventTypes);
// ReSharper restore CoVariantArrayConversion
    } // MainForm()

    /// <summary>
    /// Configure logging.
    /// </summary>
    private void ConfigureLogging()
    {
      // ok
      // Common.Logging.LogManager.Adapter
      //  = new Common.Logging.Simple.ConsoleOutLoggerFactoryAdapter();
      LogManager.Adapter 
        = new CommonLoggingToLogViewAdapter(rtfLogView);

      log = LogManager.GetCurrentClassLogger();
    } // ConfigureLogging()
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
    /// <param name="e">The <see cref="FormClosingEventArgs"/> instance
    /// containing the event data.</param>
    private void MainFormFormClosing(object sender, FormClosingEventArgs e)
    {
      e.Cancel = false;
    }

    /// <summary>
    /// Handles the FormClosed event of the MainForm control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="FormClosedEventArgs"/> instance
    /// containing the event data.</param>
    private void MainFormFormClosed(object sender, FormClosedEventArgs e)
    {
    }
    #endregion // UI HANDLING

    //// ----------------------------------------------------------------------

    #region CORE FUNCTIONALITY
    /// <summary>
    /// Adds the event.
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
          log.Debug(text);
          break;
        case "Info":
          log.Info(text);
          break;
        case "Warning":
          log.Warn(text);
          break;
        case "Error":
          log.Error(text);
          break;
        case "Fatal":
          log.Fatal(text);
          break;
        default:
          Debug.Assert(false, "This must not happen!");
          break;
      } // switch
    } // AddEvent()

    /// <summary>
    /// Adds the dummy events.
    /// </summary>
    private static void AddDummyEvents()
    {
      log.Debug("This is a dummy debug message");
      log.Info("This is a dummy info message");
      log.Warn("This is a dummy warning message");
      log.Error("This is a dummy error message");
      log.Fatal("This is a dummy fatal message");

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
        log.Error("Exception: ", ex);
      } // catch
    } // AddDummyEvents()
    #endregion // CORE FUNCTIONALITY
  }
} // TestApplication.Common.Logging