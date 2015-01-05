#region Header
// ---------------------------------------------------------------------------
// Tethys.Logging.Common.Logging
// ===========================================================================
//
// Common.Logging support for Tethys.Logging.
//
// ===========================================================================
// <copyright file="LogViewFactoryAdapter.cs" company="Tethys">
// Copyright  2003 - 2013 by Thomas Graf
//            All rights reserved.
// </copyright>
// 
// Version .. 1.00.00.00 of 13Apr17
// Project .. TgLib.Logging
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

namespace Tethys.Logging
{
  using System;
  using System.Diagnostics.CodeAnalysis;

  /// <summary>
  /// Factory adapter to get a logger that forwards the log output to
  /// an <see cref="ILogView"/> object.
  /// </summary>
  public class LogViewFactoryAdapter : ILoggerFactoryAdapter
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
    /// Initializes a new instance of the <see cref="LogViewFactoryAdapter"/> class.
    /// </summary>
    /// <param name="view">The view.</param>
    public LogViewFactoryAdapter(ILogView view)
    {
      this._view = view;
      this._addCrLf = true;
    } // LogViewAdapter()
    
    /// <summary>
    /// Initializes a new instance of the 
    /// <see cref="LogViewFactoryAdapter"/> class.
    /// </summary>
    /// <param name="view">View where to add the adapter.</param>
    /// <param name="addCrLf">Add CR/LF at the end of each text line or not.
    /// </param>
    [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly",
      MessageId = "Cr", Justification = "Intended here.")]
    [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly",
      MessageId = "Lf", Justification = "Intended here.")]
    public LogViewFactoryAdapter(ILogView view, bool addCrLf)
    {
      this._view = view;
      this._addCrLf = addCrLf;
    } // LogViewAdapter()
    #endregion // CONSTRUCTION

    //// ---------------------------------------------------------------------

    #region Implementation of ILoggerFactoryAdapter
    /// <summary>
    /// Gets the logger.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <returns>A logger.</returns>
    public ILog GetLogger(Type type)
    {
      return new LogViewLogger(this._view, this._addCrLf);
    } // GetLogger()

    /// <summary>
    /// Gets the logger.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <returns>A logger.</returns>
    public ILog GetLogger(string name)
    {
      return new LogViewLogger(this._view, this._addCrLf);
    } // GetLogger()
    #endregion
  } // LogViewAdapter
} // Tethys.Logging
