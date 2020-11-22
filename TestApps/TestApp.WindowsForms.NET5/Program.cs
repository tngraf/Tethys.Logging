// --------------------------------------------------------------------------
// Tethys.Logging
// ==========================================================================
//
// A logging library for .NET Framework 4.5 and .NET Core.
//
// ===========================================================================
//
// <copyright file="Program.cs" company="Tethys">
// Copyright  2020 by Thomas Graf
//            All rights reserved.
//            Licensed under the Apache License, Version 2.0.
//            Unless required by applicable law or agreed to in writing,
//            software distributed under the License is distributed on an
//            "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
//            either express or implied.
// </copyright>
//
// ---------------------------------------------------------------------------

namespace TestApp.WindowsForms.NET5
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// Main program class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        } // Main()
    } // Program
}
