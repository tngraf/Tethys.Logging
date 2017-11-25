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
// <copyright file="ILogEvent.cs" company="Tethys">
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
    /// Interface for logging events for log viewer.
    /// This is an abstract interface for as well log4net as
    /// NLog logging events.
    /// </summary>
    public interface ILogEvent
    {
        /// <summary>
        /// Gets the log level.
        /// </summary>
        /// <value>The level.</value>
        LogLevel Level { get; }

        /// <summary>
        /// Gets the log event time stamp.
        /// </summary>
        /// <value>The time stamp.</value>
        DateTime Timestamp { get; }

        /// <summary>
        /// Gets the log message.
        /// </summary>
        /// <value>The message.</value>
        string Message { get; }
    } // ILogEvent
} // Tethys.Logging

// ==================================
