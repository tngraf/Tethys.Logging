#region Header
// --------------------------------------------------------------------------
// Tethys.Logging
// ==========================================================================
//
// A portable logging library for .NET Framework 4.5, Silverlight 4 and 
// higher, Windows Phone 7 and higher and .NET for Windows Store apps.
//
// ==========================================================================
// <copyright file="ILogEvent.cs" company="Tethys">
// Copyright  2013 by Thomas Graf
//            All rights reserved.
// </copyright>
// 
// Version .. 1.00.00.00 of 13Mar21
// System ... Portable Library
// Tools .... Microsoft Visual Studio 2012
//
// Change Report
// 13Mar21 1.00.00.00 tg: initial version.
//
// ---------------------------------------------------------------------------
#endregion

namespace Tethys.Logging
{
  using System;

  /// <summary>
  /// Interface for logging events for log viewer.
  /// This is an abstract interface for as well log4net as
  /// NLog logging events.
  /// </summary>
  public interface ILogEvent
  {
    /// <summary>
    /// Gets the log level.
    /// </summary>
    /// <value>The level.</value>
    LogLevel Level { get; }

    /// <summary>
    /// Gets the log event time stamp.
    /// </summary>
    /// <value>The time stamp.</value>
    DateTime Timestamp { get; }

    /// <summary>
    /// Gets the log message.
    /// </summary>
    /// <value>The message.</value>
    string Message { get; }
  } // ILogEvent
} // Tethys.Logging

// ==================================
