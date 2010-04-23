@echo off
rd /s/q build
msbuild /p:Configuration=Release
cd build
if errorlevel 1 goto end
rem Ensure we're not deleting anything if we can't get to the build folder

del *.pdb
del *.xml
del ..\Toast.zip
cd ..

tools\zip -9 -r Toast.zip build\*.*

:end