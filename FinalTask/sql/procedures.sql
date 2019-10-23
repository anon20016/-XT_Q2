
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE AddUser
	@login nvarchar(20),
	@pass_hash nvarchar(20),	
	@class int, 
	@Id int OUTPUT
AS
BEGIN
	insert into usertable (user_login, user_password_hash, user_class)
	values (@login, @pass_hash, @class)

	Set @Id = @@IDENTITY;
END
GO

CREATE PROCEDURE RegisterUser
	@login nvarchar(20),
	@pass_hash nvarchar(20),	
	@class int,
	@email nvarchar(20),	
	@Register_date nvarchar(20)
AS
BEGIN
	insert into usertable (user_login, user_password_hash, user_class, email, registration_date)
	values (@login, @pass_hash, @class, @email, @Register_date)
	
END
GO


CREATE PROCEDURE DeleteById
	@Id int
AS
BEGIN
	delete from usertable where Id = @Id;
END
GO

CREATE PROCEDURE GetAll
AS
BEGIN
	select * from usertable
END
GO

CREATE PROCEDURE FindById
	@Id int
AS
BEGIN
	select * from usertable where Id = @Id;
END
GO

CREATE PROCEDURE FindByLogin
	@Login varchar(20)
AS
BEGIN
	select * from usertable where user_login = @Login;
END
GO

CREATE PROCEDURE CheckClassId
	@Id int,
	@Class int
AS
BEGIN
	select * from usertable where (Id = @Id AND user_class = @Class)
END
GO

CREATE PROCEDURE GetAllUsersForClass
	@Class int
AS
BEGIN
	select * from usertable where user_class = @Class
END
GO

CREATE PROCEDURE CheckPassword
	@Login nvarchar(20),
	@Pass nvarchar(20)
AS
BEGIN
	IF EXISTS(select * from usertable where (user_login = @Login AND user_password_hash = @Pass))
	Begin
	return 1
	end else
	return 0
END
GO

CREATE PROCEDURE CanRegister
	@Login nvarchar(20)
AS
BEGIN
	IF EXISTS(select * from usertable where user_login = @Login)
	Begin
	return 1
	end else
	return 0
END
GO

CREATE PROCEDURE EditUser
	@Login nvarchar(20),
	@First_name  nvarchar(20),
	@second_name nvarchar(20),
	@email nvarchar(20),
	@password nvarchar(20)
AS
BEGIN	
		update Usertable	
		set first_name = @First_name, second_name = @second_name, email = @email, user_password_hash = @password
		where user_login = @Login
END
GO

