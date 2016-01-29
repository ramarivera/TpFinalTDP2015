@echo off


for /f "tokens=2-4 delims=/ " %%i in ("%date%") do (
	set day=%%i
	set month=%%j
	set year=%%k
)
for /f "tokens=1-3 delims=: " %%i in ("%time%") do (
	set hour=%%i
	set minutes=%%j
	set seconds=%%k
)
set seconds=%seconds:~0,2%


set datestr=%day%.%month%.%year%
set timestr=%hour%.%minutes%.%seconds%
set timestampstr=%datestr%-%timestr%

set DEBUG_PATH="%~dp0TpFinalTDP2015.UI.WinForms\bin\Debug\"
set RELEASE_PATH="%~dp0Release"
set DLL_NAME="%~1"
set LOG_PATH="%~dp0PostBuildLog.txt"


@echo off
For %%A in (%DLL_NAME%) do (
    Set Folder=%%~dpA
    Set Name=%%~nxA
)

rem "$(SolutionDir)PostBuild.bat" "$(TargetPath)"

echo on
rem xcopy /y %DLL_NAME% %DEBUG_PATH%
rem xcopy /y %DLL_NAME% %RELEASE_PATH%

xcopy /y "%Folder%*.dll" %DEBUG_PATH%
xcopy /y "%Folder%*.exe" %DEBUG_PATH%
xcopy /y "%Folder%*.config" %DEBUG_PATH%
                      
xcopy /y "%Folder%*.dll" %RELEASE_PATH%
xcopy /y "%Folder%*.exe" %RELEASE_PATH%
xcopy /y "%Folder%*.config" %RELEASE_PATH%

echo %timestampstr%   %DLL_NAME% >> %LOG_PATH%
rem echo. >> %LOG_PATH%
