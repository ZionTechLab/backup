@echo off
REM ftp_upload.cmd
REM Usage:
REM   ftp_upload.cmd <host> <username> <password> <local_path> [remote_path]
REM Example:
REM   ftp_upload.cmd ftp.example.com myuser mypass "C:\path\to\file.txt" /uploads
REM   ftp_upload.cmd ftp.example.com myuser mypass "C:\path\to\folder" /uploads/folder
REM
REM This script uses the Windows built-in ftp.exe client (active mode) and no external modules.
REM Limitations:
REM - Only plain FTP is supported (not SFTP or FTP over TLS). For secure transfers, use PowerShell or external tools.
REM - Passwords may appear in process listings or command history. Use with care.

SETLOCAL ENABLEDELAYEDEXPANSION

if "%~1"=="" (
  echo Usage: %~nx0 ^<host^> ^<username^> ^<password^> ^<local_path^> [remote_path]
  exit /b 2
)

set "HOST=%~1"
set "USER=%~2"
set "PASS=%~3"
set "LOCAL=%~4"
set "REMOTE=%~5"

if "%REMOTE%"=="" set "REMOTE=/"

REM Create temporary script file for ftp.exe
set "FTPSCRIPT=%TEMP%\ftp_script_%RANDOM%.txt"
set "LISTFILE=%TEMP%\ftp_list_%RANDOM%.txt"

REM Normalize LOCAL path (remove trailing backslash)
set "LOCAL_NORMAL=%LOCAL%"
if "%LOCAL_NORMAL:~-1%"=="\" set "LOCAL_NORMAL=%LOCAL_NORMAL:~0,-1%"

REM Helper: upload a single file
:upload_file
  set "FILEPATH=%~1"
  set "FILENAME=%~nx1"
  >"%FTPSCRIPT%" echo open %HOST%
  >>"%FTPSCRIPT%" echo %USER%
  >>"%FTPSCRIPT%" echo %PASS%
  >>"%FTPSCRIPT%" echo binary
  >>"%FTPSCRIPT%" echo cd %REMOTE%
  >>"%FTPSCRIPT%" echo put "%FILEPATH%" "%FILENAME%"
  >>"%FTPSCRIPT%" echo bye
  ftp -n -s:"%FTPSCRIPT%"
  if errorlevel 1 (
    echo ERROR: ftp returned non-zero for file %FILEPATH%
  ) else (
    echo Uploaded %FILEPATH% -> %HOST%:%REMOTE%/%FILENAME%
  )
  goto :eof

REM If LOCAL is a directory, recursively enumerate and upload files
if exist "%LOCAL_NORMAL%\*" (
  echo Local path is a directory. Preparing recursive upload from "%LOCAL_NORMAL%" to "%REMOTE%" on %HOST%...
  REM build list of files
  del /q "%LISTFILE%" 2>nul || rem
  for /r "%LOCAL_NORMAL%" %%F in (*) do (
    echo %%~fF>>"%LISTFILE%"
  )
  if not exist "%LISTFILE%" (
    echo No files found in "%LOCAL_NORMAL%".
    goto :cleanup
  )
  REM Upload each file and ensure remote directories exist
  for /f "usebackq delims=" %%F in ("%LISTFILE%") do (
    set "SRC=%%~fF"
    REM compute remote relative path
    set "REL=!SRC:%LOCAL_NORMAL%=!"
    set "REL=!REL:~1!"
    set "REMOTEDIR=%REMOTE%"
    for %%P in ("!REL!") do set "RELNAME=%%~dpP"
    REM convert backslashes to slashes
    set "RELNAME=!RELNAME:\=/!"
    REM remove trailing slash
    if "!RELNAME:~-1!"=="/" set "RELNAME=!RELNAME:~0,-1!"
    if not "!RELNAME!"=="" (
      set "REMOTEDIR=%REMOTE%/!RELNAME!"
    )
    REM create remote directories before upload
    >"%FTPSCRIPT%" echo open %HOST%
    >>"%FTPSCRIPT%" echo %USER%
    >>"%FTPSCRIPT%" echo %PASS%
    >>"%FTPSCRIPT%" echo binary
    >>"%FTPSCRIPT%" echo mkdir %REMOTEDIR%
    >>"%FTPSCRIPT%" echo cd %REMOTEDIR%
    >>"%FTPSCRIPT%" echo put "!SRC!" "%%~nxF"
    >>"%FTPSCRIPT%" echo bye
    ftp -n -s:"%FTPSCRIPT%"
    if errorlevel 1 (
      echo ERROR: ftp failed for file !SRC!
    ) else (
      echo Uploaded !SRC! -> %HOST%:%REMOTEDIR%/%%~nxF
    )
  )
  goto :cleanup
)

REM Not a directory -> assume single file
if exist "%LOCAL_NORMAL%" (
  call :upload_file "%LOCAL_NORMAL%"
  goto :cleanup
) else (
  echo ERROR: Local path "%LOCAL%" does not exist.
  goto :cleanup
)

:cleanup
if exist "%FTPSCRIPT%" del /q "%FTPSCRIPT%" 2>nul
if exist "%LISTFILE%" del /q "%LISTFILE%" 2>nul
ENDLOCAL
exit /b 0
