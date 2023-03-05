// -------------------------------------------------------------------------------
// <copyright file="ConsoleLoggerFactoryAdapter.cs" company="Tethys">
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
    public class ConsoleLoggerFactoryAdapter : ILoggerFactoryAdapter
    {
        #region PRIVATE PROPERTIES
        /// <summary>
        /// The settings.
        /// </summary>
        private readonly IDictionary<string, string> logSettings;
        #endregion // PRIVATE PROPERTIES

        //// ---------------------------------------------------------------------

        #region CONSTRUCTION
        /// <summary>
        /// Initializes a new instance of the <see cref="ConsoleLoggerFactoryAdapter"/> class.
        /// </summary>
        /// <param name="settings">The settings (optional).</param>
        public ConsoleLoggerFactoryAdapter(IDictionary<string, string> settings = null)
        {
            this.logSettings = settings;
        } // ConsoleLoggerFactoryAdapter()
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
            return new ConsoleLogger(this.logSettings);
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
            return new ConsoleLogger(this.logSettings);
        } // GetLogger()
        #endregion // ILoggerFactoryAdapter Implementation
    } // ConsoleLoggerFactoryAdapter
} // Tethys.Logging.Simple
