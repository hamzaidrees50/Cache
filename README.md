# Project Setup

-- Create DB:
  CREATE DATABASE CachingDB;
  CREATE TABLE [dbo].[Cache](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CacheKey] [nvarchar](450) NOT NULL,
	[Response] [nvarchar](max) NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
   CONSTRAINT [PK_Cache] PRIMARY KEY CLUSTERED 
    (
	    [Id] ASC
    )
    );

-- Change Connection string according to your database server from appsettings.json
    Below is the connection string for localhost windows authentication which I used.
   "Server=localhost; Database=CachingDB;Trusted_Connection=True;TrustServerCertificate=True"

-- Build and Run in Visual Studio

# Architecture

I have used 3 layered architecture to make it as simple as possible.
API layer
Service layer
Database layer.

Entity Framework core is used and Db first approach is used to create database schema.
Minimal API features are utilised with swashbuckle API documentation.

    
