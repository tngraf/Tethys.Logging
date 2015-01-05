#region Header
// --------------------------------------------------------------------------
// Tethys.Logging
// ==========================================================================
//
// A portable logging library for .NET Framework 4.5, Silverlight 4 and 
// higher, Windows Phone 7 and higher and .NET for Windows Store apps.
//
// ==========================================================================
// <copyright file="LocalizedStrings.cs" company="Tethys">
// Copyright  2013 by Thomas Graf
//            All rights reserved.
//            See the file "License.txt" for information on usage and 
//            redistribution of this file and for a 
//            DISCLAIMER OF ALL WARRANTIES.
// </copyright>
// 
// Version .. 1.00.00.00 of 13Apr18
// System ... Portable Library
// Tools .... Microsoft Visual Studio 2012
//
// Change Report
// 13Mar21 1.00.00.00 tg: initial version.
//
// ---------------------------------------------------------------------------
#endregion

namespace TestApp.WP8
{
  using TestApp.WP8.Resources;

  /// <summary>
  /// Provides access to string resources.
  /// </summary>
  public class LocalizedStrings
  {
    /// <summary>
    /// The localized resources.
    /// </summary>
    private static readonly AppResources LocalizedResourcesInternal = new AppResources();

    /// <summary>
    /// Gets the localized resources.
    /// </summary>
    public AppResources LocalizedResources
    {
      get
      {
        return LocalizedResourcesInternal;
      }
    }
  } // LocalizedStrings
} // TestApp.WP8