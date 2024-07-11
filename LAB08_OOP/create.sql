drop table Owners

CREATE TABLE [dbo].[Owners] (
--id int NOT NULL,
fio NVARCHAR (50) NOT NULL,
birthDate DATETIME NOT NULL,
passport NCHAR (15) NOT NULL,
PRIMARY KEY CLUSTERED ([FIO] ASC)
);

CREATE TABLE [dbo].[Account] (
[id] INT IDENTITY (11000, 1) NOT NULL,
[fio] NVARCHAR (50) NOT NULL,
[accountType] NVARCHAR (50) NOT NULL,
[sendDate] DATETIME NULL,
[startBalance] INT NULL,
[wallet] NVARCHAR (10) NULL,
CONSTRAINT [PK__Personal__3214EC071237FB30] PRIMARY KEY CLUSTERED ([Id] ASC),
CONSTRAINT [FK__PersonalBil__FIO__267ABA7A] FOREIGN KEY ([FIO]) REFERENCES [dbo].[Owners] ([FIO])
);

drop table Account

use lab8oop

CREATE TABLE [dbo].[Owners] (
    [id] INT IDENTITY (1, 1) NOT NULL,
    [fio] NVARCHAR (50) NOT NULL,
    [birthDate] DATETIME NOT NULL,
    [passport] NCHAR (15) NOT NULL,
	 [ImageData] NVARCHAR(255) NULL,
    CONSTRAINT [PK__Owners__3214EC071237FB30] PRIMARY KEY CLUSTERED ([Id] ASC)
);

drop table owners

CREATE TABLE [dbo].[Account] (
    [id] INT IDENTITY (11000, 1) NOT NULL,
    [ownerId] INT NOT NULL,
	[fio] NVARCHAR (50) NOT NULL,
    [accountType] NVARCHAR (50) NOT NULL,
    [sendDate] DATETIME NULL,
    [startBalance] INT NULL,
    [wallet] NVARCHAR (10) NULL,
    CONSTRAINT [PK__Account__3214EC071237FB30] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK__Account__OwnerId__267ABA7A] FOREIGN KEY ([OwnerId]) REFERENCES [dbo].[Owners] ([Id])
);

drop table Account

SELECT TOP 1 id
FROM Owners
ORDER BY id DESC;