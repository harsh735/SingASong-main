USE [master]
GO
/****** Object:  Database [SingASong]    Script Date: 05-02-2024 14:22:15 ******/
CREATE DATABASE [SingASong]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SingASong', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\SingASong.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SingASong_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\SingASong_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [SingASong] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SingASong].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SingASong] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SingASong] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SingASong] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SingASong] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SingASong] SET ARITHABORT OFF 
GO
ALTER DATABASE [SingASong] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SingASong] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SingASong] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SingASong] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SingASong] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SingASong] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SingASong] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SingASong] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SingASong] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SingASong] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SingASong] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SingASong] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SingASong] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SingASong] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SingASong] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SingASong] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SingASong] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SingASong] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SingASong] SET  MULTI_USER 
GO
ALTER DATABASE [SingASong] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SingASong] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SingASong] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SingASong] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SingASong] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SingASong] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [SingASong] SET QUERY_STORE = ON
GO
ALTER DATABASE [SingASong] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [SingASong]
GO
/****** Object:  Table [dbo].[Albums]    Script Date: 05-02-2024 14:22:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Albums](
	[AlbumID] [int] IDENTITY(1,1) NOT NULL,
	[AlbumName] [varchar](32) NOT NULL,
	[ArtistName] [varchar](50) NULL,
	[AlbumPrice] [decimal](5, 2) NULL,
	[AlbumRating] [decimal](3, 2) NULL,
	[AlbumCover] [varbinary](max) NULL,
	[AlbumGenre] [varchar](50) NULL,
 CONSTRAINT [PK_Albums] PRIMARY KEY CLUSTERED 
(
	[AlbumID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[artists]    Script Date: 05-02-2024 14:22:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[artists](
	[ArtistID] [int] NOT NULL,
	[NAME] [varchar](32) NOT NULL,
	[Image] [varbinary](max) NULL,
	[dob] [date] NULL,
 CONSTRAINT [PK_artists] PRIMARY KEY CLUSTERED 
(
	[ArtistID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Carts]    Script Date: 05-02-2024 14:22:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carts](
	[CartID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[AlbumID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[Price] [int] NULL,
 CONSTRAINT [PK__Carts__51BCD797CC9749C4] PRIMARY KEY CLUSTERED 
(
	[CartID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[payment_methods]    Script Date: 05-02-2024 14:22:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[payment_methods](
	[paymentmethodID] [int] NOT NULL,
	[NAME] [nchar](32) NOT NULL,
 CONSTRAINT [PK_payment_methods] PRIMARY KEY CLUSTERED 
(
	[paymentmethodID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Providers]    Script Date: 05-02-2024 14:22:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Providers](
	[ProviderID] [int] NOT NULL,
	[Name] [varchar](32) NOT NULL,
	[Established] [date] NULL,
	[headquarter] [int] NULL,
 CONSTRAINT [PK_Providers] PRIMARY KEY CLUSTERED 
(
	[ProviderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Purchases]    Script Date: 05-02-2024 14:22:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Purchases](
	[AlbumID] [int] NULL,
	[AlbumName] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 05-02-2024 14:22:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](32) NOT NULL,
	[UserEmail] [varchar](48) NOT NULL,
	[UserPhoneNo] [varchar](50) NULL,
	[UserAddress] [varchar](50) NULL,
	[UserPassword] [varchar](50) NOT NULL,
	[IsAdmin] [bit] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Carts]  WITH CHECK ADD  CONSTRAINT [FK_Carts_Albums] FOREIGN KEY([AlbumID])
REFERENCES [dbo].[Albums] ([AlbumID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Carts] CHECK CONSTRAINT [FK_Carts_Albums]
GO
ALTER TABLE [dbo].[Carts]  WITH CHECK ADD  CONSTRAINT [FK_Carts_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([UserID])
GO
ALTER TABLE [dbo].[Carts] CHECK CONSTRAINT [FK_Carts_Users]
GO
/****** Object:  StoredProcedure [dbo].[AddAlbum]    Script Date: 05-02-2024 14:22:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddAlbum]
    @AlbumName NVARCHAR(255),
    @ArtistName NVARCHAR(255),
    @AlbumPrice DECIMAL(18, 2),
    @AlbumRating DECIMAL(3, 2),
    @AlbumGenre NVARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Albums (AlbumName, ArtistName, AlbumPrice, AlbumRating, AlbumGenre)
    VALUES (@AlbumName, @ArtistName,@AlbumPrice, @AlbumRating, @AlbumGenre);

    SELECT SCOPE_IDENTITY() AS AlbumID;
END;
GO
/****** Object:  StoredProcedure [dbo].[AddToCart]    Script Date: 05-02-2024 14:22:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[AddToCart]
    @UserID INT,
    @AlbumID INT,
	@Quantity INT
AS
BEGIN
    INSERT INTO Carts (UserID, AlbumID,Quantity)
    VALUES (@UserID, @AlbumID,1);
END;
GO
/****** Object:  StoredProcedure [dbo].[DeleteAlbum]    Script Date: 05-02-2024 14:22:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteAlbum]
    @AlbumID INT
AS
BEGIN
    DELETE FROM Albums WHERE AlbumID = @AlbumID;
END;
GO
/****** Object:  StoredProcedure [dbo].[DeleteFromCart]    Script Date: 05-02-2024 14:22:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteFromCart]
    @AlbumID INT
AS
BEGIN
    DELETE FROM Carts
    WHERE AlbumID = @AlbumID;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetAlbumById]    Script Date: 05-02-2024 14:22:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAlbumById]
    @AlbumID INT
AS
BEGIN
    SELECT * FROM Albums WHERE AlbumID = @AlbumID;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetAlbumByName]    Script Date: 05-02-2024 14:22:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAlbumByName]
    @AlbumName NVARCHAR(255)
AS
BEGIN
    SELECT AlbumID, AlbumName, ArtistName, AlbumPrice, AlbumRating,AlbumGenre
    FROM Albums
    WHERE AlbumName LIKE '%' + @AlbumName + '%';
END;
GO
/****** Object:  StoredProcedure [dbo].[GetAllAlbums]    Script Date: 05-02-2024 14:22:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllAlbums]
AS
BEGIN
    SELECT * FROM Albums;
END;
GO
/****** Object:  StoredProcedure [dbo].[GetCartAlbums]    Script Date: 05-02-2024 14:22:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetCartAlbums]
    @UserID INT
AS
BEGIN
    SELECT A.AlbumID, A.AlbumName, A.ArtistName, A.AlbumPrice
    FROM Carts AS C
    INNER JOIN Albums AS A ON C.AlbumID = A.AlbumID
    WHERE C.UserID = @UserID;
END;
GO
/****** Object:  StoredProcedure [dbo].[RegisterUser]    Script Date: 05-02-2024 14:22:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Create the RegisterUser stored procedure
CREATE PROCEDURE [dbo].[RegisterUser]
    @UserName NVARCHAR(255),
    @UserEmail NVARCHAR(255), -- Note: Hash your passwords in production!
    @UserPhoneNo NVARCHAR(255),
    @UserAddress NVARCHAR(20),
    @UserPassword NVARCHAR(255)
AS
BEGIN
    INSERT INTO Users (UserName, UserEmail, UserPhoneNo, UserAddress, UserPassword)
    VALUES (@UserName, @UserEmail, @UserPhoneNo, @UserAddress, @UserPassword);
END;
GO
/****** Object:  StoredProcedure [dbo].[UpdateAlbum]    Script Date: 05-02-2024 14:22:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateAlbum]
    @AlbumID INT,
    @AlbumName NVARCHAR(255),
    @ArtistName NVARCHAR(255),
    @AlbumPrice DECIMAL(10, 2),
    @AlbumRating FLOAT,
    @AlbumGenre NVARCHAR(255)
AS
BEGIN
    UPDATE Albums
    SET 
        AlbumName = @AlbumName,
        ArtistName = @ArtistName,
        AlbumPrice = @AlbumPrice,
        AlbumRating = @AlbumRating,
        AlbumGenre = @AlbumGenre
    WHERE AlbumID = @AlbumID;
END;
GO
/****** Object:  StoredProcedure [dbo].[ValidateUser]    Script Date: 05-02-2024 14:22:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- Modify the ValidateUser stored procedure
CREATE PROCEDURE [dbo].[ValidateUser]
    @UserEmail NVARCHAR(255),
    @UserPassword NVARCHAR(255)
AS
BEGIN
    SELECT UserID, UserName, UserEmail, UserPhoneNo, UserAddress
    FROM Users
    WHERE UserEmail = @UserEmail AND UserPassword = @UserPassword;
END;
GO
USE [master]
GO
ALTER DATABASE [SingASong] SET  READ_WRITE 
GO
