#region Header
// ---------------------------------------------------------------------------
// Tethys.Logging.Common.Logging
// ===========================================================================
//
// Common.Logging support for Tethys.Logging.
//
// ===========================================================================
// <copyright file="CommonLoggingToLogViewAdapter.cs" company="Tethys">
// Copyright  2003 - 2013 by Thomas Graf
//            All rights reserved.
//            See the file "License.txt" for information on usage and 
//            redistribution of this file and for a 
//            DISCLAIMER OF ALL WARRANTIES.
// </copyright>
// 
// Version .. 1.00.00.00 of 13Mar09
// Project .. TgLib.Logging.NLog
// Creater .. Thomas Graf (tg)
// System ... Microsoft .Net Framework 4
// Tools .... Microsoft Visual Studio 2010
//
// Change Report
// 10Oct18 1.00.00.00 tg: initial version of the Common.Logging support 
// library.
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
    private readonly ILogView _view;

    /// <summary>
    /// Flag 'add CR/LF at the end of each text line'.
    /// </summary>
    private readonly bool _addCrLf;
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
      _view = view;
      _addCrLf = true;
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
      _view = view;
      _addCrLf = addLineEnd;
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
      return new LogViewLogger(_view, _addCrLf);
    } // CreateLogger()
    #endregion // OVERRIDES OF ABSTRACTCACHINGLOGGERFACTORYADAPTER
  } // CommonLoggingToLogViewAdapter
} // Tethys.Logging.Common.Logging

// =======================================
// End of CommonLoggingToLogViewAdapter.cs
// =======================================
