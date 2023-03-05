// -------------------------------------------------------------------------------
// <copyright file="LogLevelFilter.cs" company="Tethys">
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

namespace Tethys.Logging.Log4Net
{
    using log4net.Core;
    using log4net.Filter;

    /// <summary>
    /// LogLevelFilter is a filter for log4net that allows only logging events
    /// to pass the have exactly the specified level.
    /// </summary>
    public class LogLevelFilter : IFilter
    {
        #region PRIVATE PROPERTIES
        /// <summary>
        /// The level to filter for.
        /// </summary>
        private readonly Level level;
        #endregion // PRIVATE PROPERTIES

        //// ---------------------------------------------------------------------

        #region PUBLIC PROPERTIES
        /// <summary>
        /// Gets or sets the next filter.
        /// </summary>
        public IFilter Next { get; set; }
        #endregion // PUBLIC PROPERTIES

        //// ---------------------------------------------------------------------

        #region CONSTRUCTION
        /// <summary>
        /// Initializes a new instance of the <see cref="LogLevelFilter"/> class.
        /// </summary>
        /// <param name="level">The level.</param>
        public LogLevelFilter(Level level)
        {
            this.level = level;
        } // LogLevelFilter()
        #endregion // CONSTRUCTION

        //// ---------------------------------------------------------------------

        #region PUBLIC METHODS
        /// <summary>
        /// Decide if the logging event should be logged through an appender.
        /// </summary>
        /// <param name="loggingEvent">The LoggingEvent to decide upon</param>
        /// <returns>The decision of the filter</returns>
        /// <remarks>
        /// If the decision is <see cref="F:log4net.Filter.FilterDecision.Deny"/>,
        /// then the event will be dropped. If the decision is 
        /// <see cref="F:log4net.Filter.FilterDecision.Neutral"/>, then the next
        /// filter, if any, will be invoked. If the decision is
        /// <see cref="F:log4net.Filter.FilterDecision.Accept"/> then
        /// the event will be logged without consulting with other filters in
        /// the chain.
        /// </remarks>
        public FilterDecision Decide(LoggingEvent loggingEvent)
        {
            if (loggingEvent.Level == this.level)
            {
                return FilterDecision.Accept;
            } // if

            return FilterDecision.Deny;
        } // Decide()

        /// <summary>
        /// Activate the options that were previously set with calls to
        /// properties. 
        /// </summary>
        public void ActivateOptions()
        {
            // not supported, only to fulfill interface
        } // ActivateOptions()
        #endregion // PUBLIC METHODS
    } // LogLevelFilter
} // Tethys.Logging.Log4Net

// ========================
// End of LogLevelFilter.cs
// ========================
