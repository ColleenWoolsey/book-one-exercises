/* Write a SELECT statement to display how many songs exist for each artist. You'll need to use the COUNT() function and the GROUP BY keyword sequence. */



SELECT COUNT(S.Id) SongCount, A.ArtistName
  FROM [Song] S JOIN Artist A 
    ON S.ArtistId = A.Id
 GROUP BY A.ArtistName
 