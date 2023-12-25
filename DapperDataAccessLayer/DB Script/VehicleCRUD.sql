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

--UPDATE--
create procedure VehicleInfoUpdate
(@id bigint ,@Name varchar(100),@VehicleNumber bigint,@RCNumber nvarchar(100),@OwnerPhNo bigint,@PurchaseDate datetime2(7))
as
begin
update VehicleInfo set Name=@Name,VehicleNumber=@Vehiclenumber,RCNumber=@RCNumber,OwnerPhNo=@OwnerPhNo,PurchaseDate=@PurchaseDate where Id=@Id
end

exec VehicleInfoUpdate 2 ,'TVS',21,'TN57X6789',6369176269,'09-12-2023'
select * from VehicleInfo
---DELETE---
create procedure VehicleInfoDelete
(@id bigint)
as
begin
delete from VehicleInfo where Id=@Id
end
exec VehicleInfoDelete 2

-- READ NUMBER---

create procedure ReadVehicleInfo
as
begin
Select * from VehicleInfo
end
