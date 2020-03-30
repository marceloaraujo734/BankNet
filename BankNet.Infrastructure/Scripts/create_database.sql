DROP DATABASE banknet;
CREATE SCHEMA IF NOT EXISTS `bankNet` DEFAULT CHARACTER SET utf8;

USE `bankNet` ;

-- -----------------------------------------------------
-- Table `bankNet`.`client`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bankNet`.`client` (
  `id` CHAR(36) NOT NULL DEFAULT 'uuid()',
  `name` VARCHAR(150) NOT NULL DEFAULT '',
  `document` VARCHAR(14) NOT NULL DEFAULT '',
  `email` VARCHAR(160) NOT NULL DEFAULT '',
  `phone` VARCHAR(13) NULL DEFAULT '',
  `createdData` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updatedData` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;

INSERT INTO `bankNet`.`client` (id, name, document, email, phone) VALUES('403b46a8-dff8-4376-8289-2421000077bd', 'MARCELO ARAUJO', '87610099031', 'marcelo.araujo@banknet.com', '11987654321');
INSERT INTO `bankNet`.`client` (id, name, document, email, phone) VALUES('7d172348-38be-4674-bb39-eb99cacdd624', 'JOSÉ DA SILVA', '93247379029', 'josedasilva@banknet.com', '11987654355');

-- -----------------------------------------------------
-- Table `bankNet`.`access`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bankNet`.`access` (
  `id` CHAR(36) NOT NULL DEFAULT 'uuid()',
  `clientId` CHAR(36) NOT NULL DEFAULT 'uuid()',
  `login` VARCHAR(30) NOT NULL DEFAULT '',
  `password` VARCHAR(10) NOT NULL DEFAULT '',
  `createdData` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updatedData` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  CONSTRAINT `fk_access_client` FOREIGN KEY (`clientId`) REFERENCES `client` (`id`))
ENGINE = InnoDB;

INSERT INTO `bankNet`.`access`(id, clientId, login, password) VALUES ('42b50449-c8ef-4a31-bcb3-50cf40459072', '403b46a8-dff8-4376-8289-2421000077bd', 'marcelo_araujo', 'bank@123');
INSERT INTO `bankNet`.`access`(id, clientId, login, password) VALUES ('2c5bb006-c9e3-448f-89a2-20c9f075e8e0', '7d172348-38be-4674-bb39-eb99cacdd624', 'jose_silva', 'jose@123');

-- -----------------------------------------------------
-- Table `bankNet`.`account`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bankNet`.`account` (
  `id` CHAR(36) NOT NULL DEFAULT 'uuid()',
  `clientId` CHAR(36) NOT NULL DEFAULT 'uuid()',
  `accountNumber` VARCHAR(14) NOT NULL DEFAULT '',
  `balance` VARCHAR(160) NOT NULL DEFAULT '',
  `createdData` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updatedData` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  CONSTRAINT `fk_account_client` FOREIGN KEY (`clientId`) REFERENCES `client` (`id`))
ENGINE = InnoDB;

INSERT INTO `bankNet`.`account` (id, clientId, accountNumber, balance) VALUES('7fdd895d-015f-4a67-9af0-c12638b36a32', '403b46a8-dff8-4376-8289-2421000077bd', '1234567', 5500.84);
INSERT INTO `bankNet`.`account` (id, clientId, accountNumber, balance) VALUES('4cb2293f-91d2-4b68-9840-e8b737073e7c', '7d172348-38be-4674-bb39-eb99cacdd624', '7654321', 10800.29);

-- -----------------------------------------------------
-- Table `bankNet`.`transaction`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `bankNet`.`transaction` (
  `id` CHAR(36) NOT NULL DEFAULT 'uuid()',
  `accountId` CHAR(36) NOT NULL DEFAULT 'uuid()',
  `typeTransaction` TINYINT(4) NOT NULL DEFAULT 0,
  `typeMovement` TINYINT(4) NOT NULL DEFAULT 0,
  `value` DECIMAL(14,2) NULL DEFAULT 0.00,
  `dateTransaction` DATETIME NOT NULL,
  `createdData` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `updatedData` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  CONSTRAINT `fk_transaction_account` FOREIGN KEY (`accountId`) REFERENCES `account` (`id`))
ENGINE = InnoDB;