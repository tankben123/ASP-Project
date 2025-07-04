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



drop table Attribute
create table Attribute(
	AttributeId smallint not null primary key identity(1, 1),
	AttributeName varchar(500) not null,
	AttributeNameVI nvarchar(500) not null
)

go

drop table product

Create table Product
(
	ProductId int not null primary key,
	CategoryId tinyint not null,
	Title nvarchar(4000) not null,
	UnitPrice decimal(10,2) not null,
	ImageUrl varchar(500) not null,
	ISBN nvarchar(500) null
)

drop table specification

create table Specification( 
	ProductId int not null,
	AttributeId int not null,
	AttributeValue nvarchar(500) null,
	primary key(ProductId, AttributeId)
)


go

--alter table Specification add constraint FK_specification_ProductId foreign key (ProductId);
--alter table Specification add constraint FK_specification_ProductId foreign key (ProductId);


create table BookUrl
(
	Id varchar(40) not null primary key
)