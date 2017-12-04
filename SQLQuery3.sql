create database Cars;

 use Cars
 CREATE TABLE [dbo].[Producer](
	[Producer] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Table_1] PRIMARY KEY CLUSTERED 
(
	[Producer] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

use Cars
CREATE TABLE [dbo].[Mark](
	[Mark] [nvarchar](50) NOT NULL,
	[Producer] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Mark] PRIMARY KEY CLUSTERED 
(
	[Mark] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Mark]  WITH CHECK ADD  CONSTRAINT [FK_Mark_Producer] FOREIGN KEY([Producer])
REFERENCES [dbo].[Producer] ([Producer])
GO

use Cars
CREATE TABLE [dbo].[Cars](
	[CarID] [int] NOT NULL,
	[mark] [nvarchar](50) NOT NULL,
	[producer] [nvarchar](50) NOT NULL,
	[color] [nvarchar](50) NULL,
	[cost] [int] NULL,
	[year] [int] NULL,
	[photo] [nvarchar](max) NULL,
 CONSTRAINT [PK_Cars] PRIMARY KEY CLUSTERED 
(
	[CarID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [dbo].[Cars]  WITH CHECK ADD  CONSTRAINT [FK_Cars_Mark] FOREIGN KEY([mark])
REFERENCES [dbo].[Mark] ([Mark])
GO

use Cars
INSERT INTO PRODUCER (Producer) values('General Motors'),('Volkswagen'),('AmericanCars');

use Cars
INSERT INTO Mark (Mark, Producer) values ('Audi','Volkswagen'), 
										 ('Porshe','Volkswagen'),
										 ('Volkswagen','Volkswagen'),
										 ('Chevrolet','General Motors'), 
										 ('GMC','General Motors'),  
										 ('Pontiac','General Motors'),
										 ('Mustang','AmericanCars'),
										 ('Dodge','AmericanCars'),
										 ('Lincoln','AmericanCars');

use Cars
INSERT INTO Cars (CarID, mark, producer, color, cost, year, photo) values(1, 'Audi','Volkswagen', 'RED', 7500, 2008, 'D:/CARS/1.jpg'),
																		 (2, 'Porshe','Volkswagen', 'RED', 12300, 2005, 'D:/CARS/2.jpg'),
																		 (3, 'Volkswagen','Volkswagen', 'GREY', 4500, 2003, 'D:/CARS/3.jpg'),
																		 (4, 'Chevrolet','General Motors', 'BLACK', 17500, 2013, 'D:/CARS/4.jpg'),
																		 (5, 'GMC','General Motors', 'WHITE', 14000, 2004, 'D:/CARS/5.jpg'),
																		 (6, 'Pontiac','General Motors', 'YELOW', 8000, 2005, 'D:/CARS/6.jpg'),
																		 (7, 'Mustang','AmericanCars', 'WHITE', 7000, 2008, 'D:/CARS/7.jpg'),
																		 (8, 'Dodge','AmericanCars', 'BLUE', 45000, 2017, 'D:/CARS/8.jpg'),
																		 (9, 'Lincoln','AmericanCars', 'BLACK', 23000, 1985, 'D:/CARS/9.jpg'),
																		 (10, 'Audi','Volkswagen', 'SPACE', 12400, 2009, 'D:/CARS/10.jpg'),
																		 (11, 'Audi','Volkswagen', 'WHITE', 7000, 2003, 'D:/CARS/11.jpg'),
																		 (12, 'Audi','Volkswagen', 'BLACK', 17500, 2013, 'D:/CARS/12.jpg');
																	

