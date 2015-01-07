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
// <copyright file="NoOpLogger.cs" company="Tethys">
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

  /// <summary>
  /// A simple logger that writes all output to 
  /// </summary>
  /// <remarks>
  /// This class is based on ideas coming from 
  /// <a href="http://netcommon.sourceforge.net">Common.Logging</a>.
  /// </remarks>
  public class NoOpLogger : ILog
  {
    #region ILog implementation
    #region Trace
    /// <summary>
    /// Log a message with 'Trace' level.
    /// </summary>
    /// <param name="message">The object to log.</param>
    public void Trace(object message)
    {
      // do nothing
    } // Trace()

    /// <summary>
    /// Log a message with 'Trace' level.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="exception">The exception.</param>
    public void Trace(object message, Exception exception)
    {
      // do nothing
    } // Trace()

    /// <summary>
    /// Log a message with 'Trace' level.
    /// </summary>
    /// <param name="formatProvider">The format provider.</param>
    /// <param name="format">The format.</param>
    /// <param name="args">The arguments.</param>
    public void TraceFormat(IFormatProvider formatProvider,
      string format, params object[] args)
    {
      // do nothing
    } // TraceFormat()

    /// <summary>
    /// Log a message with 'Trace' level.
    /// </summary>
    /// <param name="formatProvider">The format provider.</param>
    /// <param name="format">The format.</param>
    /// <param name="exception">The exception.</param>
    /// <param name="args">The arguments.</param>
    public void TraceFormat(IFormatProvider formatProvider,
      string format, Exception exception, params object[] args)
    {
      // do nothing
    } // TraceFormat()

    /// <summary>
    /// Log a message with 'Trace' level.
    /// </summary>
    /// <param name="format">The format.</param>
    /// <param name="args">The arguments.</param>
    public virtual void TraceFormat(string format, params object[] args)
    {
      // do nothing
    } // TraceFormat()

    /// <summary>
    /// Log a message with 'Trace' level.
    /// </summary>
    /// <param name="format">The format.</param>
    /// <param name="exception">The exception.</param>
    /// <param name="args">The arguments.</param>
    public virtual void TraceFormat(string format, Exception exception, params object[] args)
    {
      // do nothing
    } // TraceFormat()
    #endregion // Trace

    #region Debug
    /// <summary>
    /// Log a message with 'Debug' level.
    /// </summary>
    /// <param name="message">The object to log.</param>
    public void Debug(object message)
    {
      // do nothing
    } // Debug()

    /// <summary>
    /// Log a message with 'Debug' level.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="exception">The exception.</param>
    public void Debug(object message, Exception exception)
    {
      // do nothing
    } // Debug()

    /// <summary>
    /// Log a message with 'Debug' level.
    /// </summary>
    /// <param name="formatProvider">The format provider.</param>
    /// <param name="format">The format.</param>
    /// <param name="args">The arguments.</param>
    public void DebugFormat(IFormatProvider formatProvider,
      string format, params object[] args)
    {
      // do nothing
    } // DebugFormat()

    /// <summary>
    /// Log a message with 'Debug' level.
    /// </summary>
    /// <param name="formatProvider">The format provider.</param>
    /// <param name="format">The format.</param>
    /// <param name="exception">The exception.</param>
    /// <param name="args">The arguments.</param>
    public void DebugFormat(IFormatProvider formatProvider,
      string format, Exception exception, params object[] args)
    {
      // do nothing
    } // DebugFormat()

    /// <summary>
    /// Log a message with 'Debug' level.
    /// </summary>
    /// <param name="format">The format.</param>
    /// <param name="args">The arguments.</param>
    public virtual void DebugFormat(string format, params object[] args)
    {
      // do nothing
    } // DebugFormat()

    /// <summary>
    /// Log a message with 'Debug' level.
    /// </summary>
    /// <param name="format">The format.</param>
    /// <param name="exception">The exception.</param>
    /// <param name="args">The arguments.</param>
    public virtual void DebugFormat(string format, Exception exception, params object[] args)
    {
      // do nothing
    } // TraceFormat()
    #endregion // Debug

    #region Info
    /// <summary>
    /// Log a message with 'Info' level.
    /// </summary>
    /// <param name="message">The object to log.</param>
    public void Info(object message)
    {
      // do nothing
    } // Info()

    /// <summary>
    /// Log a message with 'Info' level.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="exception">The exception.</param>
    public void Info(object message, Exception exception)
    {
      // do nothing
    } // Info()

    /// <summary>
    /// Log a message with 'Info' level.
    /// </summary>
    /// <param name="formatProvider">The format provider.</param>
    /// <param name="format">The format.</param>
    /// <param name="args">The arguments.</param>
    public void InfoFormat(IFormatProvider formatProvider,
      string format, params object[] args)
    {
      // do nothing
    } // InfoFormat()

    /// <summary>
    /// Log a message with 'Info' level.
    /// </summary>
    /// <param name="formatProvider">The format provider.</param>
    /// <param name="format">The format.</param>
    /// <param name="exception">The exception.</param>
    /// <param name="args">The arguments.</param>
    public void InfoFormat(IFormatProvider formatProvider,
      string format, Exception exception, params object[] args)
    {
      // do nothing
    } // InfoFormat()

    /// <summary>
    /// Log a message with 'Info' level.
    /// </summary>
    /// <param name="format">The format.</param>
    /// <param name="args">The arguments.</param>
    public virtual void InfoFormat(string format, params object[] args)
    {
      // do nothing
    } // InfoFormat()

    /// <summary>
    /// Log a message with 'Info' level.
    /// </summary>
    /// <param name="format">The format.</param>
    /// <param name="exception">The exception.</param>
    /// <param name="args">The arguments.</param>
    public virtual void InfoFormat(string format, Exception exception, params object[] args)
    {
      // do nothing
    } // TraceFormat()
    #endregion // Info

    #region Warn
    /// <summary>
    /// Log a message with 'Warn' level.
    /// </summary>
    /// <param name="message">The object to log.</param>
    public void Warn(object message)
    {
      // do nothing
    } // Warn()

    /// <summary>
    /// Log a message with 'Warn' level.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="exception">The exception.</param>
    public void Warn(object message, Exception exception)
    {
      // do nothing
    } // Warn()

    /// <summary>
    /// Log a message with 'Warn' level.
    /// </summary>
    /// <param name="formatProvider">The format provider.</param>
    /// <param name="format">The format.</param>
    /// <param name="args">The arguments.</param>
    public void WarnFormat(IFormatProvider formatProvider,
      string format, params object[] args)
    {
      // do nothing
    } // WarnFormat()

    /// <summary>
    /// Log a message with 'Warn' level.
    /// </summary>
    /// <param name="formatProvider">The format provider.</param>
    /// <param name="format">The format.</param>
    /// <param name="exception">The exception.</param>
    /// <param name="args">The arguments.</param>
    public void WarnFormat(IFormatProvider formatProvider,
      string format, Exception exception, params object[] args)
    {
      // do nothing
    } // WarnFormat()

    /// <summary>
    /// Log a message with 'Warn' level.
    /// </summary>
    /// <param name="format">The format.</param>
    /// <param name="args">The arguments.</param>
    public virtual void WarnFormat(string format, params object[] args)
    {
      // do nothing
    } // WarnFormat()

    /// <summary>
    /// Log a message with 'Warn' level.
    /// </summary>
    /// <param name="format">The format.</param>
    /// <param name="exception">The exception.</param>
    /// <param name="args">The arguments.</param>
    public virtual void WarnFormat(string format, Exception exception, params object[] args)
    {
      // do nothing
    } // WarnFormat()
    #endregion // Warn

    #region Error
    /// <summary>
    /// Log a message with 'Error' level.
    /// </summary>
    /// <param name="message">The object to log.</param>
    public void Error(object message)
    {
      // do nothing
    } // Error()

    /// <summary>
    /// Log a message with 'Error' level.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="exception">The exception.</param>
    public void Error(object message, Exception exception)
    {
      // do nothing
    } // Error()

    /// <summary>
    /// Log a message with 'Error' level.
    /// </summary>
    /// <param name="formatProvider">The format provider.</param>
    /// <param name="format">The format.</param>
    /// <param name="args">The arguments.</param>
    public void ErrorFormat(IFormatProvider formatProvider,
      string format, params object[] args)
    {
      // do nothing
    } // ErrorFormat()

    /// <summary>
    /// Log a message with 'Error' level.
    /// </summary>
    /// <param name="formatProvider">The format provider.</param>
    /// <param name="format">The format.</param>
    /// <param name="exception">The exception.</param>
    /// <param name="args">The arguments.</param>
    public void ErrorFormat(IFormatProvider formatProvider,
      string format, Exception exception, params object[] args)
    {
      // do nothing
    } // ErrorFormat()

    /// <summary>
    /// Log a message with 'Error' level.
    /// </summary>
    /// <param name="format">The format.</param>
    /// <param name="args">The arguments.</param>
    public virtual void ErrorFormat(string format, params object[] args)
    {
      // do nothing
    } // ErrorFormat()

    /// <summary>
    /// Log a message with 'Error' level.
    /// </summary>
    /// <param name="format">The format.</param>
    /// <param name="exception">The exception.</param>
    /// <param name="args">The arguments.</param>
    public virtual void ErrorFormat(string format, Exception exception, params object[] args)
    {
      // do nothing
    } // ErrorFormat()
    #endregion // Error

    #region Fatal
    /// <summary>
    /// Log a message with 'Fatal' level.
    /// </summary>
    /// <param name="message">The object to log.</param>
    public void Fatal(object message)
    {
      // do nothing
    } // Fatal()

    /// <summary>
    /// Log a message with 'Fatal' level.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="exception">The exception.</param>
    public void Fatal(object message, Exception exception)
    {
      // do nothing
    } // Fatal()

    /// <summary>
    /// Log a message with 'Fatal' level.
    /// </summary>
    /// <param name="formatProvider">The format provider.</param>
    /// <param name="format">The format.</param>
    /// <param name="args">The arguments.</param>
    public void FatalFormat(IFormatProvider formatProvider,
      string format, params object[] args)
    {
      // do nothing
    } // FatalFormat()

    /// <summary>
    /// Log a message with 'Fatal' level.
    /// </summary>
    /// <param name="formatProvider">The format provider.</param>
    /// <param name="format">The format.</param>
    /// <param name="exception">The exception.</param>
    /// <param name="args">The arguments.</param>
    public void FatalFormat(IFormatProvider formatProvider,
      string format, Exception exception, params object[] args)
    {
      // do nothing
    } // FatalFormat()

    /// <summary>
    /// Log a message with 'Fatal' level.
    /// </summary>
    /// <param name="format">The format.</param>
    /// <param name="args">The arguments.</param>
    public virtual void FatalFormat(string format, params object[] args)
    {
      // do nothing
    } // FatalFormat()

    /// <summary>
    /// Log a message with 'Fatal' level.
    /// </summary>
    /// <param name="format">The format.</param>
    /// <param name="exception">The exception.</param>
    /// <param name="args">The arguments.</param>
    public virtual void FatalFormat(string format, Exception exception, params object[] args)
    {
      // do nothing
    } // FatalFormat()
    #endregion // Fatal
    #endregion // ILog implementation
  } // NoOpLogger
} // Tethys.Logging
