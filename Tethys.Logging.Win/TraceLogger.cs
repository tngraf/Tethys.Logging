#region Header
// --------------------------------------------------------------------------
// Tethys.Logging.Win
// ==========================================================================
//
// A logging library for .NET Framework 4.5.
//
// ===========================================================================
//
// <copyright file="TraceLogger.cs" company="Tethys">
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
      this.FormatOutput(sb, level, message, exception);

      // output formatted text
      System.Diagnostics.Trace.WriteLine(sb.ToString());
    } // WriteInternal()
  } // TraceLogger
} // Tethys.Logging.Simple
