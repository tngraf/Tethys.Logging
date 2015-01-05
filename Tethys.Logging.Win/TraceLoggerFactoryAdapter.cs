#region Header
// --------------------------------------------------------------------------
// Tethys.Logging
// ==========================================================================
//
// A portable logging library for .NET Framework 4.5, Silverlight 4 and 
// higher, Windows Phone 7 and higher and .NET for Windows Store apps.
//
// ==========================================================================
// <copyright file="TraceLoggerFactoryAdapter.cs" company="Tethys">
// Copyright  2013 by Thomas Graf
//            All rights reserved.
// </copyright>
// 
// Version .. 1.00.01.00 of 13Oct09
// System ... Portable Library
// Tools .... Microsoft Visual Studio 2012
//
// Change Report
// 13Oct09 1.00.01.00 tg: initial version.
//
// ---------------------------------------------------------------------------
#endregion

namespace Tethys.Logging.Win
{
    using System;

    /// <summary>
  /// Factory adapter to get a Trace logger.
  /// </summary>
  /// <remarks>
  /// This class is based on ideas coming from 
  /// <a href="http://netcommon.sourceforge.net">Common.Logging</a>.
  /// </remarks>
    public class TraceLoggerFactoryAdapter : ILoggerFactoryAdapter
  {
    /// <summary>
    /// The one and only Trace logger.
    /// </summary>
    private static readonly ILog DefaultLogger = new TraceLogger();

    #region ILoggerFactoryAdapter Implementation
    /// <summary>
    /// Get a ILog instance by type.
    /// </summary>
    /// <param name="type">The type to use for the logger</param>
    /// <returns>
    /// A logger.
    /// </returns>
    public ILog GetLogger(Type type)
    {
      return DefaultLogger;
    } // GetLogger()

    /// <summary>
    /// Get a ILog instance by name.
    /// </summary>
    /// <param name="name">The name of the logger</param>
    /// <returns>
    /// A logger.
    /// </returns>
    public ILog GetLogger(string name)
    {
      return DefaultLogger;
    } // GetLogger()
    #endregion // ILoggerFactoryAdapter Implementation
  } // TraceLoggerFactoryAdapter
} // Tethys.Logging.Simple
