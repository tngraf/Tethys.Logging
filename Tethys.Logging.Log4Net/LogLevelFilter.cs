#region Header
// ---------------------------------------------------------------------------
// Tethys.Logging.Log4Net
// ===========================================================================
//
// This library contains common code of .Net projects of Thomas Graf.
//
// ===========================================================================
// <copyright file="LogLevelFilter.cs" company="Tethys">
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
//
// ---------------------------------------------------------------------------
#endregion

namespace Tethys.Logging.Log4Net
{
  using log4net.Core;
  using log4net.Filter;

  /// <summary>
  /// LogLevelFilter is a filter for log4net that allows only logging events
  /// to pass the have exactly the specified level.
  /// </summary>
  public class LogLevelFilter : IFilter
  {
    #region PRIVATE PROPERTIES
    /// <summary>
    /// The level to filter for.
    /// </summary>
    private readonly Level _level;
    #endregion // PRIVATE PROPERTIES

    //// ---------------------------------------------------------------------

    #region PUBLIC PROPERTIES
    /// <summary>
    /// Gets or sets the next filter.
    /// </summary>
    public IFilter Next { get; set; }
    #endregion // PUBLIC PROPERTIES

    //// ---------------------------------------------------------------------

    #region CONSTRUCTION
    /// <summary>
    /// Initializes a new instance of the <see cref="LogLevelFilter"/> class.
    /// </summary>
    /// <param name="level">The level.</param>
    public LogLevelFilter(Level level)
    {
      _level = level;
    } // LogLevelFilter()
    #endregion // CONSTRUCTION

    //// ---------------------------------------------------------------------

    #region PUBLIC METHODS
    /// <summary>
    /// Decide if the logging event should be logged through an appender.
    /// </summary>
    /// <param name="loggingEvent">The LoggingEvent to decide upon</param>
    /// <returns>The decision of the filter</returns>
    /// <remarks>
    /// If the decision is <see cref="F:log4net.Filter.FilterDecision.Deny"/>,
    /// then the event will be dropped. If the decision is 
    /// <see cref="F:log4net.Filter.FilterDecision.Neutral"/>, then the next
    /// filter, if any, will be invoked. If the decision is
    /// <see cref="F:log4net.Filter.FilterDecision.Accept"/> then
    /// the event will be logged without consulting with other filters in
    /// the chain.
    /// </remarks>
    public FilterDecision Decide(LoggingEvent loggingEvent)
    {
      if (loggingEvent.Level == _level)
      {
        return FilterDecision.Accept;
      } // if
      return FilterDecision.Deny;
    } // Decide()

    /// <summary>
    /// Activate the options that were previously set with calls to
    /// properties. 
    /// </summary>
    public void ActivateOptions()
    {
      // not supported, only to fulfill interface
    } // ActivateOptions()
    #endregion // PUBLIC METHODS
  } // LogLevelFilter
} // Tethys.Logging.Log4Net

// ========================
// End of LogLevelFilter.cs
// ========================
