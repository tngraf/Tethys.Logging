<!-- 
SPDX-FileCopyrightText: (c) 2022-2023 T. Graf
SPDX-License-Identifier: Apache-2.0
-->

# Tethys.Logging Change Log

## NEXT

* Dropped support for .NET 5, added support for .NET 6.

## V1.6.1 (2021-06-06)

* log4net 2.0.8 replaced by 2.0.12 due to security vulnerabilities.

## V1.6.0 (2020-11-22)

* Support for .NET Core 3.1 and .NET 5: Tethys.Logging.Controls.NET5 (WinForms)
* Support for .NET Core 3.1 and .NET 5: Tethys.Logging.Controls.Wpf.NET5 (WPF)

## V1.5.0 (2020-06-18)

* Tethys.Logging and Tethys.Logging.Console target .Net Standard 2.0 and .Net Standard 2.1
* All other projects target .Net Framework 4.7.2.
* Creation of Nuget packages updated.

## V1.4.1 (2018-04-02)

* Tethys.Logging and Tethys.Logging.Console target .Net Standard 2.0
* All other projects target .Net Framework 4.6.1

## V1.4.0 (2018-03-03)

* Tethys.Logging.Console added.
* Fix in AbstractLogger.

## V1.3.0 (2017-11-25)

* Upgrade to VS2017.
* Test apps for Windows Phone and Win8 removed.
* Use of new .Net language features
* Code style update.
* Support for Common.Logging 3.4.1.
* Support for NLog 4.4.12.
* Support for log4net 2.0.8.
* LogViewLogger and LogViewFactoryAdapter have settings to enable/disable
  the display of time and log level.

## V1.2.0 (2015-01-07)

* Upgrade to VS2013.
* Header updated.
* Readme and Change Log reworked.
* Import folder reorganized.
* Supports now only log4net 1.2.11 (signed).
* Supports additionally Common.Logging, version 2.3.1.
* Supports additionally NLog 3.1.0.
* Published on Github.

## V1.0.1 (2013-10-12)

* NuGet support added and Nuget packages released.
* System.Diagnostics.Debug.WriteLine can be used in a portable library, but System.Diagnostics.Trace.WriteLine not => to have a trace logger a new library for Windows is needed and we will have no support for Windows Phone and WinRT.
* Again fixes for displays with non-100% display resolutions.
* Version 1.00.01.00 of Tethys.Logging released.

## V1.0.0 (2013-05-30)

* Version 1.0.0 of Tethys.Logging released on SourceForge.

## V0.9.x (2013-05-29)

* Fixes for displays @ 125% size.

## V0.9.x (2013-03-23)

* Renamed to Tethys.

## V0.9.x (2013-03-09)

* FxCop fixes.
* ReSharper fixes.
* StyleCopy fixes.

## V0.8.x (2012-07-20)

* update for NLog 2.0.

## V0.8.x (2012-05-16)

* Tethys.Logging.Control.Wpf added.

## V0.7.x (2012-04-12)

* Bugfix: When the check for the maximum size of the log output has been enabled, the clipboard is filled with log data every time the log exceeds this maximum size.
* Bugfix: The NLog adapter now adds a CR\LF at the end of an exception text.
* Improvement: The copy to clipboard functionality of RtfLogView now copies the text the same way to the clipboard as doing manually select all and copy.

## V0.6.x (2012-03-18)

* Added checkbox to enable/disable debug output for RtfLogView
* IMPORTANT: when the maximum size of the log output into windows is not limited the system will take very much time to update the windows after the application will FREEZE!

## V0.5.x (2011-11-14)

* Exception logging for Common.Logging and NLog improved.

## V0.4.x (2011-05-05)

* Application.DoEvents() removed from logging control AddEvent() handlers. Otherwise we might run into stack overflow exceptions when other threads generate too many events.
* MaxLogLength for RtfLogView and MaxLogEntries for TableLogView added.
* Exception logging for Common.Logging improved.
* Support of Visual Studio 2010 and .Net framework 4.0 client profile.

## V0.3.x (2011-04-07)

* Minor fix to properly display exceptions.

## V0.3.x (2010-10-22)

* Rearranged into multiple namespaces
  * Tethys.Logging = common logging support
  * Tethys.Logging.Common.Logging = support for Common.Logging
  * Tethys.Logging.Log4Net = support for log4net
  * Tethys.Logging.NLog = support for NLog
  * Tethys.Logging.Controls = logging controls
* Support for Common.Logging and NLog added.
* The logging controls are now independent of log4net
* RtfLogView and DebugLogForm can now add new events at
  the end successfully.

## V0.2.x (2010-04-02)

* Minor changes due to ReSharper checks.

## V0.2.x (2010-03-22)

* RtfLogView writes RTF or TXT file.
* Copy to clipboard now always first selects all text.

## V0.1.x (2009-12-22)

* Bugfix in SaveToTextFile().

## V0.1.x (2009-12-12)

* Help file added.

## V0.1.x (2009-11-29)

* first version of this library.
* DebugLogForm added.
* TableLogView added.
* RtfLogView added.

# Supported Logging Libraries

* Common.Logging 2.1.1
* Common.Logging 2.3.1
* Common.Logging 3.4.1
* NLog 2.0.0
* NLog 3.1.0
* NLog 4.4.12
* log4net 1.2.11
* log4net 2.0.8
