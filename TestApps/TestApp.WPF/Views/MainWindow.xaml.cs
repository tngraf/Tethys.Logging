#region Header
// --------------------------------------------------------------------------
// TestApplication.Wpf
// ==========================================================================
//
// A portable logging library for .NET Framework 4.5, Silverlight 4 and 
// higher, Windows Phone 7 and higher and .NET for Windows Store apps.
//
// ==========================================================================
// <copyright file="MainWindow.xaml.cs" company="Tethys">
// Copyright  2003 - 2013 by Thomas Graf
//            All rights reserved.
//            See the file "License.txt" for information on usage and 
//            redistribution of this file and for a 
//            DISCLAIMER OF ALL WARRANTIES.
// </copyright>
// 
// Version .. 1.00.00.00 of 12May18
// System ... Portable Library
// Tools .... Microsoft Visual Studio 2012
//
// Change Report
// 12May18 1.00.00.00 tg: initial version.
//
// ---------------------------------------------------------------------------
#endregion

namespace TestApplication.WPF.Views
{
  using System.Collections.Specialized;
  using System.Windows;

  using TestApplication.WPF.Core;
  using TestApplication.WPF.ViewModels;

  using Tethys.Logging.Controls.Wpf;
  using Tethys.Logging.NLog;
  
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow
  {
    /// <summary>
    /// The view model.
    /// </summary>
    private readonly MainWindowViewModel _viewmodel;

    /// <summary>
    /// The debug log window.
    /// </summary>
    private readonly DebugLogWindow _debugWindow;

    /// <summary>
    /// Initializes a new instance of the <see cref="MainWindow"/> class.
    /// </summary>
    public MainWindow()
    {
      InitializeComponent();

      _debugWindow = new DebugLogWindow();
      _debugWindow.Hiding += OnDebugWindowHiding;

      // initialize logging
      ConfigureLogging();

      _viewmodel = new MainWindowViewModel();
      DataContext = _viewmodel;
    } // MainWindow()

    /// <summary>
    /// Called when the debug window has been closed
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance 
    /// containing the event data.</param>
    private void OnDebugWindowHiding(object sender, System.EventArgs e)
    {
      CheckDebugLogWindow.IsChecked = false;
    } // OnDebugWindowHiding()

    /// <summary>
    /// Configure logging.
    /// </summary>
    private void ConfigureLogging()
    {
      // ----- configure NLog logging -----
      NLog.Config.LoggingConfiguration config
        = global::NLog.LogManager.Configuration ?? new NLog.Config.LoggingConfiguration();

      // create & add targets
      NLog.Targets.TargetWithLayout targetRtf = new NLogTargetToLogViewAdapter(
        RtfLogView, false);
      targetRtf.Layout = "${date:format=yyyy-MM-dd,HH\\:mm\\:ss}: ${message}";
      config.AddTarget("RtfLogView", targetRtf);

      NLog.Config.LoggingRule rule = new NLog.Config.LoggingRule("*", 
        global::NLog.LogLevel.Debug, targetRtf);
      config.LoggingRules.Add(rule);

      NLog.Targets.TargetWithLayout targetDebugTrace = new NLogTargetToLogViewAdapter(
        _debugWindow.RtfLogView, false);
      targetDebugTrace.Layout = "${date:format=yyyy-MM-dd,HH\\:mm\\:ss}: ${message}";
      config.AddTarget("DebugTraceView", targetDebugTrace);

      rule = new NLog.Config.LoggingRule("*", global::NLog.LogLevel.Debug, targetDebugTrace);
      config.LoggingRules.Add(rule);

      // IMPORTANT
      // You have to get the current NLog configuration, make changes to this
      // LoggingConfiguration object, then assign it back to 
      // LogManager.Configuration. Adding targets and rultes directly to 
      // NLog.LogManager.Configuration does not work!
      global::NLog.LogManager.Configuration = config;

      // ----- Common.Logging logging -----
      var properties = new NameValueCollection();
      properties["configType"] = "INLINE";
      global::Common.Logging.LogManager.Adapter
        = new global::Common.Logging.NLog.NLogLoggerFactoryAdapter(properties);

      // ----- Application -----
      LogAppCore.ConfigureLogging();
    } // ConfigureLogging()

    /// <summary>
    /// Handles the Loaded event of the Window control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/>
    /// instance containing the event data.</param>
    private void WindowLoaded(object sender, RoutedEventArgs e)
    {
    } // Window_Loaded()

    /// <summary>
    /// Handles the Closing event of the Window control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.ComponentModel.CancelEventArgs"/>
    /// instance containing the event data.</param>
    private void WindowClosing(
      object sender,
      System.ComponentModel.CancelEventArgs e)
    {
      _debugWindow.Close();

      // the next command is needed to really terminate the application
      Application.Current.Shutdown();
    } // Window_Closing()

    /// <summary>
    /// Handles the Click event of the control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/>
    /// instance containing the event data.</param>
    private void BtnAddAllEventClick(object sender, RoutedEventArgs e)
    {
      LogAppCore.AddDummyEvents();
    }

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
      }
    }

    /// <summary>
    /// Handles the Click event of the control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> 
    /// instance containing the event data.</param>
    private void BtnThreadTestClick(object sender, RoutedEventArgs e)
    {
      LogAppCore.RunThreadTest();
    }

    /// <summary>
    /// Handles the Click event of the CheckDebugLogWindow control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/>
    /// instance containing the event data.</param>
    private void CheckDebugLogWindowClick(object sender, RoutedEventArgs e)
    {
      if (_debugWindow.IsVisible)
      {
        _debugWindow.Hide();
      }
      else
      {
        _debugWindow.Show();
      }
    }
  }
}
