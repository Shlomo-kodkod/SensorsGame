CREATE DATABASE IF NOT EXISTS SensorsGame;	
USE SensorsGame;
DROP TABLE IF EXISTS Players;

CREATE TABLE Players(
    id INT AUTO_INCREMENT,
    userName VARCHAR(64) NOT NULL UNIQUE,
    secretPass VARCHAR(128) NOT NULL UNIQUE,
    gameLevel INT DEFAULT 0,
    agentType ENUM("Foot Soldier", "Squad Leader","Senior Commander","Organization Leader") NOT NULL,
    PRIMARY KEY (id)
    );
    

    

    

