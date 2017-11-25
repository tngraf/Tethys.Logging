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
// <copyright file="LogViewLogger.cs" company="Tethys">
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
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Text;

    /// <summary>
    /// A logger that forwards the log output to an <see cref="ILogView"/> object.
    /// </summary>
    public class LogViewLogger : AbstractLogger
    {
        #region PRIVATE PROPERTIES        
        /// <summary>
        /// The settings key 'add CR/LF'.
        /// </summary>
        private const string KeyAddCrLf = "AddCrLf";

        /// <summary>
        /// The settings key 'add time'.
        /// </summary>
        private const string KeyAddTime = "AddTime";

        /// <summary>
        /// The settings key 'add level'.
        /// </summary>
        private const string KeyAddLevel = "AddLevel";

        /// <summary>
        /// Target log viewer.
        /// </summary>
        private readonly ILogView view;

        /// <summary>
        /// Flag 'add CR/LF at the end of each text line'.
        /// </summary>
        private bool addCrLf;

        /// <summary>
        /// Flag 'add time'.
        /// </summary>
        private bool addTime;

        /// <summary>
        /// Flag 'add level'.
        /// </summary>
        private bool addLevel;
        #endregion // PRIVATE PROPERTIES

        //// ---------------------------------------------------------------------

        #region CONSTRUCTION
        /// <summary>
        /// Initializes a new instance of the <see cref="LogViewLogger"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public LogViewLogger(ILogView view)
        {
            this.view = view ?? throw new ArgumentNullException(nameof(view));
            this.addCrLf = true;
            this.addTime = true;
            this.addLevel = true;
        } // LogViewLogger()

        /// <summary>
        /// Initializes a new instance of the <see cref="LogViewLogger"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        /// <param name="addLineEnd">Add CR/LF at the end of each text line or not.
        /// </param>
        public LogViewLogger(ILogView view, bool addLineEnd)
        {
            this.view = view ?? throw new ArgumentNullException(nameof(view));
            this.addCrLf = addLineEnd;
            this.addTime = true;
            this.addLevel = true;
        } // LogViewLogger()

        /// <summary>
        /// Initializes a new instance of the <see cref="LogViewLogger" /> class.
        /// </summary>
        /// <param name="view">The view.</param>
        /// <param name="settings">The settings.</param>
        public LogViewLogger(ILogView view, IDictionary<string, string> settings)
        {
            this.view = view ?? throw new ArgumentNullException(nameof(view));
            this.addCrLf = true;
            this.addTime = true;
            this.addLevel = true;
            this.EvaluateSettings(settings);
        } // LogViewLogger()
        #endregion // CONSTRUCTION

        //// ---------------------------------------------------------------------

        #region OVERRIDES OF ABSTRACTLOGGER
        /// <summary>
        /// Actually sends the message to the underlying log system.
        /// </summary>
        /// <param name="level">the level of this log event.</param>
        /// <param name="message">the message to log</param>
        /// <param name="exception">the exception to log (may be null)</param>
        protected override void WriteInternal(LogLevel level,
          object message, Exception exception)
        {
            var sb = new StringBuilder();
            this.FormatOutput(sb, level, message, exception);

            if (this.addCrLf)
            {
                sb.Append("\n");
            } // if

            var le = new LogEvent(level, DateTime.Now, sb.ToString());

            this.view.AddLogEvent(le);
        } // WriteInternal()

        /// <summary>
        /// Appends the formatted message to the specified <see cref="StringBuilder" />.
        /// </summary>
        /// <param name="stringBuilder">the <see cref="StringBuilder" />
        /// that receives the formatted message.</param>
        /// <param name="level">The level.</param>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        [SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames",
            MessageId = "string", Justification = "Best solution...")]
        protected override void FormatOutput(StringBuilder stringBuilder,
                                             LogLevel level, object message, Exception exception)
        {
            if (stringBuilder == null)
            {
                throw new ArgumentNullException(nameof(stringBuilder));
            }

            // Append date and time
            if (this.addTime)
            {
                stringBuilder.Append(DateTime.Now);
                stringBuilder.Append(" ");
            } // if

            // Append a readable representation of the log level
            if (this.addLevel)
            {
                stringBuilder.Append(("[" + level.ToString().ToUpper() + "]").PadRight(8));
            } // if

            // Append the message
            stringBuilder.Append(message);

            // Append stack trace if not null
            if (exception != null)
            {
                stringBuilder.Append(Environment.NewLine).Append(exception);
            } // if
        } // FormatOutput()
        #endregion // OVERRIDES OF ABSTRACTLOGGER

        //// ---------------------------------------------------------------------

        #region PRIVATE METHODS
        /// <summary>
        /// Evaluates the settings.
        /// </summary>
        /// <param name="settings">The settings.</param>
        private void EvaluateSettings(IDictionary<string, string> settings)
        {
            if (settings == null)
            {
                return;
            } // if

            if (settings.ContainsKey(KeyAddCrLf))
            {
                var value = settings[KeyAddCrLf].Equals("TRUE", StringComparison.OrdinalIgnoreCase);
                this.addCrLf = value;
            } // if

            if (settings.ContainsKey(KeyAddTime))
            {
                var value = settings[KeyAddTime].Equals("TRUE", StringComparison.OrdinalIgnoreCase);
                this.addTime = value;
            } // if

            if (settings.ContainsKey(KeyAddLevel))
            {
                var value = settings[KeyAddLevel].Equals("TRUE", StringComparison.OrdinalIgnoreCase);
                this.addLevel = value;
            } // if
        } // EvaluateSettings()
        #endregion PRIVATE METHODS
    } // LogViewLogger
} // Tethys.Logging

// =======================
// End of LogViewLogger.cs
// =======================
