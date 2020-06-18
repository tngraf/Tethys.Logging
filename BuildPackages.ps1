# =======================================
# Build NuGet Packages for Tethys.Logging
# =======================================

# global version
$version = "1.5.0"
$copyright = "Copyright (C) 2009-2020 T. Graf"
$all = "version=" + $version + ";copyright=" + $copyright

cd Tethys.Logging
nuget pack Tethys.Logging.nuspec -properties $all
Move-Item Tethys.Logging.*.nupkg ..\export\packages -force
cd ..

cd Tethys.Logging.Controls
nuget pack Tethys.Logging.Controls.nuspec -properties $all
move Tethys.Logging.*.nupkg ..\export\packages -force
cd ..

cd Tethys.Logging.Controls.Wpf
nuget pack Tethys.Logging.Controls.Wpf.nuspec -properties $all
move Tethys.Logging.*.nupkg ..\export\packages -force
cd ..

cd Tethys.Logging.Common.Logging
nuget pack Tethys.Logging.Common.Logging.nuspec -properties $all
move Tethys.Logging.*.nupkg ..\export\packages -force
cd ..

cd Tethys.Logging.Common.Logging231
nuget pack Tethys.Logging.Common.Logging231.nuspec -properties $all
move Tethys.Logging.*.nupkg ..\export\packages -force
cd ..

cd Tethys.Logging.Common.Logging341
nuget pack Tethys.Logging.Common.Logging341.nuspec -properties $all
move Tethys.Logging.*.nupkg ..\export\packages -force
cd ..

cd Tethys.Logging.Log4net
nuget pack Tethys.Logging.Log4net.nuspec -properties $all
move Tethys.Logging.*.nupkg ..\export\packages -force
cd ..

cd Tethys.Logging.Log4net208
nuget pack Tethys.Logging.Log4net208.nuspec -properties $all
move Tethys.Logging.*.nupkg ..\export\packages -force
cd ..

cd Tethys.Logging.NLog
nuget pack Tethys.Logging.NLog.nuspec -properties $all
move Tethys.Logging.*.nupkg ..\export\packages -force
cd ..

cd Tethys.Logging.NLog310
nuget pack Tethys.Logging.NLog310.nuspec -properties $all
move Tethys.Logging.*.nupkg ..\export\packages -force
cd ..

cd Tethys.Logging.NLog4412
nuget pack Tethys.Logging.NLog4412.nuspec -properties $all
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
