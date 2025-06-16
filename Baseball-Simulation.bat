@echo off
REM 啟動機械手臂後端 (.exe)…
echo 啟動機械手臂後端 (.exe)...
start "" "C:\path\to\your\backend1.exe"

REM 等待 5 秒
echo 等待機械手臂後端初始化...
timeout /t 5

REM 啟動主體後端虛擬環境與主體後端 (uvicorn)
echo 啟動主體後端虛擬環境與主體後端 (uvicorn)...
start "" cmd /k "cd /d C:\path\to\your\backend2 && call .\venv\Scripts\activate && uvicorn server:app"

REM 等待 10 秒
echo 等待主體後端初始化...
timeout /t 10

REM 啟動前端 (npm start)
echo 啟動前端 (npm start)...
start "" cmd /k "cd /d C:\path\to\your\frontend && npm start"

echo 全部服務已成功啟動！
pause
