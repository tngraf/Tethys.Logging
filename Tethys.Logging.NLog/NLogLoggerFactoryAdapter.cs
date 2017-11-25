﻿#region Header
// --------------------------------------------------------------------------
// Tethys.Logging.NLog
// ==========================================================================
//
// A logging library for .NET Framework 4.
//
// ===========================================================================
//
// <copyright file="NLogLoggerFactoryAdapter.cs" company="Tethys">
// Copyright  2009-2015 by Thomas Graf
//            All rights reserved.
//            Licensed under the Apache License, Version 2.0.
//            Unless required by applicable law or agreed to in writing, 
//            software distributed under the License is distributed on an
//            "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
//            either express or implied. 
// </copyright>
//
// System ... Microsoft .Net Framework 4
// Tools .... Microsoft Visual Studio 2013
//
// ---------------------------------------------------------------------------
#endregion

namespace Tethys.Logging.NLog
{
    using System;

    /// <summary>
    /// Factory adapter to forward logging to NLog 2.0.
    /// </summary>
    /// <remarks>
    /// This class is based on ideas coming from 
    /// <a href="http://netcommon.sourceforge.net">Common.Logging</a>.
    /// </remarks>
    public class NLogLoggerFactoryAdapter : ILoggerFactoryAdapter
    {
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
            return new NLogLogger(global::NLog.LogManager.GetLogger(type.FullName));
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
            return new NLogLogger(global::NLog.LogManager.GetLogger(name));
        } // GetLogger()
        #endregion // ILoggerFactoryAdapter Implementation
    } // NLogLoggerFactoryAdapter
} // Tethys.Logging
