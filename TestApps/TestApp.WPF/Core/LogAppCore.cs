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
// <copyright file="LogAppCore.cs" company="Tethys">
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

namespace TestApplication.WPF.Core
{
  using System;
  using System.Diagnostics;
  using System.Threading;
  using Common.Logging;

  using TestApplication.WPF.Views;

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
      string text = string.Format("This is a {0} message", type);
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
      int x = 0;
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
      Thread testThread = new Thread(Worker);
      testThread.Start();
    } // RunThreadTest()

    /// <summary>
    /// A simple worker method to add events.
    /// </summary>
    private static void Worker()
    {
      int count = 0;
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
