// -------------------------------------------------------------------------------
// <copyright file="LogManager.cs" company="Tethys">
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
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Use the LogManager's <see cref="GetLogger(string)"/> or <see cref="GetLogger(System.Type)"/>
    /// methods to obtain <see cref="ILog"/> instances for logging.
    /// </summary>
    /// <remarks>
    /// This class is based on ideas coming from
    /// <a href="http://netcommon.sourceforge.net">Common.Logging</a>.
    /// </remarks>
    public static class LogManager
    {
        /// <summary>
        /// Logger factor to provide concrete loggers.
        /// </summary>
        private static ILoggerFactoryAdapter adapter;

        /// <summary>
        /// Gets or sets the adapter.
        /// </summary>
        /// <value>The adapter.</value>
        [SuppressMessage(
            "Microsoft.Usage",
            "CA2208:InstantiateArgumentExceptionsCorrectly",
            Justification = "Best solution here ...")]
        public static ILoggerFactoryAdapter Adapter
        {
            get
            {
                if (adapter == null)
                {
                    ILoggerFactoryAdapter defaultFactory = new NoOpLoggerFactoryAdapter();
                    return defaultFactory;
                } // if

                return adapter;
            }

            set
            {
                // ReSharper disable once NotResolvedInText
                adapter = value ?? throw new ArgumentNullException("Adapter");
            }
        } // LogManager()

        /// <summary>
        /// Gets the logger by calling <see cref="ILoggerFactoryAdapter.GetLogger(Type)"/>
        /// on the currently configured <see cref="Adapter"/> using the specified type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>the logger instance obtained from the current <see cref="Adapter"/>.</returns>
        public static ILog GetLogger(Type type)
        {
            return Adapter.GetLogger(type);
        } // GetLogger()

        /// <summary>
        /// Gets the logger by calling <see cref="ILoggerFactoryAdapter.GetLogger(string)"/>
        /// on the currently configured <see cref="Adapter"/> using the specified name.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>the logger instance obtained from the current <see cref="Adapter"/>.</returns>
        public static ILog GetLogger(string name)
        {
            return Adapter.GetLogger(name);
        } // GetLogger()
    } // LogManager
} // Tethys.Logging

// =================================
