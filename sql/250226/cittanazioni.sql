-- 1. Tabella Nazioni
CREATE TABLE country (
    Code CHAR(3) PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    Continent VARCHAR(50),
    Region VARCHAR(100),
    LifeExpectancy DECIMAL(4,1),
    GovernmentForm VARCHAR(100),
    Population INT
);

-- 2. Tabella Città
CREATE TABLE city (
    ID INT PRIMARY KEY AUTO_INCREMENT,
    Name VARCHAR(100) NOT NULL,
    CountryCode CHAR(3),
    Population INT,
    FOREIGN KEY (CountryCode) REFERENCES country(Code)
);

-- 3. Tabella Lingue
CREATE TABLE countrylanguage (
    CountryCode CHAR(3),
    Language VARCHAR(50),
    IsOfficial ENUM('T','F'),
    Percentage DECIMAL(4,1),
    PRIMARY KEY (CountryCode, Language),
    FOREIGN KEY (CountryCode) REFERENCES country(Code)
);

-- Dati Nazioni
INSERT INTO country (Code, Name, Continent, LifeExpectancy, GovernmentForm, Population) VALUES
('ITA', 'Italy', 'Europe', 82.3, 'Republic', 60000000),
('FRA', 'France', 'Europe', 81.1, 'Republic', 67000000),
('USA', 'United States', 'North America', 77.1, 'Federal Republic', 331000000),
('JPN', 'Japan', 'Asia', 83.7, 'Constitutional Monarchy', 126000000),
('DEU', 'Germany', 'Europe', 80.3, 'Federal Republic', 83000000);

-- Dati Città
INSERT INTO city (Name, CountryCode, Population) VALUES
('Rome', 'ITA', 2800000),
('Milan', 'ITA', 1350000),
('Naples', 'ITA', 960000),
('Paris', 'FRA', 2140000),
('Lyon', 'FRA', 513000),
('New York', 'USA', 8330000),
('Los Angeles', 'USA', 3970000),
('Tokyo', 'JPN', 13900000),
('Berlin', 'DEU', 3760000);

-- Dati Lingue
INSERT INTO countrylanguage (CountryCode, Language, IsOfficial, Percentage) VALUES
('ITA', 'Italian', 'T', 94.1),
('FRA', 'French', 'T', 96.0),
('USA', 'English', 'T', 86.2),
('USA', 'Spanish', 'F', 12.0),
('JPN', 'Japanese', 'T', 99.0),
('DEU', 'German', 'T', 95.0); 


 -- 1. nazione e lingua per ogni citta 
 USE world;

SELECT city.Name AS Citta, country.Name AS Nazione, Language
FROM city
INNER JOIN country ON city.CountryCode = country.Code
INNER JOIN countrylanguage ON country.Code = countrylanguage.CountryCode;

-- 2. numeri di citta per nazione 
USE world;

SELECT country.Name AS Nazione, COUNT(city.id) AS NumeroCitta
FROM country
INNER JOIN city ON country.Code = city.CountryCode
GROUP BY country.Code
ORDER BY NumeroCitta DESC;

 -- 3. nazione con alta aspettativa di lingua 
 USE world;
SELECT country.Name, LifeExpectancy, Language
FROM country
INNER JOIN countrylanguage ON country.Code = countrylanguage.CountryCode
WHERE GovernmentForm LIKE '%Republic%' 
  AND LifeExpectancy > 70; 
  
  -- esercizio pagina 60 
   -- 1. Lingue parlate per nazione e percentuale
     USE world;
SELECT country.Name AS Nazione, countrylanguage.Language, countrylanguage.Percentage
FROM country
INNER JOIN countrylanguage ON country.Code = countrylanguage.CountryCode
ORDER BY country.Name, countrylanguage.Percentage DESC; 
    
  -- 2. Percentuale della lingua più parlata per nazione
    USE world;

SELECT CountryCode, MAX(Percentage) AS MaxPercentuale
FROM countrylanguage
GROUP BY CountryCode; 

 -- 3. USE world;

SELECT c.Name AS Nazione, cl.Language, cl.Percentage
FROM country AS c
INNER JOIN countrylanguage AS cl ON c.Code = cl.CountryCode
WHERE (cl.CountryCode, cl.Percentage) IN (
    -- Questa è la SubQuery derivata dall'Esercizio 2
    SELECT CountryCode, MAX(Percentage)
    FROM countrylanguage
    GROUP BY CountryCode
)
ORDER BY cl.Percentage DESC; 

-- extra 
   USE world;

SELECT Continent, Language, TotaleParlanti
FROM (
    SELECT 
        c.Continent, 
        cl.Language, 
        SUM(c.Population * cl.Percentage / 100) AS TotaleParlanti,
        ROW_NUMBER() OVER (
            PARTITION BY c.Continent 
            ORDER BY SUM(c.Population * cl.Percentage / 100) DESC
        ) AS Posizione
    FROM country AS c
    INNER JOIN countrylanguage AS cl ON c.Code = cl.CountryCode
    GROUP BY c.Continent, cl.Language
) AS ClassificaLingue
WHERE Posizione <= 3
ORDER BY Continent, TotaleParlanti DESC;  
-- esercizio pagina 67
-- Aggiorniamo alcuni dati per il test
UPDATE country SET SurfaceArea = 301340, IndepYear = 1861 WHERE Code = 'ITA';
UPDATE country SET SurfaceArea = 551695, IndepYear = 843 WHERE Code = 'FRA';
UPDATE country SET SurfaceArea = 9833517, IndepYear = 1776 WHERE Code = 'USA';
UPDATE country SET SurfaceArea = 377975, IndepYear = NULL WHERE Code = 'JPN'; 
-- 1. superficie e indipendenza 
SELECT 
    Name AS Nazione,
    -- Controllo superficie
    CASE 
        WHEN SurfaceArea >= 100000 THEN 'SÌ (Superiore a 100.000)'
        ELSE 'NO (Inferiore a 100.000)'
    END AS Superficie_Sopra_100k,
    -- Controllo anno indipendenza
    IFNULL(CAST(IndepYear AS CHAR), 'Anno non presente') AS Anno_Indipendenza
FROM country;
-- 2. query 
-- --- prova a  modificore i valori  
SET @codice_nazione = 'ITA';  -- Il codice scelto dall'utente
SET @popolazione_minima = 1000000; -- Filtro popolazione
SET @ordine_decrescente = 1;  -- 1 per DESC, 0 per ASC
SET @mostra_nome_nazione = 1; -- 1 per SI, 0 per NO
-- -----------------------------------------------------------

SELECT 
    ci.Name AS Citta,
    ci.CountryCode,
    ci.Population,
    -- Mostra il nome nazione solo se l'utente ha scelto 1
    IF(@mostra_nome_nazione = 1, co.Name, 'Nascosto') AS Nome_Nazione
FROM city ci
JOIN country co ON ci.CountryCode = co.Code
WHERE ci.CountryCode = @codice_nazione 
  AND ci.Population >= @popolazione_minima
ORDER BY 
    -- Logica per ordinamento dinamico basato sulla scelta utente
    CASE WHEN @ordine_decrescente = 1 THEN ci.Population END DESC,
    CASE WHEN @ordine_decrescente = 0 THEN ci.Population END ASC;
    -- esercizio pagina 80 
    -- 1. Creazione della VIEW
    USE world;
CREATE VIEW CittaItaliane AS
SELECT Name, CountryCode, Population
FROM city
WHERE CountryCode = 'ITA';
-- 2. Query sulla vista appena creata
SELECT *
FROM CittaItaliane
WHERE Population < 100000
ORDER BY Population DESC; 
