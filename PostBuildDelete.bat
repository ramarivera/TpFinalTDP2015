@echo off



set DEBUG_PATH="%~dp0TpFinalTDP2015.UI.WinForms\bin\Debug\"
set RELEASE_PATH="%~dp0Release"
set TEST_PATH="%~dp0TpFinalTDP2015.Test\bin\Debug\"



RD /S /Q %DEBUG_PATH%DependencyInjection %DEBUG_PATH%Logging
RD /S /Q %TEST_PATH%DependencyInjection %TEST_PATH%Logging
RD /S /Q %RELEASE_PATH%DependencyInjection %RELEASE_PATH%Logging





