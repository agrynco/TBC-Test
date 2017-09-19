@SETLOCAL

@SET deploymentPath=%1
@ECHO deploymentPath=%deploymentPath%

RD %deploymentPath% /S /Q

MD %deploymentPath%

@ENDLOCAL
