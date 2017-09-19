SET DbUpdatesApplierFolder=%CD%
SET DbUpdatesApplier="%DbUpdatesApplierFolder%\recreate_db.bat"

REG DELETE HKEY_LOCAL_MACHINE\SOFTWARE\neosweat.integtaiontests /f
REG DELETE HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\neosweat.integtaiontests /f

REG ADD HKEY_LOCAL_MACHINE\SOFTWARE\neosweat.integtaiontests\AppSettings /v updates-applier:executable-file-name /t REG_SZ /d %DbUpdatesApplier% /f
REG ADD HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\neosweat.integtaiontests\AppSettings /v updates-applier:executable-file-name /t REG_SZ /d %DbUpdatesApplier% /f

REG ADD HKEY_LOCAL_MACHINE\SOFTWARE\neosweat.integtaiontests\AppSettings /v api:base-url /t REG_SZ /d http://dev.neosweat.ch/api /f
REG ADD HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\neosweat.integtaiontests\AppSettings /v api:base-url /t REG_SZ /d http://dev.neosweat.ch/api /f
