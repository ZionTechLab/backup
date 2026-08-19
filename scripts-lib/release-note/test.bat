@echo off
SETLOCAL

IF "%~2"=="" (
    echo Usage: %~nx0 version1 version2
    exit /b 1
)

SET V1=%1
SET V2=%2
SET OUT_DIR=%CD%\%V2%

echo Creating output folder: %OUT_DIR%
IF NOT EXIST "%OUT_DIR%" (
    mkdir "%OUT_DIR%"
)

echo Running Frontend release notes...
cd /d "C:\Users\t.perera\source\VP-FE\VoyagePro-Frontend"
call gen-release-note %V1% %V2% "%OUT_DIR%\fe"

echo.

echo Running Backend release notes...
cd /d "C:\Users\t.perera\source\VP-BE"
call gen-release-note %V1% %V2% "%OUT_DIR%\be"

echo.

REM Merge commits_fe.html files
echo Merging commits_fe.html...

SET FILE1=%OUT_DIR%\fe\commits_fe.html
SET FILE2=%OUT_DIR%\be\commits_fe.html
SET MERGED_FILE=%OUT_DIR%\merged_commits_fe.html

REM Start HTML wrapper
echo ^<html^>^<head^>^<meta charset="UTF-8"^>^<title^>Merged Commits^</title^>^</head^>^<body^> > "%MERGED_FILE%"

REM Header Section
echo ^<h1^>Release Note^</h1^> >> "%MERGED_FILE%"
echo ^<table border="1" cellpadding="5" cellspacing="0"^> >> "%MERGED_FILE%"
echo ^<tr^>^<td^>Project^</td^>^<td^>Voyage Pro^</td^>^</tr^> >> "%MERGED_FILE%"
echo ^<tr^>^<td^>Version^</td^>^<td^>%V2%^</td^>^</tr^> >> "%MERGED_FILE%"
echo ^<tr^>^<td^>Release Date^</td^>^<td^>2025-06-02^</td^>^</tr^> >> "%MERGED_FILE%"
echo ^<tr^>^<td^>Type of Release^</td^>^<td^>QA^</td^>^</tr^> >> "%MERGED_FILE%"
echo ^<tr^>^<td^>Prepared By^</td^>^<td^>Thilina^</td^>^</tr^> >> "%MERGED_FILE%"
echo ^</table^>^<br/^> >> "%MERGED_FILE%"

REM Add FE commits
echo ^<h2^>Change Log (Frontend)^</h2^> >> "%MERGED_FILE%"
more "%FILE1%" | findstr /V "<html>" | findstr /V "<head>" | findstr /V "<body>" | findstr /V "</body>" | findstr /V "</html>" >> "%MERGED_FILE%"

REM Add BE commits
echo ^<h2^>Change Log (Backend)^</h2^> >> "%MERGED_FILE%"
more "%FILE2%" | findstr /V "<html>" | findstr /V "<head>" | findstr /V "<body>" | findstr /V "</body>" | findstr /V "</html>" >> "%MERGED_FILE%"

REM Close HTML
echo ^</body^>^</html^> >> "%MERGED_FILE%"

echo.
echo Merged HTML created: %MERGED_FILE%

ENDLOCAL
pause
