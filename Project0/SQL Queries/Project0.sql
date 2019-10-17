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
	Merch				nvarchar(50)		not null,
	MerchAmount			int					not null,
	Price				money				not null,
	OrderTime			datetime			not null,
);
go

--drop table Proj0.OrderDetails
create table Proj0.OrderDetails(
	Name				nvarchar(50)		not null								primary key,
	OrderID				int					not null								foreign key			references Proj0.OrderInfo		(ID),
	ProductName			nvarchar(50)		not null								foreign key			references Proj0.Product		(Name),
);
go

--drop table Proj0.Store
create table Proj0.Store(
	ID					int					not null			identity			primary key,
	Street				nvarchar(50)		not null,
	City				nvarchar(50)		not null,
	State				nvarchar(50)		not null,
	Zip					nvarchar(50)		not null,
	MerchandiseID		int					not null
);
go

go
--drop table Proj0.Product
create table Proj0.Product(
	Name				nvarchar(50)		not null			primary key,
	Price				money				not null
);
go

--drop table Proj0.Inventory
create table Proj0.Inventory(
	ID					int					not null			identity			primary key,
	Name				nvarchar(50)		not null								foreign key			references Proj0.Product		(Name),
	Amount				int					not null,
	LocationID			int					not null								foreign key			references Proj0.Store			(ID)
);
go

insert into Proj0.Customer(FirstName, LastName) values 
('John', 'Smith'),
('Jack', 'Smith'),
('Jane', 'Smith');

insert into Proj0.Store(Street, City, State, Zip, MerchandiseID) values
('123 sesame st', 'Arlington', 'TX', '12345', 1),
('213 sesame st', 'Arlington', 'TX', '12345', 2),
('321 sesame st', 'Arlington', 'TX', '12345', 3);

insert into Proj0.Product(Name, Price) values
('Dirt', 10),
('Animal', 20),
('Box', 100);

insert into Proj0.Inventory(Name, Amount, LocationID) values 
('Dirt', 2, 1),
('Animal', 15, 1),
('Box', 30, 1),
('Dirt', 4, 2),
('Animal', 8, 2),
('Box', 50, 2),
('Dirt', 1, 3),
('Animal', 5, 3),
('Box', 20, 3);

insert into Proj0.OrderInfo(CustomerID, StoreID, Merch, MerchAmount, Price, OrderTime) values 
(1, 1, 'Dirt', 1, 10, GetDate()),
(1, 1, 'Animal', 2, 40, GetDate()),
(2, 2, 'Box', 10, 1000, GetDate()),
(3, 3, 'Animal', 3, 60, GetDate());

insert into Proj0.OrderDetails(Name, OrderID, ProductName) values
('John', 1, 'Dirt'),
('Jack', 2, 'Box'),
('Jane', 3, 'Animal');

select * from Proj0.Inventory;

select * from Proj0.OrderInfo;

select * from Proj0.OrderDetails;

select * from Proj0.Store;

select * from Proj0.Customer;

select * from Proj0.Product;