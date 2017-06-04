# =======================================
# Build NuGet Packages for Tethys.Logging
# =======================================

cd Tethys.Logging
nuget pack Tethys.Logging.csproj
Move-Item Tethys.Logging.*.nupkg ..\export\packages
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

cd Tethys.Logging.Common.Logging231
nuget pack Tethys.Logging.Common.Logging231.csproj
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

cd Tethys.Logging.NLog310
nuget pack Tethys.Logging.NLog310.csproj
move Tethys.Logging.*.nupkg ..\export\packages
cd ..

cd Tethys.Logging.Win
nuget pack Tethys.Logging.Win.csproj
move Tethys.Logging.*.nupkg ..\export\packages
cd ..

# ============================
# ============================
