/* Write a SELECT statement to display how many songs exist for each album. You'll need to use the COUNT() function and the GROUP BY keyword sequence. */



SELECT COUNT(S.Id) Title, A.Title
  FROM [Song] S JOIN Album A 
    ON S.AlbumId = A.Id
 GROUP BY A.Title
 