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

create table administer(
	administerId int IDENTITY(1,1) PRIMARY KEY not null,
	administerEmployeeNumber int,
	administerUsername varchar(255) not null,
	administerPassword varchar(255) not null,
);

create table product(
	productId int IDENTITY(1,1) PRIMARY KEY not null,
	productName varchar(255) not null,
	productPrice decimal (19,4) not null,  
	productMsrp decimal (19,4), 
	classId int foreign key references class(classId)

);

create table category (
	categoryId int IDENTITY(1,1) PRIMARY KEY not null,
	categoryName varchar(255) not null,
	categoryDescription varchar(255),
	categoryImage blob
);

create table orderDetails(
	orderDetilsId int IDENTITY(1,1) PRIMARY KEY not null,

);