// -------------------------------------------------------------------------------
// <copyright file="NLogTargetToLogViewAdapter.cs" company="Tethys">
//   Copyright (C) 2009-2023 Thomas Graf
//   All Rights Reserved.
// </copyright>
//
// Licensed under the Apache License, Version 2.0.
// Unless required by applicable law or agreed to in writing,
// software distributed under the License is distributed on an
// "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
// either express or implied.
// SPDX-License-Identifier: Apache-2.0
// -------------------------------------------------------------------------------

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
        private readonly ILogView view;

        /// <summary>
        /// Flag 'add CR/LF at the end of each text line'.
        /// </summary>
        private readonly bool addCrlf;
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
            this.view = view ?? throw new ArgumentNullException(nameof(view));
            this.addCrlf = true;
        } // NLogTargetToLogViewAdapter()

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="NLogTargetToLogViewAdapter"/> class.
        /// </summary>
        /// <param name="view">Target log viewer.</param>
        /// <param name="addCrlf">Add CR/LF at the end of each text line or not.
        /// </param>
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly",
          MessageId = "CRLF", Justification = "Intended here.")]
        public NLogTargetToLogViewAdapter(ILogView view, bool addCrlf)
        {
            this.view = view ?? throw new ArgumentNullException(nameof(view));
            this.addCrlf = addCrlf;
        } // NLogTargetToLogViewAdapter()
        #endregion // CONSTRUCTION

        //// ---------------------------------------------------------------------

        #region PROTECTED METHODS
        /// <summary>
        /// Writes logging event to the log target.
        /// </summary>
        /// <param name="logEvent">Logging event to be written out.</param>
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
                logMessage = string.Format(CultureInfo.InvariantCulture, 
                    this.addCrlf ? "{0}{1}\r\n{2}\r\n" : "{0}{1}{2}", 
                    this.Layout.Render(logEvent), logEvent.Exception.Message, 
                    logEvent.Exception.StackTrace);
            } // if

            var le = new LogEvent(ConvertLogLevel(logEvent.Level),
              logEvent.TimeStamp, logMessage);

            this.view.AddLogEvent(le);
        } // Write()
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
            var result = Logging.LogLevel.None;

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
