rem set param1=%~1
rem set param2=%~2

msbuild %~dp0\HelloWorld.sln /t:rebuild /p:configuration=Release
IF %errorlevel% NEQ 0 goto:END
%~dp0\NUnit.ConsoleRunner.3.8.0\tools\nunit3-console.exe %~dp0\HelloWorldTest\bin\Release\HelloWorldTest.dll --result=%~dp0HelloWorldTestLogs.txt
if %errorlevel% NEQ 0 goto:END
:END
exit /b %errorlevel%

