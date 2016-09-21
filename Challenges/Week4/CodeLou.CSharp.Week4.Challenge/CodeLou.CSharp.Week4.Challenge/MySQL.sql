-- Notice slight differences between MSSQL and MySQL. It's mostly the same, just a little different syntax.

CREATE SCHEMA IF NOT EXISTS codelouisville;
USE codelouisville;
CREATE TABLE IF NOT EXISTS `position`
(
	Id INT NOT NULL AUTO_INCREMENT,
    PositionName VARCHAR(100) NOT NULL,
    PRIMARY KEY (Id)    
);

CREATE TABLE IF NOT EXISTS floor
(
	Id INT NOT NULL AUTO_INCREMENT,
    FloorNumber INT NOT NULL,
    FloorName VARCHAR(5) NOT NULL,
    PRIMARY KEY (Id)
);

CREATE TABLE IF NOT EXISTS department
(
	Id INT NOT NULL AUTO_INCREMENT,
    FloorId INT NOT NULL,
    DepartmentName VARCHAR(100) NOT NULL,
    PRIMARY KEY (Id),
    KEY department_floor_idx (FloorId), -- foreign key index
    CONSTRAINT department_floor FOREIGN KEY (FloorId) REFERENCES floor (Id) ON DELETE NO ACTION ON UPDATE NO ACTION
);

CREATE TABLE IF NOT EXISTS employee
(	
	Id INT NOT NULL AUTO_INCREMENT, -- primary Key, as an INT you can have SQL Auto Increment that number when a record is inserted
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
    ActiveEmployee TINYINT(1) NOT NULL DEFAULT '0',
    PRIMARY KEY (Id),
    KEY employee_position_idx (PositionId), -- foreign key index
    KEY employee_department_idx (DepartmentId), -- foreign key index
    
    -- add a constraint that a record must have this value to be inserted, so and employee corresponds to a position, must be a unique name. 
    -- this is saying that PositionId in this table references employee_position's Id (Primary Key)
    CONSTRAINT employee_position FOREIGN KEY (PositionId) REFERENCES `position` (Id) ON DELETE NO ACTION ON UPDATE NO ACTION,
    CONSTRAINT employee_department FOREIGN KEY (DepartmentId) REFERENCES department (Id) ON DELETE NO ACTION ON UPDATE NO ACTION
);

INSERT INTO `position` (PositionName)
VALUES ('Manager'), ('Employee'), ('Assistant Manager'), ('Junior Developer'), ('Developer');

INSERT INTO floor (FloorNumber, FloorName)
VALUES (1, 'East'), (1, 'West'), (3, 'South'), (2, 'North');

INSERT INTO department (DepartmentName, FloorId)
VALUES ('Customer Support', 1), ('Sales', 2), ('Developers', 1), ('Reception', 1), ('HR', 3), ('Finance', 4);

INSERT INTO employee (PositionId, DepartmentId, FirstName, LastName, Email, Phone, Extension, HireDate, TerminationDate, StartTime, ActiveEmployee)
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
    '9:00 AM', -- StartTime, format: 'HH:MM:SS'
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
    '9:30 AM', -- StartTime, format: 'HH:MM:SS'
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
    '9:30 AM', -- StartTime, format: 'HH:MM:SS'
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
    '9:30 AM', -- StartTime, format: 'HH:MM:SS'
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
    '8:30 AM', -- StartTime, format: 'HH:MM:SS'
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
    '9:00 AM', -- StartTime, format: 'HH:MM:SS'
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
    '8:30 AM', -- StartTime, format: 'HH:MM:SS'
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
    '8:00 AM', -- StartTime, format: 'HH:MM:SS'
    1 -- ActiveEmployee
)
