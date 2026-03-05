CREATE DATABASE IF NOT EXISTS LibreriaTest;
USE LibreriaTest;

CREATE TABLE Libri (
   id INT PRIMARY KEY,
   titolo VARCHAR(100),
   autore VARCHAR(100),
   genere VARCHAR(50),
   anno_pubblicazione INT,
   prezzo DECIMAL(6,2)
);

CREATE TABLE Vendite (
   id INT PRIMARY KEY AUTO_INCREMENT,
   id_libro INT,
   data_vendita DATE,
   quantita INT,
   negozio VARCHAR(100)
);
-- Inserimento 30 Libri
INSERT INTO Libri (id, titolo, autore, genere, anno_pubblicazione, prezzo) VALUES
(1, 'It', 'Stephen King', 'Horror', 1986, 25.00), (2, 'Shining', 'Stephen King', 'Horror', 1977, 18.50),
(3, 'Il Signore degli Anelli', 'J.R.R. Tolkien', 'Fantasy', 1954, 30.00), (4, 'Harry Potter', 'J.K. Rowling', 'Fantasy', 1997, 15.00),
(5, 'Il Codice Da Vinci', 'Dan Brown', 'Giallo', 2003, 12.00), (6, 'Angeli e Demoni', 'Dan Brown', 'Giallo', 2000, 11.50),
(7, 'Misery', 'Stephen King', 'Horror', 1987, 20.00), (8, '1984', 'George Orwell', 'Fantascienza', 1949, 10.00),
(9, 'La Variante di Lüneburg', 'Paolo Maurensig', 'Giallo', 1993, 9.00), (10, 'Il Trono di Spade', 'G.R.R. Martin', 'Fantasy', 1996, 22.00),
(11, 'The Outsider', 'Stephen King', 'Horror', 2018, 19.90), (12, 'L’istituto', 'Stephen King', 'Horror', 2019, 21.00),
(13, 'Il Suggeritore', 'Donato Carrisi', 'Giallo', 2009, 14.00), (14, 'La ragazza del treno', 'Paula Hawkins', 'Giallo', 2015, 13.00),
(15, 'Sotto cupola', 'Stephen King', 'Fantascienza', 2009, 24.00), (16, 'L’ombra dello scorpione', 'Stephen King', 'Horror', 1978, 28.00),
(17, 'Fairy Tale', 'Stephen King', 'Fantasy', 2022, 23.00), (18, 'Io uccido', 'Giorgio Faletti', 'Giallo', 2002, 16.00),
(19, 'Dracula', 'Bram Stoker', 'Horror', 1897, 10.50), (20, 'Orgoglio e Pregiudizio', 'Jane Austen', 'Classico', 1813, 8.00),
(21, 'Il ritratto di Dorian Gray', 'Oscar Wilde', 'Classico', 1890, 9.50), (22, 'Cujo', 'Stephen King', 'Horror', 1981, 15.00),
(23, 'L’ultima legione', 'Valerio Massimo Manfredi', 'Storico', 2002, 12.50), (24, 'Il nome della rosa', 'Umberto Eco', 'Giallo', 1980, 14.00),
(25, 'Origin', 'Dan Brown', 'Giallo', 2017, 20.00), (26, 'Scontro di re', 'G.R.R. Martin', 'Fantasy', 1998, 22.00),
(27, 'Pet Sematary', 'Stephen King', 'Horror', 1983, 17.00), (28, 'Carrie', 'Stephen King', 'Horror', 1974, 12.00),
(29, 'Billy Summers', 'Stephen King', 'Giallo', 2021, 21.50), (30, 'Later', 'Stephen King', 'Horror', 2021, 18.00);

-- Inserimento 30 Vendite
INSERT INTO Vendite (id_libro, data_vendita, quantita, negozio) VALUES
(1, '2021-05-10', 2, 'Libreria Centrale'), (2, '2020-03-15', 1, 'BookCity Milano'),
(3, '2022-11-20', 1, 'Cartoleria Roma'), (4, '2021-06-12', 3, 'Fantasy Store'),
(5, '2020-01-25', 1, 'Libreria Centrale'), (11, '2023-01-10', 5, 'Horror Store'),
(12, '2022-04-18', 2, 'BookCity Milano'), (1, '2021-12-05', 4, 'Book & Coffee'),
(7, '2020-08-14', 1, 'Mondadori Store'), (17, '2022-09-30', 2, 'Fantasy Store'),
(29, '2021-10-10', 1, 'Libreria Centrale'), (30, '2022-02-14', 3, 'BookCity Milano'),
(10, '2021-03-22', 1, 'Cartoleria Roma'), (14, '2020-05-05', 2, 'Giallo Store'),
(25, '2022-12-01', 1, 'Mondadori Store'), (1, '2021-07-20', 2, 'Book & News'),
(2, '2020-11-11', 1, 'Libreria Centrale'), (99, '2021-01-10', 5, 'Old Book Store'), -- ORFANO
(100, '2022-05-15', 2, 'BookCity Milano'), -- ORFANO
(15, '2021-08-08', 3, 'Sci-Fi Store'), (16, '2020-04-25', 1, 'Libreria Centrale'),
(17, '2023-02-01', 2, 'Fantasy Store'), (18, '2022-06-30', 4, 'BookCity Milano'),
(19, '2021-09-12', 1, 'Horror Store'), (20, '2020-12-25', 1, 'Classico Store'),
(21, '2021-04-04', 2, 'Libreria Centrale'), (22, '2022-01-20', 3, 'Book & More'),
(23, '2020-07-07', 1, 'Storico Store'), (24, '2021-11-30', 2, 'Cartoleria Roma'),
(27, '2022-03-15', 1, 'BookCity Milano');

-- Esercizio 1 – INNER JOIN + WHERE + LIKE
SELECT l.titolo, l.autore, v.data_vendita, v.negozio
FROM Libri l
INNER JOIN Vendite v ON l.id = v.id_libro
WHERE l.autore LIKE '%King%'; 
-- Esercizio 2 – LEFT JOIN + WHERE + BETWEEN
SELECT l.titolo, l.anno_pubblicazione, l.prezzo, v.data_vendita
FROM Libri l
LEFT JOIN Vendite v ON l.id = v.id_libro
WHERE l.anno_pubblicazione BETWEEN 2000 AND 2010; 
-- Esercizio 3 – INNER JOIN + WHERE + IN 
SELECT 
    l.titolo, 
    v.negozio, 
    v.quantita, 
    (v.quantita * l.prezzo) AS prezzo_totale
FROM Libri l
INNER JOIN Vendite v ON l.id = v.id_libro
WHERE v.negozio IN ('Libreria Centrale', 'BookCity Milano', 'Cartoleria Roma'); 

-- Esercizio 4 – RIGHT JOIN + WHERE + LIKE + BETWEEN 
SELECT l.titolo, v.data_vendita, l.prezzo, v.quantita
FROM Libri l
RIGHT JOIN Vendite v ON l.id = v.id_libro
WHERE (v.data_vendita BETWEEN '2020-01-01' AND '2022-12-31')
  AND v.negozio LIKE '%Book%'; 
   -- Esercizio 5 – INNER JOIN + WHERE combinato 
   SELECT l.titolo, l.autore, l.prezzo, v.data_vendita
FROM Libri l
INNER JOIN Vendite v ON l.id = v.id_libro
WHERE l.genere IN ('Fantasy', 'Horror', 'Giallo')
  AND l.anno_pubblicazione > 2015
  AND v.negozio LIKE '%Store%'
ORDER BY v.data_vendita DESC; 