# ---------------------------------------------
# Create SBOms
# SPDX-FileCopyrightText: (c) 2023 T. Graf
# SPDX-License-Identifier: Apache-2.0
# ---------------------------------------------

New-Item -ItemType Directory -Force -Path SBOM

# create REUSE SBOM
reuse spdx > SBOM/sbom.spdx.txt

# create CycloneDX SBOM
Remove-Item "SBOM\bom.xml" -Recurse -ErrorAction SilentlyContinue
Remove-Item "SBOM\sbom.cyclonedx.xml" -Recurse -ErrorAction SilentlyContinue
dotnet-CycloneDX .\Tethys.Logging.sln -o .\SBOM\

Rename-Item -Path "SBOM\bom.xml" -NewName "sbom.cyclonedx.xml"
