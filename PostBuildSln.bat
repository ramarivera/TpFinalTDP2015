rem @echo off
rem 
rem 
rem for /f "tokens=2-4 delims=/ " %%i in ("%date%") do (
rem 	set day=%%i
rem 	set month=%%j
rem 	set year=%%k
rem )
rem for /f "tokens=1-3 delims=: " %%i in ("%time%") do (
rem 	set hour=%%i
rem 	set minutes=%%j
rem 	set seconds=%%k
rem )
rem set seconds=%seconds:~0,2%
rem 
rem 
rem set datestr=%day%.%month%.%year%
rem set timestr=%hour%.%minutes%.%seconds%
rem set timestampstr=%datestr%-%timestr%
rem 
rem set DEBUG_PATH="%~dp0TpFinalTDP2015.UI.WinForms\bin\Debug\"
rem set RELEASE_PATH="%~dp0Release"
rem set DLL_NAME="%~1"
rem set LOG_PATH="%~dp0PostBuildLog.txt"
rem 
rem 
rem @echo off
rem For %%A in (%DLL_NAME%) do (
rem     Set Folder=%%~dpA
rem     Set Name=%%~nxA
rem )
rem 
rem rem "$(SolutionDir)PostBuild.bat" "$(TargetPath)"
rem 
rem echo on
rem rem xcopy /y %DLL_NAME% %DEBUG_PATH%
rem rem xcopy /y %DLL_NAME% %RELEASE_PATH%
rem 
rem xcopy /y "%Folder%*.dll" %DEBUG_PATH%
rem xcopy /y "%Folder%*.exe" %DEBUG_PATH%
rem xcopy /y "%Folder%*.config" %DEBUG_PATH%
rem                       
rem xcopy /y "%Folder%*.dll" %RELEASE_PATH%
rem xcopy /y "%Folder%*.exe" %RELEASE_PATH%
rem xcopy /y "%Folder%*.config" %RELEASE_PATH%
rem 
rem echo %timestampstr%   %DLL_NAME% >> %LOG_PATH%
rem rem echo. >> %LOG_PATH%


@echo off

set DEBUG_PATH="%~dp0TpFinalTDP2015.UI.WinForms\bin\Debug\"
set RELEASE_PATH="%~dp0Release"

cd "%~dp0"
call :treeProcess
goto :eof

:treeProcess

for %%f in (*.dll) do xcopy /y %%f %DEBUG_PATH%
for %%f in (*.config) do xcopy /y %%f %DEBUG_PATH%
for %%f in (*.exe) do xcopy /y %%f %DEBUG_PATH%

for %%f in (*.dll) do xcopy /y %%f %RELEASE_PATH%
for %%f in (*.config) do xcopy /y %%f %RELEASE_PATH%
for %%f in (*.exe) do xcopy /y %%f %RELEASE_PATH%


for /D %%d in (*) do (
    cd %%d
    call :treeProcess
    cd ..
)
exit /b