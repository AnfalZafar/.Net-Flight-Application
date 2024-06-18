create database flight; 
use flight;

create table role(

role_id int primary key identity(1,1),
role_name varchar(255) unique

)
select * from users;
Delete from users Where users_id = 3012;
create table users(

users_id int primary key identity(1,1),
users_name varchar(255),
users_email varchar(255) unique,
users_password varchar(255),
role_id int

)

alter table users add foreign key(role_id) references role(role_id);

create table flightss(

f_id int primary key identity(1,1),
f_name varchar(255)

)

drop table schedule;

create table routess(

R_id int primary key identity(1,1),
R_from varchar(255),
R_to varchar(255)

)

select * from schedule;

create table schedule(

shedule_id  int primary key identity(1,1),
flight_id  int ,
Routess_id  int , 
Departual DATETIME DEFAULT CURRENT_TIMESTAMP,
Arraval DATETIME DEFAULT CURRENT_TIMESTAMP,
price varchar(255)

);

alter table schedule add foreign key(flight_id) references flightss(f_id);
alter table schedule add foreign key(Routess_id) references routess(R_id);

create table special_sets(

special_id  int primary key identity(1,1),
flight_id  int ,
Routess_id  int , 
s_Departual DATETIME DEFAULT CURRENT_TIMESTAMP,
s_Arraval DATETIME DEFAULT CURRENT_TIMESTAMP,
s_price varchar(255)

);
select * from special_sets;
alter table special_sets add foreign key(flight_id) references flightss(f_id);
alter table special_sets add foreign key(Routess_id) references routess(R_id);
create table class(

class_id int primary key identity(1,1),
class_name varchar(255),
class_price varchar(255)

);

drop table about;
ALTER TABLE chooses DROP COLUMN c_title;
create table about(

about_id int primary key identity(1,1),
about_title varchar(255),
about_name varchar(255),
about_description varchar(max),
about_img varchar(max)
);
create table contact(

contact_id int primary key identity(1,1),
contact_name varchar(255),
contact_subject varchar(255),
contact_email varchar(max),
contact_message varchar(max)
);
select * from contact;
Delete from orders Where o_id = 1;
drop table contact;

create table chooses(
c_id int primary key identity(1,1),
c_name varchar(255),
c_description varchar(max)

);


create table feedback(

f_id int primary key identity(1,1),
f_name varchar(255),
f_email varchar(255),
f_phone varchar(255),
f_address varchar(255),
f_feedback varchar(max)
);


create table flight_detail(
flight_id int primary key identity(1,1),
flight_detail_name varchar(255),
flight_description varchar(max),
shedule_id int,
special_id int
);
drop table flight_detail;
alter table flight_detail add foreign key(shedule_id) references schedule(shedule_id);
alter table flight_detail add foreign key(special_id) references special_sets(special_id);

create table orders(

o_id int primary key identity(1,1),
users_name varchar(255),
users_email varchar(255),
users_id varchar(255),
flight_sets varchar(255),
flight_name varchar(255),
flight_to varchar(255),
flight_from varchar(255),
total_price varchar(255),
amount_of_flights varchar(255)

);

drop table orders;
select * from orders;
