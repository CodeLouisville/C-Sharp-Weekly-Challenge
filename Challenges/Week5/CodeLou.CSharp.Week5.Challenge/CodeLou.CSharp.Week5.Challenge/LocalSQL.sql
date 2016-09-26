-- Notice slight differences between MSSQL and MySQL. It's mostly the same, just a little different syntax.

IF NOT EXISTS (SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Position')
BEGIN
	CREATE TABLE Position
	(
		Id INT IDENTITY(1,1) NOT NULL,
		PositionName VARCHAR(100) NOT NULL,
		PRIMARY KEY (Id)
	)
END
GO

IF NOT EXISTS (SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Floor')
BEGIN
CREATE TABLE [Floor]
(
	Id INT NOT NULL IDENTITY(1,1),
    FloorNumber INT NOT NULL,
    FloorName VARCHAR(5) NOT NULL,
    PRIMARY KEY (Id)
)
END
GO

IF NOT EXISTS (SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Department')
BEGIN
CREATE TABLE Department
(
	Id INT NOT NULL IDENTITY(1,1),
    FloorId INT NOT NULL,
    DepartmentName VARCHAR(100) NOT NULL,
    PRIMARY KEY (Id),
    INDEX department_floor_idx (FloorId), -- foreign key index
    CONSTRAINT department_floor FOREIGN KEY (FloorId) REFERENCES [Floor] (Id)
)
END
GO

IF NOT EXISTS (SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Employee')
BEGIN
CREATE TABLE Employee
(	
	Id INT NOT NULL IDENTITY(1,1), -- primary Key, as an INT you can have SQL Auto Increment that number when a record is inserted
    PositionId INT NOT NULL, -- foregin key
    DepartmentId INT, -- foregin key
	FirstName VARCHAR(100) NOT NULL,
	LastName VARCHAR(100) NOT NULL,
	EMail VARCHAR(100),
	Phone VARCHAR(12),
    Extension VARCHAR(4),
	HireDate DATETIME NOT NULL,
    TerminationDate DATETIME,
    StartTime VARCHAR(10) NOT NULL,
    ActiveEmployee BIT NOT NULL DEFAULT '0',
    PRIMARY KEY (Id), 
    INDEX employee_position_idx (PositionId), -- foreign key index
    INDEX employee_department_idx (DepartmentId), -- foreign key index
    
    -- add a constraint that a record must have this value to be inserted, so and employee corresponds to a position, must be a unique name. 
    -- this is saying that PositionId in this table references employee_position's Id (Primary Key)
    CONSTRAINT employee_position FOREIGN KEY (PositionId) REFERENCES Position (Id),
    CONSTRAINT employee_department FOREIGN KEY (DepartmentId) REFERENCES Department (Id)
)
END
GO

INSERT INTO Position (PositionName)
VALUES ('Manager'), ('Employee'), ('Assistant Manager'), ('Junior Developer'), ('Developer');

INSERT INTO [Floor] (FloorNumber, FloorName)
VALUES (1, 'East'), (1, 'West'), (3, 'South'), (2, 'North');

INSERT INTO Department (DepartmentName, FloorId)
VALUES ('Customer Support', 1), ('Sales', 2), ('Developers', 1), ('Reception', 1), ('HR', 3), ('Finance', 4);

INSERT INTO Employee (PositionId, DepartmentId, FirstName, LastName, Email, Phone, Extension, HireDate, TerminationDate, StartTime, ActiveEmployee)
VALUES
(
	1, -- Position: Manager
    1, -- Department: Customer Support
    'Chet', -- FirstName
    'Wilson', -- LastName
    'chet@fakeco.com', -- Email
    '555-555-5555', -- Phone
    '3424', -- Extension
    '2016-01-01 10:25:00', -- HireDate, format: 'YYYY-MM-DD HH:MM:SS' 
    NULL, -- TerminationDate
    '9:00 AM', 
    1 -- ActiveEmployee: 1 = True, 2 = False
),
(
	2, -- Position
    1, -- Department
    'AJ', -- FirstName
    'Hanson', -- LastName
    'aj@fakeco.com', -- Email
    '555-555-1234', -- Phone
    '1245', -- Extension
    '2016-09-01 8:00:00', -- HireDate, format: 'YYYY-MM-DD HH:MM:SS' 
    NULL, -- TerminationDate
    '9:30 AM', 
    1 -- ActiveEmployee
),
(
	2, -- Position
    2, -- Department
    'Dodge', -- FirstName
    'Fowler', -- LastName
    'dodge@fakeco.com', -- Email
    '555-555-5784', -- Phone
    '0124', -- Extension
    '2014-09-01 8:00:00', -- HireDate, format: 'YYYY-MM-DD HH:MM:SS' 
    '2015-01-01 8:00:00', -- TerminationDate
    '9:30 AM', 
    0 -- ActiveEmployee
),
(
	4, -- Position
    3, -- Department
    'Stephen', -- FirstName
    'Johnson', -- LastName
    'stephen@fakeco.com', -- Email
    '555-555-1337', -- Phone
    '1337', -- Extension
    '2016-09-01 8:00:00', -- HireDate, format: 'YYYY-MM-DD HH:MM:SS' 
    NULL, -- TerminationDate
    '9:30 AM', 
    1 -- ActiveEmployee
),
(
	5, -- Position
    3, -- Department
    'Matt', -- FirstName
    'Moore', -- LastName
    'matt@fakeco.com', -- Email
    '555-555-2222', -- Phone
    '2233', -- Extension
    '2010-04-01 8:00:00', -- HireDate, format: 'YYYY-MM-DD HH:MM:SS' 
    NULL, -- TerminationDate
    '8:30 AM', 
    1 -- ActiveEmployee
),
(
	2, -- Position
    4, -- Department
    'Erin', -- FirstName
    'McRoy', -- LastName
    'erin@fakeco.com', -- Email
    '555-555-3321', -- Phone
    '3131', -- Extension
    '2015-06-01 8:00:00', -- HireDate, format: 'YYYY-MM-DD HH:MM:SS' 
    NULL, -- TerminationDate
    '9:00 AM', 
    1 -- ActiveEmployee
)
,
(
	3, -- Position
    5, -- Department
    'Jessica', -- FirstName
    'Martin', -- LastName
    'jessica@fakeco.com', -- Email
    '555-555-9877', -- Phone
    '8541', -- Extension
    '2010-04-01 8:00:00', -- HireDate, format: 'YYYY-MM-DD HH:MM:SS' 
    NULL, -- TerminationDate
    '8:30 AM', 
    1 -- ActiveEmployee
)
,
(
	2, -- Position
    6, -- Department
    'David', -- FirstName
    'Branson', -- LastName
    'david@fakeco.com', -- Email
    '555-555-2315', -- Phone
    '4232', -- Extension
    '2008-05-01 8:00:00', -- HireDate, format: 'YYYY-MM-DD HH:MM:SS' 
    NULL, -- TerminationDate
    '8:00 AM', 
    1 -- ActiveEmployee
)
