@setlocal ENABLEDELAYEDEXPANSION

SET strToFind=%1
SET teststring=%2

@echo off
SET delimiter=-

SET buffer=%teststring%

REM Set a string with an arbitrary number of substrings separated by semi colons

REM Do something with each substring
:stringLOOP
    REM Stop when the string is empty
    if "!teststring!" EQU "" goto END

    for /f "delims=%delimiter%" %%a in ("!teststring!") do set substring=%%a

        REM Do something with the substring - 
        REM we just echo it for the purposes of demo
	IF %strToFind%==%substring% GOTO found

REM Now strip off the leading substring
:striploop
    set stripchar=!teststring:~0,1!
    set teststring=!teststring:~1!

    if "!teststring!" EQU "" goto stringloop

    if "!stripchar!" NEQ "%delimiter%" goto striploop

    goto stringloop
)

:END

@ECHO %strToFind% does not exist in %buffer%
ENDLOCAL
EXIT /B 0

:found
	@ECHO found %strToFind% in %buffer%
	ENDLOCAL
	EXIT /B 1