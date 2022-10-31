USE [DMA-CSD-S212_10182474];

DROP TABLE nc_Booking, nc_BookingLine, nc_CityZipCode, nc_Consumables, nc_Customer, nc_Employee, nc_GamingStation, nc_Pack, nc_PackLine, nc_Person, nc_Product, nc_Rentable;
go

CREATE TABLE nc_CityZipCode(
    zipCode INT NOT NULL,
	city VARCHAR(50),

	PRIMARY KEY(zipCode),
);

CREATE TABLE nc_Person(
	id INT IDENTITY(1,1),
	name VARCHAR(50) NOT NULL,
	phone INT,
	email VARCHAR(50) NOT NULL,

	PRIMARY KEY(id),
);

CREATE TABLE nc_Customer(
    personid INT,

    CONSTRAINT fk_ncPerson foreign key (personid) references nc_Person(id),
    PRIMARY KEY(personid),
);

CREATE TABLE nc_Employee(
    personid INT,
    address VARCHAR(50), 
    role VARCHAR(15),
    access VARCHAR(15),
    zipCode INT NOT NULL,

    CONSTRAINT fk_ncZipCode foreign key (zipCode) references nc_CityZipCode(zipCode),
    CONSTRAINT fk_ncEmployeepersonid foreign key (personid) references nc_Person(id),
    PRIMARY KEY(personid),
);

CREATE TABLE nc_Booking(
    id INT IDENTITY(1,1),
    bookingNo INT NOT NULL,
    startTime INT NOT NULL,
    endTime INT NOT NULL,
    customerid INT NOT NULL,
    employeeid INT NOT NULL,

    CONSTRAINT fk_ncCustomer foreign key (customerid) references nc_Customer(personid),
    CONSTRAINT fk_ncEmployee foreign key (employeeid) references nc_Employee(personid),
    PRIMARY KEY(id),
);

CREATE TABLE nc_Product(
    id INT IDENTITY(1,1),
    productNo INT NOT NULL,
    description VARCHAR(80),

    PRIMARY KEY(id),
);

CREATE TABLE nc_Consumables(
    productid INT NOT NULL,
    description VARCHAR(50),

    CONSTRAINT fk_ncConsumablesproducid foreign key (productid) references nc_Product(id),
    PRIMARY KEY(productid),
);

CREATE TABLE nc_Rentable(
    productid INT NOT NULL,

    CONSTRAINT fk_ncRentableproductid foreign key (productid) references nc_Product(id),
    PRIMARY KEY(id),
);

CREATE TABLE nc_BookingLine(
    bookingid INT NOT NULL,
    quantity INT NOT NULL,
    rentableid INT NOT NULL,
    consumableid INT,

    CONSTRAINT fk_ncBookinglinebookingid foreign key (bookingid) references nc_Booking(id),
    CONSTRAINT fk_ncBookinglinerentableid foreign key (rentableid) references nc_Rentable(productid),
    CONSTRAINT fk_ncBookinglineConsumableid FOREIGN KEY (consumableid) references nc_Consumables(productid),
);


CREATE TABLE nc_GamingStation(
    rentableid INT NOT NULL,
    seatNo INT NOT NULL,
    description VARCHAR(50),
    tier INT NOT NULL,
    booked INT DEFAULT 0,

    CONSTRAINT fk_ncGamingstationrentableid foreign key (rentableid) references nc_Rentable(productid),
);

CREATE TABLE nc_Pack(
    rentableid INT NOT NULL,
    id INT IDENTITY(1,1),

    CONSTRAINT fk_ncPackproductid FOREIGN KEY (rentableid) REFERENCES nc_Product(productid),
    PRIMARY KEY(id),
);

CREATE TABLE nc_PackLine(
    productid INT NOT NULL,
    quantity INT NOT NULL,
    packid INT NOT NULL,

    CONSTRAINT fk_ncPackLineproductid FOREIGN KEY (productid) REFERENCES nc_Product(productid),
    CONSTRAINT fk_ncPackLinepackid FOREIGN KEY (packid) REFERENCES nc_Pack(id),
);


