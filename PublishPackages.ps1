# -------------------------------------------------------
# Publish all Tethys.Logging NuGet packages
#
# SPDX-FileCopyrightText: (c) 2026 T. Graf
# SPDX-License-Identifier: Apache-2.0
# -------------------------------------------------------

$packagefolder = "./packages"

nuget push .\export\packages\*.nupkg -src https://api.nuget.org/v3/index.json -SkipDuplicate -ApiKey $env:NuGetApiKey
