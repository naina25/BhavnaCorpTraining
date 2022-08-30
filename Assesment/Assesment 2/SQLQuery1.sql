create database Hospital

use Hospital

create table Doctors_details(id int primary key, fullname nvarchar(20), phone numeric(10,0), age int, degree nvarchar(40), salary numeric(20,0), email nvarchar(50));

create table Patients_details(id int primary key, fullname nvarchar(20), phone numeric(10,0), age int, pat_address nvarchar(40), isVaccinated nvarchar(10), pat_department nvarchar(20));

create table Beds_details(bed_number int primary key, ward nvarchar(10), patient_id int, constraint fk_patID foreign key (patient_id) references Patients_details (id)); 

-- Creating proedure for/and inserting values into doctors table
create procedure sp_insertDoctor
(
@id int, 
@fullname nvarchar(20), 
@phone numeric(10,0), 
@age int, 
@degree nvarchar(40), 
@salary numeric(20,0), 
@email nvarchar(50)
)
as
begin
insert into Doctors_details(id, fullname,phone,age,degree,salary,email) 
values (@id, @fullname, @phone, @age, @degree, @salary, @email)

end

--executing the doctor's stored procedure(inserting the values using stored procedures)
exec sp_insertDoctor
@id=101, 
@fullname = "Dr. Nishtha Agarwal", 
@phone = 8006755422, 
@age = 29, 
@degree = "MBBS", 
@salary = 63445, 
@email = "nishtha@gmail.com"

exec sp_insertDoctor
@id=102, 
@fullname = "Dr. Neha Singh", 
@phone = 8006734546, 
@age = 39, 
@degree = "MBBS", 
@salary = 63600, 
@email = "nehaa@gmail.com"

exec sp_insertDoctor
@id=103, 
@fullname = "Dr. Tanisha Agarwal", 
@phone = 8006755431, 
@age = 52, 
@degree = "MBBS/MD", 
@salary = 83432, 
@email = "tanisha@gmail.com"

exec sp_insertDoctor
@id=104, 
@fullname = "Dr. Naina Upadhyay", 
@phone = 8006752342, 
@age = 49, 
@degree = "MBBS-MD", 
@salary = 77524, 
@email = "naina@gmail.com"

exec sp_insertDoctor
@id=105, 
@fullname = "Dr. Avinash Dubey", 
@phone = 8006755325, 
@age = 45, 
@degree = "MBBS", 
@salary = 76653, 
@email = "avinaash@gmail.com"

select * from Doctors_details;

--creating stored procedure for patients details
create procedure sp_insertPatients
(
@id int, 
@fullname nvarchar(20), 
@phone numeric(10,0), 
@age int, 
@pat_address nvarchar(40), 
@isVaccinated nvarchar(10), 
@pat_department nvarchar(20)
)
as
begin
insert into Patients_details(id, fullname,phone,age,pat_address,isVaccinated,pat_department) 
values (@id, @fullname, @phone, @age, @pat_address, @isVaccinated, @pat_department)

end

--Inserting values to patients table
exec sp_insertPatients
@id=201, 
@fullname = "Anjali Saini", 
@phone = 8006755342, 
@age = 20, 
@pat_address = "Noida", 
@isVaccinated = "yes", 
@pat_department = "General medication"

exec sp_insertPatients
@id=202, 
@fullname = "Kunal Singh", 
@phone = 8006755332, 
@age = 43, 
@pat_address = "Greater Noida", 
@isVaccinated = "yes", 
@pat_department = "ICU"

exec sp_insertPatients
@id=203, 
@fullname = "Anirudh Kumar", 
@phone = 8006755763, 
@age = 40, 
@pat_address = "Delhi", 
@isVaccinated = "no", 
@pat_department = "Casualty Department"

exec sp_insertPatients
@id=204, 
@fullname = "Arun Patel", 
@phone = 8006755343, 
@age = 30, 
@pat_address = "Noida", 
@isVaccinated = "yes", 
@pat_department = "General medication"

exec sp_insertPatients
@id=205, 
@fullname = "Vishal Upadhyay", 
@phone = 8006755349, 
@age = 50, 
@pat_address = "Noida", 
@isVaccinated = "yes", 
@pat_department = "Cardiology department"

select * from Patients_details;

--creating stored procedure for Beds details
create procedure sp_insertBeds
(
@bed_number int, 
@ward nvarchar(10), 
@patient_id int
)
as
begin
insert into Beds_details(bed_number, ward,patient_id) 
values (@bed_number, @ward,@patient_id)

end

--Inserting values to beds table
exec sp_insertBeds
@bed_number=102, 
@ward = "A", 
@patient_id = 201

exec sp_insertBeds
@bed_number=103, 
@ward = "B", 
@patient_id = 202

exec sp_insertBeds
@bed_number=101, 
@ward = "C", 
@patient_id = 203

exec sp_insertBeds
@bed_number=104, 
@ward = "A", 
@patient_id = 204

exec sp_insertBeds
@bed_number=105, 
@ward = "B", 
@patient_id = 205

select * from Beds_details;

---- Triggers for doctors, patients and beds table-----

create table Doctors_log(logID int primary key identity, docID int, operation nvarchar(20), updateDate Datetime);

select * from Doctors_log

-- Creating trigger for inserting into Doctors_details table

create trigger DoctorInsertTrigger
on Doctors_details
for insert
as
insert into Doctors_log(docID, operation, updateDate)
select id, 'Data Inserted', GETDATE() from inserted

create table Patients_log(logID int primary key identity, patID int, operation nvarchar(20), updateDate Datetime);
select * from Patients_log

-- Creating trigger for inserting into Patients_deatils table
create trigger PatientInsertTrigger
on Patients_details
for insert
as
insert into Patients_log(patID, operation, updateDate)
select id, 'Data Inserted', GETDATE() from inserted

create table Bed_logs(logID int primary key identity, bedNo int, operation nvarchar(20), updateDate Datetime);
select * from Bed_logs

create trigger BedInsertTrigger
on Beds_details
for insert
as
insert into Bed_logs(bedNo, operation, updateDate)
select bed_number, 'Data Inserted', GETDATE() from inserted