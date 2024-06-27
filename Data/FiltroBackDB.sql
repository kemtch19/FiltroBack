-- Active: 1719515971597@@baujyxdapyvqg5tgmryw-mysql.services.clever-cloud.com@3306@baujyxdapyvqg5tgmryw

-- Dueños
CREATE TABLE owners(
    id_owners INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    Names VARCHAR(50) NOT NULL,
    LastNames VARCHAR(50) NOT NULL,
    Email VARCHAR(100) UNIQUE NOT NULL,
    Address VARCHAR(100) NOT NULL,
    Phone VARCHAR(25) NOT NULL
);

INSERT INTO owners(`Names`, `LastNames`, `Email`, `Address`, `Phone`) VALUES
("Daniel", "Alzate", "test@gmail.com", "avenida siempre viva 36", "341421333");


-- veterinarios
CREATE TABLE vets (
    id_Vets INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    Name VARCHAR(120) NOT NULL,
    Phone VARCHAR(25) NOT NULL,
    Address VARCHAR(30) NOT NULL,
    YearsExperiencie INT NOT NULL,
    Email VARCHAR(100) UNIQUE NOT NULL
);

INSERT INTO vets(`Name`, `Phone`, `Address`, `YearsExperiencie`, `Email`) VALUES
("Francisco", "413213123", "calle 23 a sur 32", 2,"veterinario1@gmail.com"),
("Maria", "413213124", "calle 12 a norte 3", 1, "veterinario2@gmail.com");

-- citas
CREATE TABLE quotes(
    id_quotes INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    Date DATETIME NOT NULL,
    Description VARCHAR(255) NOT NULL,
    PetId INT NOT NULL,
    VetId INT NOT NULL,
    FOREIGN KEY (PetId) REFERENCES pets(id_pet),
    FOREIGN KEY (VetId) REFERENCES vets(id_Vets)
);

INSERT INTO quotes(`Date`, `Description`, `PetId`, `VetId`) VALUES
("2020-02-02", "Presenta vomitos recurrentes junto con diarrea presentando cuadro de desidratación", 1, 1);

-- mascotas
CREATE TABLE pets(
    id_pet INT AUTO_INCREMENT PRIMARY KEY NOT NULL,
    Name VARCHAR(25) NOT NULL,
    Specie ENUM("Gato", "Perro", "Ave") NOT NULL,
    Race ENUM("Pincher", "Rod Guailer", "Freshpoder", "Gato de Egipto") NOT NULL,
    DateBirth DATE NOT NULL,
    Photo VARCHAR(255) NOT NULL,
    OwnerId INT NOT NULL,
    FOREIGN KEY (OwnerId) REFERENCES owners(id_owners)
);

INSERT INTO pets(`Name`, `Specie`, `Race`, `DateBirth`, `Photo`, `OwnerId`) VALUES
("Luna", "Perro", "Pincher", "2021-01-02", "fotoLuna.png", 1);

SELECT * FROM vets;