@SETLOCAL

@SET appcmd=C:\Windows\System32\inetsrv\appcmd.exe 

SET domainName=%1%
SET sitePath=%2%

REM Creating site under IIS
%appcmd% add site /name:%domainName% /physicalPath:%sitePath% /bindings:http/*:80:%domainName%

@REM ADDIN THE POOL
%appcmd% add apppool /name:%domainName% /managedRuntimeVersion:v4.0 /managedPipelineMode:Integrated
%appcmd% set site /site.name:%domainName% /[path='/'].applicationPool:%domainName%

@ENDLOCAL