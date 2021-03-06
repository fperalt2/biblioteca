USE [master]
GO
/****** Object:  Database [biblioteca] ******/
CREATE DATABASE [biblioteca]
 CONTAINMENT = NONE
GO
ALTER DATABASE [biblioteca] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [biblioteca].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [biblioteca] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [biblioteca] SET ANSI_NULLS OFF
GO
ALTER DATABASE [biblioteca] SET ANSI_PADDING OFF
GO
ALTER DATABASE [biblioteca] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [biblioteca] SET ARITHABORT OFF
GO
ALTER DATABASE [biblioteca] SET AUTO_CLOSE ON
GO
ALTER DATABASE [biblioteca] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [biblioteca] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [biblioteca] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [biblioteca] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [biblioteca] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [biblioteca] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [biblioteca] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [biblioteca] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [biblioteca] SET  ENABLE_BROKER
GO
ALTER DATABASE [biblioteca] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [biblioteca] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [biblioteca] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [biblioteca] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [biblioteca] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [biblioteca] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [biblioteca] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [biblioteca] SET RECOVERY SIMPLE
GO
ALTER DATABASE [biblioteca] SET  MULTI_USER
GO
ALTER DATABASE [biblioteca] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [biblioteca] SET DB_CHAINING OFF
GO
ALTER DATABASE [biblioteca] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF )
GO
ALTER DATABASE [biblioteca] SET TARGET_RECOVERY_TIME = 60 SECONDS
GO
ALTER DATABASE [biblioteca] SET DELAYED_DURABILITY = DISABLED
GO
ALTER DATABASE [biblioteca] SET QUERY_STORE = OFF
GO
USE [biblioteca]
GO
ALTER DATABASE SCOPED CONFIGURATION SET IDENTITY_CACHE = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [biblioteca]
GO
/****** Object:  Table [dbo].[llibre] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[llibre](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[titol] [nvarchar](max) NOT NULL,
	[autor_Id] [int] NOT NULL,
 CONSTRAINT [PK_llibre] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[autor] ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[autor](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[nom] [nvarchar](max) NOT NULL,
	[cognoms] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_autor] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_autorllibre] ******/
CREATE NONCLUSTERED INDEX [IX_FK_autorllibre] ON [dbo].[llibre]
(
	[autor_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[llibre]  WITH CHECK ADD  CONSTRAINT [FK_autorllibre] FOREIGN KEY([autor_Id])
REFERENCES [dbo].[autor] ([Id])
GO
ALTER TABLE [dbo].[llibre] CHECK CONSTRAINT [FK_autorllibre]
GO
USE [master]
GO
ALTER DATABASE [biblioteca] SET  READ_WRITE
GO
