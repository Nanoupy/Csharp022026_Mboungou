
CREATE TABLE Clienti (
    id INT PRIMARY KEY AUTO_INCREMENT,
    nome VARCHAR(100),
    citta VARCHAR(100)
);

CREATE TABLE Ordini (
    id INT PRIMARY KEY AUTO_INCREMENT,
    id_cliente INT,
    data_ordine DATE,
    importo DECIMAL(7,2)
);

-- Inserimento 20 Clienti (alcuni senza ordini)
INSERT INTO Clienti (nome, citta) VALUES 
('Mario Rossi', 'Roma'), ('Luca Bianchi', 'Milano'), ('Anna Verdi', 'Napoli'),
('Giulia Neri', 'Torino'), ('Paolo Brun', 'Venezia'), ('Elena Gialli', 'Bari'),
('Marco Viola', 'Firenze'), ('Sara Rosa', 'Bologna'), ('Fabio Grigio', 'Genova'),
('Alice Arancio', 'Palermo'), ('Roberto Blu', 'Cagliari'), ('Silvia Marrone', 'Verona'),
('Matteo Oro', 'Trieste'), ('Sonia Argento', 'Messina'), ('Pietro Rame', 'Parma'),
('Claudio Ferro', 'Padova'), ('Lucia Zinco', 'Brescia'), ('Enrico Piombo', 'Lecce'),
('Marta Stagno', 'Pisa'), ('Giorgio Bronzo', 'Lucca');

-- Inserimento 20 Ordini (alcuni con id_cliente NULL per testare la RIGHT JOIN)
INSERT INTO Ordini (id_cliente, data_ordine, importo) VALUES 
(1, '2024-01-05', 150.00), (1, '2024-01-10', 50.00), (2, '2024-01-12', 300.00),
(3, '2024-01-15', 25.50), (4, '2024-01-20', 89.90), (5, '2024-01-22', 120.00),
(7, '2024-02-01', 45.00), (8, '2024-02-05', 210.00), (10, '2024-02-10', 30.00),
(10, '2024-02-12', 15.00), (12, '2024-02-15', 500.00), (13, '2024-02-20', 65.00),
(15, '2024-02-25', 90.00), (15, '2024-03-01', 110.00), (16, '2024-03-05', 40.00),
(NULL, '2024-03-06', 99.99), (NULL, '2024-03-07', 150.00), -- Ordini senza cliente
(NULL, '2024-03-08', 200.00), (NULL, '2024-03-09', 10.00), (NULL, '2024-03-10', 5.00);

-- inner join 
SELECT Clienti.nome, Ordini.data_ordine, Ordini.importo
FROM Clienti
INNER JOIN Ordini ON Clienti.id = Ordini.id_cliente; 

-- left join 
SELECT Clienti.nome, Ordini.data_ordine, Ordini.importo
FROM Clienti
LEFT JOIN Ordini ON Clienti.id = Ordini.id_cliente; 

-- right join 
SELECT Clienti.nome, Ordini.data_ordine, Ordini.importo
FROM Clienti
RIGHT JOIN Ordini ON Clienti.id = Ordini.id_cliente;
-- suite page 51 
-- 1. Clienti Attivi /Analisi Fatturato
SELECT 
    c.nome, 
    COUNT(o.id) AS numero_totale_ordini, 
    SUM(o.importo) AS totale_speso
FROM Clienti c
INNER JOIN Ordini o ON c.id = o.id_cliente
GROUP BY c.id, c.nome;

-- 2. Clienti Inattivi /Analisi Marketing
SELECT 
    c.nome, 
    c.citta
FROM Clienti c
LEFT JOIN Ordini o ON c.id = o.id_cliente
WHERE o.id_cliente IS NULL;
-- 3. Ordini Orfani /Data Cleaning
SELECT 
    o.id AS id_ordine, 
    o.data_ordine, 
    o.importo,
    c.nome AS cliente -- Risulterà NULL
FROM Clienti c
RIGHT JOIN Ordini o ON c.id = o.id_cliente
WHERE c.id IS NULL; 

