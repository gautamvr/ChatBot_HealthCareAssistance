set param1=%~1
set param2=%~2

msbuild %param1%\%param1%.csproj

C:\DINXGENHOST\INSTALLERS\NUnit.ConsoleRunner.3.8.0\tools\nunit3-console.exe %~dp0%param1%\bin\Debug\%param1%.exe --result=%~dp0%param2%
exit /b %errorlevel%

