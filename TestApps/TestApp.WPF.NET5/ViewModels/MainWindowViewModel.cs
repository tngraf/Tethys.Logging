// --------------------------------------------------------------------------
// Tethys.Logging
// ==========================================================================
//
// A logging library for .NET Framework 4.5+ and .NET Core.
//
// ===========================================================================
//
// <copyright file="MainWindowViewModel.cs" company="Tethys">
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

namespace TestApp.WPF.NET5.ViewModels
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
        /// Gets the levels.
        /// </summary>
        public ObservableCollection<LogLevelViewModel> Levels { get; }

        /// <summary>
        /// Custom text.
        /// </summary>
        private string customText;

        /// <summary>
        /// Gets or sets the custom text.
        /// </summary>
        public string CustomText
        {
            get
            {
                return this.customText;
            }

            set
            {
                if (value != this.customText)
                {
                    this.customText = value;
                    this.RaisePropertyChanged(nameof(this.CustomText));
                } // if
            }
        } // CustomText

        /// <summary>
        /// Use default text.
        /// </summary>
        private bool useDefaultText;

        /// <summary>
        /// Gets or sets a value indicating whether to use the default text.
        /// </summary>
        public bool UseDefaultText
        {
            get
            {
                return this.useDefaultText;
            }

            set
            {
                if (value != this.useDefaultText)
                {
                    this.useDefaultText = value;
                    this.RaisePropertyChanged(nameof(this.UseDefaultText));
                }
            }
        } // UseDefaultText

        /// <summary>
        /// Use custom text.
        /// </summary>
        private bool useCustomText;

        /// <summary>
        /// Gets or sets a value indicating whether to use a custom text.
        /// </summary>
        public bool UseCustomText
        {
            get
            {
                return this.useCustomText;
            }

            set
            {
                if (value != this.useCustomText)
                {
                    this.useCustomText = value;
                    this.RaisePropertyChanged(nameof(this.UseCustomText));
                }
            }
        } // UseCustomText

        /// <summary>
        /// Selected level.
        /// </summary>
        private LogLevelViewModel selectedLevel;

        /// <summary>
        /// Gets or sets the selected category.
        /// </summary>
        public LogLevelViewModel SelectedLevel
        {
            get
            {
                return this.selectedLevel;
            }

            set
            {
                if (value != this.selectedLevel)
                {
                    this.selectedLevel = value;
                    this.RaisePropertyChanged(nameof(this.SelectedLevel));
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
            this.Levels = new ObservableCollection<LogLevelViewModel>();
            this.Levels.Add(new LogLevelViewModel(LogLevel.Debug));
            this.Levels.Add(new LogLevelViewModel(LogLevel.Info));
            this.Levels.Add(new LogLevelViewModel(LogLevel.Warn));
            this.Levels.Add(new LogLevelViewModel(LogLevel.Error));
            this.Levels.Add(new LogLevelViewModel(LogLevel.Fatal));

            this.SelectedLevel = this.Levels[0];
            this.UseDefaultText = true;
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
            add
            {
                this.propertyChanged += value;
            }

            remove
            {
                // ReSharper disable once DelegateSubtraction
                this.propertyChanged -= value;
            }
        } // PropertyChanged

        /// <summary>
        /// Raises the <see cref="PropertyChanged"/> event.
        /// </summary>
        /// <param name="propertyName">The property name of the property that has
        /// changed.</param>
        protected void RaisePropertyChanged(string propertyName)
        {
            this.OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        } // RaisePropertyChanged()

        /// <summary>
        /// Raises the <see cref="PropertyChanged"/> event.
        /// </summary>
        /// <param name="e">The
        /// <see cref="System.ComponentModel.PropertyChangedEventArgs"/> instance
        /// containing the event data.</param>
        protected virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            this.propertyChanged?.Invoke(this, e);
        } // OnPropertyChanged()
        #endregion // VIEWMODEL BASE FUNCTIONALITY
    }
}
