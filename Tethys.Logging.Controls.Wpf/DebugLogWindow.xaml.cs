#region Header
// ---------------------------------------------------------------------------
// Tethys.Logging.Controls.Wpf
// ===========================================================================
//
// This library contains common code of .Net projects of Thomas Graf.
//
// ===========================================================================
// <copyright file="DebugLogWindow.xaml.cs" company="Tethys">
// Copyright  2003 - 2013 by Thomas Graf
//            All rights reserved.
//            See the file "License.txt" for information on usage and 
//            redistribution of this file and for a 
//            DISCLAIMER OF ALL WARRANTIES.
//            redistribution of this file and for a DISCLAIMER OF ALL WARRANTIES.
// </copyright>
// 
// Version .. 1.00.00.00 of 13Mar09
// Project .. TgLib.Logging.NLog
// Creater .. Thomas Graf (tg)
// System ... Microsoft .Net Framework 4
// Tools .... Microsoft Visual Studio 2010
//
// Change Report
// 12May16 1.00.00.00 tg: initial version of the tglib.logging.controls.wpf.
//
// ---------------------------------------------------------------------------
#endregion

namespace Tethys.Logging.Controls.Wpf
{
  using System;
  using System.Windows;

  /// <summary>
  /// Interaction logic for the debug log window.
  /// </summary>
  // ReSharper disable RedundantExtendsListEntry
  public partial class DebugLogWindow : Window
  // ReSharper restore RedundantExtendsListEntry
  {
    #region PUBLIC PROPERTIES
    /// <summary>
    /// Hiding event.
    /// </summary>
    public event EventHandler Hiding;
    
    /// <summary>
    /// Gets the underlying RtfLogView control
    /// </summary>
    public RtfLogView RtfLogView
    {
      get { return this._logView; }
    } // RtfLogView
    #endregion // PUBLIC PROPERTIES

    //// ---------------------------------------------------------------------

    #region CONSTRUCTION
    /// <summary>
    /// Initializes a new instance of the <see cref="DebugLogWindow"/> class.
    /// </summary>
    public DebugLogWindow()
    {
      InitializeComponent();
    } // DebugLogWindow()
    #endregion // CONSTRUCTION

    //// ---------------------------------------------------------------------

    #region UI MANAGEMENT
    /// <summary>
    /// Handles the Closing event of the Window control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.ComponentModel.CancelEventArgs"/>
    /// instance containing the event data.</param>
    private void OnWindowClosing(object sender,
      System.ComponentModel.CancelEventArgs e)
    {
      // prohibit close operation
      // ==> only hide window
      e.Cancel = true;

      // raise Hiding event
      if (Hiding != null)
      {
        EventArgs ea = new EventArgs();
        Hiding(this, ea);
      } // if

      // hide form
      Hide();
    } // OnWindowClosing()
    #endregion // UI MANAGEMENT
  } // DebugLogWindow
} // Tethys.Logging.Controls.Wpf

// =====================================================
// Tethys.Logging.Controls.Wpf: end of DebugLogWindow.cs
// =====================================================
