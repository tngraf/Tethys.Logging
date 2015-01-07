﻿#region Header
// --------------------------------------------------------------------------
// Tethys.Logging
// ==========================================================================
//
// A (portable) logging library for .NET Framework 4.5, Silverlight 4 and 
// higher, Windows Phone 7 and higher and .NET for Windows Store apps.
//
// ===========================================================================
//
// <copyright file="LogLevelViewModel.cs" company="Tethys">
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

namespace TestApplication.WPF.ViewModels
{
  using System.ComponentModel;
  using Tethys.Logging;

  /// <summary>
  /// View model wrapper for a LogLevel.
  /// </summary>
  public class LogLevelViewModel : INotifyPropertyChanged
  {
    #region PUBLIC PROPERTIES
    /// <summary>
    /// level text.
    /// </summary>
    private readonly string _levelText;

    /// <summary>
    /// Gets the level text.
    /// </summary>
    public string LevelText
    {
      get { return _levelText; }
   } // LevelText
    #endregion // PUBLIC PROPERTIES

    //// ---------------------------------------------------------------------

    /// <summary>
    /// Initializes a new instance of the
    /// <see cref="LogLevelViewModel"/> class.
    /// </summary>
    /// <param name="level">The level.</param>
    public LogLevelViewModel(LogLevel level)
    {
      _levelText = level.ToString();
    } // MainWindowViewModel()

    //// ---------------------------------------------------------------------

    #region VIEWNMODEL BASE FUNCTIONALITY
    /// <summary>
    /// PropertyChanged event handler.
    /// </summary>
    private PropertyChangedEventHandler propertyChanged;

    /// <summary>
    /// This event is raised when a property has changed.
    /// </summary>
    public event PropertyChangedEventHandler PropertyChanged
    {
      add { this.propertyChanged += value; }
      remove { this.propertyChanged -= value; }
    } // PropertyChanged

    /// <summary>
    /// Raises the <see cref="PropertyChanged"/> event.
    /// </summary>
    /// <param name="propertyName">The property name of the property that has
    /// changed.</param>
    protected void RaisePropertyChanged(string propertyName)
    {
      OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
    } // RaisePropertyChanged()

    /// <summary>
    /// Raises the <see cref="PropertyChanged"/> event.
    /// </summary>
    /// <param name="e">The
    /// <see cref="System.ComponentModel.PropertyChangedEventArgs"/> instance
    /// containing the event data.</param>
    protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
    {
      if (this.propertyChanged != null)
      {
        this.propertyChanged(this, e);
      } // if
    } // OnPropertyChanged()
    #endregion // VIEWNMODEL BASE FUNCTIONALITY
  }
}
