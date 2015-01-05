#region Header
// --------------------------------------------------------------------------
// Tethys.Logging
// ==========================================================================
//
// A portable logging library for .NET Framework 4.5, Silverlight 4 and 
// higher, Windows Phone 7 and higher and .NET for Windows Store apps.
//
// ==========================================================================
// <copyright file="TraceLogger.cs" company="Tethys">
// Copyright  2013 by Thomas Graf
//            All rights reserved.
// </copyright>
// 
// Version .. 1.00.01.00 of 13Oct09
// System ... Portable Library
// Tools .... Microsoft Visual Studio 2012
//
// Change Report
// 13Oct09 1.00.01.00 tg: initial version.
//
// ---------------------------------------------------------------------------
#endregion

using System.Diagnostics.CodeAnalysis;

[module: SuppressMessage("Microsoft.Design", 
  "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace",
  Target = "Tethys.Logging.Win", Justification = "Ok here.")]

namespace Tethys.Logging.Win
{
    using System;
    using System.Text;

    /// <summary>
  /// A simple logger that writes all output to Trace.WriteLine.
  /// </summary>
  /// <remarks>
  /// This class is based on ideas coming from 
  /// <a href="http://netcommon.sourceforge.net">Common.Logging</a>.
  /// </remarks>
  public class TraceLogger : AbstractLogger
  {
    /// <summary>
    /// Do the actual logging by constructing the log message using a <see cref="StringBuilder" /> then
    /// sending the output to <c>Trace.WriteLine</c>.
    /// </summary>
    /// <param name="level">The <see cref="LogLevel" /> of the message.</param>
    /// <param name="message">The log message.</param>
    /// <param name="exception">An optional <see cref="Exception" /> associated with the message.</param>
    protected override void WriteInternal(LogLevel level, object message, Exception exception)
    {
      // Use a StringBuilder for better performance
      var sb = new StringBuilder();
      FormatOutput(sb, level, message, exception);

      // output formatted text
      System.Diagnostics.Trace.WriteLine(sb.ToString());
    } // WriteInternal()
  } // TraceLogger
} // Tethys.Logging.Simple
