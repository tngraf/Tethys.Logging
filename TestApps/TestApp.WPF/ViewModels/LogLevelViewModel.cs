//// -------------------------------------------------------------------------
// TgLib.Logging
// ===========================================================================
// LogLevelViewModel.cs
// ===========================================================================
//
// This library contains common code of .Net projects of Thomas Graf.
//
// ===========================================================================
//
// <copyright file="LogLevelViewModel.cs" company="Tethys">
// (c) 2003 - 2010 by Thomas Graf.
//            All rights reserved.
//            See the file "License.txt" for information on usage and 
//            redistribution of this file and for a 
//            DISCLAIMER OF ALL WARRANTIES.
// </copyright>
//
// Version .. 1.00.00.08 of 12May18
// Project .. tglib.logging.controls
// Author ... Thomas Graf (tg)
// System ... Microsoft .Net framework 4.0
// Tools .... Microsoft Visual Studio 2010
//
// Change Report
// 12May18 1.00.00.08 tg: initial version.
//
//// -------------------------------------------------------------------------

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
    private PropertyChangedEventHandler _propertyChanged;

    /// <summary>
    /// This event is raised when a property has changed.
    /// </summary>
    public event PropertyChangedEventHandler PropertyChanged
    {
      add { _propertyChanged += value; }
      remove { _propertyChanged -= value; }
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
      if (_propertyChanged != null)
      {
        _propertyChanged(this, e);
      } // if
    } // OnPropertyChanged()
    #endregion // VIEWNMODEL BASE FUNCTIONALITY
  }
}
