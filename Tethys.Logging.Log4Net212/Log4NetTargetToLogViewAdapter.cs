﻿// -------------------------------------------------------------------------------
// <copyright file="Log4NetTargetToLogViewAdapter.cs" company="Tethys">
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

namespace Tethys.Logging.Log4Net
{
    using System;
    using System.Collections;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;

    using log4net.Appender;
    using log4net.Core;
    using log4net.Filter;
    using log4net.Layout;
    using log4net.Util;

    /// <summary>
    /// This adapter allows log4net to forward log events to a
    /// Tethys.Logging log view.
    /// </summary>
    public class Log4NetTargetToLogViewAdapter : IBulkAppender, IOptionHandler, IDisposable
    {
        #region PRIVATE PROPERTIES
        /// <summary>
        /// Target log viewer.
        /// </summary>
        private readonly ILogView view;
        #endregion // PRIVATE PROPERTIES

        //// ---------------------------------------------------------------------

        #region CONSTRUCTION
        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="Log4NetTargetToLogViewAdapter"/> class.
        /// </summary>
        /// <param name="view">Target log viewer.</param>
        public Log4NetTargetToLogViewAdapter(ILogView view)
        {
            this.view = view ?? throw new ArgumentNullException(nameof(view));
        } // Log4NetTargetToLogViewAdapter()
        #endregion // CONSTRUCTION

        //// ---------------------------------------------------------------------

        #region LOG4NET APPENDER MANAGEMENT

        #region FINALIZER
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, 
        /// or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);

            // This object will be cleaned up by the Dispose method.
            // Therefore, you should call GC.SupressFinalize to
            // take this object off the finalization queue
            // and prevent finalization code for this object
            // from executing a second time.
            GC.SuppressFinalize(this);
        } // Dispose()

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">
        /// true if managed resources should be disposed; otherwise, false.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
            {
                if (!this.closed)
                {
                    LogLog.Debug(typeof(Log4NetTargetToLogViewAdapter),
                        "RtfLogView: Finalizing appender named [" + this.Name + "].");
                    this.renderWriter.Close();
                    this.Close();
                } // if
            } // if
        } // Dispose()
        #endregion FINALIZER

        //// ---------------------------------------------------------------------

        #region PUBLIC INSTANCE PROPERTIES
        /// <summary>
        /// Gets or sets the threshold <see cref="Level"/> of this appender.
        /// </summary>
        /// <value>
        /// The threshold <see cref="Level"/> of the appender. 
        /// </value>
        /// <remarks>
        /// <para>
        /// All log events with lower level than the threshold level are ignored 
        /// by the appender.
        /// </para>
        /// <para>
        /// In configuration files this option is specified by setting the
        /// value of the <see cref="Threshold"/> option to a level
        /// string, such as "DEBUG", "INFO" and so on.
        /// </para>
        /// </remarks>
        public Level Threshold { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="IErrorHandler"/> for this appender.
        /// </summary>
        /// <value>The <see cref="IErrorHandler"/> of the appender</value>
        /// <remarks>
        /// <para>
        /// The <see cref="Log4NetTargetToLogViewAdapter"/> provides a default 
        /// implementation for the <see cref="ErrorHandler"/> property. 
        /// </para>
        /// </remarks>
        public virtual IErrorHandler ErrorHandler
        {
            get
            {
                return this.errorHandler;
            }

            set
            {
                lock (this)
                {
                    if (value == null)
                    {
                        // We do not throw exception here since the cause is probably a
                        // bad config file.
                        LogLog.Warn(typeof(Log4NetTargetToLogViewAdapter),
                          "Log4NetTargetToLogViewAdapter: You have tried to set a null error-handler.");
                    }
                    else
                    {
                        this.errorHandler = value;
                    }
                }
            }
        }

        /// <summary>
        /// Gets the filter chain.
        /// </summary>
        /// <value>The head of the filter chain filter chain.</value>
        /// <remarks>
        /// <para>
        /// Returns the head Filter. The Filters are organized in a linked list
        /// and so all Filters on this Appender are available through the result.
        /// </para>
        /// </remarks>
        public virtual IFilter FilterHead
        {
            get { return this.headFilter; }
        }

        /// <summary>
        /// Gets or sets the <see cref="ILayout"/> for this appender.
        /// </summary>
        /// <value>The layout of the appender.</value>
        /// <remarks>
        /// <para>
        /// See <see cref="RequiresLayout"/> for more information.
        /// </para>
        /// </remarks>
        /// <seealso cref="RequiresLayout"/>
        public virtual ILayout Layout
        {
            get { return this.layout; }
            set { this.layout = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the appender will 
        /// flush at the end of each write.
        /// </summary>
        /// <remarks>
        /// <para>The default behavior is to flush at the end of each 
        /// write. If the option is set to<c>false</c>, then the underlying 
        /// stream can defer writing to physical medium to a later time. 
        /// </para>
        /// <para>
        /// Avoiding the flush operation at the end of each append results 
        /// in a performance gain of 10 to 20 percent. However, there is safety
        /// trade-off involved in skipping flushing. Indeed, when flushing is
        /// skipped, then it is likely that the last few log events will not
        /// be recorded on disk when the application exits. This is a high
        /// price to pay even for a 20% performance gain.
        /// </para>
        /// </remarks>
        public bool ImmediateFlush { get; set; } = true;

        #endregion // PUBLIC INSTANCE PROPERTIES

        //// ---------------------------------------------------------------------

        #region IMPLEMENTATION OF IOPTIONHANDLER
        /// <summary>
        /// Initialize the appender based on the options set
        /// </summary>
        /// <remarks>
        /// <para>
        /// This is part of the <see cref="IOptionHandler"/> delayed object
        /// activation scheme. The <see cref="ActivateOptions"/> method must 
        /// be called on this object after the configuration properties have
        /// been set. Until <see cref="ActivateOptions"/> is called this
        /// object is in an undefined state and must not be used. 
        /// </para>
        /// <para>
        /// If any of the configuration properties are modified then 
        /// <see cref="ActivateOptions"/> must be called again.
        /// </para>
        /// </remarks>
        public virtual void ActivateOptions()
        {
        }
        #endregion // IMPLEMENTATION OF IOPTIONHANDLER

        //// ---------------------------------------------------------------------

        #region IMPLEMENTATION OF IAPPENDER
        /// <summary>
        /// Gets or sets the name of this appender.
        /// </summary>
        /// <value>The name of the appender.</value>
        /// <remarks>
        /// <para>
        /// The name uniquely identifies the appender.
        /// </para>
        /// </remarks>
        public string Name { get; set; }

        /// <summary>
        /// Closes the appender and release resources.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Release any resources allocated within the appender such as file handles, 
        /// network connections, etc.
        /// </para>
        /// <para>
        /// It is a programming error to append to a closed appender.
        /// </para>
        /// <para>
        /// This method cannot be overridden by subclasses. This method 
        /// delegates the closing of the appender to the <see cref="OnClose"/>
        /// method which must be overridden in the subclass.
        /// </para>
        /// </remarks>
        public void Close()
        {
            // This lock prevents the appender being closed while it is still appending
            lock (this)
            {
                if (!this.closed)
                {
                    this.OnClose();
                    this.closed = true;
                }
            }
        }

        /// <summary>
        /// Performs threshold checks and invokes filters before 
        /// delegating actual logging to the subclasses specific 
        /// <see cref="Append(LoggingEvent)"/> method.
        /// </summary>
        /// <param name="loggingEvent">The event to log.</param>
        /// <remarks>
        /// <para>
        /// This method cannot be overridden by derived classes. A
        /// derived class should override the <see cref="Append(LoggingEvent)"/> method
        /// which is called by this method.
        /// </para>
        /// <para>
        /// The implementation of this method is as follows:
        /// </para>
        /// <para>
        /// <list type="bullet">
        ///    <item>
        ///      <description>
        ///      Checks that the severity of the <paramref name="loggingEvent"/>
        ///      is greater than or equal to the <see cref="Threshold"/> of this
        ///      appender.</description>
        ///    </item>
        ///    <item>
        ///      <description>
        ///      Checks that the <see cref="IFilter"/> chain accepts the 
        ///      <paramref name="loggingEvent"/>.
        ///      </description>
        ///    </item>
        ///    <item>
        ///      <description>
        ///      Calls <see cref="PreAppendCheck()"/> and checks that 
        ///      it returns <c>true</c>.</description>
        ///    </item>
        /// </list>
        /// </para>
        /// <para>
        /// If all of the above steps succeed then the <paramref name="loggingEvent"/>
        /// will be passed to the abstract <see cref="Append(LoggingEvent)"/> method.
        /// </para>
        /// </remarks>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes",
          Justification = "This is ok here.")]
        public void DoAppend(LoggingEvent loggingEvent)
        {
            // This lock is absolutely critical for correct formatting
            // of the message in a multi-threaded environment.  Without
            // this, the message may be broken up into elements from
            // multiple thread contexts (like get the wrong thread ID).
            lock (this)
            {
                if (this.closed)
                {
                    this.ErrorHandler.Error("Attempted to append to closed appender named [" + this.Name + "].");
                    return;
                }

                // prevent re-entry
                if (this.recursiveGuard)
                {
                    return;
                }

                try
                {
                    this.recursiveGuard = true;

                    if (this.FilterEvent(loggingEvent) && this.PreAppendCheck())
                    {
                        this.Append(loggingEvent);
                    }
                }
                catch (Exception ex)
                {
                    this.ErrorHandler.Error("Failed in DoAppend", ex);
                }
                finally
                {
                    this.recursiveGuard = false;
                }
            }
        }

        #endregion // IMPLEMENTATION OF IAPPENDER

        //// ---------------------------------------------------------------------

        #region IMPLEMENTATION OF IBULKAPPENDER
        /// <summary>
        /// Performs threshold checks and invokes filters before 
        /// delegating actual logging to the subclasses specific 
        /// <see cref="Append(LoggingEvent[])"/> method.
        /// </summary>
        /// <param name="loggingEvents">The array of events to log.</param>
        /// <remarks>
        /// <para>
        /// This method cannot be overridden by derived classes. A
        /// derived class should override the <see cref="Append(LoggingEvent[])"/> method
        /// which is called by this method.
        /// </para>
        /// <para>
        /// The implementation of this method is as follows:
        /// </para>
        /// <para>
        /// <list type="bullet">
        ///    <item>
        ///      <description>
        ///      Checks that the severity of the <paramref name="loggingEvents"/>
        ///      is greater than or equal to the <see cref="Threshold"/> of this
        ///      appender.</description>
        ///    </item>
        ///    <item>
        ///      <description>
        ///      Checks that the <see cref="IFilter"/> chain accepts the 
        ///      <paramref name="loggingEvents"/>.
        ///      </description>
        ///    </item>
        ///    <item>
        ///      <description>
        ///      Calls <see cref="PreAppendCheck()"/> and checks that 
        ///      it returns <c>true</c>.</description>
        ///    </item>
        /// </list>
        /// </para>
        /// <para>
        /// If all of the above steps succeed then the <paramref name="loggingEvents"/>
        /// will be passed to the <see cref="Append(LoggingEvent[])"/> method.
        /// </para>
        /// </remarks>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes",
          Justification = "This is ok here.")]
        public void DoAppend(LoggingEvent[] loggingEvents)
        {
            // This lock is absolutely critical for correct formatting
            // of the message in a multi-threaded environment.  Without
            // this, the message may be broken up into elements from
            // multiple thread contexts (like get the wrong thread ID).
            lock (this)
            {
                if (this.closed)
                {
                    this.ErrorHandler.Error("Attempted to append to closed appender named [" + this.Name + "].");
                    return;
                }

                // prevent re-entry
                if (this.recursiveGuard)
                {
                    return;
                }

                try
                {
                    this.recursiveGuard = true;

                    var filteredEvents = new ArrayList(loggingEvents.Length);
                    foreach (var loggingEvent in loggingEvents)
                    {
                        if (this.FilterEvent(loggingEvent))
                        {
                            filteredEvents.Add(loggingEvent);
                        }
                    }

                    if (filteredEvents.Count > 0 && this.PreAppendCheck())
                    {
                        this.Append((LoggingEvent[])filteredEvents.ToArray(typeof(LoggingEvent)));
                    }
                }
                catch (Exception ex)
                {
                    this.ErrorHandler.Error("Failed in Bulk DoAppend", ex);
                }
                finally
                {
                    this.recursiveGuard = false;
                }
            }
        }
        #endregion // IMPLEMENTATION OF IBULKAPPENDER

        //// ---------------------------------------------------------------------

        /// <summary>
        /// Test if the logging event should we output by this appender
        /// </summary>
        /// <param name="loggingEvent">the event to test</param>
        /// <returns><c>true</c> if the event should be output, <c>false</c> if the event should be ignored</returns>
        /// <remarks>
        /// <para>
        /// This method checks the logging event against the threshold level set
        /// on this appender and also against the filters specified on this
        /// appender.
        /// </para>
        /// <para>
        /// The implementation of this method is as follows:
        /// </para>
        /// <para>
        /// <list type="bullet">
        ///    <item>
        ///      <description>
        ///      Checks that the severity of the <paramref name="loggingEvent"/>
        ///      is greater than or equal to the <see cref="Threshold"/> of this
        ///      appender.</description>
        ///    </item>
        ///    <item>
        ///      <description>
        ///      Checks that the <see cref="IFilter"/> chain accepts the 
        ///      <paramref name="loggingEvent"/>.
        ///      </description>
        ///    </item>
        /// </list>
        /// </para>
        /// </remarks>
        protected virtual bool FilterEvent(LoggingEvent loggingEvent)
        {
            if (!this.IsAsSevereAsThreshold(loggingEvent.Level))
            {
                return false;
            } // if

            var f = this.FilterHead;
            while (f != null)
            {
                switch (f.Decide(loggingEvent))
                {
                    case FilterDecision.Deny:
                        return false;  // Return without appending

                    case FilterDecision.Accept:
                        f = null;    // Break out of the loop
                        break;

                    case FilterDecision.Neutral:
                        f = f.Next;    // Move to next filter
                        break;
                }
            }

            return true;
        }

        //// ---------------------------------------------------------------------

        #region OVERRIDDEN APPENDERSKELETON METHODS
        /// <summary>
        /// Subclasses of <see cref="Log4NetTargetToLogViewAdapter"/> should 
        /// implement this method to perform actual logging.
        /// </summary>
        /// <param name="loggingEvent">The event to append.</param>
        /// <remarks>
        /// <para>
        /// A subclass must implement this method to perform
        /// logging of the <paramref name="loggingEvent"/>.
        /// </para>
        /// <para>This method will be called by <see cref="DoAppend(LoggingEvent)"/>
        /// if all the conditions listed for that method are met.
        /// </para>
        /// <para>
        /// To restrict the logging of events in the appender
        /// override the <see cref="PreAppendCheck()"/> method.
        /// </para>
        /// </remarks>
        protected void Append(LoggingEvent loggingEvent)
        {
            var le = new LogEvent(ConvertLogLevel(loggingEvent.Level),
              loggingEvent.TimeStamp, this.RenderLoggingEvent(loggingEvent));

            this.view.AddLogEvent(le);
        } // Append()
        #endregion // OVERRIDDEN APPENDERSKELETON METHODS

        //// ---------------------------------------------------------------------

        #region PUBLIC INSTANCE METHODS
        /// <summary>
        /// Adds a filter to the end of the filter chain.
        /// </summary>
        /// <param name="filter">the filter to add to this appender</param>
        /// <remarks>
        /// <para>
        /// The Filters are organized in a linked list.
        /// </para>
        /// <para>
        /// Setting this property causes the new filter to be pushed onto the 
        /// back of the filter chain.
        /// </para>
        /// </remarks>
        public virtual void AddFilter(IFilter filter)
        {
            if (filter == null)
            {
                throw new ArgumentNullException(nameof(filter),
                  "filter param must not be null");
            }

            if (this.headFilter == null)
            {
                this.headFilter = this.tailFilter = filter;
            }
            else
            {
                this.tailFilter.Next = filter;
                this.tailFilter = filter;
            }
        }

        /// <summary>
        /// Clears the filter list for this appender.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Clears the filter list for this appender.
        /// </para>
        /// </remarks>
        public virtual void ClearFilters()
        {
            this.headFilter = this.tailFilter = null;
        }
        #endregion // PUBLIC INSTANCE METHODS

        //// ---------------------------------------------------------------------

        #region PROTECTED INSTANCE METHODS
        /// <summary>
        /// Checks if the message level is below this appender s threshold.
        /// </summary>
        /// <param name="level"><see cref="Level"/> to test against.</param>
        /// <remarks>
        /// <para>
        /// If there is no threshold set, then the return value is always <c>true</c>.
        /// </para>
        /// </remarks>
        /// <returns>
        /// <c>true</c> if the <paramref name="level"/> meets the <see cref="Threshold"/> 
        /// requirements of this appender.
        /// </returns>
        protected virtual bool IsAsSevereAsThreshold(Level level)
        {
            return (this.Threshold == null) || level >= this.Threshold;
        }

        /// <summary>
        /// Is called when the appender is closed. Derived classes should override 
        /// this method if resources need to be released.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Releases any resources allocated within the appender such as file handles, 
        /// network connections, etc.
        /// </para>
        /// <para>
        /// It is a programming error to append to a closed appender.
        /// </para>
        /// </remarks>
        protected virtual void OnClose()
        {
            // Do nothing by default
        }

        /// <summary>
        /// Append a bulk array of logging events.
        /// </summary>
        /// <param name="loggingEvents">the array of logging events</param>
        /// <remarks>
        /// <para>
        /// This base class implementation calls the <see cref="Append(LoggingEvent)"/>
        /// method for each element in the bulk array.
        /// </para>
        /// <para>
        /// A sub class that can better process a bulk array of events should
        /// override this method in addition to <see cref="Append(LoggingEvent)"/>.
        /// </para>
        /// </remarks>
        protected virtual void Append(LoggingEvent[] loggingEvents)
        {
            foreach (var loggingEvent in loggingEvents)
            {
                this.Append(loggingEvent);
            }
        }

        /// <summary>
        /// Called before <see cref="Append(LoggingEvent)"/> as a precondition.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method is called by <see cref="DoAppend(LoggingEvent)"/>
        /// before the call to the abstract <see cref="Append(LoggingEvent)"/> method.
        /// </para>
        /// <para>
        /// This method can be overridden in a subclass to extend the checks 
        /// made before the event is passed to the <see cref="Append(LoggingEvent)"/> method.
        /// </para>
        /// <para>
        /// A subclass should ensure that they delegate this call to
        /// this base class if it is overridden.
        /// </para>
        /// </remarks>
        /// <returns><c>true</c> if the call to <see cref="Append(LoggingEvent)"/> should proceed.</returns>
        protected virtual bool PreAppendCheck()
        {
            if ((this.layout == null) && this.RequiresLayout)
            {
                this.ErrorHandler.Error(
                  "Log4NetTargetToLogViewAdapter: No layout set for the appender named ["
                  + this.Name + "].");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Renders the <see cref="LoggingEvent"/> to a string.
        /// </summary>
        /// <param name="loggingEvent">The event to render.</param>
        /// <returns>The event rendered as a string.</returns>
        /// <remarks>
        /// <para>
        /// Helper method to render a <see cref="LoggingEvent"/> to 
        /// a string. This appender must have a <see cref="Layout"/>
        /// set to render the <paramref name="loggingEvent"/> to 
        /// a string.
        /// </para>
        /// <para>If there is exception data in the logging event and 
        /// the layout does not process the exception, this method 
        /// will append the exception text to the rendered string.
        /// </para>
        /// <para>
        /// Where possible use the alternative version of this method
        /// <see cref="RenderLoggingEvent(TextWriter,LoggingEvent)"/>.
        /// That method streams the rendering onto an existing Writer
        /// which can give better performance if the caller already has
        /// a <see cref="TextWriter"/> open and ready for writing.
        /// </para>
        /// </remarks>
        protected string RenderLoggingEvent(LoggingEvent loggingEvent)
        {
            // Create the render writer on first use
            if (this.renderWriter == null)
            {
                this.renderWriter = new ReusableStringWriter(System.Globalization.CultureInfo.InvariantCulture);
            }

            // Reset the writer so we can reuse it
            this.renderWriter.Reset(RenderBufferMaxCapacity, RenderBufferSize);

            this.RenderLoggingEvent(this.renderWriter, loggingEvent);
            return this.renderWriter.ToString();
        }

        /// <summary>
        /// Renders the <see cref="LoggingEvent" /> to a string.
        /// </summary>
        /// <param name="writer">The TextWriter to write the formatted event to</param>
        /// <param name="loggingEvent">The event to render.</param>
        /// <exception cref="System.InvalidOperationException">A layout must be set</exception>
        /// <remarks>
        ///   <para>
        /// Helper method to render a <see cref="LoggingEvent" /> to
        /// a string. This appender must have a <see cref="Layout" />
        /// set to render the <paramref name="loggingEvent" /> to
        /// a string.
        ///   </para>
        ///   <para>If there is exception data in the logging event and
        /// the layout does not process the exception, this method
        /// will append the exception text to the rendered string.
        ///   </para>
        ///   <para>
        /// Use this method in preference to <see cref="RenderLoggingEvent(LoggingEvent)" />
        /// where possible. If, however, the caller needs to render the event
        /// to a string then <see cref="RenderLoggingEvent(LoggingEvent)" /> does
        /// provide an efficient mechanism for doing so.
        ///   </para>
        /// </remarks>
        protected void RenderLoggingEvent(TextWriter writer, LoggingEvent loggingEvent)
        {
            if (this.layout == null)
            {
                throw new InvalidOperationException("A layout must be set");
            }

            if (this.layout.IgnoresException)
            {
                var exceptionStr = loggingEvent.GetExceptionString();
                if (!string.IsNullOrEmpty(exceptionStr))
                {
                    // render the event and the exception
                    this.layout.Format(writer, loggingEvent);
                    writer.WriteLine(exceptionStr);
                }
                else
                {
                    // there is no exception to render
                    this.layout.Format(writer, loggingEvent);
                }
            }
            else
            {
                // The layout will render the exception
                this.layout.Format(writer, loggingEvent);
            }
        }

        /// <summary>
        /// Gets a value indicating whether this appender requires a 
        /// <see cref="Layout"/> to be set.
        /// </summary>
        /// <remarks>
        /// <para>
        /// In the rather exceptional case, where the appender 
        /// implementation admits a layout but can also work without it, 
        /// then the appender should return <c>true</c>.
        /// </para>
        /// <para>
        /// This default implementation always returns <c>true</c>.
        /// </para>
        /// </remarks>
        /// <returns>
        /// <c>true</c> if the appender requires a layout object, otherwise <c>false</c>.
        /// </returns>
        protected virtual bool RequiresLayout
        {
            get { return true; }
        }
        #endregion // PROTECTED INSTANCE METHODS

        //// ---------------------------------------------------------------------

        #region PRIVATE INSTANCE FIELDS
        /// <summary>
        /// The layout of this appender.
        /// </summary>
        /// <remarks>
        /// See <see cref="Layout"/> for more information.
        /// </remarks>
        private ILayout layout;

        /// <summary>
        /// It is assumed and enforced that errorHandler is never null.
        /// </summary>
        /// <remarks>
        /// <para>
        /// It is assumed and enforced that errorHandler is never null.
        /// </para>
        /// <para>
        /// See <see cref="ErrorHandler"/> for more information.
        /// </para>
        /// </remarks>
        private IErrorHandler errorHandler;

        /// <summary>
        /// The first filter in the filter chain.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Set to <c>null</c> initially.
        /// </para>
        /// <para>
        /// See <see cref="IFilter"/> for more information.
        /// </para>
        /// </remarks>
        private IFilter headFilter;

        /// <summary>
        /// The last filter in the filter chain.
        /// </summary>
        /// <remarks>
        /// See <see cref="IFilter"/> for more information.
        /// </remarks>
        private IFilter tailFilter;

        /// <summary>
        /// Flag indicating if this appender is closed.
        /// </summary>
        /// <remarks>
        /// See <see cref="Close"/> for more information.
        /// </remarks>
        private bool closed;

        /// <summary>
        /// The guard prevents an appender from repeatedly calling its own DoAppend method
        /// </summary>
        private bool recursiveGuard;

        /// <summary>
        /// StringWriter used to render events
        /// </summary>
        private ReusableStringWriter renderWriter;

        #endregion // PRIVATE INSTANCE FIELDS

        //// ---------------------------------------------------------------------

        #region CONSTANTS
        /// <summary>
        /// Initial buffer size
        /// </summary>
        private const int RenderBufferSize = 256;

        /// <summary>
        /// Maximum buffer size before it is recycled
        /// </summary>
        private const int RenderBufferMaxCapacity = 1024;
        #endregion // CONSTANTS

        #endregion LOG4NET APPENDER MANAGEMENT

        //// ---------------------------------------------------------------------

        #region PRIVATE METHODS
        /// <summary>
        /// Converts the log level.
        /// </summary>
        /// <param name="level">The level.</param>
        /// <returns>The log level.</returns>
        private static LogLevel ConvertLogLevel(Level level)
        {
            var result = LogLevel.None;

            if (level == Level.Trace)
            {
                result = LogLevel.Trace;
            }
            else if (level == Level.Debug)
            {
                result = LogLevel.Debug;
            }
            else if (level == Level.Info)
            {
                result = LogLevel.Info;
            }
            else if (level == Level.Warn)
            {
                result = LogLevel.Warn;
            }
            else if (level == Level.Error)
            {
                result = LogLevel.Error;
            }
            else if (level == Level.Fatal)
            {
                result = LogLevel.Fatal;
            }
            else if (level == Level.Off)
            {
                result = LogLevel.None;
            } // if

            return result;
        } // ConvertLogLevel()
        #endregion PRIVATE METHODS
    } // Log4NetTargetToLogViewAdapter
} // Tethys.Logging.Log4Net

// =======================================
// End of Log4NetTargetToLogViewAdapter.cs
// =======================================
