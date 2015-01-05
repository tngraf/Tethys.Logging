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
// </copyright>
// 
// Version .. 1.00.00.00 of 13Apr20
// Project .. TgLib.Logging
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

namespace Tethys.Logging
{
  using System;
  using System.Text;

  /// <summary>
  /// A logger that forwards the log output to an <see cref="ILogView"/> object.
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

      this._view = view;
      this._addCrLf = true;
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

      this._view = view;
      this._addCrLf = addLineEnd;
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
    protected override void WriteInternal(LogLevel level, 
      object message, Exception exception)
    {
      var sb = new StringBuilder();
      this.FormatOutput(sb, level, message, exception);

      if (this._addCrLf)
      {
        sb.Append("\n");
      } // if

      var le = new LogEvent(level, DateTime.Now, sb.ToString());

      this._view.AddLogEvent(le);
    } // WriteInternal()
    #endregion // OVERRIDES OF ABSTRACTLOGGER

    //// ---------------------------------------------------------------------

    #region PRIVATE METHODS
    #endregion PRIVATE METHODS
  } // LogViewLogger
} // Tethys.Logging

// =======================
// End of LogViewLogger.cs
// =======================
