#region Header
// --------------------------------------------------------------------------
// Tethys.Logging
// ==========================================================================
//
// A (portable) logging library for .NET Framework 4.5, Silverlight 4 and 
// higher, Windows Phone 7 and higher and .NET for Windows Store apps.
//
// ===========================================================================
//
// <copyright file="MainForm.cs" company="Tethys">
// Copyright  2009-2015 by Thomas Graf
//            All rights reserved.
//            Licensed under the Apache License, Version 2.0.
//            Unless required by applicable law or agreed to in writing, 
//            software distributed under the License is distributed on an
//            "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
//            either express or implied. 
// </copyright>
//
// ---------------------------------------------------------------------------
#endregion

namespace TestApp.LogView
{
  using System;
  using System.Windows.Forms;

  using Tethys.Logging;

  /// <summary>
  /// Main form of the application.
  /// </summary>
  public partial class MainForm : Form
  {
    /// <summary>
    /// Event strings.
    /// </summary>
    private readonly string[] eventTypes =
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
      comboEventType.Items.AddRange(this.eventTypes);
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
        = new LogViewFactoryAdapter(rtfLogView);

      // ----- Application -----
      LogAppCore.ConfigureLogging();
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
      string typeStr = (string)comboEventType.SelectedItem;
      if (radioDefaultText.Checked)
      {
        LogAppCore.AddEvent(typeStr);
      }
      else
      {
        LogAppCore.AddEvent(typeStr, txtEventText.Text);
      } // if
    } // btnAddEvent_Click()

    /// <summary>
    /// BTNs the add all events click.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance
    /// containing the event data.</param>
    private void BtnAddAllEventsClick(object sender, EventArgs e)
    {
      LogAppCore.AddDummyEvents();
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
    #endregion // UI HANDLING

    //// ----------------------------------------------------------------------
  } // MainForm
} // TestApp.LogView
