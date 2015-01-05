//// -------------------------------------------------------------------------
// TestApplication.Wpf
// ===========================================================================
// ExtensionMethods.cs
// ===========================================================================
//
// This library contains common code of .Net projects of Thomas Graf.
//
// ===========================================================================
//
// <copyright file="ExtensionMethods.cs" company="TgSoft">
// (c) 2003 - 2010 by Thomas Graf.
//            All rights reserved.
//            See the file "License.txt" for information on usage and 
//            redistribution of this file and for a 
//            DISCLAIMER OF ALL WARRANTIES.
// </copyright>
//
// Version .. 1.00.00.08 of 12May18
// Project .. tglib.logging.controls
// Author ... Thomas Graf (tg)
// System ... Microsoft .Net framework 4.0
// Tools .... Microsoft Visual Studio 2010
//
// Change Report
// 12May18 1.00.00.00 tg: initial version.
//
//// -------------------------------------------------------------------------

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
