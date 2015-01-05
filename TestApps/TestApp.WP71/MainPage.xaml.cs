#region Header
// --------------------------------------------------------------------------
// TestApplication.WP71
// ==========================================================================
//
// A portable logging library for .NET Framework 4.5, Silverlight 4 and 
// higher, Windows Phone 7 and higher and .NET for Windows Store apps.
//
// ==========================================================================
// <copyright file="MainPage.xaml.cs" company="Tethys">
// Copyright  2003 - 2013 by Thomas Graf
//            All rights reserved.
//            See the file "License.txt" for information on usage and 
//            redistribution of this file and for a 
//            DISCLAIMER OF ALL WARRANTIES.
// </copyright>
// 
// Version .. 1.00.00.00 of 13Mar26
// System ... Portable Library
// Tools .... Microsoft Visual Studio 2012
//
// Change Report
// 13Mar26 1.00.00.00 tg: initial version.
//
// ---------------------------------------------------------------------------
#endregion

namespace TestApp.WP71
{
  using System.Windows;

  using TestApp.WP71.Core;

  using TestApplication.WPF.ViewModels;

  using Tethys.Logging;

  /// <summary>
  /// Main page of the application.
  /// </summary>
  public partial class MainPage
  {
    /// <summary>
    /// The view model.
    /// </summary>
    private readonly MainWindowViewModel _viewmodel;

    /// <summary>
    /// Initializes a new instance of the <see cref="MainPage"/> class.
    /// </summary>
    public MainPage()
    {
      InitializeComponent();

      // initialize logging
      ConfigureLogging();

      _viewmodel = new MainWindowViewModel();
      DataContext = _viewmodel;
    } // MainPage()

    /// <summary>
    /// Handles the Click event of the control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/>
    /// instance containing the event data.</param>
    private void BtnAddAllEventClick(object sender, RoutedEventArgs e)
    {
      LogAppCore.AddDummyEvents();
    } // BtnAddAllEventClick()

    /// <summary>
    /// Handles the Click event of the control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/>
    /// instance containing the event data.</param>
    private void BtnAddNewEventClick(object sender, RoutedEventArgs e)
    {
      if (_viewmodel.UseDefaultText)
      {
        LogAppCore.AddEvent(_viewmodel.SelectedLevel.LevelText);
      }
      else
      {
        LogAppCore.AddEvent(
          _viewmodel.SelectedLevel.LevelText,
          _viewmodel.CustomText);
      } // if
    } // BtnAddNewEventClick()

    //// -----------------------------------------------------------------------

    #region CORE METHODS
    /// <summary>
    /// Configures the logging.
    /// </summary>
    private void ConfigureLogging()
    {
      // LogManager.Adapter = new DebugLoggerFactoryAdapter();
      LogManager.Adapter = new TextBoxLoggerFactoryAdapter(_txtBoxLog);

      // ----- Application -----
      LogAppCore.ConfigureLogging();
    } // ConfigureLogging()
    #endregion // CORE METHODS
  }
}