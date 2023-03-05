<!-- 
SPDX-FileCopyrightText: (c) 2009-2023 T. Graf
SPDX-License-Identifier: Apache-2.0
-->

# Tethys.Logging

[![Build status](https://ci.appveyor.com/api/projects/status/wwv7i34nlv8h4g4i?svg=true)](https://ci.appveyor.com/project/tngraf/tethys-logging)
[![License](https://img.shields.io/badge/license-Apache--2.0-blue.svg)](http://www.apache.org/licenses/LICENSE-2.0)
[![NuGet](https://img.shields.io/badge/nuget%20package-v1.6.0-blue.svg)](https://www.nuget.org/packages/Tethys.Logging/)
[![REUSE status](https://api.reuse.software/badge/git.fsfe.org/reuse/api)](https://api.reuse.software/info/git.fsfe.org/reuse/api)

Simple logging &amp; enhancements for existing logging frameworks

# What is Tethys.Logging?

Tethys.Logging is itself a very simple logging framework and adds some enhancements to existing logging frameworks (Common.Logging, NLog, log4net).

Most of the enhancements target the simple display of log message. Yes, you could write all log message to a file and then display them. But for applications with a graphical user interface it's often more easy to show log messages in a (separate) window. With proper configuration such message can be use as well for the user (trace, audit trail) as for the developer.

## Libraries

* **Tethys.Logging** - Platform independent basic logging support (.Net Standard 2.0).
* **Tethys.Logging.Common.Logging** - Adapter for Common.Logging (.NET Framework 4.72+, Common.Logging 2.1.1).
* **Tethys.Logging.Common.Logging231** - Adapter for Common.Logging (.NET Framework 4.72+, Common.Logging 2.3.1).
* **Tethys.Logging.Common.Logging341** - Adapter for Common.Logging (.NET Framework 4.72+, Common.Logging 3.4.1).
* **Tethys.Logging.Console** - log output to console window (.Net Standard 2.0).
* **Tethys.Logging.Controls** - Logging controls for WinForms (.NET Framework 4.72+).
* **Tethys.Logging.Controls.NET5** - Logging controls for WinForms (.NET Core 3.1 and .NET 5).
* **Tethys.Logging.Controls.Wpf** - Logging controls for WPF (.NET Framework 4.72+)
* **Tethys.Logging.Controls.Wpf.NET5** - Logging controls for WPF (.NET Core 3.1 and .NET 5)
* **Tethys.Logging.Log4Net** - Adapter for log4net 1.2.10 (.NET Framework 4.72+, log4net 1.2.11).
* **Tethys.Logging.Log4Net212** - Adapter for log4net 2.0.8 (.NET Framework 4.72+, log4net 2.0.12).
* **Tethys.Logging.NLog** - Adapter for NLog (.NET Framework 4.72+, NLog 2.0).
* **Tethys.Logging.NLog310** - Adapter for NLog (.NET Framework 4.72+, NLog 3.1.0).
* **Tethys.Logging.NLog4412** - Adapter for NLog (.NET Framework 4.72+, NLog 4.4.12).
* **Tethys.Logging.Win** - Adapter for Trace (.NET Framework 4.72+).

## Binaries

**Binaries are available on Nuget:**

* **[http://www.nuget.org/packages/Tethys.Logging/](http://www.nuget.org/packages/Tethys.Logging/)**
* **[https://www.nuget.org/packages/Tethys.Logging.Common.Logging/](https://www.nuget.org/packages/Tethys.Logging.Common.Logging/)**
* **[https://www.nuget.org/packages/Tethys.Logging.Common.Logging231/](https://www.nuget.org/packages/Tethys.Logging.Common.Logging231/)**
* **[https://www.nuget.org/packages/Tethys.Logging.Common.Logging341/](https://www.nuget.org/packages/Tethys.Logging.Common.Logging341/)**
* **[https://www.nuget.org/packages/Tethys.Logging.Console/](https://www.nuget.org/packages/Tethys.Logging.Console/)**
* **[https://www.nuget.org/packages/Tethys.Logging.Controls/](https://www.nuget.org/packages/Tethys.Logging.Controls/)**
* **[https://www.nuget.org/packages/Tethys.Logging.Controls.NET5/](https://www.nuget.org/packages/Tethys.Logging.Controls.NET5/)**
* **[https://www.nuget.org/packages/Tethys.Logging.Controls.Wpf/](https://www.nuget.org/packages/Tethys.Logging.Controls.Wpf/)**
* **[https://www.nuget.org/packages/Tethys.Logging.Controls.Wpf.NET5/](https://www.nuget.org/packages/Tethys.Logging.Controls.Wpf.NET5/)**
* **[https://www.nuget.org/packages/Tethys.Logging.Log4Net/](https://www.nuget.org/packages/Tethys.Logging.Log4Net/)**
* **[https://www.nuget.org/packages/Tethys.Logging.Log4Net212/](https://www.nuget.org/packages/Tethys.Logging.Log4Net212/)**
* **[https://www.nuget.org/packages/Tethys.Logging.NLog/](https://www.nuget.org/packages/Tethys.Logging.NLog/)**
* **[https://www.nuget.org/packages/Tethys.Logging.NLog310/](https://www.nuget.org/packages/Tethys.Logging.NLog310/)**
* **[https://www.nuget.org/packages/Tethys.Logging.NLog4412/](https://www.nuget.org/packages/Tethys.Logging.NLog4412/)**
* **[https://www.nuget.org/packages/Tethys.Logging.Win/](https://www.nuget.org/packages/Tethys.Logging.Win/)**

## Test Applications

* TestApp.LogView - .NET Client Framework 4, WinForms. 
* TestApp.Common.Logging - .NET Client Framework 4, WinForms, Common.Logging 2.1.1. 
* TestApp.Common.Logging231 - .NET Client Framework 4, WinForms, Common.Logging 2.3.1. 
* TestApp.Common.Logging341 - .NET Client Framework 4, WinForms, Common.Logging 3.4.1. 
* TestApp.Common.Logging.NLog - .NET Client Framework 4, WinForms, Common.Logging, NLog.
* TestApp.log4net - .NET Framework 4, WinForms, log4net.
* TestApp.log4net212 - .NET Framework 4, WinForms, log4net 2.0.12.
* TestApp.NLog - .NET Client Framework 4, WinForms, NLog.
* TestApp.NLog310 - .NET Client Framework 4, WinForms, NLog 3.1.0.
* TestApp.NLog4412 - .NET Client Framework 4, WinForms, NLog 4.4.12.
* TestApp.NLog2 - .NET Client Framework 4, WinForms, NLog.
* TestApp.WindowsForms - .NET Client Framework 4, WinForms.
* TestApp.WPF - .NET Client Framework 4, WPF, Common.Logging, NLog.

## Documentation

Documentation is not very elaborate: there is a Windows help files (CHM), 
generated from the XML comments and there are a couple of example/test 
applications, see Overview.txt for details.

## License

Copyright 2009-2023 T. Graf

Licensed under the **Apache License, Version 2.0** (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and limitations under the License.
