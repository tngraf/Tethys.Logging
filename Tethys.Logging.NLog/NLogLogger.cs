// -------------------------------------------------------------------------------
// <copyright file="NLogLogger.cs" company="Tethys">
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

using System.Diagnostics.CodeAnalysis;

[module: SuppressMessage("Microsoft.Design",
  "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace",
  Target = "Tethys.Logging.Simple", Justification = "Ok here.")]

namespace Tethys.Logging.NLog
{
    using System;
    using System.Text;

    /// <summary>
    /// A simple logger that forwards all output to a NLog 2.0 logger.
    /// </summary>
    /// <remarks>
    /// This class is based on ideas coming from 
    /// <a href="http://netcommon.sourceforge.net">Common.Logging</a>.
    /// </remarks>
    public class NLogLogger : AbstractLogger
    {
        #region PRIVATE PROPERTIES
        /// <summary>
        /// The internal NLog logger.
        /// </summary>
        private readonly global::NLog.Logger logger;

        /// <summary>
        /// Declaring type used for the NLog logger.
        /// </summary>
        private static readonly Type DeclaringType = typeof(NLogLogger);
        #endregion // PRIVATE PROPERTIES

        //// ---------------------------------------------------------------------

        #region CONSTRUCTION
        /// <summary>
        /// Initializes a new instance of the <see cref="NLogLogger"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        protected internal NLogLogger(global::NLog.Logger logger)
        {
            this.logger = logger;
        } // NLogLogger()
        #endregion // CONSTRUCTION

        //// ---------------------------------------------------------------------

        #region ABSTRACTLOGGER IMPLEMENTATION
        /// <summary>
        /// Do the actual logging by constructing the log message using a
        /// <see cref="StringBuilder" /> then
        /// sending the output to NLog.
        /// </summary>
        /// <param name="level">The <see cref="Logging.LogLevel" /> of the message.
        /// </param>
        /// <param name="message">The log message.</param>
        /// <param name="exception">An optional <see cref="Exception" />
        /// associated with the message.</param>
        protected override void WriteInternal(LogLevel level,
          object message, Exception exception)
        {
            global::NLog.LogLevel nloglevel = TranslateLevel(level);
            global::NLog.LogEventInfo logEvent = new global::NLog.LogEventInfo(
              nloglevel, this.logger.Name, null, "{0}", new[] { message },
              exception);

            this.logger.Log(DeclaringType, logEvent);
        } // WriteInternal()
        #endregion // ABSTRACTLOGGER IMPLEMENTATION

        //// ---------------------------------------------------------------------

        #region PRIVATE METHODS
        /// <summary>
        /// Translates the Tethys.Logging level to a NLog level.
        /// </summary>
        /// <param name="level">The level.</param>
        /// <returns>The NLog log level.</returns>
        private static global::NLog.LogLevel TranslateLevel(LogLevel level)
        {
            switch (level)
            {
                case LogLevel.Trace:
                    return global::NLog.LogLevel.Trace;
                case LogLevel.Debug:
                    return global::NLog.LogLevel.Debug;
                case LogLevel.Info:
                    return global::NLog.LogLevel.Info;
                case LogLevel.Warn:
                    return global::NLog.LogLevel.Warn;
                case LogLevel.Error:
                    return global::NLog.LogLevel.Error;
                case LogLevel.Fatal:
                    return global::NLog.LogLevel.Fatal;
                default:
                    throw new ArgumentOutOfRangeException(nameof(level),
                        "invalid log level");
            } // switch
        } // TranslateLevel()
        #endregion PRIVATE METHODS
    } // NLogLogger
} // Tethys.Logging.Simple
