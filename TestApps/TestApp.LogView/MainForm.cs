// -------------------------------------------------------------------------------
// <copyright file="MainForm.cs" company="Tethys">
//   Copyright (C) 2009-2023 Thomas Graf
//   All Rights Reserved.
// </copyright>
//
// Licensed under the Apache License, Version 2.0.
// Unless required by applicable law or agreed to in writing,
// software distributed under the License is distributed on an
// "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
// either express or implied.
// SPDX-License-Identifier: Apache-2.0
// -------------------------------------------------------------------------------

namespace TestApp.LogView
{
    using System;
    using System.Collections.Generic;
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
            var settings = new Dictionary<string, string>();
            settings.Add("AddTime", "false");
            settings.Add("AddLevel", "false");
            LogManager.Adapter = new LogViewFactoryAdapter(this.rtfLogView, settings);

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
            var typeStr = (string)this.comboEventType.SelectedItem;
            if (this.radioDefaultText.Checked)
            {
                LogAppCore.AddEvent(typeStr);
            }
            else
            {
                LogAppCore.AddEvent(typeStr, this.txtEventText.Text);
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
            this.txtEventText.Enabled = this.radioCustomText.Checked;
        } // btnAddEvent_Click()
        #endregion // UI HANDLING

        //// ----------------------------------------------------------------------
    } // MainForm
} // TestApp.LogView
