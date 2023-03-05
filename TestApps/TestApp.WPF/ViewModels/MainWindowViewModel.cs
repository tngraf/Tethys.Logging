// -------------------------------------------------------------------------------
// <copyright file="MainWindowViewModel.cs" company="Tethys">
//   Copyright (C) 2009-2023 Thomas Graf
//   All Rights Reserved.
// </copyright>
//
// Licensed under the Apache License, Version 2.0.
// Unless required by applicable law or agreed to in writing,
// software distributed under the License is distributed on an
// "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
// either express or implied.
// SPDX-License-Identifier: Apache-2.0
// -------------------------------------------------------------------------------

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
        private readonly ObservableCollection<LogLevelViewModel> levels;

        /// <summary>
        /// Gets the levels.
        /// </summary>
        public ObservableCollection<LogLevelViewModel> Levels
        {
            get { return this.levels; }
        }

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
                    this.RaisePropertyChanged("CustomText");
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
                    this.RaisePropertyChanged("UseDefaultText");
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
                    this.RaisePropertyChanged("UseCustomText");
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
                    this.RaisePropertyChanged("SelectedLevel");
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
            this.levels = new ObservableCollection<LogLevelViewModel>();
            this.levels.Add(new LogLevelViewModel(LogLevel.Debug));
            this.levels.Add(new LogLevelViewModel(LogLevel.Info));
            this.levels.Add(new LogLevelViewModel(LogLevel.Warn));
            this.levels.Add(new LogLevelViewModel(LogLevel.Error));
            this.levels.Add(new LogLevelViewModel(LogLevel.Fatal));

            this.SelectedLevel = this.levels[0];
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
        #endregion // VIEWNMODEL BASE FUNCTIONALITY
    }
}
