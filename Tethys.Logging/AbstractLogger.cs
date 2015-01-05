#region Header
// --------------------------------------------------------------------------
// Tethys.Logging
// ==========================================================================
//
// A portable logging library for .NET Framework 4.5, Silverlight 4 and 
// higher, Windows Phone 7 and higher and .NET for Windows Store apps.
//
// ==========================================================================
// <copyright file="AbstractLogger.cs" company="Tethys">
// Copyright  2013 by Thomas Graf
//            All rights reserved.
// </copyright>
// 
// Version .. 1.00.00.00 of 13Apr03
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
  using System.Diagnostics.CodeAnalysis;
  using System.Globalization;
  using System.Text;

  /// <summary>
  /// An abstract logger to simply the creation of loggers.
  /// </summary>
  /// <remarks>
  /// This class is based on ideas coming from 
  /// <a href="http://netcommon.sourceforge.net">Common.Logging</a>.
  /// </remarks>
  public abstract class AbstractLogger : ILog
  {
    /// <summary>
    /// Appends the formatted message to the specified <see cref="StringBuilder" />.
    /// </summary>
    /// <param name="stringBuilder">the <see cref="StringBuilder" />
    /// that receives the formatted message.</param>
    /// <param name="level">The level.</param>
    /// <param name="message">The message.</param>
    /// <param name="exception">The exception.</param>
    [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames",
      MessageId = "string", Justification = "Best solution...")]
    protected virtual void FormatOutput(StringBuilder stringBuilder,
      LogLevel level, object message, Exception exception)
    {
      if (stringBuilder == null)
      {
        throw new ArgumentNullException("stringBuilder");
      }

      // Append date and time
      stringBuilder.Append(DateTime.Now);
      stringBuilder.Append(" ");

      // Append a readable representation of the log level
      stringBuilder.Append(("[" + level.ToString().ToUpper() + "]").PadRight(8));

      // Append the message
      stringBuilder.Append(message);

      // Append stack trace if not null
      if (exception != null)
      {
        stringBuilder.Append(Environment.NewLine).Append(exception);
      } // if
    } // FormatOutput()

    /// <summary>
    /// Do the actual logging by constructing the log message using a <see cref="StringBuilder" /> then
    /// sending the output to this final target implemented in derived classes.
    /// </summary>
    /// <param name="level">The <see cref="LogLevel" /> of the message.</param>
    /// <param name="message">The log message.</param>
    /// <param name="exception">An optional <see cref="Exception" /> associated with the message.</param>
    protected abstract void WriteInternal(LogLevel level, object message, Exception exception);

    #region ILog implementation
    #region Trace
    /// <summary>
    /// Log a message with 'Trace' level.
    /// </summary>
    /// <param name="message">The object to log.</param>
    public void Trace(object message)
    {
      WriteInternal(LogLevel.Trace, message, null);
    } // Trace()

    /// <summary>
    /// Log a message with 'Trace' level.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="exception">The exception.</param>
    public void Trace(object message, Exception exception)
    {
      WriteInternal(LogLevel.Trace, message, exception);
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
      WriteInternal(LogLevel.Trace,
        string.Format(formatProvider, format, args), null);
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
      WriteInternal(LogLevel.Trace, string.Format(formatProvider,
        format, args), exception);
    } // TraceFormat()

    /// <summary>
    /// Log a message with 'Trace' level.
    /// </summary>
    /// <param name="format">The format.</param>
    /// <param name="args">The arguments.</param>
    public virtual void TraceFormat(string format, params object[] args)
    {
      WriteInternal(LogLevel.Trace, string.Format(
        CultureInfo.InvariantCulture, format, args), null);
    } // TraceFormat()

    /// <summary>
    /// Log a message with 'Trace' level.
    /// </summary>
    /// <param name="format">The format.</param>
    /// <param name="exception">The exception.</param>
    /// <param name="args">The arguments.</param>
    public virtual void TraceFormat(string format, Exception exception, params object[] args)
    {
      WriteInternal(LogLevel.Trace, string.Format(
        CultureInfo.InvariantCulture, format, args), exception);
    } // TraceFormat()
    #endregion // Trace

    #region Debug
    /// <summary>
    /// Log a message with 'Debug' level.
    /// </summary>
    /// <param name="message">The object to log.</param>
    public void Debug(object message)
    {
      WriteInternal(LogLevel.Debug, message, null);
    } // Debug()

    /// <summary>
    /// Log a message with 'Debug' level.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="exception">The exception.</param>
    public void Debug(object message, Exception exception)
    {
      WriteInternal(LogLevel.Debug, message, exception);
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
      WriteInternal(LogLevel.Debug,
        string.Format(formatProvider, format, args), null);
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
      WriteInternal(LogLevel.Debug, string.Format(formatProvider,
        format, args), exception);
    } // DebugFormat()

    /// <summary>
    /// Log a message with 'Debug' level.
    /// </summary>
    /// <param name="format">The format.</param>
    /// <param name="args">The arguments.</param>
    public virtual void DebugFormat(string format, params object[] args)
    {
      WriteInternal(LogLevel.Debug, string.Format(
        CultureInfo.InvariantCulture, format, args), null);
    } // DebugFormat()

    /// <summary>
    /// Log a message with 'Debug' level.
    /// </summary>
    /// <param name="format">The format.</param>
    /// <param name="exception">The exception.</param>
    /// <param name="args">The arguments.</param>
    public virtual void DebugFormat(string format, Exception exception, params object[] args)
    {
      WriteInternal(LogLevel.Debug, string.Format(
        CultureInfo.InvariantCulture, format, args), exception);
    } // TraceFormat()
    #endregion // Debug

    #region Info
    /// <summary>
    /// Log a message with 'Info' level.
    /// </summary>
    /// <param name="message">The object to log.</param>
    public void Info(object message)
    {
      WriteInternal(LogLevel.Info, message, null);
    } // Info()

    /// <summary>
    /// Log a message with 'Info' level.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="exception">The exception.</param>
    public void Info(object message, Exception exception)
    {
      WriteInternal(LogLevel.Info, message, exception);
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
      WriteInternal(LogLevel.Info,
        string.Format(formatProvider, format, args), null);
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
      WriteInternal(LogLevel.Info, string.Format(formatProvider,
        format, args), exception);
    } // InfoFormat()

    /// <summary>
    /// Log a message with 'Info' level.
    /// </summary>
    /// <param name="format">The format.</param>
    /// <param name="args">The arguments.</param>
    public virtual void InfoFormat(string format, params object[] args)
    {
      WriteInternal(LogLevel.Info, string.Format(
        CultureInfo.InvariantCulture, format, args), null);
    } // InfoFormat()

    /// <summary>
    /// Log a message with 'Info' level.
    /// </summary>
    /// <param name="format">The format.</param>
    /// <param name="exception">The exception.</param>
    /// <param name="args">The arguments.</param>
    public virtual void InfoFormat(string format, Exception exception, params object[] args)
    {
      WriteInternal(LogLevel.Info, string.Format(
        CultureInfo.InvariantCulture, format, args), exception);
    } // TraceFormat()
    #endregion // Info

    #region Warn
    /// <summary>
    /// Log a message with 'Warn' level.
    /// </summary>
    /// <param name="message">The object to log.</param>
    public void Warn(object message)
    {
      WriteInternal(LogLevel.Warn, message, null);
    } // Warn()

    /// <summary>
    /// Log a message with 'Warn' level.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="exception">The exception.</param>
    public void Warn(object message, Exception exception)
    {
      WriteInternal(LogLevel.Warn, message, exception);
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
      WriteInternal(LogLevel.Warn,
        string.Format(formatProvider, format, args), null);
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
      WriteInternal(LogLevel.Warn, string.Format(formatProvider,
        format, args), exception);
    } // WarnFormat()

    /// <summary>
    /// Log a message with 'Warn' level.
    /// </summary>
    /// <param name="format">The format.</param>
    /// <param name="args">The arguments.</param>
    public virtual void WarnFormat(string format, params object[] args)
    {
      WriteInternal(LogLevel.Warn, string.Format(
        CultureInfo.InvariantCulture, format, args), null);
    } // WarnFormat()

    /// <summary>
    /// Log a message with 'Warn' level.
    /// </summary>
    /// <param name="format">The format.</param>
    /// <param name="exception">The exception.</param>
    /// <param name="args">The arguments.</param>
    public virtual void WarnFormat(string format, Exception exception, params object[] args)
    {
      WriteInternal(LogLevel.Warn, string.Format(
        CultureInfo.InvariantCulture, format, args), exception);
    } // WarnFormat()
    #endregion // Warn

    #region Error
    /// <summary>
    /// Log a message with 'Error' level.
    /// </summary>
    /// <param name="message">The object to log.</param>
    public void Error(object message)
    {
      WriteInternal(LogLevel.Error, message, null);
    } // Error()

    /// <summary>
    /// Log a message with 'Error' level.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="exception">The exception.</param>
    public void Error(object message, Exception exception)
    {
      WriteInternal(LogLevel.Error, message, exception);
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
      WriteInternal(LogLevel.Error,
        string.Format(formatProvider, format, args), null);
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
      WriteInternal(LogLevel.Error, string.Format(formatProvider,
        format, args), exception);
    } // ErrorFormat()

    /// <summary>
    /// Log a message with 'Error' level.
    /// </summary>
    /// <param name="format">The format.</param>
    /// <param name="args">The arguments.</param>
    public virtual void ErrorFormat(string format, params object[] args)
    {
      WriteInternal(LogLevel.Error, string.Format(
        CultureInfo.InvariantCulture, format, args), null);
    } // ErrorFormat()

    /// <summary>
    /// Log a message with 'Error' level.
    /// </summary>
    /// <param name="format">The format.</param>
    /// <param name="exception">The exception.</param>
    /// <param name="args">The arguments.</param>
    public virtual void ErrorFormat(string format, Exception exception, params object[] args)
    {
      WriteInternal(LogLevel.Error, string.Format(
        CultureInfo.InvariantCulture, format, args), exception);
    } // ErrorFormat()
    #endregion // Error

    #region Fatal
    /// <summary>
    /// Log a message with 'Fatal' level.
    /// </summary>
    /// <param name="message">The object to log.</param>
    public void Fatal(object message)
    {
      WriteInternal(LogLevel.Trace, message, null);
    } // Fatal()

    /// <summary>
    /// Log a message with 'Fatal' level.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="exception">The exception.</param>
    public void Fatal(object message, Exception exception)
    {
      WriteInternal(LogLevel.Trace, message, exception);
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
      WriteInternal(LogLevel.Fatal,
        string.Format(formatProvider, format, args), null);
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
      WriteInternal(LogLevel.Fatal, string.Format(formatProvider,
        format, args), exception);
    } // FatalFormat()

    /// <summary>
    /// Log a message with 'Fatal' level.
    /// </summary>
    /// <param name="format">The format.</param>
    /// <param name="args">The arguments.</param>
    public virtual void FatalFormat(string format, params object[] args)
    {
      WriteInternal(LogLevel.Fatal, string.Format(
        CultureInfo.InvariantCulture, format, args), null);
    } // FatalFormat()

    /// <summary>
    /// Log a message with 'Fatal' level.
    /// </summary>
    /// <param name="format">The format.</param>
    /// <param name="exception">The exception.</param>
    /// <param name="args">The arguments.</param>
    public virtual void FatalFormat(string format, Exception exception, params object[] args)
    {
      WriteInternal(LogLevel.Fatal, string.Format(
        CultureInfo.InvariantCulture, format, args), exception);
    } // FatalFormat()
    #endregion // Fatal
    #endregion // ILog implementation
  } // AbstractLogger
} // Tethys.Logging
