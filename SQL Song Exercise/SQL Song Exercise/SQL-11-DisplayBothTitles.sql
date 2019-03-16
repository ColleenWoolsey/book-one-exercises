/* Modify the previous query to also display the title of the album. */

SELECT TOP 1 MAX(SongLength) as MaxLength, S.Title, A.Title
	 FROM Song S JOIN Album A
	 ON S.AlbumId = A.Id
	 GROUP BY S.Title, A.Title
	 ORDER BY MaxLength DESC
	 
    