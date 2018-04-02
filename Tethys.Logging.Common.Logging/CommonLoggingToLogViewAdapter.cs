#region Header
// --------------------------------------------------------------------------
// Tethys.Logging.Common.Logging
// ==========================================================================
//
// A (portable) logging library for .NET Framework 4.5, Silverlight 4 and 
// higher, Windows Phone 7 and higher and .NET for Windows Store apps.
//
// ===========================================================================
//
// <copyright file="CommonLoggingToLogViewAdapter.cs" company="Tethys">
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

namespace Tethys.Logging.Common.Logging
{
    using global::Common.Logging;

    using global::Common.Logging.Factory;

    /// <summary>
    /// This adapter allows Common.Logging to forward log events to a
    /// Tethys.Logging log view.
    /// </summary>
    public class CommonLoggingToLogViewAdapter : AbstractCachingLoggerFactoryAdapter
    {
        #region PRIVATE PROPERTIES
        /// <summary>
        /// Target log viewer.
        /// </summary>
        private readonly Tethys.Logging.ILogView view;

        /// <summary>
        /// Flag 'add CR/LF at the end of each text line'.
        /// </summary>
        private readonly bool addCrLf;
        #endregion // PRIVATE PROPERTIES

        //// ---------------------------------------------------------------------

        #region CONSTRUCTION
        /// <summary>
        /// Initializes a new instance of the 
        /// <see cref="CommonLoggingToLogViewAdapter"/> class.
        /// </summary>
        /// <param name="view">View where to add the adapter.</param>
        public CommonLoggingToLogViewAdapter(ILogView view)
        {
            this.view = view;
            this.addCrLf = true;
        } // CommonLoggingToLogViewAdapter()

        /// <summary>
        /// Initializes a new instance of the 
        /// <see cref="CommonLoggingToLogViewAdapter"/> class.
        /// </summary>
        /// <param name="view">View where to add the adapter.</param>
        /// <param name="addLineEnd">Add CR/LF at the end of each text line or not.
        /// </param>
        public CommonLoggingToLogViewAdapter(ILogView view, bool addLineEnd)
        {
            this.view = view;
            this.addCrLf = addLineEnd;
        } // CommonLoggingToLogViewAdapter()
        #endregion // CONSTRUCTION

        //// ---------------------------------------------------------------------

        #region OVERRIDES OF ABSTRACTCACHINGLOGGERFACTORYADAPTER
        /// <summary>
        /// Create the specified named logger instance.
        /// </summary>
        /// <param name="name">Logger name.</param>
        /// <returns>A logger.</returns>
        /// <remarks>
        /// Derived factories need to implement this method to create the
        /// actual logger instance.
        /// </remarks>
        protected override ILog CreateLogger(string name)
        {
            return new LogViewLogger(this.view, this.addCrLf);
        } // CreateLogger()
        #endregion // OVERRIDES OF ABSTRACTCACHINGLOGGERFACTORYADAPTER
    } // CommonLoggingToLogViewAdapter
} // Tethys.Logging.Common.Logging

// =======================================
// End of CommonLoggingToLogViewAdapter.cs
// =======================================
