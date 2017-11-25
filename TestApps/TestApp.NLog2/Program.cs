#region Header
// --------------------------------------------------------------------------
// Tethys.Logging
// ==========================================================================
//
// A (portable) logging library for .NET Framework 4.5, Silverlight 4 and 
// higher, Windows Phone 7 and higher and .NET for Windows Store apps.
//
// ===========================================================================
//
// <copyright file="Program.cs" company="Tethys">
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
#endregion

namespace TestApp.NLog2
{
    using System;
    using System.Windows.Forms;

    /// <summary>
  /// Application main class.
  /// </summary>
  public static class Program
  {
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    public static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new MainForm());
    }
  }
}
