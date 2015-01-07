#region Header
// --------------------------------------------------------------------------
// Tethys.Logging.Win
// ==========================================================================
//
// A logging library for .NET Framework 4.5.
//
// ===========================================================================
//
// <copyright file="TraceLoggerFactoryAdapter.cs" company="Tethys">
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
