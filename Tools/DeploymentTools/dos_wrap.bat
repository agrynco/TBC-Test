@ECHO OFF

SET cmdName=%1
SET acceptReturnCodes=%2

ECHO %cmdName% %3 %4 %5 %6 %7 %8 %9

CALL %cmdName% %3 %4 %5 %6 %7 %8 %9

SET errorCode=%ERRORLEVEL%
ECHO %cmdName% returned %errorCode%
IF %errorCode%==0 EXIT /B 0

REM check errorCode
ECHO str_contain.bat %errorCode% %acceptReturnCodes%
CALL str_contain.bat %errorCode% %acceptReturnCodes% 

SET contains=%ERRORLEVEL%
IF %contains%==1 GOTO acceptable

ECHO ERRORLEVEL %errorCode% is NOT acceptable
EXIT /B %errorCode%

:acceptable
ECHO ERRORLEVEL %errorCode% is acceptable
EXIT /B 0