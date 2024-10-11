@echo off

for /f "delims=" %%a in (.\converter_log.txt) do (
  rem 出力する
  echo %%a
  ping 1.1.1.1 -n 1 -w 1 > NUL
)
exit /b