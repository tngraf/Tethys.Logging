#region Header
// --------------------------------------------------------------------------
// Tethys.Logging
// ==========================================================================
//
// A portable logging library for .NET Framework 4.5, Silverlight 4 and 
// higher, Windows Phone 7 and higher and .NET for Windows Store apps.
//
// ==========================================================================
// <copyright file="App.xaml.cs" company="Tethys">
// Copyright  2013 by Thomas Graf
//            All rights reserved.
//            See the file "License.txt" for information on usage and 
//            redistribution of this file and for a 
//            DISCLAIMER OF ALL WARRANTIES.
// </copyright>
// 
// Version .. 1.00.00.00 of 13Apr18
// System ... Portable Library
// Tools .... Microsoft Visual Studio 2012
//
// Change Report
// 13Mar21 1.00.00.00 tg: initial version.
//
// ---------------------------------------------------------------------------
#endregion

namespace TestApp.WP71
{
  using System.Windows;
  using System.Windows.Navigation;

  using Microsoft.Phone.Controls;
  using Microsoft.Phone.Shell;

  /// <summary>
  /// Main application class.
  /// </summary>
  public partial class App
  {
    /// <summary>
    /// Gets the root frame of the Phone Application.
    /// </summary>
    /// <returns>The root frame of the Phone Application.</returns>
    public PhoneApplicationFrame RootFrame { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="App"/> class.
    /// </summary>
    public App()
    {
      // Global handler for uncaught exceptions. 
      UnhandledException += Application_UnhandledException;

      // Standard Silverlight initialization
      InitializeComponent();

      // Phone-specific initialization
      InitializePhoneApplication();

      // Show graphics profiling information while debugging.
      if (System.Diagnostics.Debugger.IsAttached)
      {
        // Display the current frame rate counters.
        Current.Host.Settings.EnableFrameRateCounter = true;

        // Disable the application idle detection by setting the UserIdleDetectionMode property of the
        // application's PhoneApplicationService object to Disabled.
        // Caution:- Use this under debug mode only. Application that disables user idle detection will continue to run
        // and consume battery power when the user is not using the phone.
        PhoneApplicationService.Current.UserIdleDetectionMode = IdleDetectionMode.Disabled;
      }
    }

    /// <summary>
    /// Code to execute when the application is launching (e.g., from Start)
    /// This code will not execute when the application is reactivated
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="LaunchingEventArgs"/> instance containing the event data.</param>
    private void Application_Launching(object sender, LaunchingEventArgs e)
    {
    }

    /// <summary>
    /// Code to execute when the application is activated (brought to foreground)
    /// This code will not execute when the application is first launched
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="ActivatedEventArgs"/> instance containing the event data.</param>
    private void Application_Activated(object sender, ActivatedEventArgs e)
    {
    }

    /// <summary>
    /// Code to execute when the application is deactivated (sent to background)
    /// This code will not execute when the application is closing
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="DeactivatedEventArgs"/> instance containing the event data.</param>
    private void Application_Deactivated(object sender, DeactivatedEventArgs e)
    {
    }

    /// <summary>
    /// Code to execute when the application is closing (e.g., user hit Back)
    /// This code will not execute when the application is deactivated
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="ClosingEventArgs"/> instance containing the event data.</param>
    private void Application_Closing(object sender, ClosingEventArgs e)
    {
    }

    /// <summary>
    /// Code to execute if a navigation fails
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="NavigationFailedEventArgs"/> instance containing the event data.</param>
    private void RootFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
    {
      if (System.Diagnostics.Debugger.IsAttached)
      {
        // A navigation has failed; break into the debugger
        System.Diagnostics.Debugger.Break();
      }
    }

    /// <summary>
    /// Code to execute on Unhandled Exceptions
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="ApplicationUnhandledExceptionEventArgs"/> instance containing the event data.</param>
    private void Application_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
    {
      if (System.Diagnostics.Debugger.IsAttached)
      {
        // An unhandled exception has occurred; break into the debugger
        System.Diagnostics.Debugger.Break();
      }
    }

    #region Phone application initialization

    /// <summary>
    /// Avoid double-initialization
    /// </summary>
    private bool _phoneApplicationInitialized;

    /// <summary>
    /// Do not add any additional code to this method
    /// </summary>
    private void InitializePhoneApplication()
    {
      if (this._phoneApplicationInitialized)
      {
        return;
      } // if

      // Create the frame but don't set it as RootVisual yet; this allows the splash
      // screen to remain active until the application is ready to render.
      RootFrame = new PhoneApplicationFrame();
      RootFrame.Navigated += CompleteInitializePhoneApplication;

      // Handle navigation failures
      RootFrame.NavigationFailed += RootFrame_NavigationFailed;

      // Ensure we don't initialize again
      this._phoneApplicationInitialized = true;
    }

    /// <summary>
    /// Do not add any additional code to this method
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="NavigationEventArgs"/> instance containing the event data.</param>
    private void CompleteInitializePhoneApplication(object sender, NavigationEventArgs e)
    {
      // Set the root visual to allow the application to render
// ReSharper disable RedundantCheckBeforeAssignment
      if (RootVisual != RootFrame)
// ReSharper restore RedundantCheckBeforeAssignment
      {
        RootVisual = RootFrame;
      } // if

      // Remove this handler since it is no longer needed
      RootFrame.Navigated -= CompleteInitializePhoneApplication;
    }
    #endregion
  }
}