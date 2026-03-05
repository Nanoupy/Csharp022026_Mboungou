CREATE TABLE IF NOT EXISTS Clienti (
    id INT PRIMARY KEY AUTO_INCREMENT,
    nome VARCHAR(100),
    cognome VARCHAR(100),
    email VARCHAR(100),
    eta INT,
    citta VARCHAR(100)
);

-- Inserimento di 20 record di esempio
INSERT INTO Clienti (nome, cognome, email, eta, citta) VALUES
('Andrew', 'Rossi', 'andrew.rossi@gmail.com', 25, 'Roma'),
('Mireil', 'Verdi', 'mireil.v@outlook.it', 32, 'Milano'),
('Marco', 'Neri', 'm.neri@gmail.com', 45, 'Napoli'),
('Alessia', 'Bravi', 'ale.b@yahoo.com', 30, 'Roma Nord'),
('Luc', 'Russo', 'luca88@gmail.com', 38, 'Torino'),
('Antonio', 'Gallo', 'antogallo@libero.it', 50, 'Palermo'),
('Giulia', 'Costa', 'giuly@gmail.com', 22, 'Genova'),
('Marta', 'Bruno', 'm.bruno@gmail.com', 34, 'Firenze'),
('Alberto', 'Rizzo', 'alberto.rizzo@tiscali.it', 29, 'Roma Est'),
('Sara', 'Santi', 'sara.s@gmail.com', 41, 'Bologna'),
('Paolo', 'Fabbri', 'fabbri.p@me.com', 35, 'Verona'),
('Annamaria', 'Grassi', 'anna.grassi@gmail.com', 28, 'Bari'),
('Roberto', 'Mazza', 'robym@gmail.com', 33, 'Roma Centro'),
('Elena', 'Fred', 'elena.f@gmail.com', 40, 'Venezia'),
('Alessandro', 'Longo', 'alex.longo@fastweb.it', 37, 'Cagliari'),
('Chiara', 'Parodi', 'chiara.p@gmail.com', 19, 'Genova'),
('Alice', 'Basso', 'alice.basso@gmail.com', 31, 'Padova'),
('Matteo', 'Serra', 'm.serra@outlook.com', 27, 'Roma'),
('Arianna', 'Negri', 'arianna.n@gmail.com', 42, 'Milano'),
('Angelo', 'Fonti', 'a.fonti@gmail.com', 36, 'Torino');

-- Clienti con email su dominio Gmail 
SELECT * FROM Clienti 
WHERE email LIKE '%@gmail.com';
-- Clienti con nome che inizia con la lettera 'A' 
SELECT * FROM Clienti 
WHERE nome LIKE 'A%'; 
-- Clienti con cognome che contiene esattamente 5 lettere 
SELECT * FROM Clienti 
WHERE cognome LIKE '_____'; 

-- Clienti con età compresa tra 30 e 40 anni (inclusi) 
SELECT * FROM Clienti 
WHERE eta BETWEEN 30 AND 40; 
-- Clienti che vivono in città il cui nome contiene 'roma' 
SELECT * FROM Clienti 
WHERE citta LIKE '%roma%'; 

