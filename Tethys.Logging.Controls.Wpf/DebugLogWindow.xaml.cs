#region Header
// --------------------------------------------------------------------------
// Tethys.Logging.Controls.WPF
// ==========================================================================
//
// A logging library for .NET Framework 4.
//
// ===========================================================================
//
// <copyright file="DebugLogWindow.xaml.cs" company="Tethys">
// Copyright  2009-2015 by Thomas Graf
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
