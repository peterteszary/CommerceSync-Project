-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2024. Feb 25. 07:10
-- Kiszolgáló verziója: 10.4.32-MariaDB
-- PHP verzió: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `product_bridge`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `products`
--

CREATE TABLE `products` (
  `ProductID` int(11) NOT NULL,
  `Name` varchar(100) NOT NULL,
  `Description` text DEFAULT NULL,
  `Price` decimal(10,2) NOT NULL,
  `SalesPrice` decimal(10,2) DEFAULT NULL,
  `Category` varchar(50) DEFAULT NULL,
  `Tag` varchar(50) DEFAULT NULL,
  `ShortDescription` text DEFAULT NULL,
  `LongDescription` text DEFAULT NULL,
  `SKU` varchar(50) DEFAULT NULL,
  `StockQuantity` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- A tábla adatainak kiíratása `products`
--

INSERT INTO `products` (`ProductID`, `Name`, `Description`, `Price`, `SalesPrice`, `Category`, `Tag`, `ShortDescription`, `LongDescription`, `SKU`, `StockQuantity`) VALUES
(1, 'Pendrive 1GB', '1 gigabájtos pendrive', 10.99, NULL, 'Pendrive', NULL, '1GB pendrive', NULL, 'PD1GB', 100),
(2, 'Pendrive 2GB', '2 gigabájtos pendrive', 14.99, NULL, 'Pendrive', NULL, '2GB pendrive', NULL, 'PD2GB', 80),
(3, 'Pendrive 4GB', '4 gigabájtos pendrive', 19.99, NULL, 'Pendrive', NULL, '4GB pendrive', NULL, 'PD4GB', 70),
(4, 'Pendrive 8GB', '8 gigabájtos pendrive', 24.99, NULL, 'Pendrive', NULL, '8GB pendrive', NULL, 'PD8GB', 60),
(5, 'Pendrive 16GB', '16 gigabájtos pendrive', 29.99, NULL, 'Pendrive', NULL, '16GB pendrive', NULL, 'PD16GB', 50),
(6, 'Pendrive 32GB', '32 gigabájtos pendrive', 39.99, NULL, 'Pendrive', NULL, '32GB pendrive', NULL, 'PD32GB', 40),
(7, 'Pendrive 64GB', '64 gigabájtos pendrive', 49.99, NULL, 'Pendrive', NULL, '64GB pendrive', NULL, 'PD64GB', 30),
(8, 'Pendrive 128GB', '128 gigabájtos pendrive', 69.99, NULL, 'Pendrive', NULL, '128GB pendrive', NULL, 'PD128GB', 20),
(9, 'Pendrive 256GB', '256 gigabájtos pendrive', 99.99, NULL, 'Pendrive', NULL, '256GB pendrive', NULL, 'PD256GB', 10),
(10, 'Pendrive 512GB', '512 gigabájtos pendrive', 149.99, NULL, 'Pendrive', NULL, '512GB pendrive', NULL, 'PD512GB', 5);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `users`
--

CREATE TABLE `users` (
  `UserID` int(11) NOT NULL,
  `Username` varchar(50) NOT NULL,
  `Password` varchar(100) NOT NULL,
  `Email` varchar(100) DEFAULT NULL,
  `FullName` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- A tábla adatainak kiíratása `users`
--

INSERT INTO `users` (`UserID`, `Username`, `Password`, `Email`, `FullName`) VALUES
(1, 'peterteszary', 'jelszo123', 'peterteszary@gmail.com', 'Peter Teszary');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `websites`
--

CREATE TABLE `websites` (
  `WebsiteID` int(11) NOT NULL,
  `URL` varchar(255) NOT NULL,
  `AuthenticationURL` varchar(255) NOT NULL,
  `Username` varchar(50) NOT NULL,
  `Password` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `products`
--
ALTER TABLE `products`
  ADD PRIMARY KEY (`ProductID`),
  ADD UNIQUE KEY `Name` (`Name`);

--
-- A tábla indexei `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`UserID`),
  ADD UNIQUE KEY `Username` (`Username`);

--
-- A tábla indexei `websites`
--
ALTER TABLE `websites`
  ADD PRIMARY KEY (`WebsiteID`),
  ADD UNIQUE KEY `URL` (`URL`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `products`
--
ALTER TABLE `products`
  MODIFY `ProductID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT a táblához `users`
--
ALTER TABLE `users`
  MODIFY `UserID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT a táblához `websites`
--
ALTER TABLE `websites`
  MODIFY `WebsiteID` int(11) NOT NULL AUTO_INCREMENT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
