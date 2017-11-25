Tethys.Logging
==============

Simple logging &amp; enhancements for existing logging frameworks

## Project Build Status ##
[![Build status](https://ci.appveyor.com/api/projects/status/wwv7i34nlv8h4g4i?svg=true)](https://ci.appveyor.com/project/tngraf/tethys-logging)
[![License](https://img.shields.io/badge/license-Apache--2.0-blue.svg)](http://www.apache.org/licenses/LICENSE-2.0)
[![NuGet](https://img.shields.io/badge/nuget%20package-v1.2.0-blue.svg)](https://www.nuget.org/packages/Tethys.Logging/)

# What is Tethys.Logging? #

Tethys.Logging is itself a very simple logging framework and adds some enhancements to existing logging frameworks (Common.Logging, NLog, log4net).

Most of the enhancements target the simple display of log message. Yes, you could write all log message to a file and then display them. But for applications with a graphical user interface it's often more easy to show log messages in a (separate) window. With proper configuration such message can be use as well for the user (trace, audit trail) as for the developer. 

## Libraries ##
* **Tethys.Logging** - Platform independent basic logging support (Portable library: .NET Framework 4.x, Silverlight 4, Windows Phone 7/8 and .NET for Windows 	Store apps).
* **Tethys.Logging.Common.Logging** - Adapter for Common.Logging (.NET Client Framework 4, Common.Logging 2.1.1).
* **Tethys.Logging.Common.Logging231** - Adapter for 	Common.Logging (.NET Client Framework 4, Common.Logging 2.3.1).
* **Tethys.Logging.Controls** - Logging controls for WinForms (.NET Client Framework 4).
* **Tethys.Logging.Controls.Wpf** - Logging controls for WPF (.NET Client Framework 4)
* **Tethys.Logging.NLog** - Adapter for NLog (.NET Client Framework 4, NLog 2.0).
* **Tethys.Logging.NLog310** - Adapter for NLog (.NET Framework 4.5, NLog 3.1.0).
* **Tethys.Logging.Log4Net** - Adapter for log4net 1.2.10 (.NET Framework 4, log4net 1.2.11).

## Binaries ##

**Binaries are available on Nuget:**

* **[http://www.nuget.org/packages/Tethys.Logging/](http://www.nuget.org/packages/Tethys.Logging/)**
* **[https://www.nuget.org/packages/Tethys.Logging.Common.Logging/](https://www.nuget.org/packages/Tethys.Logging.Common.Logging/)**
* **[https://www.nuget.org/packages/Tethys.Logging.Common.Logging231/](https://www.nuget.org/packages/Tethys.Logging.Common.Logging231/)**
* **[https://www.nuget.org/packages/Tethys.Logging.Controls/](https://www.nuget.org/packages/Tethys.Logging.Controls/)**
* **[https://www.nuget.org/packages/Tethys.Logging.Controls.Wpf/](https://www.nuget.org/packages/Tethys.Logging.Controls.Wpf/)**
* **[https://www.nuget.org/packages/Tethys.Logging.Log4Net/](https://www.nuget.org/packages/Tethys.Logging.Log4Net/)**
* **[https://www.nuget.org/packages/Tethys.Logging.NLog/](https://www.nuget.org/packages/Tethys.Logging.NLog/)**
* **[https://www.nuget.org/packages/Tethys.Logging.NLog310/](https://www.nuget.org/packages/Tethys.Logging.NLog310/)**
* **[https://www.nuget.org/packages/Tethys.Logging.Win/](https://www.nuget.org/packages/Tethys.Logging.Win/)**

## Test Applications ##
* TestApp.LogView - .NET Client Framework 4, WinForms. 
* TestApp.Common.Logging - .NET Client Framework 4, WinForms, Common.Logging. 
* TestApp.Common.Logging.NLog - .NET Client Framework 4, WinForms, Common.Logging, NLog.
* TestApp.log4net - .NET Framework 4, WinForms, log4net.
* TestApp.NLog - .NET Client Framework 4, WinForms, NLog.
* TestApp.NLog2 - .NET Client Framework 4, WinForms, NLog.
* TestApp.WindowsForms - .NET Client Framework 4, WinForms.
* TestApp.WPF - .NET Client Framework 4, WPF, Common.Logging, NLog.

Release Notes for this Version
------------------------------
This is the first public release of Tethys.Logging as open source on Github. 
Yet Tethys.Logging is not completely new - the framework and is predecessor versions are under development for more that 5 years now and have been used in some professional applications. 
See ChangeLog.md for more details.
Tethys.Logging has also been published on SourceForge before, see [http://sourceforge.net/projects/tethyslogging/?source=directory](http://sourceforge.net/projects/tethyslogging/?source=directory).

Documentation
-------------
Documentation is not very elaborate: there is a Windows help files (CHM), 
generated from the XML comments and there are a couple of example/test 
applications, see Overview.txt for details.

License
-------
Copyright 2009-2017 T. Graf

Licensed under the **Apache License, Version 2.0** (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and limitations under the License.
