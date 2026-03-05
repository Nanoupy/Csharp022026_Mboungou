CREATE TABLE Libri (
    id INT PRIMARY KEY,
    titolo VARCHAR(100),
    autore VARCHAR(100),
    genere VARCHAR(50),
    prezzo DECIMAL(5,2),
    anno_pubblicazione INT
);

-- Inserimento di 6 nuovi libri
INSERT INTO Libri (id, titolo, autore, genere, prezzo, anno_pubblicazione) VALUES
(1, 'Il nome della rosa', 'Umberto Eco', 'Storico', 18.50, 1980),
(2, 'Il problema dei tre corpi', 'Liu Cixin', 'Fantascienza', 22.00, 2008),
(3, 'Sapiens', 'Yuval Noah Harari', 'Saggistica', 25.00, 2011),
(4, 'Dune', 'Frank Herbert', 'Fantascienza', 15.90, 1965),
(5, 'L’amica geniale', 'Elena Ferrante', 'Narrativa', 19.00, 2011),
(6, 'Circe', 'Madeline Miller', 'Fantasy', 14.50, 2018);

-- Aggregazione e Raggruppamento (GROUP BY)
SELECT 
    genere, 
    COUNT(*) AS numero_totale_libri, 
    ROUND(AVG(prezzo), 2) AS prezzo_medio
FROM Libri
GROUP BY genere
ORDER BY genere ASC;


-- 3. Ordinamento Risultati (ORDER BY)
SELECT * FROM Libri
WHERE anno_pubblicazione > 2010
ORDER BY anno_pubblicazione DESC, prezzo ASC;
