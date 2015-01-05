#region Header
// --------------------------------------------------------------------------
// Tethys.Logging
// ==========================================================================
//
// A portable logging library for .NET Framework 4.5, Silverlight 4 and 
// higher, Windows Phone 7 and higher and .NET for Windows Store apps.
//
// ==========================================================================
// <copyright file="LogManager.cs" company="Tethys">
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
  using System.Diagnostics.CodeAnalysis;

  /// <summary>
  /// Use the LogManager's <see cref="GetLogger(string)"/> or <see cref="GetLogger(System.Type)"/> 
  /// methods to obtain <see cref="ILog"/> instances for logging.
  /// </summary>
  /// <remarks>
  /// This class is based on ideas coming from 
  /// <a href="http://netcommon.sourceforge.net">Common.Logging</a>.
  /// </remarks>
  public static class LogManager
  {
    /// <summary>
    /// Logger factor to provide concrete loggers.
    /// </summary>
    private static ILoggerFactoryAdapter adapter;

    /// <summary>
    /// Gets or sets the adapter.
    /// </summary>
    /// <value>The adapter.</value>
    [SuppressMessage("Microsoft.Usage",
      "CA2208:InstantiateArgumentExceptionsCorrectly",
      Justification = "Best solution here ...")]
    public static ILoggerFactoryAdapter Adapter
    {
      get
      {
        if (adapter == null)
        {
          ILoggerFactoryAdapter defaultFactory = new NoOpLoggerFactoryAdapter();
          return defaultFactory;
        } // if
        return adapter;
      }

      set
      {
        if (value == null)
        {
// ReSharper disable NotResolvedInText
          throw new ArgumentNullException("Adapter");
// ReSharper restore NotResolvedInText
        } // if

        adapter = value;
      }
    } // LogManager()

    /// <summary>
    /// Gets the logger by calling <see cref="ILoggerFactoryAdapter.GetLogger(Type)"/>
    /// on the currently configured <see cref="Adapter"/> using the specified type.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <returns>the logger instance obtained from the current <see cref="Adapter"/></returns>
    public static ILog GetLogger(Type type)
    {
      return Adapter.GetLogger(type);
    } // GetLogger()

    /// <summary>
    /// Gets the logger by calling <see cref="ILoggerFactoryAdapter.GetLogger(string)"/>
    /// on the currently configured <see cref="Adapter"/> using the specified name.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <returns>the logger instance obtained from the current <see cref="Adapter"/></returns>
    public static ILog GetLogger(string name)
    {
      return Adapter.GetLogger(name);
    } // GetLogger()
  } // LogManager
} // Tethys.Logging

// =================================
