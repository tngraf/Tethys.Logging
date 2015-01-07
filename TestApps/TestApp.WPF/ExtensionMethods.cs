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
// <copyright file="ExtensionMethods.cs" company="Tethys">
// Copyright  2009-2015 by Thomas Graf
//            All rights reserved.
//            Licensed under the Apache License, Version 2.0.
//            Unless required by applicable law or agreed to in writing, 
//            software distributed under the License is distributed on an
//            "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
//            either express or implied. 
// </copyright>
//
// System ... Portable Library
// Tools .... Microsoft Visual Studio 2013
//
// ---------------------------------------------------------------------------
#endregion

namespace TestApplication.WPF
{
  using System.Windows;
  using System.Windows.Media;
  using System.Windows.Media.Effects;

  /// <summary>
  /// TODO: Update summary.
  /// </summary>
  public static class ExtensionMethods
  {
    /// <summary>
    /// BlurWindow effects.
    /// </summary>
    public enum BlurWindowEffect
    {
      /// <summary>
      /// Blur in.
      /// </summary>
      In,

      /// <summary>
      /// Blur out.
      /// </summary>
      Out
    } // BlurWindowEffect

    /// <summary>
    /// Backup of the current background.
    /// </summary>
    private static Brush blurWindowCurrentBackground;

    /// <summary>
    /// Blurs the window.
    /// </summary>
    /// <param name="win">The win.</param>
    /// <param name="mode">The mode.</param>
    public static void BlurWindow(this Window win, BlurWindowEffect mode)
    {
      if (mode == BlurWindowEffect.Out)
      {
        var blur = new BlurEffect();
        blurWindowCurrentBackground = win.Background;

        blur.Radius = 5;
        win.Background = new SolidColorBrush(Colors.Gainsboro);
        win.Effect = blur;
      }
      else
      {
        win.Effect = null;
        win.Background = blurWindowCurrentBackground;
      } // if
    } // BlurWindow()
  }
}
