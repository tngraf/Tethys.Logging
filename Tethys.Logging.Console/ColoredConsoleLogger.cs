// -------------------------------------------------------------------------------
// <copyright file="ColoredConsoleLogger.cs" company="Tethys">
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
    public class ColoredConsoleLogger : AbstractLogger
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
        /// The settings key for the color for log level trace.
        /// </summary>
        private const string KeyColorTrace = "ColorTrace";

        /// <summary>
        /// The settings key for the color for log level debug.
        /// </summary>
        private const string KeyColorDebug = "ColorDebug";

        /// <summary>
        /// The settings key for the color for log level info.
        /// </summary>
        private const string KeyColorInfo = "ColorInfo";

        /// <summary>
        /// The settings key for the color for log level warn.
        /// </summary>
        private const string KeyColorWarn = "ColorWarn";

        /// <summary>
        /// The settings key for the color for log level error.
        /// </summary>
        private const string KeyColorError = "ColorError";

        /// <summary>
        /// The settings key for the color for log level fatal.
        /// </summary>
        private const string KeyColorFatal = "ColorFatal";

        /// <summary>
        /// The color for trace output.
        /// </summary>
        private const ConsoleColor DefaultColorTrace = ConsoleColor.DarkGray;

        /// <summary>
        /// The color for debug output.
        /// </summary>
        private const ConsoleColor DefaultColorDebug = ConsoleColor.Gray;

        /// <summary>
        /// The color for info output.
        /// </summary>
        private const ConsoleColor DefaultColorInfo = ConsoleColor.White;

        /// <summary>
        /// The color for warning output.
        /// </summary>
        private const ConsoleColor DefaultColorWarn = ConsoleColor.Yellow;

        /// <summary>
        /// The color for error output.
        /// </summary>
        private const ConsoleColor DefaultColorError = ConsoleColor.Red;

        /// <summary>
        /// The color for fatal error output.
        /// </summary>
        private const ConsoleColor DefaultColorFatal = ConsoleColor.Red;

        /// <summary>
        /// The minimum log level.
        /// </summary>
        private readonly LogLevel minLogLevel;

        /// <summary>
        /// Flag 'add time'.
        /// </summary>
        private bool addTime;

        /// <summary>
        /// Flag 'add level'.
        /// </summary>
        private bool addLevel;

        /// <summary>
        /// The color for trace output.
        /// </summary>
        private ConsoleColor colorTrace = DefaultColorTrace;

        /// <summary>
        /// The color for debug output.
        /// </summary>
        private ConsoleColor colorDebug = DefaultColorDebug;

        /// <summary>
        /// The color for info output.
        /// </summary>
        private ConsoleColor colorInfo = DefaultColorInfo;

        /// <summary>
        /// The color for warning output.
        /// </summary>
        private ConsoleColor colorWarn = DefaultColorWarn;

        /// <summary>
        /// The color for error output.
        /// </summary>
        private ConsoleColor colorError = DefaultColorError;

        /// <summary>
        /// The color for fatal error output.
        /// </summary>
        private ConsoleColor colorFatal = DefaultColorFatal;
        #endregion // PRIVATE PROPERTIES

        //// ---------------------------------------------------------------------

        #region CONSTRUCTION
        /// <summary>
        /// Initializes a new instance of the <see cref="ColoredConsoleLogger" /> class.
        /// </summary>
        /// <param name="minLevel">The minimum log level.</param>
        /// <param name="settings">The settings.</param>
        public ColoredConsoleLogger(LogLevel minLevel, IDictionary<string, string> settings)
        {
            this.minLogLevel = minLevel;
            this.addTime = true;
            this.addLevel = true;
            this.EvaluateSettings(settings);
        } // ColoredConsoleLogger()
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
            if (level < this.minLogLevel)
            {
                return;
            } // if

            // Use a StringBuilder for better performance
            var sb = new StringBuilder();
            this.FormatOutput(sb, level, message, exception);

            // backup current console color
            var backup = Console.ForegroundColor;
            Console.ForegroundColor = this.GetForegroundColor(level);

            // output formatted text
            Console.WriteLine(sb.ToString());

            Console.ForegroundColor = backup;
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
        /// Gets the foreground color for the given log level.
        /// </summary>
        /// <param name="level">The log level.</param>
        /// <returns>A <see cref="ConsoleColor"/> value.</returns>
        private ConsoleColor GetForegroundColor(LogLevel level)
        {
            var color = ConsoleColor.White;

            switch (level)
            {
                case LogLevel.Trace:
                    color = this.colorTrace;
                    break;
                case LogLevel.Debug:
                    color = this.colorDebug;
                    break;
                case LogLevel.Info:
                    color = this.colorInfo;
                    break;
                case LogLevel.Warn:
                    color = this.colorWarn;
                    break;
                case LogLevel.Error:
                    color = this.colorError;
                    break;
                case LogLevel.Fatal:
                    color = this.colorFatal;
                    break;
            } // switch

            return color;
        } // GetForegroundColor()

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

            ConsoleColor color;
            if (settings.ContainsKey(KeyColorTrace))
            {
                if (Enum.TryParse(settings[KeyColorTrace], true, out color))
                {
                    this.colorTrace = color;
                } // if
            } // if

            if (settings.ContainsKey(KeyColorDebug))
            {
                if (Enum.TryParse(settings[KeyColorDebug], true, out color))
                {
                    this.colorDebug = color;
                } // if
            } // if

            if (settings.ContainsKey(KeyColorInfo))
            {
                if (Enum.TryParse(settings[KeyColorInfo], true, out color))
                {
                    this.colorInfo = color;
                } // if
            } // if

            if (settings.ContainsKey(KeyColorWarn))
            {
                if (Enum.TryParse(settings[KeyColorWarn], true, out color))
                {
                    this.colorWarn = color;
                } // if
            } // if

            if (settings.ContainsKey(KeyColorError))
            {
                if (Enum.TryParse(settings[KeyColorError], true, out color))
                {
                    this.colorError = color;
                } // if
            } // if

            if (settings.ContainsKey(KeyColorFatal))
            {
                if (Enum.TryParse(settings[KeyColorFatal], true, out color))
                {
                    this.colorFatal = color;
                } // if
            } // if
        } // EvaluateSettings()
        #endregion PRIVATE METHODS
    } // ColoredConsoleLogger
} // Tethys.Logging.Console
