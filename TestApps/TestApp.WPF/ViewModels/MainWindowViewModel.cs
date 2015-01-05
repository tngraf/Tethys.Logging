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
// <copyright file="MainWindowViewModel.cs" company="Tethys">
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
  using System.Collections.ObjectModel;
  using System.ComponentModel;
  using Tethys.Logging;

  /// <summary>
  /// MainWindow view model.
  /// </summary>
  public class MainWindowViewModel : INotifyPropertyChanged
  {
    #region PUBLIC PROPERTIES
    /// <summary>
    /// The levels.
    /// </summary>
    private readonly ObservableCollection<LogLevelViewModel> _levels;

    /// <summary>
    /// Gets the levels.
    /// </summary>
    public ObservableCollection<LogLevelViewModel> Levels
    {
      get { return _levels; }
    }

    /// <summary>
    /// Custom text.
    /// </summary>
    private string _customText;

    /// <summary>
    /// Gets or sets the custom text.
    /// </summary>
    public string CustomText
    {
      get
      {
        return _customText;
      }

      set
      {
        if (value != _customText)
        {
          _customText = value;
          RaisePropertyChanged("CustomText");
        } // if
      }
    } // CustomText

    /// <summary>
    /// Use default text.
    /// </summary>
    private bool _useDefaultText;

    /// <summary>
    /// Gets or sets a value indicating whether to use the default text.
    /// </summary>
    public bool UseDefaultText
    {
      get
      {
        return _useDefaultText;
      }

      set
      {
        if (value != _useDefaultText)
        {
          _useDefaultText = value;
          RaisePropertyChanged("UseDefaultText");
        }
      }
    } // UseDefaultText

    /// <summary>
    /// Use custom text.
    /// </summary>
    private bool _useCustomText;

    /// <summary>
    /// Gets or sets a value indicating whether to use a custom text.
    /// </summary>
    public bool UseCustomText
    {
      get
      {
        return _useCustomText;
      }

      set
      {
        if (value != _useCustomText)
        {
          _useCustomText = value;
          RaisePropertyChanged("UseCustomText");
        }
      }
    } // UseCustomText

    /// <summary>
    /// Selected level.
    /// </summary>
    private LogLevelViewModel _selectedLevel;

    /// <summary>
    /// Gets or sets the selected category.
    /// </summary>
    public LogLevelViewModel SelectedLevel
    {
      get
      {
        return _selectedLevel;
      }

      set
      {
        if (value != _selectedLevel)
        {
          _selectedLevel = value;
          RaisePropertyChanged("SelectedLevel");
        }
      }
    } // SelectedLevel
    #endregion // PUBLIC PROPERTIES

    //// ---------------------------------------------------------------------

    /// <summary>
    /// Initializes a new instance of the
    ///  <see cref="MainWindowViewModel"/> class.
    /// </summary>
    public MainWindowViewModel()
    {
      _levels = new ObservableCollection<LogLevelViewModel>();
      _levels.Add(new LogLevelViewModel(LogLevel.Debug));
      _levels.Add(new LogLevelViewModel(LogLevel.Info));
      _levels.Add(new LogLevelViewModel(LogLevel.Warn));
      _levels.Add(new LogLevelViewModel(LogLevel.Error));
      _levels.Add(new LogLevelViewModel(LogLevel.Fatal));

      SelectedLevel = _levels[0];
      UseDefaultText = true;
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
