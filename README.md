<!-- 
SPDX-FileCopyrightText: (c) 2009-2026 T. Graf
SPDX-License-Identifier: Apache-2.0
-->

# Tethys.Logging

[![Build status](https://ci.appveyor.com/api/projects/status/wwv7i34nlv8h4g4i?svg=true)](https://ci.appveyor.com/project/tngraf/tethys-logging)
[![License](https://img.shields.io/badge/license-Apache--2.0-blue.svg)](http://www.apache.org/licenses/LICENSE-2.0)
[![NuGet](https://img.shields.io/badge/nuget%20package-v2.0.0-blue.svg)](https://www.nuget.org/packages/Tethys.Logging/)
[![REUSE status](https://api.reuse.software/badge/git.fsfe.org/reuse/api)](https://api.reuse.software/info/git.fsfe.org/reuse/api)
[![SBOM](https://img.shields.io/badge/SBOM-CycloneDX-brightgreen)](https://github.com/tngraf/Tethys.Logging/blob/master/SBOM/sbom.cyclonedx.xml)

Simple logging &amp; enhancements for existing logging frameworks

# What is Tethys.Logging?

Tethys.Logging is itself a very simple logging framework and adds some enhancements to existing logging frameworks (Common.Logging, NLog, log4net).

Most of the enhancements target the simple display of log message. Yes, you could write all log message to a file and then display them. But for applications with a graphical user interface it's often more easy to show log messages in a (separate) window. With proper configuration such message can be use as well for the user (trace, audit trail) as for the developer.

## Libraries

* **Tethys.Logging** - Platform independent basic logging support (.Net Standard 2.0).
* **Tethys.Logging.Console** - log output to console window (.Net Standard 2.0).
* **Tethys.Logging.Controls** - Logging controls for WinForms (.NET Framework 4.72+).
* **Tethys.Logging.Controls.NET5** - Logging controls for WinForms (.NET Core 3.1 and .NET 5 and later).
* **Tethys.Logging.Controls.NET8** - Logging controls for WinForms (.NET 8 and later).
* **Tethys.Logging.Controls.Wpf** - Logging controls for WPF (.NET Framework 4.72+)
* **Tethys.Logging.Controls.Wpf.NET5** - Logging controls for WPF (.NET Core 3.1 and .NET 5 and later)
* **Tethys.Logging.Win** - Adapter for Trace (.NET Framework 4.72+).

## Binaries

**Binaries are available on Nuget:**

* **[http://www.nuget.org/packages/Tethys.Logging/](http://www.nuget.org/packages/Tethys.Logging/)**
* **[https://www.nuget.org/packages/Tethys.Logging.Console/](https://www.nuget.org/packages/Tethys.Logging.Console/)**
* **[https://www.nuget.org/packages/Tethys.Logging.Controls/](https://www.nuget.org/packages/Tethys.Logging.Controls/)**
* **[https://www.nuget.org/packages/Tethys.Logging.Controls.NET5/](https://www.nuget.org/packages/Tethys.Logging.Controls.NET5/)**
* **[https://www.nuget.org/packages/Tethys.Logging.Controls.NET8/](https://www.nuget.org/packages/Tethys.Logging.Controls.NET8/)**
* **[https://www.nuget.org/packages/Tethys.Logging.Controls.Wpf/](https://www.nuget.org/packages/Tethys.Logging.Controls.Wpf/)**
* **[https://www.nuget.org/packages/Tethys.Logging.Controls.Wpf.NET5/](https://www.nuget.org/packages/Tethys.Logging.Controls.Wpf.NET5/)**
* **[https://www.nuget.org/packages/Tethys.Logging.Win/](https://www.nuget.org/packages/Tethys.Logging.Win/)**

## Test Applications

* TestApp.LogView - .NET Client Framework 4, WinForms. 
* TestApp.WindowsForms - .NET Client Framework 4, WinForms.
* TestApp.WPF - .NET Client Framework 4, WPF, Common.Logging, NLog.

## Documentation

Documentation is not very elaborate: there is a Windows help files (CHM), 
generated from the XML comments and there are a couple of example/test 
applications, see Overview.txt for details.

## License

Copyright 2009-2026 T. Graf

Licensed under the **Apache License, Version 2.0** (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and limitations under the License.
