echo off


set DEBUG_PATH="%~dp0TpFinalTDP2015.UI.WinForms\bin\Debug\"
set RELEASE_PATH="%~dp0Release"
set TEST_PATH="%~dp0TpFinalTDP2015.Test\bin\Debug\"

RD /S /Q %DEBUG_PATH%DependencyInjection %TEST_PATH%Logging
RD /S /Q %DEBUG_PATH%DependencyInjection %DEBUG_PATH%Logging
RD /S /Q %DEBUG_PATH%DependencyInjection %RELEASE_PATH%Logging

call :treeProcess
goto :eof

:treeProcess

xcopy /y /F "*.dll" %DEBUG_PATH%
xcopy /y /F "*.exe" %DEBUG_PATH%
xcopy /y /F "*.config" %DEBUG_PATH%
          
xcopy /y /F "*.dll" %TEST_PATH%
xcopy /y /F "*.exe" %TEST_PATH%
xcopy /y /F "*.config" %TEST_PATH%
           
xcopy /y /F "*.dll" %RELEASE_PATH%
xcopy /y /F "*.exe" %RELEASE_PATH%
xcopy /y /F "*.config" %RELEASE_PATH%


for /D %%d in (*) do (
    cd %%d
    call :treeProcess
    cd ..
)
exit /b



