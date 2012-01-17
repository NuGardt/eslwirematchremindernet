echo off
color 0a
SET DevEnvDir="%VS100COMNTOOLS%..\IDE\"
SET WORKDIR=%CD%
cls

PUSHD %DevEnvDir%
devenv "%WORKDIR%\NuGardt ESL Wire Plugin Match Reminder.sln" /rebuild "Release"
PUSHD %WORKDIR%


REM Create Archive
PATH = "C:\Program Files\WinRAR"
winrar a "%WORKDIR%\Release\ESLWirePluginMatchReminder.rar" -m5 -t -ep -ag"-YYYY.MM.DD" "Readme.txt" "COPYING.txt" "bin\Release\com.NuGardt.ESLWirePlugin.MatchReminder.dll"

REM Create Installer
PATH = "C:\Program Files (x86)\NSIS"
makeNSIS.exe Installer.nsi
move ESLWirePluginMatchReminder*.exe "%WORKDIR%\Release\"
pause