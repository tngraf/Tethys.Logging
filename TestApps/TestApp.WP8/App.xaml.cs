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

namespace TestApp.WP8
{
  using System;
  using System.Diagnostics;
  using System.Windows;
  using System.Windows.Markup;
  using System.Windows.Navigation;

  using Microsoft.Phone.Controls;
  using Microsoft.Phone.Shell;

  using TestApp.WP8.Resources;

  /// <summary>
  /// App class.
  /// </summary>
  public partial class App
  {
    /// <summary>
    /// Gets the root frame of the Phone Application.
    /// </summary>
    /// <returns>The root frame of the Phone Application.</returns>
    public static PhoneApplicationFrame RootFrame { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="App"/> class.
    /// </summary>
    public App()
    {
      // Global handler for uncaught exceptions.
      UnhandledException += Application_UnhandledException;

      // Standard XAML initialization
      InitializeComponent();

      // Phone-specific initialization
      InitializePhoneApplication();

      // Language display initialization
      InitializeLanguage();

      // Show graphics profiling information while debugging.
      if (Debugger.IsAttached)
      {
        // Display the current frame rate counters.
        Current.Host.Settings.EnableFrameRateCounter = true;

        // Prevent the screen from turning off while under the debugger by disabling
        // the application's idle detection.
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
      if (Debugger.IsAttached)
      {
        // A navigation has failed; break into the debugger
        Debugger.Break();
      }
    }

    /// <summary>
    /// Code to execute on Unhandled Exceptions
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="ApplicationUnhandledExceptionEventArgs"/> instance containing the event data.</param>
    private void Application_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
    {
      if (Debugger.IsAttached)
      {
        // An unhandled exception has occurred; break into the debugger
        Debugger.Break();
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

      // Handle reset requests for clearing the backstack
      RootFrame.Navigated += CheckForResetNavigation;

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

    /// <summary>
    /// Checks for reset navigation.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="NavigationEventArgs"/> instance containing the event data.</param>
    private void CheckForResetNavigation(object sender, NavigationEventArgs e)
    {
      // If the app has received a 'reset' navigation, then we need to check
      // on the next navigation to see if the page stack should be reset
      if (e.NavigationMode == NavigationMode.Reset)
      {
        RootFrame.Navigated += ClearBackStackAfterReset;
      } // if
    }

    /// <summary>
    /// Clears the back stack after reset.
    /// </summary>
    /// <param name="sender">The sender.</param>
    /// <param name="e">The <see cref="NavigationEventArgs"/> instance containing the event data.</param>
    private void ClearBackStackAfterReset(object sender, NavigationEventArgs e)
    {
      // Unregister the event so it doesn't get called again
      RootFrame.Navigated -= ClearBackStackAfterReset;

      // Only clear the stack for 'new' (forward) and 'refresh' navigations
      if (e.NavigationMode != NavigationMode.New && e.NavigationMode != NavigationMode.Refresh)
      {
        return;
      } // if

      // For UI consistency, clear the entire page stack
      while (RootFrame.RemoveBackEntry() != null)
      {
        // do nothing
      } // while
    } // ClearBackStackAfterReset()

    #endregion
    
    /// <summary>
    /// Initialize the app's font and flow direction as defined in its localized resource strings.
    /// </summary>
    /// <remarks>
    /// To ensure that the font of your application is aligned with its supported languages and that the
    /// FlowDirection for each of those languages follows its traditional direction, ResourceLanguage
    /// and ResourceFlowDirection should be initialized in each <c>resx</c> file to match these values with that
    /// file's culture. For example:
    /// <para />
    /// <code>AppResources.es-ES.resx</code>
    ///    ResourceLanguage's value should be <c>"es-ES"</c>
    ///    ResourceFlowDirection's value should be "LeftToRight"
    /// <para />
    /// <code>AppResources.ar-SA.resx</code>
    ///     ResourceLanguage's value should be <c>"ar-SA"</c>
    ///     ResourceFlowDirection's value should be "RightToLeft"
    /// <para />
    /// For more info on localizing Windows Phone apps see <c>http://go.microsoft.com/fwlink/?LinkId=262072.</c>
    /// </remarks>
    private void InitializeLanguage()
    {
      try
      {
        // Set the font to match the display language defined by the
        // ResourceLanguage resource string for each supported language.
        //
        // Fall back to the font of the neutral language if the Display
        // language of the phone is not supported.
        //
        // If a compiler error is hit then ResourceLanguage is missing from
        // the resource file.
        RootFrame.Language = XmlLanguage.GetLanguage(AppResources.ResourceLanguage);

        // Set the FlowDirection of all elements under the root frame based
        // on the ResourceFlowDirection resource string for each
        // supported language.
        //
        // If a compiler error is hit then ResourceFlowDirection is missing from
        // the resource file.
        FlowDirection flow = (FlowDirection)Enum.Parse(typeof(FlowDirection), AppResources.ResourceFlowDirection);
        RootFrame.FlowDirection = flow;
      }
      catch
      {
        // If an exception is caught here it is most likely due to either
        // ResourceLangauge not being correctly set to a supported language
        // code or ResourceFlowDirection is set to a value other than LeftToRight
        // or RightToLeft.
        if (Debugger.IsAttached)
        {
          Debugger.Break();
        }

        throw;
      }
    }
  }
}