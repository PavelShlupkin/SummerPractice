

CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[DateOfBrith] [date] NULL,
	[Login] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL
	)
	drop table [dbo].[Users]

	CREATE PROCEDURE AddUser
	@ID int OUTPUT,
	@Name varchar(40),
	@DateOfBrith DATETIME,
	@Login varchar(50),
	@Password varchar(30)
	AS 
	insert into Users ([Name],[DateOfBrith],[Login],[Password])
	values (@Name,@DateOfBrith,@Login,@Password)
	drop procedure AddUser

	insert into Users ([Name],[DateOfBrith],[Login],[Password])
	values ('Pavel','1998-1-1 00:00:00','pas','pas')

	CREATE PROCEDURE findForLogin 
	@Login varchar(20)
	as SELECT ID from Users where Login = @Login

	CREATE PROCEDURE authorizationUser
	@Login varchar(20),
	@Password varchar(20)
	AS SELECT ID from Users where Login = @Login and Password = @Password

	CREATE PROCEDURE getUserById
	@ID int
	as
	SELECT *from Users where ID = @ID

	CREATE PROCEDURE editName
	@ID int,
	@Name varchar(100)
	AS update Users set Name = @Name where ID = @ID 

	CREATE PROCEDURE editPasswordUser
	@ID int,
	@Password varchar(100)
	AS update Users set Password = @Password where ID = @ID 


	CREATE PROCEDURE getAnswardsByIDUser
	@ID int
	as
	SELECT *FROM Answards where ID_user = @ID
	drop procedure getAnswardsByIDUser

	CREATE TABLE [dbo].[Answards](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ID_user] [int] NOT NULL,
	[Title] [varchar](50) NOT NULL)

	drop table [dbo].[Answards]

	CREATE PROCEDURE AddAnsward
	@ID_user int,
	@Title varchar(50)
	AS INSERT INTO Answards([ID_user],[Title])
	VALUES (@ID_user,@Title)
	drop procedure AddAnsward
	
	insert into Answards([ID_user],[Title])
	values ('1','Чемпион')


	CREATE PROCEDURE findAnsward
	@ID int,
	@Name varchar(50) AS
	SELECT ID FROM Users WHERE login LIKE @Name+'%'
	exec findTitle 'Чемпион'
	drop procedure findAnsward

	CREATE PROCEDURE deleteAnsward
	@ID int 
	as delete Answards where ID = @ID

	CREATE PROCEDURE UpdateAnsward
	@ID int,
	@Title varchar(250)
	as
	Update Answards SET Title = @Title WHERE ID = @ID
	drop procedure UpdateAnsward
