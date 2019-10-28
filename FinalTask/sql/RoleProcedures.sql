
CREATE PROCEDURE FindRoleById
	@Id int
AS
BEGIN
	select * from Roles where Id = @Id;
END
GO

CREATE PROCEDURE FindRoleByLogin
	@Name varchar(30)
AS
BEGIN
	select * from Roles where Role_Name = @Name;
END
GO

CREATE PROCEDURE IsUserInRole
	@user_name nvarchar(30),
	@role_name nvarchar(30)
AS
BEGIN
	IF Exists(select * from UserInRoles join Usertable On UserInRoles.id_user = Usertable.Id join Roles On Roles.Id = UserInRoles.id_role where user_login = @user_name AND Role_Name = @role_name)
	return 1
	else
	return 0
END
GO

CREATE PROCEDURE GetUsersInRole
	@role_name nvarchar(30)
AS
BEGIN
	select user_login from Usertable Join UserInRoles ON Usertable.Id = UserInRoles.id_user Join Roles ON Roles.id = UserInRoles.id_role where Role_Name = @role_name
END
GO

CREATE PROCEDURE GetRolesForUser
	@user_name nvarchar(30)
AS
BEGIN
	select Role_Name from Usertable Join UserInRoles ON Usertable.Id = UserInRoles.id_user Join Roles ON Roles.id = UserInRoles.id_role where user_login = @user_name
END
GO

CREATE PROCEDURE CreateRole
	@Name nvarchar(30)
AS
BEGIN
	insert into Roles(Role_Name)
	values (@Name)	
END
GO

CREATE PROCEDURE DeleteRole
	@Name nvarchar(30)
AS
BEGIN
	delete from Roles where Role_Name = @Name
END
GO

CREATE PROCEDURE GetAllRoles
AS
BEGIN
	select Role_Name from Roles
END
GO

CREATE PROCEDURE RoleExists
	@Name nvarchar(30)
AS
BEGIN
	IF Exists(select * from Roles where Role_Name = @Name)
	return 1
	else
	return 0
END
GO

CREATE PROCEDURE AddUserToRole
	@User_name nvarchar(30),		
	@Role_name nvarchar(30)
AS
BEGIN	
	declare @f int;
	declare @t int;
	select @f = Id from Usertable where user_login = @User_name;
	select @t = Id from Roles where Role_Name = @Role_name;

	Insert into UserInRoles (id_user, id_role)
	values(@f, @t)
END
GO


CREATE PROCEDURE RemoveUserFromRole
	@User_name nvarchar(30),		
	@Role_name nvarchar(30)
AS
BEGIN	
	declare @f int;
	declare @t int;
	select @f = Id from Usertable where user_login = @User_name;
	select @t = Id from Roles where Role_Name = @Role_name;

	Delete from UserInRoles where id_user = @f and id_role = @t
END
GO
