#region Header
// ---------------------------------------------------------------------------
// Tethys.Logging.NLog
// ===========================================================================
//
// This library contains common code of .Net projects of Thomas Graf.
//
// ===========================================================================
// <copyright file="SingleLogLevelFilter.cs" company="Tethys">
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
// 10Oct18 1.00.00.00 tg: initial version of the NLog support libray.
// 12Jul20 1.00.01.00 tg: update for NLog 2.0.
//
// ---------------------------------------------------------------------------
#endregion

namespace Tethys.Logging.NLog
{
  using global::NLog;

  using global::NLog.Filters;

  /// <summary>
  /// SingleLogLevelFilter is a filter for NLog that allows only 
  /// logging events to pass the have exactly the specified level.
  /// </summary>
  public class SingleLogLevelFilter : Filter
  {
    #region PRIVATE PROPERTIES
    /// <summary>
    /// Log level that should get filtered.
    /// </summary>
    private readonly LogLevel _logLevel;
    #endregion // PRIVATE PROPERTIES

    //// ---------------------------------------------------------------------

    #region PUBLIC PROPERTIES
    /// <summary>
    /// Gets or sets the user-requested action to be taken when filter matches. 
    /// </summary>
    public new FilterResult Action { get; set; }
    #endregion // PUBLIC PROPERTIES

    //// ---------------------------------------------------------------------

    #region CONSTRUCTION
    /// <summary>
    /// Initializes a new instance of the 
    /// <see cref="SingleLogLevelFilter"/> class.
    /// </summary>
    /// <param name="logLevel">The log level.</param>
    public SingleLogLevelFilter(LogLevel logLevel)
    {
      _logLevel = logLevel;
    } // SingleLogLevelFilter()
    #endregion // CONSTRUCTION

    //// ---------------------------------------------------------------------

    #region PROTECTED METHODS
    /// <summary>
    /// Checks whether log event should be logged or not.
    /// </summary>
    /// <param name="logEvent">Log event.</param>
    /// <returns>
    /// The filter result.
    /// </returns>
    protected override FilterResult Check(LogEventInfo logEvent)
    {
      return logEvent.Level == _logLevel ?
        FilterResult.Log : FilterResult.Ignore;
    } // Check()
    #endregion // PROTECTED METHODS
  } // SingleLogLevelFilter
} // Tethys.Logging.NLog

// ===================================================
// Tethys.Logging.NLog: end of SingleLogLevelFilter.cs
// ===================================================
