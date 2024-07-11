create procedure [dbo].[sp_InsertOwner]
@fio nvarchar(50),
@birthDate datetime,
@passport nchar(10),
@id int out
as 
insert into Owners (fio, dirthDate, passport)
values (@fio, @birthDate, @passport)

set @id=SCOPE_IDENTITY()
GO