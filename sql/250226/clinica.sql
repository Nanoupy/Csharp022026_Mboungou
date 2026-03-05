CREATE DATABASE IF NOT EXISTS clinica;
USE clinica;
-- 1. Specializzazione (Tabella Indipendente)
CREATE TABLE Specializzazione (
    id_specializzazione INT PRIMARY KEY AUTO_INCREMENT,
    nome VARCHAR(100) UNIQUE NOT NULL
);

-- 2. Reparto (Tabella Indipendente)
CREATE TABLE Reparto (
    id_reparto INT PRIMARY KEY AUTO_INCREMENT,
    nome VARCHAR(100) NOT NULL,
    numero_posti INT NOT NULL CHECK (numero_posti > 0) 
);

-- 3. Paziente (Tabella Indipendente)
CREATE TABLE Paziente (
    id_paziente INT PRIMARY KEY AUTO_INCREMENT,
    nome VARCHAR(100) NOT NULL, 
    cognome VARCHAR(100) NOT NULL, 
    data_nascita DATE NOT NULL,
    codice_fiscale CHAR(16) UNIQUE NOT NULL,
    telefono VARCHAR(20),
    email VARCHAR(100), 
    data_registrazione DATETIME DEFAULT CURRENT_TIMESTAMP
);

-- 4. Medico (Dipende da Specializzazione)
CREATE TABLE Medico (
    id_medico INT PRIMARY KEY AUTO_INCREMENT,
    nome VARCHAR(100) NOT NULL,
    cognome VARCHAR(100) NOT NULL,
    id_specializzazione INT, 
    stipendio DECIMAL(10,2) CHECK (stipendio > 0),
    data_assunzione DATE NOT NULL, 
    FOREIGN KEY (id_specializzazione) REFERENCES Specializzazione(id_specializzazione) ON DELETE SET NULL
);

-- 5. Appuntamento (Dipende da Paziente e Medico)
CREATE TABLE Appuntamento (
    id_appuntamento INT PRIMARY KEY AUTO_INCREMENT, 
    id_paziente INT, 
    id_medico INT, 
    data_appuntamento DATETIME NOT NULL, 
    stato ENUM('prenotato', 'completato', 'annullato') DEFAULT 'prenotato', 
    costo DECIMAL(10,2) DEFAULT 0 CHECK (costo >= 0), 
    FOREIGN KEY (id_paziente) REFERENCES Paziente(id_paziente) ON DELETE CASCADE,
    FOREIGN KEY (id_medico) REFERENCES Medico(id_medico) ON DELETE CASCADE
);

-- 6. Ricovero (Dipende da Paziente e Reparto)
CREATE TABLE Ricovero (
    id_ricovero INT PRIMARY KEY AUTO_INCREMENT,
    id_paziente INT, 
    id_reparto INT, 
    data_ingresso DATE NOT NULL,
    data_dimissione DATE NULL, 
    CONSTRAINT chk_date CHECK (data_dimissione IS NULL OR data_dimissione > data_ingresso), 
    FOREIGN KEY (id_paziente) REFERENCES Paziente(id_paziente) ON DELETE CASCADE, 
    FOREIGN KEY (id_reparto) REFERENCES Reparto(id_reparto) ON DELETE CASCADE 
);

-- 7. Prescrizione (Dipende da Appuntamento)
CREATE TABLE Prescrizione (
    id_prescrizione INT PRIMARY KEY AUTO_INCREMENT, 
    id_appuntamento INT,
    descrizione TEXT NOT NULL, 
    data_prescrizione DATE NOT NULL,
    FOREIGN KEY (id_appuntamento) REFERENCES Appuntamento(id_appuntamento) ON DELETE CASCADE
);

-- 8. Pagamento (Dipende da Appuntamento)
CREATE TABLE Pagamento (
    id_pagamento INT PRIMARY KEY AUTO_INCREMENT, 
    id_appuntamento INT, 
    importo DECIMAL(10,2) NOT NULL,
    metodo_pagamento VARCHAR(50),
    data_pagamento DATETIME DEFAULT CURRENT_TIMESTAMP, 
    FOREIGN KEY (id_appuntamento) REFERENCES Appuntamento(id_appuntamento) ON DELETE CASCADE 
);
-- 2 Popolamento Dati 
-- Inserimento Specializzazioni e Reparti
INSERT INTO Specializzazione (nome) VALUES ('Cardiologia'), ('Ortopedia'), ('Neurologia'), ('Pediatria');
INSERT INTO Reparto (nome, numero_posti) VALUES ('Reparto A', 10), ('Reparto B', 5);

-- Inserimento Medici ( per 10 medici)
INSERT INTO Medico (nome, cognome, id_specializzazione, stipendio, data_assunzione) VALUES 
('Mario', 'Rossi', 1, 4500.00, '2020-01-10'), ('Luca', 'Bianchi', 2, 4200.00, '2021-03-15'),
('Paola', 'Verdi', 3, 4800.00, '2019-05-20'), ('Anna', 'Neri', 4, 3900.00, '2022-02-01'),
('Marco', 'Galli', 1, 4600.00, '2018-11-12'), ('Elena', 'Rizzo', 2, 4100.00, '2020-07-25'),
('Roberto', 'Ferri', 3, 5000.00, '2017-09-30'), ('Sara', 'Bruni', 4, 4000.00, '2021-12-05'),
('Fabio', 'Gatti', 1, 4700.00, '2019-01-15'), ('Giulia', 'Leoni', 2, 4300.00, '2022-06-10');

-- Inserimento Pazienti ( per 20 pazienti)
INSERT INTO Paziente (nome, cognome, data_nascita, codice_fiscale) VALUES 
('Giuseppe', 'Verdi', '1980-05-20', 'VRDGPP80E20F205Z'), ('Anna', 'Neri', '1992-11-12', 'NRNNAA92S52H501X'),
('Pietro', 'Rossi', '1975-03-15', 'RSSPTR75C15F205R'), ('Maria', 'Bianchi', '1988-07-22', 'BNCMRA88L62H501T'),
('Filippo', 'Rizzo', '1960-01-30', 'RZZFPP60A30L219G'), ('Lucia', 'Galli', '1995-09-05', 'GLLLCA95P45F205W'),
('Carlo', 'Ferri', '1955-12-10', 'FRRCRL55T10H501Q'), ('Sonia', 'Gatti', '2001-04-18', 'GTTSNA01D58L219Y'),
('Matteo', 'Bruni', '1982-08-25', 'BRNMTT82M25F205K'), ('Elena', 'Costa', '1970-02-14', 'CSTLNE70B54H501V'),
('Giovanni', 'Russo', '1985-11-30', 'RSSGNN85S30L219J'), ('Clara', 'Serra', '1990-06-12', 'SRRCLR90H52F205U'),
('Paolo', 'Manni', '1968-05-05', 'MNNPLA68E05H501D'), ('Rita', 'Dati', '1977-10-20', 'DTARTI77R60L219C'),
('Enzo', 'Bassi', '1998-12-01', 'BSSNZE98T01F205O'), ('Marta', 'Fonti', '2005-03-25', 'FNTMRT05C65H501X'),
('Simone', 'Lupi', '1983-09-15', 'LPUSMN83P15L219Z'), ('Valeria', 'Pini', '1991-01-10', 'PNIVLR91A50F205B'),
('Oscar', 'Valli', '1972-04-04', 'VLLSCR72D04H501N'), ('Nadia', 'Santi', '1989-08-08', 'SNTNDA89M48L219F');

-- Inserimento Appuntamenti (Esempio per 30 appuntamenti)
INSERT INTO Appuntamento (id_paziente, id_medico, data_appuntamento, stato, costo) VALUES 
(1, 1, '2024-02-01 10:00:00', 'completato', 120.00), (1, 2, '2024-02-15 11:30:00', 'completato', 150.00),
(1, 1, '2024-02-20 09:00:00', 'completato', 120.00), (1, 3, '2024-02-25 15:00:00', 'completato', 200.00),
(1, 5, '2024-03-01 10:30:00', 'completato', 130.00), (2, 4, '2024-01-10 16:00:00', 'completato', 100.00),
(3, 5, '2024-01-12 09:00:00', 'completato', 130.00), (4, 1, '2024-01-15 11:00:00', 'completato', 120.00),
(5, 2, '2024-01-18 14:00:00', 'completato', 150.00), (6, 3, '2024-01-20 08:30:00', 'completato', 200.00),
(7, 4, '2024-01-22 17:00:00', 'completato', 100.00), (8, 5, '2024-01-25 10:00:00', 'completato', 130.00),
(9, 1, '2024-01-28 09:30:00', 'completato', 120.00), (10, 2, '2024-01-30 15:30:00', 'completato', 150.00),
(11, 3, '2024-02-02 12:00:00', 'completato', 200.00), (12, 4, '2024-02-04 11:00:00', 'completato', 100.00),
(13, 5, '2024-02-06 08:00:00', 'completato', 130.00), (14, 1, '2024-02-08 14:00:00', 'completato', 120.00),
(15, 2, '2024-02-10 16:30:00', 'completato', 150.00), (16, 3, '2024-02-12 10:00:00', 'completato', 200.00),
(17, 4, '2024-02-14 09:00:00', 'completato', 100.00), (18, 5, '2024-02-16 11:30:00', 'completato', 130.00),
(19, 1, '2024-02-18 15:00:00', 'completato', 120.00), (20, 2, '2024-02-20 17:00:00', 'completato', 150.00),
(1, 6, '2024-02-22 08:30:00', 'completato', 140.00), (2, 7, '2024-02-24 14:00:00', 'completato', 180.00),
(3, 8, '2024-02-26 10:00:00', 'completato', 110.00), (4, 9, '2024-02-28 11:00:00', 'completato', 135.00),
(5, 10, '2024-03-02 16:00:00', 'completato', 125.00), (6, 6, '2024-03-04 09:30:00', 'completato', 140.00);

-- Inserimento ricovero ( per 10 ricoveri) 
INSERT INTO Ricovero (id_paziente, id_reparto, data_ingresso, data_dimissione) VALUES 
(1, 1, '2024-01-01', '2024-01-05'), 
(1, 1, '2024-02-10', '2024-02-15'), 
(2, 2, '2024-01-12', '2024-01-18'), 
(3, 1, '2024-02-01', '2024-02-08'), 
(4, 2, '2024-02-20', '2024-02-25'), 
(5, 1, '2024-03-01', NULL),       
(6, 2, '2024-03-02', NULL),        
(7, 1, '2024-02-15', '2024-02-22'),
(8, 2, '2024-01-05', '2024-01-10'),
(9, 1, '2024-03-05', NULL); 

---- Inserimento pagamenti ( per 10 pagamenti) 
INSERT INTO Pagamento (id_appuntamento, importo, metodo_pagamento, data_pagamento) VALUES 
(1, 120.00, 'Carta di Credito', '2024-02-01'), 
(2, 150.00, 'Contanti', '2024-02-15'),       
(3, 120.00, 'Bancomat', '2024-02-20'),        
(4, 200.00, 'Carta di Credito', '2024-02-25'),
(5, 130.00, 'Contanti', '2024-03-01'),
(6, 100.00, 'Bancomat', '2024-01-10'),
(7, 130.00, 'Carta di Credito', '2024-01-12'),
(8, 120.00, 'Contanti', '2024-01-15'),
(9, 150.00, 'Bancomat', '2024-01-18'),
(10, 200.00, 'Carta di Credito', '2024-01-20'); 

-- Inserimento 10 Prescrizioni
INSERT INTO Prescrizione (id_appuntamento, descrizione, data_prescrizione) VALUES 
(1, 'Riposo assoluto per 5 giorni e monitoraggio pressione.', '2024-02-01'),
(2, 'Applicazione ghiaccio 3 volte al giorno e pomata antinfiammatoria.', '2024-02-15'),
(3, 'Analisi del sangue complete e controllo colesterolo.', '2024-02-20'),
(4, 'Risonanza magnetica nucleare encefalo.', '2024-02-25'),
(5, 'Dieta iposodica e camminata giornaliera di 30 minuti.', '2024-03-01'),
(6, 'Sciroppo per la tosse, 10ml ogni 8 ore per 5 giorni.', '2024-01-10'),
(7, 'Fisioterapia riabilitativa 2 volte a settimana.', '2024-01-12'),
(8, 'Elettrocardiogramma sotto sforzo.', '2024-01-15'),
(9, 'Tutore rigido per il polso da tenere la notte.', '2024-01-18'),
(10, 'Controllo neurologico tra 6 mesi.', '2024-01-20');
-- 3 Risoluzione Query 
--- QUERY 1: Appuntamenti per medico (ordinati per impegno)
SELECT m.cognome, m.nome, COUNT(a.id_appuntamento) AS tot_appuntamenti
FROM Medico m
LEFT JOIN Appuntamento a ON m.id_medico = a.id_medico
GROUP BY m.id_medico
ORDER BY tot_appuntamenti DESC; 

-- QUERY 2: Pazienti con più di 3 appuntamenti 
SELECT p.cognome, p.nome, COUNT(a.id_appuntamento) AS tot_visite
FROM Paziente p
JOIN Appuntamento a ON p.id_paziente = a.id_paziente
GROUP BY p.id_paziente
HAVING tot_visite > 3; 
-- QUERY 3: Incasso totale per ogni medico
SELECT m.cognome, m.nome, SUM(a.costo) AS incasso_totale
FROM Medico m
JOIN Appuntamento a ON m.id_medico = a.id_medico
WHERE a.stato = 'completato'
GROUP BY m.id_medico; 
-- QUERY 4: Medico con stipendio più alto per specializzazione 
SELECT nome, cognome, nome_specializzazione, stipendio
FROM (
    SELECT m.nome, m.cognome, s.nome AS nome_specializzazione, m.stipendio,
           RANK() OVER (PARTITION BY s.id_specializzazione ORDER BY m.stipendio DESC) as rnk
    FROM Medico m
    JOIN Specializzazione s ON m.id_specializzazione = s.id_specializzazione
) as ranking
WHERE rnk = 1; 
-- QUERY 5: Paziente che ha speso di più 
SELECT p.nome, p.cognome, SUM(pay.importo) as spesa_totale
FROM Paziente p
JOIN Appuntamento a ON p.id_paziente = a.id_paziente
JOIN Pagamento pay ON a.id_appuntamento = pay.id_appuntamento
GROUP BY p.id_paziente
ORDER BY spesa_totale DESC
LIMIT 1;
-- QUERY 6: Tasso di occupazione reparti 
SELECT r.nome, 
       (COUNT(ric.id_ricovero) / r.numero_posti) * 100 AS tasso_occupazione
FROM Reparto r
LEFT JOIN Ricovero ric ON r.id_reparto = ric.id_reparto 
     AND ric.data_dimissione IS NULL -- Ricoverati attuali
GROUP BY r.id_reparto; 
-- QUERY 7: Medici inattivi negli ultimi 30 giorni 
SELECT m.nome, m.cognome
FROM Medico m
WHERE NOT EXISTS (
    SELECT 1 FROM Appuntamento a 
    WHERE a.id_medico = m.id_medico 
    AND a.data_appuntamento >= DATE_SUB(CURDATE(), INTERVAL 30 DAY)
); 
-- QUERY 8: Specializzazione con più incasso 
SELECT s.nome, SUM(a.costo) as incasso
FROM Specializzazione s
JOIN Medico m ON s.id_specializzazione = m.id_specializzazione
JOIN Appuntamento a ON m.id_medico = a.id_medico
GROUP BY s.id_specializzazione
ORDER BY incasso DESC
LIMIT 1; 
-- QUERY 9: Incasso mensile e variazione percentuale 
SELECT 
    mese, 
    incasso_attuale,
    LAG(incasso_attuale) OVER (ORDER BY mese) as incasso_precedente,
    ((incasso_attuale - LAG(incasso_attuale) OVER (ORDER BY mese)) / LAG(incasso_attuale) OVER (ORDER BY mese)) * 100 as variazione_perc
FROM (
    SELECT DATE_FORMAT(data_pagamento, '%Y-%m') as mese, SUM(importo) as incasso_attuale
    FROM Pagamento
    GROUP BY mese
) as mensile; 
-- QUERY 10: Pazienti "Top" (Almeno 2 ricoveri, 5 appuntamenti, spesa sopra la media) 
SELECT p.nome, p.cognome
FROM Paziente p
WHERE 
    (SELECT COUNT(*) FROM Ricovero r WHERE r.id_paziente = p.id_paziente) >= 2
    AND 
    (SELECT COUNT(*) FROM Appuntamento a WHERE a.id_paziente = p.id_paziente) >= 5
    AND 
    (SELECT SUM(importo) FROM Pagamento pay 
     JOIN Appuntamento app ON pay.id_appuntamento = app.id_appuntamento 
     WHERE app.id_paziente = p.id_paziente) > (
        SELECT AVG(tot_speso) FROM (
            SELECT SUM(importo) as tot_speso 
            FROM Pagamento pa 
            JOIN Appuntamento ap ON pa.id_appuntamento = ap.id_appuntamento 
            GROUP BY ap.id_paziente
        ) as medie
    ); 
