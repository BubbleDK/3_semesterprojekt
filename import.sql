USE [DMA-CSD-S212_10182474];

--DROP TABLE nc_PackLine, nc_Pack, nc_GamingStation, nc_BookingLine, nc_Rentable, nc_Consumables, nc_Product, nc_Booking, nc_Customer, nc_Employee, nc_Person, nc_CityZipCode;
DROP TABLE nc_GamingStation, nc_BookingLine, nc_Consumables, nc_Product, nc_Booking, nc_Customer, nc_Employee, nc_Person, nc_CityZipCode;
go

CREATE TABLE nc_CityZipCode(
    zipCode INT NOT NULL,
	city VARCHAR(50),

	PRIMARY KEY(zipCode),
);

CREATE TABLE nc_Person(
	id INT IDENTITY(1,1),
	name VARCHAR(50) NOT NULL,
	phone VARCHAR(50),
	email VARCHAR(50) NOT NULL,
	personType VARCHAR(50) NOT NULL,
    password VARCHAR(50) NOT NULL,

	PRIMARY KEY(id),
);

CREATE TABLE nc_Customer(
    personid INT,

    CONSTRAINT fk_ncPerson foreign key (personid) references nc_Person(id) ON DELETE CASCADE,
    PRIMARY KEY(personid),
);

CREATE TABLE nc_Employee(
    personid INT,
    address VARCHAR(50), 
    role VARCHAR(15) NOT NULL,
    zipCode INT NOT NULL,

    CONSTRAINT fk_ncZipCode foreign key (zipCode) references nc_CityZipCode(zipCode),
    CONSTRAINT fk_ncEmployeepersonid foreign key (personid) references nc_Person(id) ON DELETE CASCADE,
    PRIMARY KEY(personid),
);

CREATE TABLE nc_Booking(
    id INT IDENTITY(1,1),
    bookingNo VARCHAR(50) NOT NULL UNIQUE,
    startTime DateTime NOT NULL,
    endTime DateTime NOT NULL,
    customerid INT,

    CONSTRAINT fk_ncCustomer foreign key (customerid) references nc_Customer(personid) ON DELETE SET NULL,
    PRIMARY KEY(id),
);

CREATE TABLE nc_Product(
    id INT IDENTITY(1,1),
    productNo VARCHAR(50) NOT NULL UNIQUE,
    productType VARCHAR(80),
    name VARCHAR(25) NOT NULL,
    isActive BIT,

    PRIMARY KEY(id),
);

CREATE TABLE nc_Consumables(
    productid INT NOT NULL,
    description VARCHAR(50),

    CONSTRAINT fk_ncConsumablesproductid foreign key (productid) references nc_Product(id) ON DELETE CASCADE,
    PRIMARY KEY(productid),
);

CREATE TABLE nc_BookingLine(
    bookingid INT NOT NULL,
    quantity INT,
    stationid INT NOT NULL,
    consumableid INT,

    CONSTRAINT fk_ncBookinglinebookingid foreign key (bookingid) references nc_Booking(id) ON DELETE CASCADE,
    CONSTRAINT fk_ncBookinglineStationid foreign key (stationid) references nc_Product(id),
);

CREATE TABLE nc_GamingStation(
    stationid INT NOT NULL,
    seatNo VARCHAR(50) NOT NULL,
    description VARCHAR(50),

    CONSTRAINT fk_ncGamingstationrentableid foreign key (stationid) references nc_Product(id),
	PRIMARY KEY(stationid),
);

--CREATE TABLE nc_Pack(
--    rentableid INT NOT NULL,
--    id INT IDENTITY(1,1),

--    CONSTRAINT fk_ncPackproductid FOREIGN KEY (rentableid) REFERENCES nc_Product(productid),
--    PRIMARY KEY(id),
--);

--CREATE TABLE nc_PackLine(
--    productid INT NOT NULL,
--    quantity INT NOT NULL,
--    packid INT NOT NULL,

--    CONSTRAINT fk_ncPackLineproductid FOREIGN KEY (productid) REFERENCES nc_Product(productid),
--    CONSTRAINT fk_ncPackLinepackid FOREIGN KEY (packid) REFERENCES nc_Pack(id),
--);


INSERT INTO nc_CityZipCode VALUES (9000, 'Aalborg');

INSERT INTO nc_Person VALUES ('John', '88888888', 'john@gmail.com', 'Customer');
INSERT INTO nc_Person VALUES ('Bodil', '88888889', 'bodil@gmail.com', 'Employee');
INSERT INTO nc_Person VALUES ('Carsten', '99999999', 'carsten@gmail.com', 'Customer');

INSERT INTO nc_Customer VALUES (1);
INSERT INTO nc_Customer VALUES (3);

INSERT INTO nc_Employee VALUES (2, 'bodilvej 2', 'Admin', 9000);

INSERT INTO nc_Booking VALUES (40, '1955-12-13 12:43:00', '1955-12-13 14:43:00', 3);

INSERT INTO nc_Product VALUES ('FEDTFEDT', 'Gamingstation', 'Produkt1', 1)
INSERT INTO nc_Product VALUES ('FEDTNICE', 'Consumable', 'Produkt2', 1)

INSERT INTO nc_Consumables VALUES (2, 'Et eller andet nice');

INSERT INTO nc_BookingLine VALUES (1, 5, 1, 2);

INSERT INTO nc_GamingStation VALUES (1, 'EtNiceSted', 'Sindssyg pc');