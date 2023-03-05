// -------------------------------------------------------------------------------
// <copyright file="ConsoleLogger.cs" company="Tethys">
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

using System.Diagnostics.CodeAnalysis;

[module: SuppressMessage("Microsoft.Design",
  "CA1020:AvoidNamespacesWithFewTypes", Scope = "namespace",
  Target = "Tethys.Logging.Simple", Justification = "Ok here.")]

namespace Tethys.Logging.Console
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// A simple logger that writes all output to the console.
    /// </summary>
    public class ConsoleLogger : AbstractLogger
    {
        #region PRIVATE PROPERTIES        
        /// <summary>
        /// The settings key 'add time'.
        /// </summary>
        private const string KeyAddTime = "AddTime";

        /// <summary>
        /// The settings key 'add level'.
        /// </summary>
        private const string KeyAddLevel = "AddLevel";

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
        /// Initializes a new instance of the <see cref="ConsoleLogger" /> class.
        /// </summary>
        /// <param name="settings">The settings.</param>
        public ConsoleLogger(IDictionary<string, string> settings)
        {
            this.addTime = true;
            this.addLevel = true;
            this.EvaluateSettings(settings);
        } // ConsoleLogger()
        #endregion // CONSTRUCTION

        //// ---------------------------------------------------------------------

        #region OVERRIDES OF ABSTRACTLOGGER
        /// <summary>
        /// Do the actual logging by constructing the log message using a <see cref="StringBuilder" /> then
        /// sending the output to <c>Debug.WriteLine</c>.
        /// </summary>
        /// <param name="level">The <see cref="LogLevel" /> of the message.</param>
        /// <param name="message">The log message.</param>
        /// <param name="exception">An optional <see cref="Exception" /> associated with the message.</param>
        protected override void WriteInternal(LogLevel level, object message, Exception exception)
        {
            // Use a StringBuilder for better performance
            var sb = new StringBuilder();
            this.FormatOutput(sb, level, message, exception);

            // output formatted text
            Console.WriteLine(sb.ToString());
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
    } // ConsoleLogger
} // Tethys.Logging.Console
