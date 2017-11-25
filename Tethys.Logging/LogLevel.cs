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
// <copyright file="LogLevel.cs" company="Tethys">
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
    /// <summary>
    /// Logging levels (of log4net and NLog).
    /// </summary>
    public enum LogLevel
    {
        /// <summary>
        /// No log level (=> ignore).
        /// </summary>
        None = 0,

        /// <summary>
        /// A trace logging level.
        /// </summary>
        Trace = 1,

        /// <summary>
        /// A debug logging level.
        /// </summary>
        Debug = 2,

        /// <summary>
        /// A info logging level.
        /// </summary>
        Info = 3,

        /// <summary>
        /// A warn logging level.
        /// </summary>
        Warn = 4,

        /// <summary>
        /// An error logging level.
        /// </summary>
        Error = 5,

        /// <summary>
        /// A fatal logging level.
        /// </summary>
        Fatal = 6,
    } // LogLevel
} // Tethys.Logging

// =================================
