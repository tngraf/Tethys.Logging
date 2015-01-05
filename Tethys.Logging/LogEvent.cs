#region Header
// --------------------------------------------------------------------------
// Tethys.Logging
// ==========================================================================
//
// A portable logging library for .NET Framework 4.5, Silverlight 4 and 
// higher, Windows Phone 7 and higher and .NET for Windows Store apps.
//
// ==========================================================================
// <copyright file="LogEvent.cs" company="Tethys">
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
  /// This is a generic log event. 
  /// </summary>
  public class LogEvent : ILogEvent
  {
    #region PUBLIC PROPERTIES
    /// <summary>
    /// Gets the log level.
    /// </summary>
    /// <value>The level.</value>
    public LogLevel Level { get; private set; }

    /// <summary>
    /// Gets the log event time stamp.
    /// </summary>
    /// <value>The time stamp.</value>
    public DateTime Timestamp { get; private set; }

    /// <summary>
    /// Gets the log message.
    /// </summary>
    /// <value>The message.</value>
    public string Message { get; private set; }
    #endregion // PUBLIC PROPERTIES

    //// ---------------------------------------------------------------------

    #region CONSTRUCTION
    /// <summary>
    /// Initializes a new instance of the <see cref="LogEvent"/> class.
    /// </summary>
    public LogEvent()
    {
      this.Level = LogLevel.None;
      this.Timestamp = DateTime.Now;
      this.Message = string.Empty;
    } // LogEvent()

    /// <summary>
    /// Initializes a new instance of the <see cref="LogEvent"/> class.
    /// </summary>
    /// <param name="level">The level.</param>
    /// <param name="timestamp">The time stamp.</param>
    /// <param name="message">The message.</param>
    public LogEvent(LogLevel level, DateTime timestamp, string message)
    {
      this.Level = level;
      this.Timestamp = timestamp;
      this.Message = message;
    } // LogEvent()
    #endregion // CONSTRUCTION
  } // LogEvent
} // Tethys.Logging

// ==========================================
