--create schema
create schema Proj0;
go

-- drop table Proj0.Customer
create table Proj0.Customer(
	ID					int					not null			identity			primary key,
	FirstName			nvarchar(50)		not null,
	LastName			nvarchar(50)		not null,
);
go

--drop table Proj0.OrderInfo
create table Proj0.OrderInfo(
	ID					int					not null			identity			primary key,
	CustomerID			int					not null								foreign key			references Proj0.Customer		(ID),
	StoreID				int					not null								foreign key			references Proj0.Store			(ID),
	OrderTime			datetime			not null,
);
go

--drop table Proj0.OrderDetails
create table Proj0.OrderDetails(
	OrderID				int					not null								foreign key			references Proj0.OrderInfo		(ID),
	MerchID				int					not null								foreign key			references Proj0.Merchandise	(ID),
	Stock				int					not null,
	constraint PK_OrdDet primary key (OrderID, MerchID)
);
go

--drop table Proj0.Store
create table Proj0.Store(
	ID					int					not null			identity			primary key,
	Location			nvarchar(200)		not null,
);
go

go
--drop table Proj0.Merchandise
create table Proj0.Merchandise(
	ID					int					not null			identity			primary key,
	Name				nvarchar(50)		not null,
	Price				money				not null
);
go

--drop table Proj0.Inventory
create table Proj0.Inventory(
	MerchID				int					not null								foreign key			references Proj0.Merchandise	(ID),
	LocationID			int					not null								foreign key			references Proj0.Store			(ID),
	Stock				int					not null,
	constraint PK_Inven primary key(MerchID, LocationID)
);
go
--drop table Proj0.Product
insert into Proj0.Customer(FirstName, LastName) values 
('John', 'Smith'),
('Jack', 'Smith'),
('Jane', 'Smith');

insert into Proj0.Store(Location) values
('123 sesame st Arlington TX 12345'),
('213 sesame st Arlington TX 12345'),
('321 sesame st Arlington TX 12345');

insert into Proj0.Merchandise(Name, Price) values
('WhiteAss', 10),
('BlackAss', 20),
('GreyAss', 100);

--update Proj0.Merchandise
--set Name = 'WhiteAss' where Name = 'Shape';
--update Proj0.Merchandise
--set Name = 'BlackAss' where Name = 'Animal';
--update Proj0.Merchandise
--set Name = 'GreyAss' where Name = 'Number';


insert into Proj0.Inventory(MerchID, LocationID, Stock) values 
(1, 1, 300),
(1, 2, 150),
(1, 3, 100),
(2, 1, 200),
(2, 2, 125),
(2, 3, 75),
(3, 1, 100),
(3, 2, 50),
(3, 3, 25);

insert into Proj0.OrderInfo(CustomerID, StoreID, OrderTime) values 
(1, 1, GetDate()),
(1, 1, GetDate()),
(2, 2, GetDate()),
(3, 3, GetDate());

insert into Proj0.OrderDetails(OrderID, MerchID, Stock) values
(1, 1, 20),
(2, 2, 30),
(3, 3, 40),
(4, 1, 15);

select * from Proj0.Inventory;

select * from Proj0.OrderInfo;

select * from Proj0.OrderDetails;

select * from Proj0.Store;

select * from Proj0.Customer;

select * from Proj0.Merchandise;