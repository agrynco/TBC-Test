@ECHO OFF
SET targetMachineIp=%1
SET userName=%2
SET password=%3
SET cmdName=%4
SET poolName=%5

RemCom.exe \\%targetMachineIp% /user:%userName% /pwd:%password% C:\Windows\system32\inetsrv\appcmd.exe %cmdName% apppool %poolName%
ECHO ERRORLEVEL=%ERRORLEVEL%
