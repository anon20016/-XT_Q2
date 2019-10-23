create table Usertable(
	Id int IDENTITY(1,1) PRIMARY KEY, 
	user_login nvarchar(20),
	user_password_hash nvarchar(20),

	first_name nvarchar(20),
	second_name nvarchar(20),

	email nvarchar(20),

	user_class int,

	registration_date datetime,
	
	image_id nvarchar(100),
)

create table Roles(
	Id int IDENTITY(1,1) PRIMARY KEY, 
	Role_Name varchar(20),
	Discription varchar(200)
)


create table UserInRoles(
	id_user int,
	id_role int,

	FOREIGN KEY (id_user) REFERENCES Usertable(Id),
	FOREIGN KEY (id_role) REFERENCES Roles(Id)
)

drop table usertable

Insert into Roles(Role_Name, Discription)
values ('Admin', 'main administrator'), ('Moderator', 'moderator'), ('User', 'normal user')