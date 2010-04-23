@echo off

rem Builds
rd /s/q build
C:\Windows\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe Toast.sln /p:Configuration=Release

rem Ensure we're not deleting anything if we can't get to the build folder
cd build
if errorlevel 1 goto end

rem Remove some clutter and old files
del *.pdb
del *.xml
del ..\Toast.zip
cd ..

rem ZIP-em-up
tools\zip -9 -r Toast.zip build\*.*

:end