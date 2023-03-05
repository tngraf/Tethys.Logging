// -------------------------------------------------------------------------------
// <copyright file="ILogView.cs" company="Tethys">
//   Copyright (C) 2009-2023 Thomas Graf
//   All Rights Reserved.
// </copyright>
//
// Licensed under the Apache License, Version 2.0.
// Unless required by applicable law or agreed to in writing,
// software distributed under the License is distributed on an
// "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
// either express or implied.
// SPDX-License-Identifier: Apache-2.0
// -------------------------------------------------------------------------------

namespace Tethys.Logging
{
    /// <summary>
    /// This is the interface for all log viewer components.
    /// </summary>
    public interface ILogView
    {
        /// <summary>
        /// Adds a log event.
        /// </summary>
        /// <param name="logEvent">The log event.</param>
        void AddLogEvent(ILogEvent logEvent);
    } // ILogView
} // TgLib.Logging

// ==========================================
