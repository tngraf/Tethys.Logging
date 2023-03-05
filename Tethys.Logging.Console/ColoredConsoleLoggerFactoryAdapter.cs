// -------------------------------------------------------------------------------
// <copyright file="ColoredConsoleLoggerFactoryAdapter.cs" company="Tethys">
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

namespace Tethys.Logging.Console
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Factory adapter to get a console logger.
    /// </summary>
    /// <remarks>
    /// This class is based on ideas coming from 
    /// <a href="http://netcommon.sourceforge.net">Common.Logging</a>.
    /// </remarks>
    public class ColoredConsoleLoggerFactoryAdapter : ILoggerFactoryAdapter
    {
        #region PRIVATE PROPERTIES
        /// <summary>
        /// The settings.
        /// </summary>
        private readonly IDictionary<string, string> logSettings;

        /// <summary>
        /// The minimum log level.
        /// </summary>
        private readonly LogLevel minLogLevel;
        #endregion // PRIVATE PROPERTIES

        //// ---------------------------------------------------------------------

        #region CONSTRUCTION
        /// <summary>
        /// Initializes a new instance of the <see cref="ColoredConsoleLoggerFactoryAdapter" /> class.
        /// </summary>
        /// <param name="minLevel">The minimum log level to display.</param>
        /// <param name="settings">The settings (optional).</param>
        public ColoredConsoleLoggerFactoryAdapter(LogLevel minLevel, 
            IDictionary<string, string> settings = null)
        {
            this.minLogLevel = minLevel;
            this.logSettings = settings;
        } // ColoredConsoleLoggerFactoryAdapter()
        #endregion // CONSTRUCTION

        //// ---------------------------------------------------------------------

        #region ILoggerFactoryAdapter Implementation
        /// <summary>
        /// Get a ILog instance by type.
        /// </summary>
        /// <param name="type">The type to use for the logger</param>
        /// <returns>
        /// A logger.
        /// </returns>
        public ILog GetLogger(Type type)
        {
            return new ColoredConsoleLogger(this.minLogLevel, this.logSettings);
        } // GetLogger()

        /// <summary>
        /// Get a ILog instance by name.
        /// </summary>
        /// <param name="name">The name of the logger</param>
        /// <returns>
        /// A logger.
        /// </returns>
        public ILog GetLogger(string name)
        {
            return new ColoredConsoleLogger(this.minLogLevel, this.logSettings);
        } // GetLogger()
        #endregion // ILoggerFactoryAdapter Implementation
    } // ColoredConsoleLoggerFactoryAdapter
} // Tethys.Logging.Simple
