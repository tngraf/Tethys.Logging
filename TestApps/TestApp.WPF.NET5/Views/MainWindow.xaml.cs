// --------------------------------------------------------------------------
// Tethys.Logging
// ==========================================================================
//
// A logging library for .NET Framework 4.5+ and .NET Core.
//
// ===========================================================================
//
// <copyright file="MainWindow.xaml.cs" company="Tethys">
// Copyright  2009-2015 by Thomas Graf
//            All rights reserved.
//            Licensed under the Apache License, Version 2.0.
//            Unless required by applicable law or agreed to in writing,
//            software distributed under the License is distributed on an
//            "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
//            either express or implied.
// </copyright>
//
// ---------------------------------------------------------------------------

// ReSharper disable once CheckNamespace
namespace TestApp.WPF.NET5
{
    using System.Collections.Generic;
    using System.Windows;

    using TestApp.WPF.NET5.Core;
    using TestApp.WPF.NET5.ViewModels;
    using Tethys.Logging;

    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow
    {
        /// <summary>
        /// The view model.
        /// </summary>
        private readonly MainWindowViewModel viewmodel;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();

            // initialize logging
            this.ConfigureLogging();

            this.viewmodel = new MainWindowViewModel();
            this.DataContext = this.viewmodel;
        } // MainWindow()

        /// <summary>
        /// Configure logging.
        /// </summary>
        private void ConfigureLogging()
        {
            this.RtfLogView.AddAtTail = true;
#if !DEBUG
            this.RtfLogView.MaxLogLength = 10000;
#endif
            this.RtfLogView.ShowDebugEvents = true;

            var settings = new Dictionary<string, string>();
            settings.Add("AddTime", "false");
            settings.Add("AddLevel", "false");
            settings.Add("AddCrLf", "false");
            LogManager.Adapter = new LogViewFactoryAdapter(this.RtfLogView, settings);

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
            if (this.viewmodel.UseDefaultText)
            {
                LogAppCore.AddEvent(this.viewmodel.SelectedLevel.LevelText);
            }
            else
            {
                LogAppCore.AddEvent(
                  this.viewmodel.SelectedLevel.LevelText,
                  this.viewmodel.CustomText);
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
    }
}
