/* Write a SELECT statement to display how many songs exist for each genre. 
You'll need to use the COUNT() function and the GROUP BY keyword sequence.*/

SELECT COUNT(S.Id) as SongCount, G.Label
  FROM [Song] S JOIN Genre G 
    ON S.GenreId = G.Id
 GROUP BY G.Label;