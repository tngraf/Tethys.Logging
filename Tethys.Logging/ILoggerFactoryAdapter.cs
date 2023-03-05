// -------------------------------------------------------------------------------
// <copyright file="ILoggerFactoryAdapter.cs" company="Tethys">
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
    /// LoggerFactoryAdapter interface is used by the <see cref="LogManager"/>
    /// to get the correct logger.
    /// </summary>
    /// <remarks>
    /// This class is based on ideas coming from
    /// <a href="http://netcommon.sourceforge.net">Common.Logging</a>.
    /// </remarks>
    public interface ILoggerFactoryAdapter
    {
        /// <summary>
        /// Get a ILog instance by type.
        /// </summary>
        /// <param name="type">The type to use for the logger.</param>
        /// <returns>A logger.</returns>
        ILog GetLogger(Type type);

        /// <summary>
        /// Get a ILog instance by name.
        /// </summary>
        /// <param name="name">The name of the logger.</param>
        /// <returns>A logger.</returns>
        ILog GetLogger(string name);
    } // ILoggerFactoryAdapter
} // Tethys.Logging
