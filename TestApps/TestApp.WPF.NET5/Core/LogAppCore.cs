// -------------------------------------------------------------------------------
// <copyright file="LogAppCore.cs" company="Tethys">
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

namespace TestApp.WPF.NET5.Core
{
    using System;
    using System.Diagnostics;
    using System.Threading;
    using TestApp.WPF.NET5;
    using Tethys.Logging;

    /// <summary>
    /// Core functionality of the test application.
    /// </summary>
    public static class LogAppCore
    {
        /// <summary>
        /// Common.Logging logger (more abstract).
        /// </summary>
        private static ILog log;

        /// <summary>
        /// Configures the logging.
        /// </summary>
        public static void ConfigureLogging()
        {
            log = LogManager.GetLogger(typeof(MainWindow));
        } // ConfigureLogging()

        /// <summary>
        /// Adds the event.
        /// </summary>
        /// <param name="type">The type.</param>
        public static void AddEvent(string type)
        {
            var text = $"This is a {type} message";
            AddEvent(type, text);
        } // AddEvent()

        /// <summary>
        /// Adds the event.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="text">The text.</param>
        public static void AddEvent(string type, string text)
        {
            switch (type)
            {
                case "Debug":
                    log.Debug(text);
                    break;
                case "Info":
                    log.Info(text);
                    break;
                case "Warn":
                    log.Warn(text);
                    break;
                case "Error":
                    log.Error(text);
                    break;
                case "Fatal":
                    log.Fatal(text);
                    break;
                default:
                    Debug.Assert(false, "Must not happen!");
                    // ReSharper disable HeuristicUnreachableCode
                    break;
                    // ReSharper restore HeuristicUnreachableCode
            } // switch
        } // AddEvent()

        /// <summary>
        /// Adds some dummy events.
        /// </summary>
        public static void AddDummyEvents()
        {
            log.Debug("This is a dummy debug message");
            log.Info("This is a dummy info message");
            log.Warn("This is a dummy warning message");
            log.Error("This is a dummy error message");
            log.Fatal("This is a dummy fatal message");

            // log exception
            var x = 0;
            try
            {
                // force exception
                // ReSharper disable RedundantAssignment
                x = 1 / x;
                // ReSharper restore RedundantAssignment
            }
            catch (Exception ex)
            {
                log.Error("Exception: ", ex);
            } // catch
        } // AddDummyEvents()

        /// <summary>
        /// Runs the thread test.
        /// </summary>
        public static void RunThreadTest()
        {
            var testThread = new Thread(Worker);
            testThread.Start();
        } // RunThreadTest()

        /// <summary>
        /// A simple worker method to add events.
        /// </summary>
        private static void Worker()
        {
            var count = 0;
            while (count < 200)
            {
                AddEvent("Info", "Testrun " + count);
                AddDummyEvents();
                count++;
                Thread.Sleep(5);
            } // while
        } // Worker()
    } // LogAppCore
} // TestApplication.WPF.Core
