#region Header
// --------------------------------------------------------------------------
// Tethys.Logging
// ==========================================================================
//
// A (portable) logging library for .NET Framework 4.5, Silverlight 4 and 
// higher, Windows Phone 7 and higher and .NET for Windows Store apps.
//
// ===========================================================================
//
// <copyright file="TextBoxLoggerFactoryAdapter.cs" company="Tethys">
// Copyright  2009-2015 by Thomas Graf
//            All rights reserved.
//            Licensed under the Apache License, Version 2.0.
//            Unless required by applicable law or agreed to in writing, 
//            software distributed under the License is distributed on an
//            "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
//            either express or implied. 
// </copyright>
//
// System ... Portable Library
// Tools .... Microsoft Visual Studio 2013
//
// ---------------------------------------------------------------------------
#endregion

// ReSharper disable CheckNamespace
namespace Tethys.Logging
// ReSharper restore CheckNamespace
{
  using System;
  using System.Windows.Controls;

  /// <summary>
  /// Factory adapter to get a Debug logger.
  /// </summary>
  public class TextBoxLoggerFactoryAdapter : ILoggerFactoryAdapter
  {
    /// <summary>
    /// The <see cref="TextBox"/> where to write the log output.
    /// </summary>
    private readonly TextBox txtBoxLog;

    /// <summary>
    /// Initializes a new instance of the <see cref="TextBoxLoggerFactoryAdapter"/> class.
    /// </summary>
    /// <param name="txtBoxLog">The <see cref="TextBox"/> where to write the log output.</param>
    public TextBoxLoggerFactoryAdapter(TextBox txtBoxLog)
    {
      this.txtBoxLog = txtBoxLog;
    } // TextBoxLoggerFactoryAdapter()

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
      return new TextBoxLogger(this.txtBoxLog);
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
      return new TextBoxLogger(this.txtBoxLog);
    } // GetLogger()
    #endregion // ILoggerFactoryAdapter Implementation
  } // DebugLoggerFactoryAdapter
} // Tethys.Logging.Simple
