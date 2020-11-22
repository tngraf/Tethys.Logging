// --------------------------------------------------------------------------
// Tethys.Logging
// ==========================================================================
//
// A logging library for .NET Framework 4.5+ and .NET Core.
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
// ---------------------------------------------------------------------------

namespace TestApp.WPF.NET5.ViewModels
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
        /// Gets the level text.
        /// </summary>
        public string LevelText { get; }
        #endregion // PUBLIC PROPERTIES

        //// ---------------------------------------------------------------------

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="LogLevelViewModel"/> class.
        /// </summary>
        /// <param name="level">The level.</param>
        public LogLevelViewModel(LogLevel level)
        {
            this.LevelText = level.ToString();
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
                var propertyChangedEventHandler = this.propertyChanged;
                if (propertyChangedEventHandler != null)
                {
                    // ReSharper disable once DelegateSubtraction
                    this.propertyChanged -= value;
                } // if
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
