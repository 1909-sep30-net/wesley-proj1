-- create a 3 tables: employee, department, EmpDetails

go
-- create the schema
create schema work;
go

-- create the Employee table
-- drop table work.Employee;
create table work.Employee(
	ID					int					not null		identity(1, 1),
	FirstName			nvarchar(50)		not null,
	LastName			nvarchar(50)		not null,
	SSN					int					not null,
	DeptID				int					not null		foreign key				references work.Department (ID),
	constraint			WK_ID				primary key		(ID)
);

go

-- create the Department table, FK to Employee.DeptID
-- drop table work.Department;
create table work.Department(
	ID					int					not null		identity(1, 1),
	Name				nvarchar(50)		not null,
	Location			nvarchar(50)		not null,
	constraint			Dept_ID				primary key		(ID)
);

go

-- create the EmpDetails table, FK to Employee.ID
-- drop table work.EmpDetails;
create table work.EmpDetails(
	ID					int					not null		identity(1, 1),
	EmployeeID			int					not null		Foreign Key				references work.Employee (ID),
	Salary				int					not null,
	Address1			nvarchar(50)		not null,
	Address2			nvarchar(50)		not null,
	City				nvarchar(50)		not null,
	State				nvarchar(50)		not null,
	Country				nvarchar(50)		not null
);

go

insert into work.Department (Name, Location) values ('Executive', 'A');
insert into work.Department (Name, Location) values ('Money', 'B');
insert into work.Department (Name, Location) values ('Clean-up', 'C');

select * from work.Department;

insert into work.Employee (FirstName, LastName, SSN, DeptID) values ('John', 'Smith', 123, 1);
insert into work.Employee (FirstName, LastName, SSN, DeptID) values ('Jane', 'Smith', 213, 2);
insert into work.Employee (FirstName, LastName, SSN, DeptID) values ('Jack', 'Smith', 312, 3);

select * from work.Employee;

insert into work.EmpDetails (EmployeeID, Salary, Address1, Address2, City, State, Country) values (1, 1234, '123 sesame st', 'N/A', 'abc', 'ab', 'dba');
insert into work.EmpDetails (EmployeeID, Salary, Address1, Address2, City, State, Country) values (2, 1234, '321 sesame st', 'N/A', 'abc', 'ab', 'dba');
insert into work.EmpDetails (EmployeeID, Salary, Address1, Address2, City, State, Country) values (3, 1234, '213 sesame st', 'N/A', 'abc', 'ab', 'dba');

select * from work.EmpDetails;

insert into work.Department (Name, Location) values ('Marketing', 'D');
insert into work.Employee	(FirstName, LastName, SSN, DeptID) values ('Tina', 'Smith', 321, 4);
insert into work.EmpDetails (EmployeeID, Salary, Address1, Address2, City, State, Country) values (4, 1234, '312 sesame st', 'N/A', 'abc', 'ab', 'dba');

select A.* from work.Employee as A
Inner Join work.Department as B
	on A.DeptID = B.ID
where B.Name = 'Marketing';

select B.Name, sum(Salary)
from work.Employee as A
left join work.Department as B
	on A.DeptID = B.ID
left join work.EmpDetails as C
	on A.ID = C.EmployeeID
group by B.Name;


select * from work.Employee group by DeptID;


update work.EmpDetails set Salary += 90000 where FirstName = 'Tina';