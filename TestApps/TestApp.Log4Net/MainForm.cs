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

namespace TestApplication
{
    using System;
    using System.Diagnostics;
    using System.Globalization;
    using System.Threading;
    using System.Windows.Forms;

    using log4net;
    using log4net.Config;
    using log4net.Core;
    using log4net.Layout;

    using Tethys.Logging.Controls;
    using Tethys.Logging.Log4Net;

    /// <summary>
    /// Main form of the application.
    /// </summary>
    public partial class MainForm : Form
    {
        #region PRIVATE PROPERTIES
        /// <summary>
        /// Logger for use in this class.
        /// </summary>
        private static readonly ILog Log =
          LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Event strings.
        /// </summary>
        private readonly string[] eventTypes =
          {
        "Debug", "Info", "Warning", "Error", "Fatal"
      };

        /// <summary>
        /// The debug log form.
        /// </summary>
        private readonly DebugLogForm debugLogForm;

        /// <summary>
        /// First log4net adapter.
        /// </summary>
        private Log4NetTargetToLogViewAdapter log4NetAdapter1;

        /// <summary>
        /// Second log4net adapter.
        /// </summary>
        private Log4NetTargetToLogViewAdapter log4NetAdapter2;

        /// <summary>
        /// Third log4net adapter.
        /// </summary>
        private Log4NetTargetToLogViewAdapter log4NetAdapter3;
        #endregion // PRIVATE PROPERTIES

        //// ---------------------------------------------------------------------

        #region CONSTRUCTION
        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            // Set default culture for this application
            // This is needed since we do not support ALL languages...
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("de-de");

            this.InitializeComponent();

            // ReSharper disable once CoVariantArrayConversion
            this.comboEventType.Items.AddRange(this.eventTypes);
            this.comboEventType.SelectedIndex = 0;
            this.radioDefaultText.Checked = true;

            this.debugLogForm = new DebugLogForm();
            this.debugLogForm.HidingEvent += this.OnDebugLogFormHiding;

            this.ConfigureLogging();
        } // // MainForm()
        #endregion // CONSTRUCTION

        //// ---------------------------------------------------------------------

        #region UI MANAGEMENT
        /// <summary>
        /// Is called when the form has been loaded.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing
        /// the event data.</param>
        private void MainFormLoad(object sender, EventArgs e)
        {
            this.propertyGridRtf.CommandsVisibleIfAvailable = true;
            this.propertyGridRtf.SelectedObject = this.simpleRtfLogView;
            this.propertyGridTable.CommandsVisibleIfAvailable = true;
            this.propertyGridTable.SelectedObject = this.tableLogView;
        } // MainForm_Load()

        /// <summary>
        /// Is called when the form is about to close.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="FormClosingEventArgs"/> instance
        /// containing the event data.</param>
        private void MainFormFormClosing(object sender, FormClosingEventArgs e)
        {
            this.debugLogForm.Close();
            e.Cancel = false;
        } // MainForm_FormClosing()

        /// <summary>
        /// Adds a new event.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance
        /// containing the event data.</param>
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
            AddDummyEvents();
        } // btnAddAllEvents_Click()

        /// <summary>
        /// Checks the show debug log form checked changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the
        /// event data.</param>
        private void CheckShowDebugLogFormCheckedChanged(object sender, EventArgs e)
        {
            if (this.checkShowDebugLogForm.Checked)
            {
                this.debugLogForm.Show(this);
            }
            else
            {
                this.debugLogForm.Hide();
            } // if
        } // checkShowDebugLogForm_CheckedChanged()

        /// <summary>
        /// Is called when the debug log form has been closed (hidden) by the user.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing
        /// the event data.</param>
        private void OnDebugLogFormHiding(object sender, EventArgs e)
        {
            this.checkShowDebugLogForm.Checked = false;
        } // OnDebugLogFormHiding()
        #endregion // UI MANAGEMENT

        //// ---------------------------------------------------------------------

        #region CORE METHODS
        /// <summary>
        /// Configures the logging.
        /// </summary>
        private void ConfigureLogging()
        {
            this.log4NetAdapter1 = new Log4NetTargetToLogViewAdapter(this.simpleRtfLogView);
            this.log4NetAdapter1.Layout
              = new PatternLayout("%date %-5level %logger - %message%newline");
            this.log4NetAdapter1.AddFilter(new LogLevelFilter(Level.Info));
            BasicConfigurator.Configure(this.log4NetAdapter1);

            this.log4NetAdapter2 = new Log4NetTargetToLogViewAdapter(this.tableLogView);
            this.log4NetAdapter2.Layout
              = new PatternLayout("%message%newline");
            BasicConfigurator.Configure(this.log4NetAdapter2);

            this.log4NetAdapter3 = new Log4NetTargetToLogViewAdapter(this.debugLogForm.RtfLogView);
            this.log4NetAdapter3.Layout =
              new PatternLayout("%date %-5level %logger - %message%newline");
            BasicConfigurator.Configure(this.log4NetAdapter3);
        } // ConfigureLogging()

        /// <summary>
        /// Adds a new event.
        /// </summary>
        private void AddEvent()
        {
            var typeStr = (string)this.comboEventType.SelectedItem;
            string text;

            if (this.radioDefaultText.Checked)
            {
                text = $"This is a {typeStr} message";
            }
            else
            {
                text = this.txtEventText.Text;
            } // if

            switch (typeStr)
            {
                case "Debug":
                    Log.Debug(text);
                    break;
                case "Info":
                    Log.Info(text);
                    break;
                case "Warning":
                    Log.Warn(text);
                    break;
                case "Error":
                    Log.Error(text);
                    break;
                case "Fatal":
                    Log.Fatal(text);
                    break;
                default:
                    Debug.Assert(false, "This must not happen!");
                    break;
            } // switch
        } // AddEvent()

        /// <summary>
        /// Adds dummy events of all types.
        /// </summary>
        private static void AddDummyEvents()
        {
            Log.Debug("This is a dummy debug message");
            Log.Info("This is a dummy info message");
            Log.Warn("This is a dummy warning message");
            Log.Error("This is a dummy error message");
            Log.Fatal("This is a dummy fatal message");

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
                Log.Error("Exception: " + ex.Message, ex);
            } // catch
        } // AddDummyEvents()
        #endregion // CORE METHODS
    } // MainForm
} // TestApplication
