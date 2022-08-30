create database Bank;
use Bank;

---- Triggers for insertion updation deletion-----

create table Customers_log(logID int primary key identity, custId int, operation nvarchar(20), updateDate Datetime);

select * from Customers_log;

-- Creating trigger for inserting into CustomersDetails table

create trigger CustomerInsertTrigger
on CustomerDetails
for insert
as
insert into Customers_log(custId, operation, updateDate)
select CustId, 'Data Inserted', GETDATE() from inserted

-- Creating trigger for updating into CustomersDetails table
create trigger CustomerUpdateTrigger
on CustomerDetails
after update
as
insert into Customers_log(custId, operation, updateDate)
select CustId, 'Data Updated', GETDATE() from deleted


-- Creating trigger for deleting into CustomersDetails table

create trigger CustomerDeleteTrigger
on CustomerDetails
after delete
as
insert into Customers_log(custId, operation, updateDate)
select CustId, 'Data Deleted', GETDATE() from deleted