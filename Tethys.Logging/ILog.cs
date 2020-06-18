// --------------------------------------------------------------------------
// Tethys.Logging
// ==========================================================================
//
// A (portable) logging library for .NET Framework 4.5, Silverlight 4 and
// higher, Windows Phone 7 and higher and .NET for Windows Store apps.
//
// ===========================================================================
//
// <copyright file="ILog.cs" company="Tethys">
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

namespace Tethys.Logging
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Interface for logger.
    /// </summary>
    public interface ILog
    {
        #region Trace
        /// <summary>
        /// Log a message with 'Trace' level.
        /// </summary>
        /// <param name="message">The object to log.</param>
        void Trace(object message);

        /// <summary>
        /// Log a message with 'Trace' level.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        void Trace(object message, Exception exception);

        /// <summary>
        /// Log a message with 'Trace' level.
        /// </summary>
        /// <param name="formatProvider">The format provider.</param>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        void TraceFormat(
            IFormatProvider formatProvider, string format, params object[] args);

        /// <summary>
        /// Log a message with 'Trace' level.
        /// </summary>
        /// <param name="formatProvider">The format provider.</param>
        /// <param name="format">The format.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="args">The arguments.</param>
        void TraceFormat(
            IFormatProvider formatProvider, string format, Exception exception, params object[] args);

        /// <summary>
        /// Log a message with 'Trace' level.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        void TraceFormat(string format, params object[] args);

        /// <summary>
        /// Log a message with 'Trace' level.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="args">The arguments.</param>
        void TraceFormat(
            string format, Exception exception, params object[] args);
        #endregion // Trace

        //// --------------------------------------------------------------------

        #region Debug
        /// <summary>
        /// Log a message with 'Debug' level.
        /// </summary>
        /// <param name="message">The object to log.</param>
        void Debug(object message);

        /// <summary>
        /// Log a message with 'Debug' level.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        void Debug(object message, Exception exception);

        /// <summary>
        /// Log a message with 'Debug' level.
        /// </summary>
        /// <param name="formatProvider">The format provider.</param>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        void DebugFormat(
            IFormatProvider formatProvider, string format, params object[] args);

        /// <summary>
        /// Log a message with 'Debug' level.
        /// </summary>
        /// <param name="formatProvider">The format provider.</param>
        /// <param name="format">The format.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="args">The arguments.</param>
        void DebugFormat(
            IFormatProvider formatProvider, string format, Exception exception, params object[] args);

        /// <summary>
        /// Log a message with 'Debug' level.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        void DebugFormat(string format, params object[] args);

        /// <summary>
        /// Log a message with 'Debug' level.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="args">The arguments.</param>
        void DebugFormat(
            string format, Exception exception, params object[] args);
        #endregion // Debug

        //// --------------------------------------------------------------------

        #region Info
        /// <summary>
        /// Log a message with 'Info' level.
        /// </summary>
        /// <param name="message">The object to log.</param>
        void Info(object message);

        /// <summary>
        /// Log a message with 'Info' level.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        void Info(object message, Exception exception);

        /// <summary>
        /// Log a message with 'Info' level.
        /// </summary>
        /// <param name="formatProvider">The format provider.</param>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        void InfoFormat(
            IFormatProvider formatProvider, string format, params object[] args);

        /// <summary>
        /// Log a message with 'Info' level.
        /// </summary>
        /// <param name="formatProvider">The format provider.</param>
        /// <param name="format">The format.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="args">The arguments.</param>
        void InfoFormat(
            IFormatProvider formatProvider, string format, Exception exception, params object[] args);

        /// <summary>
        /// Log a message with 'Info' level.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        void InfoFormat(string format, params object[] args);

        /// <summary>
        /// Log a message with 'Info' level.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="args">The arguments.</param>
        void InfoFormat(
            string format, Exception exception, params object[] args);
        #endregion // Info

        //// --------------------------------------------------------------------

        #region Warn
        /// <summary>
        /// Log a message with 'Warn' level.
        /// </summary>
        /// <param name="message">The object to log.</param>
        void Warn(object message);

        /// <summary>
        /// Log a message with 'Warn' level.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        void Warn(object message, Exception exception);

        /// <summary>
        /// Log a message with 'Warn' level.
        /// </summary>
        /// <param name="formatProvider">The format provider.</param>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        void WarnFormat(
            IFormatProvider formatProvider, string format, params object[] args);

        /// <summary>
        /// Log a message with 'Warn' level.
        /// </summary>
        /// <param name="formatProvider">The format provider.</param>
        /// <param name="format">The format.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="args">The arguments.</param>
        void WarnFormat(
            IFormatProvider formatProvider, string format, Exception exception, params object[] args);

        /// <summary>
        /// Log a message with 'Warn' level.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        void WarnFormat(string format, params object[] args);

        /// <summary>
        /// Log a message with 'Warn' level.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="args">The arguments.</param>
        void WarnFormat(
            string format, Exception exception, params object[] args);
        #endregion // Warn

        //// --------------------------------------------------------------------

        #region Error
        /// <summary>
        /// Log a message with 'Error' level.
        /// </summary>
        /// <param name="message">The object to log.</param>
        [SuppressMessage(
            "Microsoft.Naming",
            "CA1716:IdentifiersShouldNotMatchKeywords",
            MessageId = "Error",
            Justification = "This is ok here!")]
        void Error(object message);

        /// <summary>
        /// Log a message with 'Error' level.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        [SuppressMessage(
            "Microsoft.Naming",
            "CA1716:IdentifiersShouldNotMatchKeywords",
            MessageId = "Error",
            Justification = "This is ok here!")]
        void Error(object message, Exception exception);

        /// <summary>
        /// Log a message with 'Error' level.
        /// </summary>
        /// <param name="formatProvider">The format provider.</param>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        [SuppressMessage(
            "Microsoft.Naming",
            "CA1716:IdentifiersShouldNotMatchKeywords",
            MessageId = "Error",
            Justification = "This is ok here!")]
        void ErrorFormat(
            IFormatProvider formatProvider, string format, params object[] args);

        /// <summary>
        /// Log a message with 'Error' level.
        /// </summary>
        /// <param name="formatProvider">The format provider.</param>
        /// <param name="format">The format.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="args">The arguments.</param>
        [SuppressMessage(
            "Microsoft.Naming",
            "CA1716:IdentifiersShouldNotMatchKeywords",
            MessageId = "Error",
            Justification = "This is ok here!")]
        void ErrorFormat(
            IFormatProvider formatProvider, string format, Exception exception, params object[] args);

        /// <summary>
        /// Log a message with 'Error' level.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        [SuppressMessage(
            "Microsoft.Naming",
            "CA1716:IdentifiersShouldNotMatchKeywords",
            MessageId = "Error",
            Justification = "This is ok here!")]
        void ErrorFormat(string format, params object[] args);

        /// <summary>
        /// Log a message with 'Error' level.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="args">The arguments.</param>
        [SuppressMessage(
            "Microsoft.Naming",
            "CA1716:IdentifiersShouldNotMatchKeywords",
            MessageId = "Error",
            Justification = "This is ok here!")]
        void ErrorFormat(
            string format, Exception exception, params object[] args);
        #endregion // Error

        //// --------------------------------------------------------------------

        #region Trace
        /// <summary>
        /// Log a message with 'Fatal' level.
        /// </summary>
        /// <param name="message">The object to log.</param>
        void Fatal(object message);

        /// <summary>
        /// Log a message with 'Fatal' level.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        void Fatal(object message, Exception exception);

        /// <summary>
        /// Log a message with 'Fatal' level.
        /// </summary>
        /// <param name="formatProvider">The format provider.</param>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        void FatalFormat(
            IFormatProvider formatProvider, string format, params object[] args);

        /// <summary>
        /// Log a message with 'Fatal' level.
        /// </summary>
        /// <param name="formatProvider">The format provider.</param>
        /// <param name="format">The format.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="args">The arguments.</param>
        void FatalFormat(
            IFormatProvider formatProvider, string format, Exception exception, params object[] args);

        /// <summary>
        /// Log a message with 'Fatal' level.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="args">The arguments.</param>
        void FatalFormat(string format, params object[] args);

        /// <summary>
        /// Log a message with 'Fatal' level.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="args">The arguments.</param>
        void FatalFormat(
            string format, Exception exception, params object[] args);
        #endregion // Fatal
    } // ILog
} // Tethys.Logging

// ==========================================
