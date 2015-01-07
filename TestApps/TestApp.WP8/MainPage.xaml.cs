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
// <copyright file="MainPage.xaml.cs" company="Tethys">
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

namespace TestApp.WP8
{
  using System.Windows;

  using TestApp.WP8.Core;

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
    private readonly MainWindowViewModel viewmodel;

    /// <summary>
    /// Initializes a new instance of the <see cref="MainPage"/> class.
    /// </summary>
    public MainPage()
    {
      InitializeComponent();

      // initialize logging
      ConfigureLogging();

      this.viewmodel = new MainWindowViewModel();
      DataContext = this.viewmodel;
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
      if (this.viewmodel.UseDefaultText)
      {
        LogAppCore.AddEvent(this.viewmodel.SelectedLevel.LevelText);
      }
      else
      {
        LogAppCore.AddEvent(
          this.viewmodel.SelectedLevel.LevelText,
          this.viewmodel.CustomText);
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
  } // MainPage
} // TestApp.WP8