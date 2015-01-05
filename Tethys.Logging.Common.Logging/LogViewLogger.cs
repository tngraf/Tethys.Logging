#region Header
// ---------------------------------------------------------------------------
// Tethys.Logging.Common.Logging
// ===========================================================================
//
// Common.Logging support for Tethys.Logging.
//
// ===========================================================================
// <copyright file="LogViewLogger.cs" company="Tethys">
// Copyright  2003 - 2013 by Thomas Graf
//            All rights reserved.
//            See the file "License.txt" for information on usage and 
//            redistribution of this file and for a 
//            DISCLAIMER OF ALL WARRANTIES.
// </copyright>
// 
// Version .. 1.00.00.00 of 13Apr20
// Project .. TgLib.Logging.NLog
// Creater .. Thomas Graf (tg)
// System ... Microsoft .Net Framework 4
// Tools .... Microsoft Visual Studio 2010
//
// Change Report
// 10Oct18 1.00.00.00 tg: initial version of the Common.Logging support 
// library.
//
// ---------------------------------------------------------------------------
#endregion

namespace Tethys.Logging.Common.Logging
{
  using System;
  using System.Globalization;

  using global::Common.Logging.Factory;

  /// <summary>
  /// Logger required for logging event redirection.
  /// </summary>
  public class LogViewLogger : AbstractLogger
  {
    #region PRIVATE PROPERTIES
    /// <summary>
    /// Target log viewer.
    /// </summary>
    private readonly ILogView _view;

    /// <summary>
    /// Flag 'add CR/LF at the end of each text line'.
    /// </summary>
    private readonly bool _addCrLf;
    #endregion // PRIVATE PROPERTIES

    //// ---------------------------------------------------------------------

    #region PUBLIC PROPERTIES
    #region OVERRIDES OF ABSTRACTLOGGER
    /// <summary>
    /// Checks if this logger is enabled for the <see cref="F:Common.Logging.LogLevel.Trace"/> level.
    /// </summary>
    /// <remarks>
    /// Override this in your derived class to comply with the underlying logging system
    /// </remarks>
    public override bool IsTraceEnabled
    {
      get { return true; }
    }

    /// <summary>
    /// Checks if this logger is enabled for the <see cref="F:Common.Logging.LogLevel.Debug"/> level.
    /// </summary>
    /// <remarks>
    /// Override this in your derived class to comply with the underlying logging system
    /// </remarks>
    public override bool IsDebugEnabled
    {
      get { return true; }
    }

    /// <summary>
    /// Checks if this logger is enabled for the <see cref="F:Common.Logging.LogLevel.Error"/> level.
    /// </summary>
    /// <remarks>
    /// Override this in your derived class to comply with the underlying logging system
    /// </remarks>
    public override bool IsErrorEnabled
    {
      get { return true; }
    }

    /// <summary>
    /// Checks if this logger is enabled for the <see cref="F:Common.Logging.LogLevel.Fatal"/> level.
    /// </summary>
    /// <remarks>
    /// Override this in your derived class to comply with the underlying logging system
    /// </remarks>
    public override bool IsFatalEnabled
    {
      get { return true; }
    }

    /// <summary>
    /// Checks if this logger is enabled for the <see cref="F:Common.Logging.LogLevel.Info"/> level.
    /// </summary>
    /// <remarks>
    /// Override this in your derived class to comply with the underlying logging system
    /// </remarks>
    public override bool IsInfoEnabled
    {
      get { return true; }
    }

    /// <summary>
    /// Checks if this logger is enabled for the <see cref="F:Common.Logging.LogLevel.Warn"/> level.
    /// </summary>
    /// <remarks>
    /// Override this in your derived class to comply with the underlying logging system
    /// </remarks>
    public override bool IsWarnEnabled
    {
      get { return true; }
    }
    #endregion // OVERRIDES OF ABSTRACTLOGGER
    #endregion // PUBLIC PROPERTIES

    //// ---------------------------------------------------------------------

    #region CONSTRUCTION
    /// <summary>
    /// Initializes a new instance of the <see cref="LogViewLogger"/> class.
    /// </summary>
    /// <param name="view">The view.</param>
    public LogViewLogger(ILogView view)
    {
      if (view == null)
      {
        throw new ArgumentNullException("view");
      } // if

      _view = view;
      _addCrLf = true;
    } // LogViewLogger()

    /// <summary>
    /// Initializes a new instance of the <see cref="LogViewLogger"/> class.
    /// </summary>
    /// <param name="view">The view.</param>
    /// <param name="addLineEnd">Add CR/LF at the end of each text line or not.
    /// </param>
    public LogViewLogger(ILogView view, bool addLineEnd)
    {
      if (view == null)
      {
        throw new ArgumentNullException("view");
      } // if

      _view = view;
      _addCrLf = addLineEnd;
    } // LogViewLogger()
    #endregion // CONSTRUCTION

    //// ---------------------------------------------------------------------

    #region OVERRIDES OF ABSTRACTLOGGER
    /// <summary>
    /// Actually sends the message to the underlying log system.
    /// </summary>
    /// <param name="level">the level of this log event.</param>
    /// <param name="message">the message to log</param>
    /// <param name="exception">the exception to log (may be null)</param>
    protected override void WriteInternal(global::Common.Logging.LogLevel level, 
      object message, Exception exception)
    {
      string logMessage;
      string addon = _addCrLf ? "\n" : string.Empty;

      if (exception == null)
      {
        logMessage = string.Format(CultureInfo.InvariantCulture,
          "{0}{1}", message, addon);
      }
      else
      {
        logMessage = string.Format(CultureInfo.InvariantCulture, 
          "{0}{1}{2}{3}{4}{5}", message, addon,
          exception.Message, addon, exception.StackTrace, addon);
      } // if

      LogEvent le = new LogEvent(ConvertLogLevel(level),
        DateTime.Now, logMessage);

      _view.AddLogEvent(le);
    } // WriteInternal()
    #endregion // OVERRIDES OF ABSTRACTLOGGER

    //// ---------------------------------------------------------------------

    #region PRIVATE METHODS
    /// <summary>
    /// Converts the log level.
    /// </summary>
    /// <param name="level">The level.</param>
    /// <returns>The log level.</returns>
    private static LogLevel ConvertLogLevel(global::Common.Logging.LogLevel level)
    {
      LogLevel result = LogLevel.None;

      if (level == global::Common.Logging.LogLevel.Trace)
      {
        result = LogLevel.Trace;
      }
      else if (level == global::Common.Logging.LogLevel.Debug)
      {
        result = LogLevel.Debug;
      }
      else if (level == global::Common.Logging.LogLevel.Info)
      {
        result = LogLevel.Info;
      }
      else if (level == global::Common.Logging.LogLevel.Warn)
      {
        result = LogLevel.Warn;
      }
      else if (level == global::Common.Logging.LogLevel.Error)
      {
        result = LogLevel.Error;
      }
      else if (level == global::Common.Logging.LogLevel.Fatal)
      {
        result = LogLevel.Fatal;
      }
      else if (level == global::Common.Logging.LogLevel.Off)
      {
        result = LogLevel.None;
      } // if

      return result;
    } // ConvertLogLevel()
    #endregion PRIVATE METHODS
  } // LogViewLogger
} // Tethys.Logging.Common.Logging

// =======================
// End of LogViewLogger.cs
// =======================
