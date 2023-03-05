// -------------------------------------------------------------------------------
// <copyright file="LogViewFactoryAdapter.cs" company="Tethys">
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
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    /// <summary>
    /// Factory adapter to get a logger that forwards the log output to
    /// an <see cref="ILogView"/> object.
    /// </summary>
    public class LogViewFactoryAdapter : ILoggerFactoryAdapter
    {
        #region PRIVATE PROPERTIES
        /// <summary>
        /// Target log viewer.
        /// </summary>
        private readonly ILogView view;

        /// <summary>
        /// Flag 'add CR/LF at the end of each text line'.
        /// </summary>
        private readonly bool addCrLf;

        /// <summary>
        /// The settings.
        /// </summary>
        private readonly IDictionary<string, string> logSettings;
        #endregion // PRIVATE PROPERTIES

        //// ---------------------------------------------------------------------

        #region CONSTRUCTION
        /// <summary>
        /// Initializes a new instance of the <see cref="LogViewFactoryAdapter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        public LogViewFactoryAdapter(ILogView view)
        {
            this.view = view;
            this.addCrLf = true;
        } // LogViewAdapter()

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="LogViewFactoryAdapter"/> class.
        /// </summary>
        /// <param name="view">View where to add the adapter.</param>
        /// <param name="addCrLf">Add CR/LF at the end of each text line or not.
        /// </param>
        [SuppressMessage(
            "Microsoft.Naming",
            "CA1709:IdentifiersShouldBeCasedCorrectly",
            MessageId = "Cr",
            Justification = "Intended here.")]
        [SuppressMessage(
            "Microsoft.Naming",
            "CA1709:IdentifiersShouldBeCasedCorrectly",
            MessageId = "Lf",
            Justification = "Intended here.")]
        public LogViewFactoryAdapter(ILogView view, bool addCrLf)
        {
            this.view = view;
            this.addCrLf = addCrLf;
        } // LogViewAdapter()

        /// <summary>
        /// Initializes a new instance of the <see cref="LogViewFactoryAdapter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        /// <param name="settings">The settings.</param>
        public LogViewFactoryAdapter(ILogView view, IDictionary<string, string> settings)
        {
            this.view = view;

            this.logSettings = settings;

            if (this.logSettings == null)
            {
                return;
            } // if

            if (settings.ContainsKey("AddCrLf"))
            {
                var value = settings["AddCrLf"].Equals("TRUE", StringComparison.OrdinalIgnoreCase);
                this.addCrLf = value;
            } // if
        } // LogViewAdapter()
        #endregion // CONSTRUCTION

        //// ---------------------------------------------------------------------

        #region Implementation of ILoggerFactoryAdapter
        /// <summary>
        /// Gets the logger.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>A logger.</returns>
        public ILog GetLogger(Type type)
        {
            return new LogViewLogger(this.view, this.logSettings);
        } // GetLogger()

        /// <summary>
        /// Gets the logger.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>A logger.</returns>
        public ILog GetLogger(string name)
        {
            return new LogViewLogger(this.view, this.logSettings);
        } // GetLogger()
        #endregion
    } // LogViewAdapter
} // Tethys.Logging
