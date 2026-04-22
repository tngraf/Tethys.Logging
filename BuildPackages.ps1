# =============================================
# Build NuGet Packages for Tethys.Logging
# SPDX-FileCopyrightText: (c) 2022-2026 T. Graf
# SPDX-License-Identifier: Apache-2.0
# =============================================

# global version
$version = "2.0.0"
$copyright = "Copyright (C) 2009-2026 T. Graf"
$all = "version=" + $version + ";copyright=" + $copyright

New-Item -Path "export" -ItemType Directory -Force
New-Item -Path "export\packages" -ItemType Directory -Force

cd Tethys.Logging
nuget pack Tethys.Logging.nuspec -properties $all
Move-Item Tethys.Logging.*.nupkg ..\export\packages -force
cd ..

cd Tethys.Logging.Controls
nuget pack Tethys.Logging.Controls.nuspec -properties $all
move Tethys.Logging.*.nupkg ..\export\packages -force
cd ..

cd Tethys.Logging.Controls.NET5
nuget pack Tethys.Logging.Controls.NET5.nuspec -properties $all
move Tethys.Logging.*.nupkg ..\export\packages -force
cd ..

cd Tethys.Logging.Controls.NET8
nuget pack Tethys.Logging.Controls.NET8.nuspec -properties $all
move Tethys.Logging.*.nupkg ..\export\packages -force
cd ..

cd Tethys.Logging.Controls.Wpf
nuget pack Tethys.Logging.Controls.Wpf.nuspec -properties $all
move Tethys.Logging.*.nupkg ..\export\packages -force
cd ..

cd Tethys.Logging.Controls.Wpf.NET5
nuget pack Tethys.Logging.Controls.Wpf.NET5.nuspec -properties $all
move Tethys.Logging.*.nupkg ..\export\packages -force
cd ..

cd Tethys.Logging.Win
nuget pack Tethys.Logging.Win.nuspec -properties $all
move Tethys.Logging.*.nupkg ..\export\packages -force
cd ..

cd Tethys.Logging.Console
nuget pack Tethys.Logging.Console.nuspec -properties $all
move Tethys.Logging.*.nupkg ..\export\packages -force
cd ..

# ============================
# ============================
