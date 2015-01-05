:REM =======================================
:REM Build NuGet Packages for Tethys.Logging
:REM =======================================

cd Tethys.Logging
nuget pack Tethys.Logging.csproj
move Tethys.Logging.*.nupkg ..\export\packages
cd ..

cd Tethys.Logging.Controls
nuget pack Tethys.Logging.Controls.csproj
move Tethys.Logging.*.nupkg ..\export\packages
cd ..

cd Tethys.Logging.Controls.Wpf
nuget pack Tethys.Logging.Controls.Wpf.csproj
move Tethys.Logging.*.nupkg ..\export\packages
cd ..

cd Tethys.Logging.Common.Logging
nuget pack Tethys.Logging.Common.Logging.csproj
move Tethys.Logging.*.nupkg ..\export\packages
cd ..

cd Tethys.Logging.Log4net
nuget pack Tethys.Logging.Log4net.csproj
move Tethys.Logging.*.nupkg ..\export\packages
cd ..

cd Tethys.Logging.NLog
nuget pack Tethys.Logging.NLog.csproj
move Tethys.Logging.*.nupkg ..\export\packages
cd ..

cd Tethys.Logging.Win
nuget pack Tethys.Logging.Win.csproj
move Tethys.Logging.*.nupkg ..\export\packages
cd ..

:REM ============================
:REM ============================
