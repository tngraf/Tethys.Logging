// -------------------------------------------------------------------------------
// <copyright file="SingleLogFilter.cs" company="Tethys">
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
    using global::NLog;

    using global::NLog.Filters;

    /// <summary>
    /// SingleLogLevelFilter is a filter for NLog that allows only 
    /// logging events to pass the have exactly the specified level.
    /// </summary>
    public class SingleLogLevelFilter : Filter
    {
        #region PRIVATE PROPERTIES
        /// <summary>
        /// Log level that should get filtered.
        /// </summary>
        private readonly LogLevel logLevel;
        #endregion // PRIVATE PROPERTIES

        //// ---------------------------------------------------------------------

        #region PUBLIC PROPERTIES
        /// <summary>
        /// Gets or sets the user-requested action to be taken when filter matches. 
        /// </summary>
        public new FilterResult Action { get; set; }
        #endregion // PUBLIC PROPERTIES

        //// ---------------------------------------------------------------------

        #region CONSTRUCTION
        /// <summary>
        /// Initializes a new instance of the 
        /// <see cref="SingleLogLevelFilter"/> class.
        /// </summary>
        /// <param name="logLevel">The log level.</param>
        public SingleLogLevelFilter(LogLevel logLevel)
        {
            this.logLevel = logLevel;
        } // SingleLogLevelFilter()
        #endregion // CONSTRUCTION

        //// ---------------------------------------------------------------------

        #region PROTECTED METHODS
        /// <summary>
        /// Checks whether log event should be logged or not.
        /// </summary>
        /// <param name="logEvent">Log event.</param>
        /// <returns>
        /// The filter result.
        /// </returns>
        protected override FilterResult Check(LogEventInfo logEvent)
        {
            return logEvent.Level == this.logLevel ?
              FilterResult.Log : FilterResult.Ignore;
        } // Check()
        #endregion // PROTECTED METHODS
    } // SingleLogLevelFilter
} // Tethys.Logging.NLog

// ===================================================
// Tethys.Logging.NLog: end of SingleLogLevelFilter.cs
// ===================================================
