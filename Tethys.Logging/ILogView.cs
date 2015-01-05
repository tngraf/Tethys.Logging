#region Header
// --------------------------------------------------------------------------
// Tethys.Logging
// ==========================================================================
//
// A portable logging library for .NET Framework 4.5, Silverlight 4 and 
// higher, Windows Phone 7 and higher and .NET for Windows Store apps.
//
// ==========================================================================
// <copyright file="ILogView.cs" company="Tethys">
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
  /// <summary>
  /// This is the interface for all log viewer components.
  /// </summary>
  public interface ILogView
  {
    /// <summary>
    /// Adds a log event.
    /// </summary>
    /// <param name="logEvent">The log event.</param>
    void AddLogEvent(ILogEvent logEvent);
  } // ILogView
} // TgLib.Logging

// ==========================================
