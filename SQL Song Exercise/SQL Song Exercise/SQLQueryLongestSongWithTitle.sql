/* Using MAX() function, write a select statement to find the song with the longest duration.
   The result should display the song title and the duration. */

   SELECT TOP 1 MAX(SongLength) as MaxLength, Title
	 FROM Song
	 GROUP BY Title
	 ORDER BY MaxLength DESC
	
 
