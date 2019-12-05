create table Usertable(
	Id int IDENTITY(1,1) PRIMARY KEY, 
	user_login nvarchar(30),
	user_password_hash nvarchar(50),

	first_name nvarchar(30),
	second_name nvarchar(30),

	email nvarchar(30),

	user_class int,

	registration_date datetime,
	
	image_id nvarchar(100),
)

create table Roles(
	Id int IDENTITY(1,1) PRIMARY KEY, 
	Role_Name varchar(30),
	Discription varchar(200)
)


create table UserInRoles(
	id_user int,
	id_role int,

	FOREIGN KEY (id_user) REFERENCES Usertable(Id),
	FOREIGN KEY (id_role) REFERENCES Roles(Id)
)


Insert into Roles(Role_Name, Discription)
values ('Admin', 'main administrator'), ('Moderator', 'moderator'), ('User', 'normal user')


create table Filestable(
	Id int IDENTITY(1,1) PRIMARY KEY, 
	wfile_name nvarchar(100),
	wfile_path nvarchar(400),

	wfile_extention nvarchar(50),	

	wfile_owner nvarchar(30),
	protected nvarchar(30),
	visible int,

	add_date datetime,
	change_date datetime,	
	tags nvarchar(300)
)
