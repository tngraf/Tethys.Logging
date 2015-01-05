﻿#region Header
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
// </copyright>
// 
// Version .. 1.00.00.00 of 13Mar26
// System ... Portable Library
// Tools .... Microsoft Visual Studio 2012
//
// Change Report
// 13Mar21 1.00.00.00 tg: initial version.
//
// ---------------------------------------------------------------------------
#endregion

namespace TestApp.WindowsForms
{
  using System;
  using System.Globalization;
  using System.Threading;
  using System.Windows.Forms;

  using Tethys.Logging;
  using Tethys.Logging.Simple;
  using Tethys.Logging.Test;

  /// <summary>
  /// Main form class of this application.
  /// </summary>
  public partial class MainForm : Form
  {
    #region PRIVATE PROPERTIES
    /// <summary>
    /// Logger for use in this class.
    /// </summary>
    private static ILog log;

    /// <summary>
    /// Event type texts.
    /// </summary>
    private readonly string[] _eventTypes = 
    {
      "Debug", "Info", "Warning", "Error", "Fatal"
    };
    #endregion // PRIVATE PROPERTIES

    //// -----------------------------------------------------------------------

    #region CONSTRUCTION
    /// <summary>
    /// Initializes a new instance of the <see cref="MainForm"/> class.
    /// </summary>
    public MainForm()
    {
      // Set default culture for this application
      // This is needed since we do not support ALL languages...
      Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");

      this.InitializeComponent();

// ReSharper disable CoVariantArrayConversion
      this.comboEventType.Items.AddRange(this._eventTypes);
// ReSharper restore CoVariantArrayConversion
      this.comboEventType.SelectedIndex = 0;
      this.radioDefaultText.Checked = true;

      this.ConfigureLogging();
    } // // MainForm()
    #endregion // CONSTRUCTION

    //// -----------------------------------------------------------------------

    #region UI MANAGEMENT
    /// <summary>
    /// Is called when the form has been loaded.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the
    /// event data.</param>
    private void MainFormLoad(object sender, EventArgs e)
    {
    } // MainFormLoad()

    /// <summary>
    /// Is called when the form is about to close.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="FormClosingEventArgs"/> instance
    /// containing the event data.</param>
    private void MainFormFormClosing(object sender, FormClosingEventArgs e)
    {
      e.Cancel = false;
    } // MainFormFormClosing()

    /// <summary>
    /// Adds a new event.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing
    /// the event data.</param>
    private void BtnAddEventClick(object sender, EventArgs e)
    {
      this.AddEvent();
    } // btnAddEvent_Click()

    /// <summary>
    /// Adds dummy events of all types.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing 
    /// the event data.</param>
    private void BtnAddAllEventsClick(object sender, EventArgs e)
    {
      LogTest.AddDummyEvents(log);
    } // btnAddAllEvents_Click()
    #endregion // UI MANAGEMENT

    //// -----------------------------------------------------------------------

    #region CORE METHODS
    /// <summary>
    /// Configures the logging.
    /// </summary>
    private void ConfigureLogging()
    {
      LogManager.Adapter = new DebugLoggerFactoryAdapter();
      log = LogManager.GetLogger(typeof(MainForm));
    } // ConfigureLogging()

    /// <summary>
    /// Adds a new event.
    /// </summary>
    private void AddEvent()
    {
      string typeStr = (string)this.comboEventType.SelectedItem;
      string text;

      if (this.radioDefaultText.Checked)
      {
        text = string.Format("This is a {0} message", typeStr);
      }
      else
      {
        text = this.txtEventText.Text;
      } // if

      LogTest.AddEvent(log, typeStr, text);
    } // AddEvent()

    #endregion // CORE METHODS
  } // MainForm
} // TestApplication
