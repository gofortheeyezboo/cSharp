

-- CREATE TABLE profiles
-- (
--   id VARCHAR(255) NOT NULL,
--   email VARCHAR(255) NOT NULL,
--   name VARCHAR(255),
--   picture VARCHAR(255),
--   PRIMARY KEY (id)
-- );

-- CREATE TABLE todolists
-- (
--   id INT NOT NULL AUTO_INCREMENT,
--   creatorId VARCHAR(255) NOT NULL,
--   title VARCHAR(255) NOT NULL,
--   body VARCHAR(255) NOT NULL,

--   PRIMARY KEY (id),

--   FOREIGN KEY (creatorId)
--     REFERENCES profiles (id)
--     ON DELETE CASCADE

-- );
-- CREATE TABLE todotasks
-- (
-- id INT NOT NULL AUTO_INCREMENT,
-- creatorId VARCHAR(255) NOT NULL,
-- body VARCHAR(255) NOT NULL,  

--   PRIMARY KEY (id),

--   FOREIGN KEY (creatorId)
--     REFERENCES profiles (id)
--     ON DELETE CASCADE

-- );



-- CREATE TABLE partymembers
-- (
--   id INT NOT NULL AUTO_INCREMENT,
--   memberId VARCHAR(255) NOT NULL,
--   partyId INT NOT NULL,
--   creatorId VARCHAR(255) NOT NULL,

--     PRIMARY KEY (id),

--     FOREIGN KEY (creatorId)
--     REFERENCES profiles (id)
--     ON DELETE CASCADE,

--     FOREIGN KEY (memberId)
--     REFERENCES profiles (id)
--     ON DELETE CASCADE,

--     FOREIGN KEY (partyId)
--     REFERENCES parties (id)
--     ON DELETE CASCADE

-- )