#region Header
// ---------------------------------------------------------------------------
// Tethys.Logging.Controls
// ===========================================================================
//
// This library contains common code of .Net projects of Thomas Graf.
//
// ===========================================================================
// <copyright file="DebugLogForm.cs" company="Tethys">
// Copyright  2003 - 2013 by Thomas Graf
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
// 09Nov29 1.00.00.00 tg: initial version of the tglib.logging.controls libray.
// 09Dec22 1.00.00.01 tg: bugfix in SaveToTextFile().
//
// ---------------------------------------------------------------------------
#endregion

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
    public RtfLogView RtfLogView
    {
      get { return rtfLogView; }
    } // RtfLogView
    #endregion // PUBLIC PROPERTIES

    //// ---------------------------------------------------------------------

    #region CONSTRUCTION
    /// <summary>
    /// Initializes a new instance of the <see cref="DebugLogForm"/> class.
    /// </summary>
    public DebugLogForm()
    {
      InitializeComponent();
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
      if (HidingEvent != null)
      {
        EventArgs ea = new EventArgs();
        HidingEvent(this, ea);
      } // if

      // hide form
      Hide();
    } // DebugLogForm_FormClosing()
    #endregion // UI MANAGEMENT

    //// ---------------------------------------------------------------------

    #region CORE METHODS
    #endregion // CORE METHODS
  } // DebugLogForm
} // Tethys.Logging.Controls

// ===============================================
// Tethys.Logging.Controls: end of DebugLogForm.cs
// ===============================================
