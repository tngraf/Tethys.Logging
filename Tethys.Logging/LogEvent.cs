// -------------------------------------------------------------------------------
// <copyright file="LogEvent.cs" company="Tethys">
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

namespace Tethys.Logging
{
    using System;

    /// <summary>
    /// This is a generic log event.
    /// </summary>
    public class LogEvent : ILogEvent
    {
        #region PUBLIC PROPERTIES
        /// <summary>
        /// Gets the log level.
        /// </summary>
        /// <value>The level.</value>
        public LogLevel Level { get; }

        /// <summary>
        /// Gets the log event time stamp.
        /// </summary>
        /// <value>The time stamp.</value>
        public DateTime Timestamp { get; }

        /// <summary>
        /// Gets the log message.
        /// </summary>
        /// <value>The message.</value>
        public string Message { get; }
        #endregion // PUBLIC PROPERTIES

        //// ---------------------------------------------------------------------

        #region CONSTRUCTION
        /// <summary>
        /// Initializes a new instance of the <see cref="LogEvent"/> class.
        /// </summary>
        public LogEvent()
        {
            this.Level = LogLevel.None;
            this.Timestamp = DateTime.Now;
            this.Message = string.Empty;
        } // LogEvent()

        /// <summary>
        /// Initializes a new instance of the <see cref="LogEvent"/> class.
        /// </summary>
        /// <param name="level">The level.</param>
        /// <param name="timestamp">The time stamp.</param>
        /// <param name="message">The message.</param>
        public LogEvent(LogLevel level, DateTime timestamp, string message)
        {
            this.Level = level;
            this.Timestamp = timestamp;
            this.Message = message;
        } // LogEvent()
        #endregion // CONSTRUCTION
    } // LogEvent
} // Tethys.Logging

// ==========================================
