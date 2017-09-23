-- -- Start checking possibility of using
DECLARE @newDbVersion       VARCHAR(11)
SET @newDbVersion = '0.2'

DECLARE @currentDbVersion       VARCHAR(11)
SET @currentDbVersion = dbo.GetCurrentDbVersionAsString()

DECLARE @errorMessage NVARCHAR(500);

IF dbo.CompareDbVersionWithCurrent(@newDbVersion) <> 1
BEGIN
    SET @errorMessage = 'Cannot install script ' + @newDbVersion + '. DB version ' + @currentDbVersion + ' expected.'
    RAISERROR(@errorMessage, 20, -1) WITH LOG
END
GO
-- End checking possibility of using

-- BEGIN CHANGES
INSERT INTO People
(
	-- Id -- this column value is auto-generated
	Birthdate,
	FirstName,
	Gender,
	LastName,
	PersonalNumber,
	Salary,
	Created,
	IsDeleted
)
VALUES
(
	'1977-05-15',
	'Anatolii',
	1,
	'Grynchuk',
	'1',
	'100000',
	GETDATE(),
	0
)

INSERT INTO People
(
	-- Id -- this column value is auto-generated
	Birthdate,
	FirstName,
	Gender,
	LastName,
	PersonalNumber,
	Salary,
	Created,
	IsDeleted
)
VALUES
(
	'1965-08-5',
	'Alex',
	2,
	'Anisimov',
	'1',
	'100000',
	GETDATE(),
	0
)
-- END CHANGES

-- Start writing new version info 
GO
IF @@ERROR <> 0
BEGIN
    DECLARE @errorMessage VARCHAR(MAX)
    SET @errorMessage = ERROR_MESSAGE()
    RAISERROR(@errorMessage, 16, 1)
END
ELSE
BEGIN
    DECLARE @newDbVersion       varchar(11)
    SET @newDbVersion = '0.2'
    BEGIN
        EXEC AppendDbVersionInfo @newDbVersion, 'Populate test data'
        
        PRINT 'Completed successfully'
    END
END
GO
-- End writing new version info
