
CREATE DATABASE [MoneyManager]
 ON  PRIMARY 
( NAME = N'MoneyManager', FILENAME = N'C:\Users\NguyenXuanSon\Documents\GitHub\Food_delivery_app\Database\MoneyManagerDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MoneyManager_log', FILENAME = N'C:\Users\NguyenXuanSon\Documents\GitHub\Food_delivery_app\Database\MoneyManagerDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
	
create table UserTransaction (
	Id Varchar(55) primary key,
	Title Varchar(55),
    TransType varchar(55),
	TransIcon varchar(55),
	CreTime Time,
	CreDate Date,
	Amount numeric(10,2),
	[status] bit
)

create table [User] (
	Id Varchar(55) primary key,
	Fullname Varchar (55),
	Username varchar(55),
	[Password] varchar(55),
	[Email] varchar (55),
	[Phone] varchar (55),
	TransID Varchar (55),
	[status] bit
)
alter table [user] drop constraint UserTrans

drop table [User]
drop table [UserTransaction]

alter table [user] add constraint UserTrans foreign key (TransID) references UserTransaction(Id)

INSERT INTO UserTransaction
VALUES ('01','Food&Dring','expense','Food&Dring','00:00:00.0000000','2021-06-12',500,1);

INSERT INTO UserTransaction
VALUES ('02','Bussiness','income','Bussiness','10:10:00.0000000','2021-06-11',1000,1);

INSERT INTO UserTransaction
VALUES ('03','Shopping','expense','Shopping','20:30:00.0000000','2021-06-10',200,1);

INSERT INTO UserTransaction
VALUES ('04','Salary','income','Salary','11:25:00.0000000','2021-06-09',3000,1);

INSERT INTO UserTransaction
VALUES ('05','Electricity bill','expense','Bill','09:00:00.0000000','2021-06-08',1600,1);

drop table UserTransaction

select * from UserTransaction