for /F "tokens=2* delims= " %%f IN ('reg query HKCU\Environment /v PATH ^| findstr /i path') do set OLD_SYSTEM_PATH=%%g
setx PATH "C:\Program Files (x86)\AMG Sistemas\AMG DapperEntities\bin;%OLD_SYSTEM_PATH%"
