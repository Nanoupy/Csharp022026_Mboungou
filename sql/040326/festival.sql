CREATE DATABASE IF NOT EXISTS festival;
USE festival;
-- 1. Artista (Singoli o Band)
CREATE TABLE Artista (
    id_artista INT PRIMARY KEY AUTO_INCREMENT,
    nome_darte VARCHAR(100) UNIQUE NOT NULL,
    tipo ENUM('singolo', 'band') NOT NULL,
    genere VARCHAR(50)
);

-- 2. Palco
CREATE TABLE Palco (
    id_palco INT PRIMARY KEY AUTO_INCREMENT,
    nome VARCHAR(50) NOT NULL,
    capacita_max INT NOT NULL CHECK (capacita_max > 0),
    posizione VARCHAR(100)
);

-- 3. Staff Tecnico
CREATE TABLE Staff (
    id_staff INT PRIMARY KEY AUTO_INCREMENT,
    nome VARCHAR(100) NOT NULL,
    ruolo VARCHAR(50),
    id_palco INT,
    FOREIGN KEY (id_palco) REFERENCES Palco(id_palco) ON DELETE SET NULL
);

-- 4. Performance (Evento Live)
CREATE TABLE Performance (
    id_performance INT PRIMARY KEY AUTO_INCREMENT,
    id_artista INT,
    id_palco INT,
    data_ora DATETIME NOT NULL,
    durata_minuti INT DEFAULT 60 CHECK (durata_minuti > 0),
    FOREIGN KEY (id_artista) REFERENCES Artista(id_artista) ON DELETE CASCADE,
    FOREIGN KEY (id_palco) REFERENCES Palco(id_palco) ON DELETE CASCADE
);

-- 5. Collaborazione (Relazione N-M tra Artisti)
CREATE TABLE Collaborazione (
    id_artista1 INT,
    id_artista2 INT,
    id_performance INT,
    PRIMARY KEY (id_artista1, id_artista2, id_performance),
    FOREIGN KEY (id_artista1) REFERENCES Artista(id_artista) ON DELETE CASCADE,
    FOREIGN KEY (id_artista2) REFERENCES Artista(id_artista) ON DELETE CASCADE,
    FOREIGN KEY (id_performance) REFERENCES Performance(id_performance) ON DELETE CASCADE,
    CHECK (id_artista1 < id_artista2) -- Evita duplicati speculari
);

-- 6. Biglietto (Prezzo Variabile)
CREATE TABLE Biglietto (
    id_biglietto INT PRIMARY KEY AUTO_INCREMENT,
    tipologia VARCHAR(50) NOT NULL, -- 'Daily', 'VIP', 'Full-Pass'
    prezzo DECIMAL(10,2) NOT NULL CHECK (prezzo >= 0),
    data_validita DATE NOT NULL
);

-- 7. Spettatore e Pagamento
CREATE TABLE Spettatore (
    id_spettatore INT PRIMARY KEY AUTO_INCREMENT,
    nome VARCHAR(100) NOT NULL,
    email VARCHAR(100) UNIQUE NOT NULL
);

CREATE TABLE Acquisto (
    id_acquisto INT PRIMARY KEY AUTO_INCREMENT,
    id_spettatore INT,
    id_biglietto INT,
    data_pagamento DATETIME DEFAULT CURRENT_TIMESTAMP,
    metodo_pagamento VARCHAR(50),
    FOREIGN KEY (id_spettatore) REFERENCES Spettatore(id_spettatore),
    FOREIGN KEY (id_biglietto) REFERENCES Biglietto(id_biglietto)
);

-- 8. Sponsor
CREATE TABLE Sponsor (
    id_sponsor INT PRIMARY KEY AUTO_INCREMENT,
    nome VARCHAR(100) UNIQUE NOT NULL,
    contributo_totale DECIMAL(15,2) CHECK (contributo_totale > 0)
);

-- Sponsorizzazione associata a Performance
CREATE TABLE Sponsorizzazione (
    id_sponsor INT,
    id_performance INT,
    PRIMARY KEY (id_sponsor, id_performance),
    FOREIGN KEY (id_sponsor) REFERENCES Sponsor(id_sponsor),
    FOREIGN KEY (id_performance) REFERENCES Performance(id_performance)
);
-- popoliamo il db 
-- Artisti e Palchi
INSERT INTO Artista (nome_darte, tipo, genere) VALUES ('RockBand', 'band', 'Rock'), ('DJ Cloud', 'singolo', 'EDM'), ('Indie Duo', 'band', 'Indie');
INSERT INTO Palco (nome, capacita_max) VALUES ('Main Stage', 10000), ('Alternative Tent', 3000);

-- Performance e Biglietti
INSERT INTO Biglietto (tipologia, prezzo, data_validita) VALUES ('Giorno 1', 50.00, '2024-07-01'), ('Giorno 2', 55.00, '2024-07-02');
INSERT INTO Performance (id_artista, id_palco, data_ora) VALUES (1, 1, '2024-07-01 21:00:00'), (2, 1, '2024-07-01 23:00:00'), (1, 2, '2024-07-02 20:00:00');

-- Spettatori e Acquisti
INSERT INTO Spettatore (nome, email) VALUES ('Mario Rossi', 'mario@test.com'), ('Luca Bianchi', 'luca@test.com');
INSERT INTO Acquisto (id_spettatore, id_biglietto, metodo_pagamento) VALUES (1, 1, 'Carta'), (2, 1, 'PayPal'), (1, 2, 'Carta');

-- Collaborazioni
INSERT INTO Collaborazione (id_artista1, id_artista2, id_performance) VALUES (1, 2, 1);

-- query 
-- Q1: Performance per artista
SELECT a.nome_darte, COUNT(p.id_performance) AS tot_performance
FROM Artista a
LEFT JOIN Performance p ON a.id_artista = p.id_artista
GROUP BY a.id_artista;
-- Q2: Incasso totale per giorno 
SELECT b.data_validita, SUM(b.prezzo) AS incasso_giornaliero
FROM Biglietto b
JOIN Acquisto acc ON b.id_biglietto = acc.id_biglietto
GROUP BY b.data_validita; 
-- Q3: Artisti su più di un palco 
SELECT a.nome_darte, COUNT(DISTINCT p.id_palco) AS num_palchi
FROM Artista a
JOIN Performance p ON a.id_artista = p.id_artista
GROUP BY a.id_artista
HAVING num_palchi > 1; 
-- Q4: Palco con più spettatori 
SELECT pa.nome, COUNT(acc.id_acquisto) AS tot_spettatori
FROM Palco pa
JOIN Performance perf ON pa.id_palco = perf.id_palco
JOIN Biglietto b ON DATE(perf.data_ora) = b.data_validita
JOIN Acquisto acc ON b.id_biglietto = acc.id_biglietto
GROUP BY pa.id_palco
ORDER BY tot_spettatori DESC LIMIT 1; 
-- Q5: Artista che ha generato più incasso  
SELECT a.nome_darte, SUM(b.prezzo) AS incasso_generato
FROM Artista a
JOIN Performance p ON a.id_artista = p.id_artista
JOIN Biglietto b ON DATE(p.data_ora) = b.data_validita
JOIN Acquisto acc ON b.id_biglietto = acc.id_biglietto
GROUP BY a.id_artista
ORDER BY incasso_generato DESC LIMIT 1; 
-- Q6: Coppie di artisti con almeno 2 collaborazioni 
SELECT a1.nome_darte AS Artista_1, a2.nome_darte AS Artista_2, COUNT(*) AS num_collaborazioni
FROM Collaborazione c
JOIN Artista a1 ON c.id_artista1 = a1.id_artista
JOIN Artista a2 ON c.id_artista2 = a2.id_artista
GROUP BY id_artista1, id_artista2
HAVING num_collaborazioni >= 2; 
-- Q7: Sponsor su almeno 3 giorni diversi 
SELECT s.nome, COUNT(DISTINCT DATE(p.data_ora)) AS giorni_sponsorizzati
FROM Sponsor s
JOIN Sponsorizzazione sp ON s.id_sponsor = sp.id_sponsor
JOIN Performance p ON sp.id_performance = p.id_performance
GROUP BY s.id_sponsor
HAVING giorni_sponsorizzati >= 3; 
-- Q8: Palco con incasso più alto per ogni giorno 
SELECT giorno, nome_palco, incasso
FROM (
    SELECT DATE(p.data_ora) as giorno, pa.nome as nome_palco, SUM(b.prezzo) as incasso,
           RANK() OVER (PARTITION BY DATE(p.data_ora) ORDER BY SUM(b.prezzo) DESC) as rnk
    FROM Palco pa
    JOIN Performance p ON pa.id_palco = p.id_palco
    JOIN Biglietto b ON DATE(p.data_ora) = b.data_validita
    JOIN Acquisto acc ON b.id_biglietto = acc.id_biglietto
    GROUP BY giorno, pa.id_palco
) t WHERE rnk = 1; 
-- Q9: Variazione percentuale incasso giorno per giorno 
WITH DailyRevenue AS (
    SELECT b.data_validita AS giorno, SUM(b.prezzo) AS totale
    FROM Biglietto b
    JOIN Acquisto acc ON b.id_biglietto = acc.id_biglietto
    GROUP BY giorno
)
SELECT giorno, totale,
       LAG(totale) OVER (ORDER BY giorno) as precedente,
       ROUND(((totale - LAG(totale) OVER (ORDER BY giorno)) / LAG(totale) OVER (ORDER BY giorno)) * 100, 2) as variazione_perc
FROM DailyRevenue; 
-- Q10: Spettatori che hanno partecipato a tutti i giorni del festival 
SELECT s.nome, COUNT(DISTINCT b.data_validita) as giorni_partecipati
FROM Spettatore s
JOIN Acquisto a ON s.id_spettatore = a.id_spettatore
JOIN Biglietto b ON a.id_biglietto = b.id_biglietto
GROUP BY s.id_spettatore
HAVING giorni_partecipati = (SELECT COUNT(DISTINCT data_validita) FROM Biglietto); 