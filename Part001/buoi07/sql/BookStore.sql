create database BookStore

create table Category(
	CategoryId tinyint primary key identity(1, 1),
	CategoryName nvarchar(64) not null
)

go

set identity_insert Category on
insert into Category(CategoryId, CategoryName)
values(1, N'Sách')

set identity_insert Category off



create table Attribute(
	AttributeId smallint not null primary key,
	AttributeName varchar(32) not null,
	AttributeNameVI nvarchar(64) not null
)

go

--drop table product

Create table Product
(
	ProductId int not null primary key,
	CategoryId tinyint not null,
	Title nvarchar(256) not null,
	UnitPrice decimal(10,2) not null,
	ImageUrl varchar(32) not null,
	ISBN nvarchar(500) null
)

--drop table specification

create table Specification( 
	ProductId int not null,
	AttributeId smallint not null,
	AttributeValue nvarchar(32) not null,
	primary key(ProductId, AttributeId)
)

--alter table Specification add constraint FK_specification_ProductId foreign key (ProductId);
--alter table Specification add constraint FK_specification_ProductId foreign key (ProductId);


select *From Product