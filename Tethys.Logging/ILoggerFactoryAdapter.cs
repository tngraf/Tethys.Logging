#region Header
// --------------------------------------------------------------------------
// Tethys.Logging
// ==========================================================================
//
// A portable logging library for .NET Framework 4.5, Silverlight 4 and 
// higher, Windows Phone 7 and higher and .NET for Windows Store apps.
//
// ==========================================================================
// <copyright file="ILoggerFactoryAdapter.cs" company="Tethys">
// Copyright  2013 by Thomas Graf
//            All rights reserved.
// </copyright>
// 
// Version .. 1.00.00.00 of 13Mar21
// System ... Portable Library
// Tools .... Microsoft Visual Studio 2012
//
// Change Report
// 13Mar21 1.00.00.00 tg: initial version.
//
// ---------------------------------------------------------------------------
#endregion

namespace Tethys.Logging
{
  using System;

  /// <summary>
  /// LoggerFactoryAdapter interface is used by the <see cref="LogManager"/>
  /// to get the correct logger.
  /// </summary>
  /// <remarks>
  /// This class is based on ideas coming from 
  /// <a href="http://netcommon.sourceforge.net">Common.Logging</a>.
  /// </remarks>
  public interface ILoggerFactoryAdapter
  {
    /// <summary>
    /// Get a ILog instance by type.
    /// </summary>
    /// <param name="type">The type to use for the logger</param>
    /// <returns>A logger.</returns>
    ILog GetLogger(Type type);

    /// <summary>
    /// Get a ILog instance by name.
    /// </summary>
    /// <param name="name">The name of the logger</param>
    /// <returns>A logger.</returns>
    ILog GetLogger(string name);
  } // ILoggerFactoryAdapter
} // Tethys.Logging
