// -------------------------------------------------------------------------------
// <copyright file="LogTest.cs" company="Tethys">
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

// ReSharper disable CheckNamespace
namespace Tethys.Logging.Test
// ReSharper restore CheckNamespace
{
  using System;
  using System.Diagnostics;

  /// <summary>
  /// Test support methods.
  /// </summary>
  public static class LogTest
  {
    /// <summary>
    /// Adds a new event.
    /// </summary>
    /// <param name="log">The log.</param>
    /// <param name="type">The log level type.</param>
    /// <param name="text">The text.</param>
    public static void AddEvent(ILog log, string type, string text)
    {
      switch (type)
      {
        case "Debug":
          log.Debug(text);
          break;
        case "Info":
          log.Info(text);
          break;
        case "Warning":
          log.Warn(text);
          break;
        case "Error":
          log.Error(text);
          break;
        case "Fatal":
          log.Fatal(text);
          break;
        default:
          Debug.Assert(false, "Unknown event type!");
          break;
      } // switch
    } // AddEvent()

    /// <summary>
    /// Adds dummy events of all types.
    /// </summary>
    /// <param name="log">The log.</param>
    public static void AddDummyEvents(ILog log)
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
        log.Error("Exception: " + ex.Message, ex);
      } // catch
    } // AddDummyEvents()
  } // LogTest
} // Tethys.Logging.Test
