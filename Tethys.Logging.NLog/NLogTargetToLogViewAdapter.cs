#region Header
// ---------------------------------------------------------------------------
// Tethys.Logging.NLog
// ===========================================================================
//
// This library contains common code of .Net projects of Thomas Graf.
//
// ===========================================================================
// <copyright file="NLogTargetToLogViewAdapter.cs" company="Tethys">
// Copyright  2003 - 2013 by Thomas Graf
//            All rights reserved.
//            See the file "License.txt" for information on usage and 
//            redistribution of this file and for a 
//            DISCLAIMER OF ALL WARRANTIES.
// </copyright>
// 
// Version .. 1.00.00.00 of 13Mar09
// Project .. TgLib.Logging.NLog
// Creater .. Thomas Graf (tg)
// System ... Microsoft .Net Framework 4
// Tools .... Microsoft Visual Studio 2010
//
// Change Report
// 10Oct18 1.00.00.00 tg: initial version of the NLog support libray.
// 12Jul20 1.00.01.00 tg: update for NLog 2.0.
//
// ---------------------------------------------------------------------------
#endregion

namespace Tethys.Logging.NLog
{
  using System;
  using System.Diagnostics.CodeAnalysis;
  using System.Globalization;

  using global::NLog;

  using global::NLog.Targets;

  /// <summary>
  /// This adapter allows NLog to forward log events to a
  /// Tethys Logging log view.
  /// </summary>
  /// <remarks>
  /// This class is based on ideas coming from 
  /// <a href="http://netcommon.sourceforge.net">Common.Logging</a>.
  /// </remarks>
  public sealed class NLogTargetToLogViewAdapter : TargetWithLayout
  {
    #region PRIVATE PROPERTIES
    /// <summary>
    /// Target log viewer.
    /// </summary>
    private readonly ILogView _view;

    /// <summary>
    /// Flag 'add CR/LF at the end of each text line'.
    /// </summary>
    private readonly bool _addCrlf;
    #endregion // PRIVATE PROPERTIES

    //// ---------------------------------------------------------------------

    #region CONSTRUCTION
    /// <summary>
    /// Initializes a new instance of the
    /// <see cref="NLogTargetToLogViewAdapter"/> class.
    /// </summary>
    /// <param name="view">Target log viewer.</param>
    public NLogTargetToLogViewAdapter(ILogView view)
    {
      if (view == null)
      {
        throw new ArgumentNullException("view");
      } // if

      _view = view;
      this._addCrlf = true;
    } // NLogTargetToLogViewAdapter()

    /// <summary>
    /// Initializes a new instance of the
    /// <see cref="NLogTargetToLogViewAdapter"/> class.
    /// </summary>
    /// <param name="view">Target log viewer.</param>
    /// <param name="addCRLF">Add CR/LF at the end of each text line or not.
    /// </param>
    [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly",
      MessageId = "CRLF", Justification = "Intended here.")]   
    public NLogTargetToLogViewAdapter(ILogView view, bool addCRLF)
    {
      if (view == null)
      {
        throw new ArgumentNullException("view");
      } // if

      _view = view;
      this._addCrlf = addCRLF;
    } // NLogTargetToLogViewAdapter()
    #endregion // CONSTRUCTION

    //// ---------------------------------------------------------------------

    #region PROTECTED METHODS
    /// <summary>
    /// Writes logging event to the log target.
    /// </summary>
    /// <param name="logEvent">Logging event to be written out.</param>
#if true
    protected override void Write(LogEventInfo logEvent)
    {
      string logMessage;

      if (logEvent.Exception == null)
      {
        logMessage = string.Format(CultureInfo.InvariantCulture, "{0}",
          this.Layout.Render(logEvent));
      }
      else
      {
        if (this._addCrlf)
        {
          logMessage = string.Format(CultureInfo.InvariantCulture, "{0}{1}\r\n{2}\r\n",
            Layout.Render(logEvent),
            logEvent.Exception.Message, logEvent.Exception.StackTrace);
        }
        else
        {
          logMessage = string.Format(CultureInfo.InvariantCulture, "{0}{1}{2}",
            Layout.Render(logEvent),
            logEvent.Exception.Message, logEvent.Exception.StackTrace);
        } // if
      } // if

      LogEvent le = new LogEvent(ConvertLogLevel(logEvent.Level),
        logEvent.TimeStamp, logMessage);

      _view.AddLogEvent(le);
    } // Write()
#else
    // for NLog 1.0
    protected override void Write(LogEventInfo logEvent) 
    { 
      string logMessage;

      if (logEvent.Exception == null)
      {
        logMessage = string.Format("{0}", this.
          CompiledLayout.GetFormattedMessage(logEvent));
      }
      else
      {
        if (_addCrlf)
        {
          logMessage = string.Format("{0}{1}\r\n{2}\r\n",
            CompiledLayout.GetFormattedMessage(logEvent),
            logEvent.Exception.Message, logEvent.Exception.StackTrace);
        }
        else
        {
          logMessage = string.Format("{0}{1}{2}",
            CompiledLayout.GetFormattedMessage(logEvent),
            logEvent.Exception.Message, logEvent.Exception.StackTrace);
        } // if
      } // if

      LogEvent le = new LogEvent(ConvertLogLevel(logEvent.Level),
        logEvent.Timestamp, logMessage);

      _view.AddLogEvent(le);
    } // Write()
#endif
    #endregion // PROTECTED METHODS

    //// ---------------------------------------------------------------------

    #region PRIVATE METHODS
    /// <summary>
    /// Converts the log level.
    /// </summary>
    /// <param name="level">The level.</param>
    /// <returns>The log level.</returns>
    private static Logging.LogLevel ConvertLogLevel(LogLevel level)
    {
      Logging.LogLevel result = Logging.LogLevel.None;

      if (level == LogLevel.Trace)
      {
        result = Logging.LogLevel.Trace;
      }
      else if (level == LogLevel.Debug)
      {
        result = Logging.LogLevel.Debug;
      }
      else if (level == LogLevel.Info)
      {
        result = Logging.LogLevel.Info;
      }
      else if (level == LogLevel.Warn)
      {
        result = Logging.LogLevel.Warn;
      }
      else if (level == LogLevel.Error)
      {
        result = Logging.LogLevel.Error;
      }
      else if (level == LogLevel.Fatal)
      {
        result = Logging.LogLevel.Fatal;
      }
      else if (level == LogLevel.Off)
      {
        result = Logging.LogLevel.None;
      } // if

      return result;
    } // ConvertLogLevel()
    #endregion PRIVATE METHODS
  } // NLogTargetToLogViewAdapter
} // Tethys.Logging.NLog

// =========================================================
// Tethys.Logging.NLog: end of NLogTargetToLogViewAdapter.cs
// =========================================================
