/* Using MAX() function, write a select statement to find the album with the longest duration.
  The result should display the album title and the duration. */

 

  SELECT TOP 1 MAX(AlbumLength) as MaxLength, Title
	 FROM ALbum
	 GROUP BY Title
	 ORDER BY MaxLength DESC