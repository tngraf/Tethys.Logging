# ---------------------------------------------
# Clean project
# SPDX-FileCopyrightText: (c) 2022-2026 T. Graf
# SPDX-License-Identifier: Apache-2.0
# ---------------------------------------------

dotnet clean
Remove-Item "Tethys.Logging\bin" -Recurse -ErrorAction SilentlyContinue
Remove-Item "Tethys.Logging\obj" -Recurse -ErrorAction SilentlyContinue

Remove-Item "Tethys.Logging.Controls\bin" -Recurse -ErrorAction SilentlyContinue
Remove-Item "Tethys.Logging.Controls\obj" -Recurse -ErrorAction SilentlyContinue

Remove-Item "Tethys.Logging.Controls.NET5\bin" -Recurse -ErrorAction SilentlyContinue
Remove-Item "Tethys.Logging.Controls.NET5\obj" -Recurse -ErrorAction SilentlyContinue

Remove-Item "Tethys.Logging.Controls.NET8\bin" -Recurse -ErrorAction SilentlyContinue
Remove-Item "Tethys.Logging.Controls.NET8\obj" -Recurse -ErrorAction SilentlyContinue

Remove-Item "Tethys.Logging.Controls.Wpf\bin" -Recurse -ErrorAction SilentlyContinue
Remove-Item "Tethys.Logging.Controls.Wpf\obj" -Recurse -ErrorAction SilentlyContinue

Remove-Item "Tethys.Logging.Controls.Wpf.NET5\bin" -Recurse -ErrorAction SilentlyContinue
Remove-Item "Tethys.Logging.Controls.Wpf.NET5\obj" -Recurse -ErrorAction SilentlyContinue

Remove-Item "Tethys.Logging.Win\bin" -Recurse -ErrorAction SilentlyContinue
Remove-Item "Tethys.Logging.Win\obj" -Recurse -ErrorAction SilentlyContinue

Remove-Item "Tethys.Logging.Console\bin" -Recurse -ErrorAction SilentlyContinue
Remove-Item "Tethys.Logging.Console\obj" -Recurse -ErrorAction SilentlyContinue
