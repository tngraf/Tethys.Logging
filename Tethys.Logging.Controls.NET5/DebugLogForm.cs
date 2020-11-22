// --------------------------------------------------------------------------
// Tethys.Logging.Controls
// ==========================================================================
//
// A logging library for .NET Framework 4.
//
// ===========================================================================
//
// <copyright file="DebugLogForm.cs" company="Tethys">
// Copyright  2009-2017 by Thomas Graf
//            All rights reserved.
//            Licensed under the Apache License, Version 2.0.
//            Unless required by applicable law or agreed to in writing,
//            software distributed under the License is distributed on an
//            "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
//            either express or implied.
// </copyright>
//
// System ... Microsoft .Net Framework 4
// Tools .... Microsoft Visual Studio 2013
//
// ---------------------------------------------------------------------------

namespace Tethys.Logging.Controls
{
    using System;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    /// <summary>
    /// DebugLogForm implements a form that contains a RtfLogView to display
    /// log4net logging events. This form can be easily added to an application
    /// to show logging only if it is explicitly needed.
    /// </summary>
    [ComVisible(false)]
    public partial class DebugLogForm : Form
    {
        #region PUBLIC PROPERTIES
        /// <summary>
        /// Hiding event.
        /// </summary>
        public event EventHandler HidingEvent;

        /// <summary>
        /// Gets the underlying RtfLogView control
        /// </summary>
        public RtfLogView RtfLogView { get; private set; }
        #endregion // PUBLIC PROPERTIES

        //// ---------------------------------------------------------------------

        #region CONSTRUCTION
        /// <summary>
        /// Initializes a new instance of the <see cref="DebugLogForm"/> class.
        /// </summary>
        public DebugLogForm()
        {
            this.InitializeComponent();
        } // DebugLogForm()
        #endregion // CONSTRUCTION

        //// ---------------------------------------------------------------------

        #region UI MANAGEMENT
        /// <summary>
        /// This function is called when the user has clicked on the
        /// close window control box. We do not want the window to be
        /// closed - we only want it to be hidden. So we disallow closing
        /// the window and hide it by ourselves. The parent of the debug
        /// trace window is informed by the Hiding event.
        /// </summary>
        /// <param name="sender">The debug trace form itself.</param>
        /// <param name="e">The <see cref="FormClosingEventArgs"/> instance
        /// containing the event data.</param>
        private void DebugLogFormFormClosing(object sender, FormClosingEventArgs e)
        {
            // prohibit close operation
            e.Cancel = true;

            // raise Hiding event
            if (this.HidingEvent != null)
            {
                EventArgs ea = new EventArgs();
                this.HidingEvent(this, ea);
            } // if

            // hide form
            this.Hide();
        } // DebugLogForm_FormClosing()
        #endregion // UI MANAGEMENT
    } // DebugLogForm
} // Tethys.Logging.Controls

// ===============================================
// Tethys.Logging.Controls: end of DebugLogForm.cs
// ===============================================
