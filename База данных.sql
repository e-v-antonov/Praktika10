--set ansi_padding on
--go
--set quoted_identifier on
--go
--set ansi_nulls on
--go

--create database [Tetris]
--go

--use [Tetris]
--go

--create table [dbo].[User_Login]
--(
--	[id_user] [int] not null identity (1,1),
--	[login] [varchar] (16) not null,
--	[password] [varchar] (16) not null

--	constraint [PK_User] primary key clustered 
--	([id_user] ASC) on [PRIMARY],
--	constraint [UQ_Login] unique ([login]),
--	constraint [UQ_Password] unique ([password]),
--	constraint [CH_Login] check (len([login]) between 4 and 16),
--	constraint [CH_Password] check (len([password]) between 4 and 16)
--)
--go

--create table [dbo].[Result]
--(
--	[id_result] [int] not null identity (1, 1),
--	[points] [int] not null

--	constraint [PK_Result] primary key clustered
--	([id_result] ASC) on [PRIMARY],
--	constraint [UQ_Points] unique ([points])
--)
--go

--create table [dbo].[Relation]
--(
--	[id_relation] [int] not null identity (1, 1),
--	[user_id] [int] not null,
--	[result_id] [int] not null

--	constraint [PK_Relation] primary key clustered
--	([id_relation] ASC) on [PRIMARY],
--	constraint [FK_User] foreign key ([user_id])
--	references [dbo].[User_Login] ([id_user]),
--	constraint [FK_Result] foreign key ([result_id])
--	references [dbo].[Result] ([id_result])
--)


--insert into [dbo].[User_Login] ([login], [password]) values 
--	('admin', 'admin'),
--	('user1', 'user1'),
--	('user2', 'user2')

--insert into [dbo].[Result] ([points]) values
--	(500),
--	(100), 
--	(0), 
--	(700),
--	(800)

--insert into [dbo].[Relation] ([user_id], [result_id]) values
--	(1, 1),
--	(1, 2),
--	(1, 3),
--	(1, 4),
--	(1, 5),
--	(2, 2),
--	(2, 5),
--	(2, 5),
--	(3, 1),
--	(3, 3),
--	(3, 2)

--create procedure dobavlenie_result  @point as int		-- процедура добавления в таблицу Амплуа
--as
--begin
--	insert into Tetris.dbo.Result (points) values (@point);
--end;
--go

--create procedure dobavlenie_user  @login as varchar (16), @password as varchar (16)		-- процедура добавления в таблицу Амплуа
--as
--begin
--	insert into Tetris.dbo.User_Login (login, password) values (@login, @password);
--end;
--go

--create procedure dobavlenie_relation @user as int, @points as int
--as
--begin
--	insert into Tetris.dbo.Relation (user_id, result_id) values (@user, @points)
--end;
--go

select  dbo.Result.points from dbo.Relation 
join dbo.User_Login on dbo.User_Login.id_user = dbo.Relation.user_id
join dbo.Result on dbo.Result.id_result = dbo.Relation.result_id where (dbo.User_Login.login = 'admin')