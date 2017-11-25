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
// System ... Portable Library
// Tools .... Microsoft Visual Studio 2013
//
// ---------------------------------------------------------------------------
#endregion

namespace TestApp.Common.Logging341
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
            this.InitializeComponent();

            // initialize logging
            this.ConfigureLogging();

            // ReSharper disable CoVariantArrayConversion
            this.comboEventType.Items.AddRange(this.eventTypes);
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
            global::Common.Logging.LogManager.Adapter
              = new CommonLoggingToLogViewAdapter(this.rtfLogView);

            log = global::Common.Logging.LogManager.GetCurrentClassLogger();
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
            this.comboEventType.SelectedIndex = 0;
            this.radioDefaultText.Checked = true;
        } // MainForm_Load()

        /// <summary>
        /// BTNs the add event click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance
        /// containing the event data.</param>
        private void BtnAddEventClick(object sender, EventArgs e)
        {
            this.AddEvent();
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
            this.txtEventText.Enabled = this.radioCustomText.Checked;
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
            var typeStr = (string)this.comboEventType.SelectedItem;
            var text = this.radioDefaultText.Checked 
                ? $"This is a {typeStr} message" : this.txtEventText.Text;

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
            var x = 0;
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