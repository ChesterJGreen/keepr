CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
  name varchar(255) COMMENT 'User Name',
  email varchar(255) COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture'
) default charset utf8 COMMENT '';

CREATE TABLE keeps (  
    id int NOT NULL primary key AUTO_INCREMENT comment 'primary key',
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
    name varchar(255) comment 'name of keep',
    description varchar(1000) comment 'description of keep',
    img varchar(255) comment 'image for keep',
    views int NOT NULL DEFAULT 0 comment 'views of keep',
    shares int NOT NULL DEFAULT 0 comment 'shares of keep',
    keeps int NOT NULL DEFAULT 0 comment 'number of times saved in a vault',
    creatorId VARCHAR(255) COMMENT 'creator of keep',
    FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
) default charset utf8 comment '';

CREATE TABLE vaults (  
    id int NOT NULL primary key AUTO_INCREMENT comment 'primary key',
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
    name varchar(255) comment 'name of vault',
    description varchar(1000) comment 'description of vault',
    img VARCHAR(255) comment 'img of vault',
    isPrivate TINYINT comment 'is vault private?',
    creatorId VARCHAR(255) COMMENT 'creator of vault',
    FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE
) default charset utf8 comment '';

CREATE TABLE vaultKeeps (  
    id int NOT NULL primary key AUTO_INCREMENT comment 'primary key',
    creatorId VARCHAR(255) COMMENT 'creator of keep',
    vaultId int NOT NULL comment 'vault id',
    keepId int NOT NULL comment 'keep id',
    FOREIGN KEY (creatorId) REFERENCES accounts(id) ON DELETE CASCADE,
    FOREIGN KEY (vaultId) REFERENCES vaults(id) ON DELETE CASCADE,
    FOREIGN KEY (keepId) REFERENCES keeps(id) ON DELETE CASCADE
) default charset utf8 comment '';


ALTER TABLE vaults
ADD img VARCHAR(255);

