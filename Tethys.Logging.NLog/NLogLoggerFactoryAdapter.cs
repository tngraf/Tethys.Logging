#region Header
// --------------------------------------------------------------------------
// Tethys.Logging
// ==========================================================================
//
// A portable logging library for .NET Framework 4.5, Silverlight 4 and 
// higher, Windows Phone 7 and higher and .NET for Windows Store apps.
//
// ==========================================================================
// <copyright file="NLogLoggerFactoryAdapter.cs" company="Tethys">
// Copyright  2013 by Thomas Graf
//            All rights reserved.
//            See the file "License.txt" for information on usage and 
//            redistribution of this file and for a 
//            DISCLAIMER OF ALL WARRANTIES.
// </copyright>
// 
// Version .. 1.00.00.00 of 13Apr03
// System ... Portable Library
// Tools .... Microsoft Visual Studio 2012
//
// Change Report
// 13Mar21 1.00.00.00 tg: initial version.
//
// ---------------------------------------------------------------------------
#endregion

namespace Tethys.Logging.NLog
{
  using System;

  /// <summary>
  /// Factory adapter to forward logging to NLog 2.0.
  /// </summary>
  /// <remarks>
  /// This class is based on ideas coming from 
  /// <a href="http://netcommon.sourceforge.net">Common.Logging</a>.
  /// </remarks>
  public class NLogLoggerFactoryAdapter : ILoggerFactoryAdapter
  {
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
      return new NLogLogger(global::NLog.LogManager.GetLogger(type.FullName));
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
      return new NLogLogger(global::NLog.LogManager.GetLogger(name));
    } // GetLogger()
    #endregion // ILoggerFactoryAdapter Implementation
  } // NLogLoggerFactoryAdapter
} // Tethys.Logging
