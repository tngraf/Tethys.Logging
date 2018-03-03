:REM =======================================
:REM Build NuGet Packages for Tethys.Logging
:REM =======================================

cd Tethys.Logging
nuget pack Tethys.Logging.nuspec
move Tethys.Logging.*.nupkg ..\export\packages
cd ..

cd Tethys.Logging.Controls
nuget pack Tethys.Logging.Controls.nuspec
move Tethys.Logging.*.nupkg ..\export\packages
cd ..

cd Tethys.Logging.Controls.Wpf
nuget pack Tethys.Logging.Controls.Wpf.nuspec
move Tethys.Logging.*.nupkg ..\export\packages
cd ..

cd Tethys.Logging.Common.Logging
nuget pack Tethys.Logging.Common.Logging.nuspec
move Tethys.Logging.*.nupkg ..\export\packages
cd ..

cd Tethys.Logging.Common.Logging231
nuget pack Tethys.Logging.Common.Logging231.nuspec
move Tethys.Logging.*.nupkg ..\export\packages
cd ..

cd Tethys.Logging.Common.Logging341
nuget pack Tethys.Logging.Common.Logging341.nuspec
move Tethys.Logging.*.nupkg ..\export\packages
cd ..

cd Tethys.Logging.Log4net
nuget pack Tethys.Logging.Log4net.nuspec
move Tethys.Logging.*.nupkg ..\export\packages
cd ..

cd Tethys.Logging.Log4net208
nuget pack Tethys.Logging.Log4net208.nuspec
move Tethys.Logging.*.nupkg ..\export\packages
cd ..

cd Tethys.Logging.NLog
nuget pack Tethys.Logging.NLog.nuspec
move Tethys.Logging.*.nupkg ..\export\packages
cd ..

cd Tethys.Logging.NLog310
nuget pack Tethys.Logging.NLog310.nuspec
move Tethys.Logging.*.nupkg ..\export\packages
cd ..

cd Tethys.Logging.NLog4412
nuget pack Tethys.Logging.NLog4412.nuspec
move Tethys.Logging.*.nupkg ..\export\packages
cd ..

cd Tethys.Logging.Win
nuget pack Tethys.Logging.Win.nuspec
move Tethys.Logging.*.nupkg ..\export\packages
cd ..

cd Tethys.Logging.Console
nuget pack Tethys.Logging.Console.nuspec
move Tethys.Logging.*.nupkg ..\export\packages
cd ..

:REM ============================
:REM ============================
