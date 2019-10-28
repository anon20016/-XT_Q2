
CREATE PROCEDURE AddWFile
	@name nvarchar(100),
	@path nvarchar(400),	
	@owner nvarchar(30), 
	@ext nvarchar(50),
	@protected nvarchar(30),
	@visible int,
	@add_date  nvarchar(20),
	@change_date  nvarchar(20),
	@tags  nvarchar(300),
	@Id int OUTPUT
AS
BEGIN
	insert into Filestable(wfile_name, wfile_path, wfile_owner, wfile_extention, protected, visible, add_date, change_date, tags)
	values (@name, @path, @owner, @ext, @protected, @visible, @add_date, @change_date, @tags)

	Set @Id = @@IDENTITY;
END
GO

CREATE PROCEDURE ChangeFilePath
	@Id int,
	@new_path nvarchar(400)
AS
BEGIN
	update Filestable	
		set wfile_path = @new_path
		where Id = @Id
END
GO

CREATE PROCEDURE DeleteFileById
	@Id int
AS
BEGIN
	delete from Filestable where Id = @Id
END
GO

CREATE PROCEDURE FindFileById
	@Id int
AS
BEGIN
	select * from Filestable where Id = @Id
END
GO

CREATE PROCEDURE FindFileByPath
	@path nvarchar(400)
AS
BEGIN
	select * from Filestable where wfile_path = @path
END
GO

CREATE PROCEDURE RenameFileByID
	@Id int,
	@name nvarchar(100)
AS
BEGIN
	update Filestable	
		set wfile_name = @name
		where Id = @Id
END
GO

CREATE PROCEDURE GetAllFilesForUser
	@username nvarchar(30)
AS
BEGIN
	select * from Filestable where wfile_owner = @username
END
GO

CREATE PROCEDURE GetVisibleFilesForUser
	@username nvarchar(30)
AS
BEGIN
	select * from Filestable where wfile_owner = @username and visible = 1
END
GO




