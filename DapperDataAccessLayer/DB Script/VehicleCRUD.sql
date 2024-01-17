--VECHICLE INFO--
-----STORED PROCEDURE-----
--INSERT--
CREATE TABLE [VehicleInfo]
(
[Id] [bigint] primary key identity(1,1) not null,
[Name] [varchar](50) NOT NULL,
[VehicleNumber] [int] NOT NULL,
[RCNumber] nvarchar (100) NOT NULL,
[OwnerPhNo] [bigint] NOT NULL,
[PurchaseDate] [datetime2](7) NOT NULL
)
drop table VehicleInfo
select * from VehicleInfo

go

--STORED PROCEDURE--

create procedure VehicleInfoInsert


(@Name varchar(100),@VehicleNumber bigint,@RCNumber nvarchar(100),@OwnerPhNo bigint,@PurchaseDate datetime2(7))
as
begin

insert into VehicleInfo values (@Name,@VehicleNumber,@RCNumber,@OwnerPhNo,@PurchaseDate)


end
exec VehicleInfoInsert'Activa',12,'TN57A2633',9865457334,'11-08-2023'
exec VehicleInfoInsert'Scooty',13,'TN57A2623',9865454434,'10-10-2023'
exec VehicleInfoInsert 'Jupiter',10,'TN57Y5467',9856454434,'09-27-2023'
select * from VehicleInfo
drop procedure VehicleInfoInsert

go
--UPDATE--
create procedure VehicleInfoUpdate
(@id bigint ,@Name varchar(100),@VehicleNumber bigint,@RCNumber nvarchar(100),@OwnerPhNo bigint,@PurchaseDate datetime2(7))
as
begin
update VehicleInfo set Name=@Name,VehicleNumber=@Vehiclenumber,RCNumber=@RCNumber,OwnerPhNo=@OwnerPhNo,PurchaseDate=@PurchaseDate where Id=@Id
end

exec VehicleInfoUpdate 2 ,'TVS',21,'TN57X6789',6369176269,'09-12-2023'
select * from VehicleInfo
go
---DELETE---
create procedure VehicleInfoDelete
(@id bigint)
as
begin
delete from VehicleInfo where Id=@Id
end
exec VehicleInfoDelete 2

go
-- READ NUMBER---

create procedure ReadVehicleInfo
as
begin
Select * from VehicleInfo
end

--LOCATION--
Create table [Location]
(
[LocationId][bigint] primary key identity(1,1) not null,
[LocationName] [nvarchar](50) Not Null
)

Select * from location
drop table Locations

create procedure LocationDetail
(@LocationName nvarchar (50))
as
begin
insert into Location values (@LocationName)
end
drop procedure LocationDetail
exec LocationDetail 'Coimbatore'
exec LocationDetail 'Chennai'
exec LocationDetail 'Madurai'
exec LocationDetail 'Trichy'
exec LocationDetail 'Palani'
select * from Location

update Location set LocationName='Bangalore' Where LocationId=2

--REGISTRATION---
select * from Registration
truncate table Registration

Create Procedure Insertdata
(@UserName nvarchar(50),@Password nvarchar(50),@ConfirmPassword nvarchar(50))
as
begin
Insert into Registration values(@UserName,@Password,@ConfirmPassword)
end

drop procedure Insertdata

exec InsertData 'Anu','Anu_123','Anu_123'
exec InsertData 'Mithra','Mi_123','Mi_123'
exec InsertData 'Babu','Ba_432','Ba_432'
exec InsertData 'Mala','Ma@123','Ma@123'

create procedure VerifyPassword
(@UserName nvarchar(50),@Password nvarchar(50))
as
begin
select* from Registration where UserName=@UserName and Password=@Password
end

drop procedure VerifyPassword

exec VerifyPassword 'Mithra','Mi_123'

create procedure GetallReg
as
begin
Select * from Registration
end
drop procedure GetallReg

exec GetallReg

create procedure VerifyRegistration
(@UserName nvarchar(50),@Password nvarchar(50),@ConfirmPassword nvarchar(50))
as
begin
select * from Registration where UserName=@UserName or Password=@Password or ConfirmPassword=@ConfirmPassword
end
drop procedure VerifyRegistration

exec VerifyRegistration 'Anu','Anu_123','Anu_123'
exec VerifyRegistration 'Mithra','Mi_123','Mi_123'
exec VerifyRegistration 'Babu','Ba_432','Ba_432'

---FIND BY NUMBER---
create procedure FindByNumber
@RegistrationId bigint
as
begin
select * from Registration where RegistrationId = @RegistrationId
end
exec FindByNumber 3
--UPDATE--
create procedure UpdateReg
(@RegistrationId bigint,@UserName nvarchar(50),@Password nvarchar(50),@ConfirmPassword nvarchar(50))
as
begin
update Registration set UserName=@UserName,Password=@Password, ConfirmPassword=@ConfirmPassword where RegistrationId=@RegistrationId
end

exec UpdateReg 3,Suganthi,Su@123,Su@123
select * from Registration

create procedure DeleteRegistration
(@RegistrationId bigint)
as
begin
delete from Registration Where RegistrationId=@RegistrationId
end

exec DeleteRegistration 9
select * from registration

Create Procedure FindbyId
(@RegistrationId bigint)
as
begin
Select * from Registration where RegistrationId=@RegistrationId
end

exec FindbyId 1
