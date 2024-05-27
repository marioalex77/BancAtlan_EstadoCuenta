USE [master]
GO

/****** Object:  Database [BancAtlan_EstadoCuenta]    Script Date: 25/5/2024 06:45:20 ******/
CREATE DATABASE [BancAtlan_EstadoCuenta]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BancAtlan_EstadoCuenta', FILENAME = N'/var/opt/mssql/data/BancAtlan_EstadoCuenta.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BancAtlan_EstadoCuenta_log', FILENAME = N'/var/opt/mssql/data/BancAtlan_EstadoCuenta_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BancAtlan_EstadoCuenta].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [BancAtlan_EstadoCuenta] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [BancAtlan_EstadoCuenta] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [BancAtlan_EstadoCuenta] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [BancAtlan_EstadoCuenta] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [BancAtlan_EstadoCuenta] SET ARITHABORT OFF 
GO

ALTER DATABASE [BancAtlan_EstadoCuenta] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [BancAtlan_EstadoCuenta] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [BancAtlan_EstadoCuenta] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [BancAtlan_EstadoCuenta] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [BancAtlan_EstadoCuenta] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [BancAtlan_EstadoCuenta] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [BancAtlan_EstadoCuenta] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [BancAtlan_EstadoCuenta] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [BancAtlan_EstadoCuenta] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [BancAtlan_EstadoCuenta] SET  DISABLE_BROKER 
GO

ALTER DATABASE [BancAtlan_EstadoCuenta] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [BancAtlan_EstadoCuenta] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [BancAtlan_EstadoCuenta] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [BancAtlan_EstadoCuenta] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [BancAtlan_EstadoCuenta] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [BancAtlan_EstadoCuenta] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [BancAtlan_EstadoCuenta] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [BancAtlan_EstadoCuenta] SET RECOVERY FULL 
GO

ALTER DATABASE [BancAtlan_EstadoCuenta] SET  MULTI_USER 
GO

ALTER DATABASE [BancAtlan_EstadoCuenta] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [BancAtlan_EstadoCuenta] SET DB_CHAINING OFF 
GO

ALTER DATABASE [BancAtlan_EstadoCuenta] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [BancAtlan_EstadoCuenta] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [BancAtlan_EstadoCuenta] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [BancAtlan_EstadoCuenta] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [BancAtlan_EstadoCuenta] SET QUERY_STORE = ON
GO

ALTER DATABASE [BancAtlan_EstadoCuenta] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO

ALTER DATABASE [BancAtlan_EstadoCuenta] SET  READ_WRITE 
GO

USE [BancAtlan_EstadoCuenta]
GO

/****** Object:  Table [dbo].[usuario]    Script Date: 25/5/2024 07:56:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[usuario](
	[id_usuario] [int] IDENTITY(1,1) NOT NULL,
	[correo] [nvarchar](255) NOT NULL,
	[password] [nvarchar](1000) NOT NULL,
 CONSTRAINT [PK_usuario] PRIMARY KEY CLUSTERED 
(
	[id_usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tipo_transaccion](
	[id_tipo_transaccion] [int] IDENTITY(1,1) NOT NULL,
	[valor] [char](1) NOT NULL,
	[concepto] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_tipo_transaccion] PRIMARY KEY CLUSTERED 
(
	[id_tipo_transaccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

INSERT INTO [dbo].[tipo_transaccion](valor,concepto) VALUES('C', 'COMPRA');
INSERT INTO [dbo].[tipo_transaccion](valor,concepto) VALUES('P', 'PAGO');

CREATE TABLE [dbo].[cliente](
	[id_cliente] [int] IDENTITY(1,1) NOT NULL,
	[nombres] [nvarchar](1000) NOT NULL,
	[apellidos] [nvarchar](1000) NOT NULL,
	[genero] [nchar](1) NOT NULL,
 CONSTRAINT [PK_cliente] PRIMARY KEY CLUSTERED 
(
	[id_cliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[tarjeta](
	[id_tarjeta] [int] IDENTITY(1,1) NOT NULL,
	[id_cliente] [int] NOT NULL,
	[numero] [varchar](16) NOT NULL,
	[limite_credito] [decimal](19, 4) NOT NULL,
	[saldo] [decimal](19, 4) NOT NULL,
	[interes] [decimal](5, 2) NOT NULL,
	[saldo_minimo] [decimal](5, 2) NOT NULL,
	[dia_corte_mes] [int] NOT NULL,
 CONSTRAINT [PK_tarjeta] PRIMARY KEY CLUSTERED 
(
	[id_tarjeta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tarjeta]  WITH CHECK ADD  CONSTRAINT [FK_tarjeta_cliente] FOREIGN KEY([id_tarjeta])
REFERENCES [dbo].[cliente] ([id_cliente])
GO

ALTER TABLE [dbo].[tarjeta] CHECK CONSTRAINT [FK_tarjeta_cliente]
GO

CREATE TABLE [dbo].[estado_cuenta](
	[id_estado_cuenta] [int] IDENTITY(1,1) NOT NULL,
	[id_tarjeta] [int] NOT NULL,
	[mes] [int] NOT NULL,
	[anio] [int] NOT NULL,
	[disponible] [decimal](19, 2) NOT NULL,
	[saldo] [decimal](19, 2) NOT NULL,
	[pago_minimo] [decimal](19, 2) NOT NULL,
	[fecha_vto_pago] [datetime] NOT NULL,
 CONSTRAINT [PK_estado_cuenta] PRIMARY KEY CLUSTERED 
(
	[id_estado_cuenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[estado_cuenta]  WITH CHECK ADD  CONSTRAINT [FK_estado_cuenta_tarjeta] FOREIGN KEY([id_tarjeta])
REFERENCES [dbo].[tarjeta] ([id_tarjeta])
GO

ALTER TABLE [dbo].[estado_cuenta] CHECK CONSTRAINT [FK_estado_cuenta_tarjeta]
GO

CREATE TABLE [dbo].[transaccion](
	[id_transaccion] [int] IDENTITY(1,1) NOT NULL,
	[id_tarjeta] [int] NOT NULL,
	[fecha_transaccion] [datetime] NOT NULL,
	[fecha_movimiento] [datetime] NOT NULL,
	[descripcion] [nvarchar](2500) NOT NULL,
	[id_tipo_transaccion] [int] NOT NULL,
	[monto] [decimal](19, 4) NOT NULL,
	[signo] [char](1) NOT NULL,
 CONSTRAINT [PK_transaccion] PRIMARY KEY CLUSTERED 
(
	[id_transaccion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[transaccion] ADD  CONSTRAINT [DF_transaccion_signo]  DEFAULT ('D') FOR [signo]
GO

ALTER TABLE [dbo].[transaccion]  WITH CHECK ADD  CONSTRAINT [FK_transaccion_tarjeta] FOREIGN KEY([id_tarjeta])
REFERENCES [dbo].[tarjeta] ([id_tarjeta])
GO

ALTER TABLE [dbo].[transaccion] CHECK CONSTRAINT [FK_transaccion_tarjeta]
GO

ALTER TABLE [dbo].[transaccion]  WITH CHECK ADD  CONSTRAINT [FK_transaccion_tipo_transaccion] FOREIGN KEY([id_tipo_transaccion])
REFERENCES [dbo].[tipo_transaccion] ([id_tipo_transaccion])
GO

ALTER TABLE [dbo].[transaccion] CHECK CONSTRAINT [FK_transaccion_tipo_transaccion]
GO