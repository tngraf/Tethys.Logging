// -------------------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="Tethys">
//   Copyright (C) 2009-2023 Thomas Graf
//   All Rights Reserved.
// </copyright>
//
// Licensed under the Apache License, Version 2.0.
// Unless required by applicable law or agreed to in writing,
// software distributed under the License is distributed on an
// "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
// either express or implied.
// SPDX-License-Identifier: Apache-2.0
// -------------------------------------------------------------------------------

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
        private readonly MainWindowViewModel viewmodel;

        /// <summary>
        /// The debug log window.
        /// </summary>
        private readonly DebugLogWindow debugWindow;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();

            this.debugWindow = new DebugLogWindow();
            this.debugWindow.Hiding += this.OnDebugWindowHiding;

            // initialize logging
            this.ConfigureLogging();

            this.viewmodel = new MainWindowViewModel();
            this.DataContext = this.viewmodel;
        } // MainWindow()

        /// <summary>
        /// Called when the debug window has been closed
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance 
        /// containing the event data.</param>
        private void OnDebugWindowHiding(object sender, System.EventArgs e)
        {
            this.CheckDebugLogWindow.IsChecked = false;
        } // OnDebugWindowHiding()

        /// <summary>
        /// Configure logging.
        /// </summary>
        private void ConfigureLogging()
        {
            // ----- configure NLog logging -----
            var config = global::NLog.LogManager.Configuration ?? new NLog.Config.LoggingConfiguration();

            // create & add targets
            NLog.Targets.TargetWithLayout targetRtf = new NLogTargetToLogViewAdapter(
                this.RtfLogView, false);
            targetRtf.Layout = "${date:format=yyyy-MM-dd,HH\\:mm\\:ss}: ${message}";
            config.AddTarget("RtfLogView", targetRtf);

            var rule = new NLog.Config.LoggingRule("*", global::NLog.LogLevel.Debug, targetRtf);
            config.LoggingRules.Add(rule);

            NLog.Targets.TargetWithLayout targetDebugTrace = new NLogTargetToLogViewAdapter(
              this.debugWindow.RtfLogView, false);
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
            this.debugWindow.Close();

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

        /// <summary>
        /// Handles the Click event of the CheckDebugLogWindow control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/>
        /// instance containing the event data.</param>
        private void CheckDebugLogWindowClick(object sender, RoutedEventArgs e)
        {
            if (this.debugWindow.IsVisible)
            {
                this.debugWindow.Hide();
            }
            else
            {
                this.debugWindow.Show();
            }
        }
    }
}
