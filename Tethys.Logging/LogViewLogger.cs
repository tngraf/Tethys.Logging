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
// <copyright file="LogViewLogger.cs" company="Tethys">
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
    private readonly ILogView view;

    /// <summary>
    /// Flag 'add CR/LF at the end of each text line'.
    /// </summary>
    private readonly bool addCrLf;
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

      this.view = view;
      this.addCrLf = true;
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

      this.view = view;
      this.addCrLf = addLineEnd;
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

      if (this.addCrLf)
      {
        sb.Append("\n");
      } // if

      var le = new LogEvent(level, DateTime.Now, sb.ToString());

      this.view.AddLogEvent(le);
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
