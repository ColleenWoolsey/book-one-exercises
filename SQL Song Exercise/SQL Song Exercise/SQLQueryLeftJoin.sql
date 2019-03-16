/* Write a SELECT query that provides the song titles, album title, and artist name for all of the data 
   you just entered in. Use the LEFT JOIN keyword sequence to connect the tables, and the WHERE keyword
   to filter the results to the album and artist you added.

Reminder: Direction of join matters. Try the following statements and see the difference in results.

SELECT a.Title, s.Title FROM Album a LEFT JOIN Song s ON s.AlbumId = a.AlbumId;
SELECT a.Title, s.Title FROM Song s LEFT JOIN Album a ON s.AlbumId = a.AlbumId;  */

