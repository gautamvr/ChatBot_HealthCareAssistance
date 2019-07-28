rem set param1=%~1
rem set param2=%~2

msbuild %~dp0\CHATBOT.sln /t:rebuild /p:configuration=Release
IF %errorlevel% NEQ 0 goto:END
%~dp0\packages\NUnit.ConsoleRunner.3.10.0\tools\nunit3-console.exe %~dp0BusinessLayerTest\bin\Release\BusinessLayerTest.dll %~dp0DataLayerTest\bin\Release\DataLayerTest.dll --result=%~dp0ChatBotTestResultsLogs.txt
if %errorlevel% NEQ 0 goto:END
:END
exit /b %errorlevel%

