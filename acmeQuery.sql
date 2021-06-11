create database acme
use acme 

create table clientAddress(
	clientAddressId int IDENTITY(1,1) PRIMARY KEY not null,
	clientAddressAddressLine1 varchar(255),
	clientAddressAddressLine2 varchar(255),
	clientAddressAddressLine3 varchar(255),
	clientAddressAddressLine4 varchar(255),
	clientAddressPostalCode varchar(255) not null,
);	

create table client(
	clientId int IDENTITY(1,1) PRIMARY KEY not null,
	clientName varchar(255) not null, 
	clientSurname varchar(255) not null,
	clientEmail varchar(255) not null,
	clientPassword varchar(255) not null,
	clientAddressId int foreign key references clientAddress(clientAddressId) 
);

create table administrator(
	administratorId int IDENTITY(1,1) PRIMARY KEY not null,
	administratorEmployeeNumber int,
	administratorUsername varchar(255) not null,
	administratorPassword varchar(255) not null,
);


create table category (
	categoryId int IDENTITY(1,1) PRIMARY KEY not null,
	categoryName varchar(255) not null,
	categoryDescription varchar(255),
	categoryImageUrl varchar(max)
);

create table product(
	productId int IDENTITY(1,1) PRIMARY KEY not null,
	productName varchar(255) not null,
	productMsrp decimal (19,4), 
	productPrice decimal (19,4) not null,  
	categoryId int foreign key references category(categoryId)
);

create table orderDetails(
	orderDetailsId int IDENTITY(1,1) PRIMARY KEY not null,
	orderDetailsDatePlaced Date not null,
	clientId int foreign key references client(clientId) not null,
	productId int foreign key references product(productId) not null,
	orderDetailsFulfilled bit not null
);