-- Creazione della tabella Vendite
CREATE TABLE IF NOT EXISTS Vendite (
    id INT PRIMARY KEY AUTO_INCREMENT,
    prodotto VARCHAR(100),
    categoria VARCHAR(50),
    quantita INT,
    prezzo_unitario DECIMAL(6,2),
    data_vendita DATE
);

-- Inserimento di 20 record di esempio
INSERT INTO Vendite (prodotto, categoria, quantita, prezzo_unitario, data_vendita) VALUES
('iPhone 15', 'Elettronica', 3, 999.00, '2024-01-10'),
('Samsung TV 4K', 'Elettronica', 1, 650.00, '2024-01-12'),
('Scrivania Legno', 'Arredamento', 2, 120.50, '2024-01-15'),
('Lampada Desk', 'Arredamento', 10, 25.00, '2024-01-16'),
('Caffettiera Espresso', 'Casa', 5, 45.90, '2024-01-20'),
('Microonde', 'Casa', 2, 89.00, '2024-01-22'),
('MacBook Air', 'Elettronica', 1, 1150.00, '2024-02-01'),
('Cuffie Noise Cancelling', 'Elettronica', 4, 199.00, '2024-02-03'),
('Tappeto Soggiorno', 'Arredamento', 1, 150.00, '2024-02-05'),
('Aspirapolvere', 'Casa', 3, 130.00, '2024-02-07'),
('Monitor 27 pollici', 'Elettronica', 2, 240.00, '2024-02-10'),
('Tastiera Meccanica', 'Elettronica', 6, 85.00, '2024-02-12'),
('Sedia Ergonomica', 'Arredamento', 5, 210.00, '2024-02-15'),
('Frullatore', 'Casa', 8, 35.00, '2024-02-18'),
('Mouse Wireless', 'Elettronica', 15, 29.90, '2024-02-20'),
('Libreria Bianca', 'Arredamento', 1, 95.00, '2024-02-22'),
('Set Pentole', 'Casa', 2, 110.00, '2024-02-25'),
('iPad Pro', 'Elettronica', 2, 899.00, '2024-03-01'),
('Divano 3 posti', 'Arredamento', 1, 750.00, '2024-03-03'),
('Bollitore Elettrico', 'Casa', 12, 19.50, '2024-03-05');
-- Totale vendite per categoria 
SELECT categoria, COUNT(*) AS numero_vendite FROM Vendite GROUP BY categoria; 
-- Prezzo medio per categoria 
SELECT categoria, AVG(prezzo_unitario) AS prezzo_medio FROM Vendite GROUP BY categoria;
-- Quantità totale per prodotto 
SELECT prodotto, SUM(quantita) AS quantita_totale FROM Vendite GROUP BY prodotto; 
-- Prezzo MAX e MIN 
SELECT MAX(prezzo_unitario) AS prezzo_max, MIN(prezzo_unitario) AS prezzo_min FROM Vendite; 
-- Conteggio righe totali 
SELECT COUNT(*) AS totale_registrazioni FROM Vendite; 
-- I 5 prodotti più costosi 
SELECT prodotto, prezzo_unitario FROM Vendite ORDER BY prezzo_unitario DESC LIMIT 5; 
-- I 3 meno venduti  
SELECT prodotto, SUM(quantita) AS tot_qta FROM Vendite GROUP BY prodotto ORDER BY tot_qta ASC LIMIT 3; 
 