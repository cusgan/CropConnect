-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Dec 03, 2024 at 06:57 AM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `dbcropconnect`
--

-- --------------------------------------------------------

--
-- Table structure for table `account`
--

CREATE TABLE `account` (
  `Id` int(11) NOT NULL,
  `Email` varchar(50) NOT NULL,
  `PasswordHash` longtext NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `account`
--

INSERT INTO `account` (`Id`, `Email`, `PasswordHash`) VALUES
(999, 'test@email.com', 'test');

-- --------------------------------------------------------

--
-- Table structure for table `farm`
--

CREATE TABLE `farm` (
  `Id` int(11) NOT NULL,
  `OwnerAccountId` int(11) NOT NULL,
  `FarmName` varchar(50) NOT NULL,
  `Location` varchar(100) NOT NULL,
  `FarmType` int(11) NOT NULL,
  `FarmSize` int(11) NOT NULL,
  `ContactInfo` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `guide`
--

CREATE TABLE `guide` (
  `Id` int(11) NOT NULL,
  `AuthorId` int(11) NOT NULL,
  `Title` varchar(50) NOT NULL,
  `Content` varchar(100) NOT NULL,
  `DatePosted` datetime(6) NOT NULL,
  `LastUpdated` datetime(6) NOT NULL,
  `HeadingImage` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `guide`
--

INSERT INTO `guide` (`Id`, `AuthorId`, `Title`, `Content`, `DatePosted`, `LastUpdated`, `HeadingImage`) VALUES
(999, 999, 'Test Guide', 'This is a Test Guide.', '2024-12-03 13:54:37.000000', '2024-12-03 13:54:37.000000', '');

-- --------------------------------------------------------

--
-- Table structure for table `message`
--

CREATE TABLE `message` (
  `Id` int(11) NOT NULL,
  `SenderId` int(11) NOT NULL,
  `ReceiverId` int(11) NOT NULL,
  `Content` varchar(100) NOT NULL,
  `TimeStamp` datetime(6) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `notification`
--

CREATE TABLE `notification` (
  `Id` int(11) NOT NULL,
  `ReceiverId` int(11) NOT NULL,
  `Content` varchar(100) NOT NULL,
  `Picture` varchar(100) NOT NULL,
  `Destination` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `posting`
--

CREATE TABLE `posting` (
  `Id` int(11) NOT NULL,
  `PosterId` int(11) NOT NULL,
  `ProductImage` varchar(100) NOT NULL,
  `ProductName` varchar(50) NOT NULL,
  `ProductDescription` varchar(100) NOT NULL,
  `ProductType` int(11) NOT NULL,
  `UnitType` int(11) NOT NULL,
  `Price` float NOT NULL,
  `Stock` int(11) NOT NULL,
  `AdditionalInfo` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `profile`
--

CREATE TABLE `profile` (
  `Id` int(11) NOT NULL,
  `AccountId` int(11) NOT NULL,
  `Name` varchar(50) NOT NULL,
  `Bio` varchar(100) NOT NULL,
  `WorkExperience` varchar(100) NOT NULL,
  `BirthDate` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `rating`
--

CREATE TABLE `rating` (
  `Id` int(11) NOT NULL,
  `RatedId` int(11) NOT NULL,
  `RaterId` int(11) NOT NULL,
  `Value` float NOT NULL,
  `Content` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20241203054216_FirstMigration', '8.0.8'),
('20241203055011_AddAllModels', '8.0.8');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `account`
--
ALTER TABLE `account`
  ADD PRIMARY KEY (`Id`);

--
-- Indexes for table `farm`
--
ALTER TABLE `farm`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_Farm_OwnerAccountId` (`OwnerAccountId`);

--
-- Indexes for table `guide`
--
ALTER TABLE `guide`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_Guide_AuthorId` (`AuthorId`);

--
-- Indexes for table `message`
--
ALTER TABLE `message`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_Message_ReceiverId` (`ReceiverId`),
  ADD KEY `IX_Message_SenderId` (`SenderId`);

--
-- Indexes for table `notification`
--
ALTER TABLE `notification`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_Notification_ReceiverId` (`ReceiverId`);

--
-- Indexes for table `posting`
--
ALTER TABLE `posting`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_Posting_PosterId` (`PosterId`);

--
-- Indexes for table `profile`
--
ALTER TABLE `profile`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_Profile_AccountId` (`AccountId`);

--
-- Indexes for table `rating`
--
ALTER TABLE `rating`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IX_Rating_RatedId` (`RatedId`),
  ADD KEY `IX_Rating_RaterId` (`RaterId`);

--
-- Indexes for table `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `account`
--
ALTER TABLE `account`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=1000;

--
-- AUTO_INCREMENT for table `farm`
--
ALTER TABLE `farm`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `guide`
--
ALTER TABLE `guide`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=1000;

--
-- AUTO_INCREMENT for table `message`
--
ALTER TABLE `message`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `notification`
--
ALTER TABLE `notification`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `posting`
--
ALTER TABLE `posting`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `profile`
--
ALTER TABLE `profile`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `rating`
--
ALTER TABLE `rating`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `farm`
--
ALTER TABLE `farm`
  ADD CONSTRAINT `FK_Farm_Account_OwnerAccountId` FOREIGN KEY (`OwnerAccountId`) REFERENCES `account` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `guide`
--
ALTER TABLE `guide`
  ADD CONSTRAINT `FK_Guide_Account_AuthorId` FOREIGN KEY (`AuthorId`) REFERENCES `account` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `message`
--
ALTER TABLE `message`
  ADD CONSTRAINT `FK_Message_Account_ReceiverId` FOREIGN KEY (`ReceiverId`) REFERENCES `account` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_Message_Account_SenderId` FOREIGN KEY (`SenderId`) REFERENCES `account` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `notification`
--
ALTER TABLE `notification`
  ADD CONSTRAINT `FK_Notification_Account_ReceiverId` FOREIGN KEY (`ReceiverId`) REFERENCES `account` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `posting`
--
ALTER TABLE `posting`
  ADD CONSTRAINT `FK_Posting_Account_PosterId` FOREIGN KEY (`PosterId`) REFERENCES `account` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `profile`
--
ALTER TABLE `profile`
  ADD CONSTRAINT `FK_Profile_Account_AccountId` FOREIGN KEY (`AccountId`) REFERENCES `account` (`Id`) ON DELETE CASCADE;

--
-- Constraints for table `rating`
--
ALTER TABLE `rating`
  ADD CONSTRAINT `FK_Rating_Account_RatedId` FOREIGN KEY (`RatedId`) REFERENCES `account` (`Id`) ON DELETE CASCADE,
  ADD CONSTRAINT `FK_Rating_Account_RaterId` FOREIGN KEY (`RaterId`) REFERENCES `account` (`Id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
