@SET appcmd=C:\Windows\System32\inetsrv\appcmd.exe

SET domainName=dev.neosweat.ch

SET currentDir=%CD%

CD "%currentDir%\..\Sources\Neosweat.Web"
SET sitePath="%CD%"
CD "%currentDir%"

CD "%currentDir%\..\Sources\Neosweat.Web.API"
SET apiPath="%CD%"
CD "%currentDir%"

CALL setup_site.bat %domainName% %sitePath%

%appcmd% add app /site.name:dev.neosweat.ch /path:/api /physicalPath:%apiPath%

@SET appName=neosweat

REG ADD HKEY_LOCAL_MACHINE\SOFTWARE\%appName%\ConnectionStrings /v neosweat /t REG_SZ /d "Data Source=neosweatDbSrv;Initial Catalog=dev.neosweat.ch;Persist Security Info=True;User ID=sa;Password=sa;" /f
REG ADD HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\%domainName%\ConnectionStrings /v neosweat /t REG_SZ /d "Data Source=neosweatDbSrv;Initial Catalog=dev.neosweat.ch;Persist Security Info=True;User ID=sa;Password=sa;" /f

REG ADD HKEY_LOCAL_MACHINE\SOFTWARE\%appName%\AppSettings /v ApplicationEnvironment /t REG_SZ /d "Development" /f
REG ADD HKEY_LOCAL_MACHINE\SOFTWARE\%appName%\AppSettings /v ApplicationEnvironment /t REG_SZ /d "Development" /f
    
REM CALL _setup_unit_tests.bat