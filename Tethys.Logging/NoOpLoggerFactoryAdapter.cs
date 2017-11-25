#region Header
// --------------------------------------------------------------------------
// Tethys.Logging
// ==========================================================================
//
// A (portable) logging library for .NET Framework 4.5, Silverlight 4 and 
// higher, Windows Phone 7 and higher and .NET for Windows Store apps.
//
// ===========================================================================
//
// <copyright file="NoOpLoggerFactoryAdapter.cs" company="Tethys">
// Copyright  2009-2015 by Thomas Graf
//            All rights reserved.
//            Licensed under the Apache License, Version 2.0.
//            Unless required by applicable law or agreed to in writing, 
//            software distributed under the License is distributed on an
//            "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
//            either express or implied. 
// </copyright>
//
// ---------------------------------------------------------------------------
#endregion

namespace Tethys.Logging
{
    using System;

    /// <summary>
    /// Factory adapter to get a Debug logger.
    /// </summary>
    /// <remarks>
    /// This class is based on ideas coming from 
    /// <a href="http://netcommon.sourceforge.net">Common.Logging</a>.
    /// </remarks>
    public class NoOpLoggerFactoryAdapter : ILoggerFactoryAdapter
    {
        /// <summary>
        /// The one and only logger that logs nothing...
        /// </summary>
        private static readonly ILog DefaultLogger = new NoOpLogger();

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
            return DefaultLogger;
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
            return DefaultLogger;
        } // GetLogger()
        #endregion // ILoggerFactoryAdapter Implementation
    } // NoOpLoggerFactoryAdapter
} // Tethys.Logging
