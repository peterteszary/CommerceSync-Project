---
outline: deep
---

# Dokumentáció

## A Programcsomag felépítése

A Programcsomag felépítése, kapcsolódási pontok és Tech-Stack

<!-- ![TechStack](.vitepress/dist/assets/TechStack.png) -->

![alt text](img/TechStack.png)

## Folyamatábra

A ProductBridge és WooSync programok folyamatábrái

<!-- ![Folyamatábra](.vitepress/dist/assets/projektmunka-folyamatabra-foprogramok-Teszary-Peter-CommerceSync.png) -->

![alt text](img/projektmunka-folyamatabra.png)

## Adatbázis

Az adatbázis létrehozásakor arra törekszünk, hogy minél egyszerűbb legyen az adatok felhasználása és tényleg csak a legszükségesebb adatokkal dolgozzunk. Éppen ezért az alábbi ábrán látható a használni kívánt táblák és adatok felosztása.

<!-- ![Adatbázisok](.vitepress/dist/assets/img/sync-databases.png) -->

![alt text](img/sync-databases.png)

## Az adatbázist létrehozó parancsok

```
-- Felhasználók tábla létrehozása
CREATE TABLE Users (
    UserID INT PRIMARY KEY AUTO_INCREMENT,
    Username VARCHAR(50) NOT NULL,
    Password VARCHAR(100) NOT NULL,
    Email VARCHAR(100),
    FullName VARCHAR(100),
    UNIQUE(Username)
);

-- Termékek tábla létrehozása
CREATE TABLE Products (
    ProductID INT PRIMARY KEY AUTO_INCREMENT,
    Name VARCHAR(100) NOT NULL,
    Description TEXT,
    Price DECIMAL(10, 2) NOT NULL,
    SalesPrice DECIMAL(10, 2),
    Category VARCHAR(50),
    Tag VARCHAR(50),
    ShortDescription TEXT,
    LongDescription TEXT,
    SKU VARCHAR(50),
    StockQuantity INT NOT NULL,
    UNIQUE(Name)
);

-- Weboldalak tábla létrehozása
CREATE TABLE Websites (
    WebsiteID INT PRIMARY KEY AUTO_INCREMENT,
    URL VARCHAR(255) NOT NULL,
    AuthenticationURL VARCHAR(255) NOT NULL,
    Username VARCHAR(50) NOT NULL,
    Password VARCHAR(100) NOT NULL,
    UNIQUE(URL)
);

-- Példa felhasználó hozzáadása
INSERT INTO Users (Username, Password, Email, FullName) 
VALUES ('peterteszary', 'jelszo123', 'peterteszary@gmail.com', 'Peter Teszary');

-- Példa termékek hozzáadása (10 darab pendrive)
INSERT INTO Products (Name, Description, Price, Category, ShortDescription, SKU, StockQuantity) 
VALUES 
('Pendrive 1GB', '1 gigabájtos pendrive', 10.99, 'Pendrive', '1GB pendrive', 'PD1GB', 100),
('Pendrive 2GB', '2 gigabájtos pendrive', 14.99, 'Pendrive', '2GB pendrive', 'PD2GB', 80),
('Pendrive 4GB', '4 gigabájtos pendrive', 19.99, 'Pendrive', '4GB pendrive', 'PD4GB', 70),
('Pendrive 8GB', '8 gigabájtos pendrive', 24.99, 'Pendrive', '8GB pendrive', 'PD8GB', 60),
('Pendrive 16GB', '16 gigabájtos pendrive', 29.99, 'Pendrive', '16GB pendrive', 'PD16GB', 50),
('Pendrive 32GB', '32 gigabájtos pendrive', 39.99, 'Pendrive', '32GB pendrive', 'PD32GB', 40),
('Pendrive 64GB', '64 gigabájtos pendrive', 49.99, 'Pendrive', '64GB pendrive', 'PD64GB', 30),
('Pendrive 128GB', '128 gigabájtos pendrive', 69.99, 'Pendrive', '128GB pendrive', 'PD128GB', 20),
('Pendrive 256GB', '256 gigabájtos pendrive', 99.99, 'Pendrive', '256GB pendrive', 'PD256GB', 10),
('Pendrive 512GB', '512 gigabájtos pendrive', 149.99, 'Pendrive', '512GB pendrive', 'PD512GB', 5);
```