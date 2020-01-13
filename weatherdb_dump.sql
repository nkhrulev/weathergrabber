use weatherdb;

drop table if exists cities;

create table cities (
  id int auto_increment primary key not null,
  name varchar(255) not null,
  outerid int not null,
  url varchar(255) not null
);

drop table if exists weather;

create table weather (
  id int auto_increment primary key not null,
  data json not null,
  day datetime not null,
  importdate timestamp not null default current_timestamp on update current_timestamp,
  cityouterid int not null,
  cityname varchar(255) not null
);

drop table if exists weatherbyhours;

create table weatherbyhours (
  id int auto_increment primary key not null,
  weatherid int not null,
  humidity float not null,
  temperature float not null,
  time time not null,
  wind varchar(255) null,
  iconsvg varchar(8000) not null
);