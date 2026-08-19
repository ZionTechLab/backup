@echo off
echo Starting Galaxy Song Book (Backend + Frontend)...
echo.

start "Galaxy Song Book Backend" cmd /k "cd /d %~dp0express-be && npm run dev"

timeout /t 3 /nobreak >nul

start "Galaxy Song Book Frontend" cmd /k "set PORT=3001 && cd /d %~dp0my-app && npm start"

echo Both apps launching...
echo Backend: http://localhost:3000
echo Frontend: http://localhost:3001
