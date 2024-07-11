create procedure Find_bill_By_Surname @srnm nvarchar(15)
as
begin
set @srnm = @srnm + '%'
SELECT Account.id, Account.fio, Owners.birthDate, Owners.passport, Account.wallet, Account.startBalance from 
Account inner join Owners on Account.fio = Owners.fio
where Account.fio like @srnm
end;

exec Find_bill_By_Surname @srnm='Бычковская';

create procedure  Find_bill_by_type @wallet nvarchar(15)
as
begin
set @wallet = @wallet + '%'
SELECT Account.id, Account.fio, Owners.birthDate, Owners.passport, Account.wallet, Account.startBalance from 
Account inner join Owners on Account.fio = Owners.fio
where Account.wallet like @wallet
end;

exec  Find_bill_by_type @wallet='USD';

create procedure Find_Surname @srnm nvarchar(15)
as
begin
set @srnm = @srnm + '%'
SELECT Account.id, Account.accountType, Account.sendDate, owners.fio, Owners.birthDate, Owners.passport, Account.wallet, Account.startBalance from 
Account inner join Owners on Account.ownerId = Owners.id
where Owners.fio like @srnm
end;

exec Find_Surname @srnm='Бычковская';

create procedure  Find_type @wallet nvarchar(15)
as
begin
set @wallet = @wallet + '%'
SELECT Account.id, Account.accountType, Account.sendDate, owners.fio, Owners.birthDate, Owners.passport, Account.wallet, Account.startBalance from 
Account inner join Owners on Account.ownerId = Owners.id
where Account.wallet like @wallet
end;

drop procedure  Find_Surname;

exec  Find_type @wallet='USD';
