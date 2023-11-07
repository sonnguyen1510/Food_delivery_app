
CREATE DATABASE [MoneyManager]
 ON  PRIMARY 
( NAME = N'MoneyManager', FILENAME = N'C:\Users\NguyenXuanSon\Documents\GitHub\Food_delivery_app\Database\MoneyManagerDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MoneyManager_log', FILENAME = N'C:\Users\NguyenXuanSon\Documents\GitHub\Food_delivery_app\Database\MoneyManagerDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
	
create table UserTransaction (
	Id numeric IDENTITY(1,1) primary key,
	Title Varchar(55),
    TransType varchar(55),
	TransIcon varchar(55),
	CreTime Time,
	CreDate Date,
	Amount numeric(10,2),
	[UserId] Varchar(55),
	[status] bit
)

create table [User] (
	Id numeric IDENTITY(1,1) primary key,
	Fullname Varchar (55),
	Username varchar(55),
	[Password] varchar(55),
	[Email] varchar (55),
	[Phone] varchar (55),
	[status] bit
)
alter table [user] drop constraint UserTrans

drop table [User]
drop table [UserTransaction]

alter table [UserTransaction] add constraint UserTrans foreign key (UserId) references [User](Id)

INSERT INTO [User] (Id, Fullname, Username, [Password], [Email], [Phone], [status])
VALUES ('U123456', 'John Doe', 'johndoe123', '12345', 'john.doe@email.com', '123-456-7890', 1);

INSERT INTO [User] (Id, Fullname, Username, [Password], [Email], [Phone], [status])
VALUES ('U789012', 'Jane Smith', 'janesmith789', '12345', 'jane.smith@email.com', '987-654-3210', 0);


INSERT INTO UserTransaction
VALUES ('01','Food&Dring','expense','Food&Dring','00:00:00.0000000','2021-06-12',500,'U123456',1);

INSERT INTO UserTransaction
VALUES ('02','Bussiness','income','Bussiness','10:10:00.0000000','2021-06-11',1000,'U123456',1);

INSERT INTO UserTransaction
VALUES ('03','Shopping','expense','Shopping','20:30:00.0000000','2021-06-10',200,'U123456',1);

INSERT INTO UserTransaction
VALUES ('04','Salary','income','Salary','11:25:00.0000000','2021-06-09',3000,'U123456',1);

INSERT INTO UserTransaction
VALUES ('05','Electricity bill','expense','Bill','09:00:00.0000000','2021-06-08',1600,'U123456',1);

INSERT INTO UserTransaction
VALUES ('06','Food&Dring','expense','Food&Dring','09:24:00.0000000','2021-05-02',800,'U789012',1);
INSERT INTO UserTransaction
VALUES ('07','Salary','income','Salary','12:00:00.0000000','2021-05-12',1600,'U789012',1);

select * from UserTransaction