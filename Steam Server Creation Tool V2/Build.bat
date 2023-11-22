REM
REM This file helps me to copy files into a folder for me to package production builds for new versions
REM


@echo off
setlocal enabledelayedexpansion

REM Get the directory of the batch file
set "batchDir=%~dp0"

REM Define the name of the new directory
set "newDirName=SSCTV2"

REM Combine the batch file directory and the new directory name
set "newDirPath=%batchDir%%newDirName%"

REM Create the new directory
mkdir "%newDirPath%"

echo Directory created at: %newDirPath%

REM Specify the files to copy
REM set "filesToCopy="AutoUpdater.exe" "Newtonsoft.Json.dll" "Steam Server Creation Tool V2.exe""
set "filesToCopy="Newtonsoft.Json.dll" "Steam Server Creation Tool V2.exe""

REM Loop through the array and copy each file
for %%f in (%filesToCopy%) do (
    copy "!batchDir!%%~f" "!newDirPath!"
)

echo Files copied to: %newDirPath%

endlocal
