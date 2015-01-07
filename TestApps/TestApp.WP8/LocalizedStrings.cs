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
// <copyright file="LocalizedStrings.cs" company="Tethys">
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