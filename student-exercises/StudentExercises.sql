DROP TABLE IF EXISTS ExerciseIntersection;
DROP TABLE IF EXISTS Exercise;
DROP TABLE IF EXISTS Instructor;
DROP TABLE IF EXISTS Student;
DROP TABLE IF EXISTS Cohort;

CREATE TABLE Cohort (
  Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
  CohortName VARCHAR(50) NOT NULL
);

CREATE TABLE Student (
  Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
  StudentFirstName VARCHAR(50) NOT NULL,
  StudentLastName VARCHAR(50) NOT NULL,
  StudentSlackHandle VARCHAR(50) NOT NULL,
  CohortId INTEGER NOT NULL,
  CONSTRAINT FK_StudentCohort FOREIGN KEY(CohortId) REFERENCES Cohort(Id)
);

CREATE TABLE Instructor (
  Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
  InstructorFirstName VARCHAR(50) NOT NULL,
  InstructorLastName VARCHAR(50) NOT NULL,
  InstructorSlackHandle VARCHAR(50) NOT NULL,
  CohortId INTEGER NOT NULL,
  CONSTRAINT FK_InstructorCohort FOREIGN KEY(CohortId) REFERENCES Cohort(Id)
);

/* Language goes in square brackets because it's a SQL reserved word */
/* VARCHAR has a maximum length of 4000characters and after that use text */

CREATE TABLE Exercise (
  Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
  ExerciseName VARCHAR(50) NOT NULL,
  [Language] VARCHAR(50) NOT NULL
);

CREATE TABLE ExerciseIntersection (
  Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
  ExerciseId int NOT NULL,
  CONSTRAINT FK_ExerciseIntersectionExercise FOREIGN KEY(ExerciseId) REFERENCES Exercise(Id),
  StudentId int NOT NULL,
  CONSTRAINT FK_ExerciseIntersectionStudent FOREIGN KEY(StudentId) REFERENCES Student(Id),
);

INSERT INTO Cohort (CohortName) VALUES ('Cohort 28');
INSERT INTO Cohort (CohortName) VALUES ('Cohort 29');
INSERT INTO Cohort (CohortName) VALUES ('Cohort 30');

INSERT INTO Student (StudentFirstName, StudentLastName, StudentSlackHandle, CohortId)
VALUES ('Snow', 'White', 'SnowWhite@slack', 1);
INSERT INTO Student (StudentFirstName, StudentLastName, StudentSlackHandle, CohortId)
VALUES ('Dopey', 'Abc', 'DopeyAbc@slack', 2);
INSERT INTO Student (StudentFirstName, StudentLastName, StudentSlackHandle, CohortId)
VALUES ('Grumpy', 'Def', 'GrumpyDef@slack', 3);
INSERT INTO Student (StudentFirstName, StudentLastName, StudentSlackHandle, CohortId)
VALUES ('Sneezy', 'Ghi', 'SneezyGhi@slack', 1);
INSERT INTO Student (StudentFirstName, StudentLastName, StudentSlackHandle, CohortId)
VALUES ('Bashful', 'Jkl', 'BashfulJkl@slack', 2);
INSERT INTO Student (StudentFirstName, StudentLastName, StudentSlackHandle, CohortId)
VALUES ('Doc', 'Mno', 'DocMno@slack', 3);
INSERT INTO Student (StudentFirstName, StudentLastName, StudentSlackHandle, CohortId)
VALUES ('Happy', 'Pqr', 'HappyPqr@slack', 1);
INSERT INTO Student (StudentFirstName, StudentLastName, StudentSlackHandle, CohortId)
VALUES ('Sleepy', 'Stu', 'SleepyStu@slack', 2);
INSERT INTO Student (StudentFirstName, StudentLastName, StudentSlackHandle, CohortId)
VALUES ('Magic', 'Mirror', 'MagicMirror@slack', 3);

INSERT INTO Instructor (InstructorFirstName, InstructorLastName, InstructorSlackHandle, CohortId)
VALUES ('Andy', 'Prince', 'AndyPrince@slack', 2);
INSERT INTO Instructor (InstructorFirstName, InstructorLastName, InstructorSlackHandle, CohortId)
VALUES ('Steve', 'Huntsman', 'SteveHuntsman@slack', 1);
INSERT INTO Instructor (InstructorFirstName, InstructorLastName, InstructorSlackHandle, CohortId)
VALUES ('SQLInsertionAttack', 'Queen', 'Hacker@slack', 2);
INSERT INTO Instructor (InstructorFirstName, InstructorLastName, InstructorSlackHandle, CohortId)
VALUES ('Singsong', 'Birds', 'SingsongBirds@slack', 1);
INSERT INTO Instructor (InstructorFirstName, InstructorLastName, InstructorSlackHandle, CohortId)
VALUES ('Poison', 'Apple', 'PoisonApple@slack', 3);

INSERT INTO Exercise (ExerciseName, Language)
VALUES ('Ternary Traveler', 'JavaScript');
INSERT INTO Exercise (ExerciseName, Language)
VALUES ('Kennel', 'React');
INSERT INTO Exercise (ExerciseName, Language)
VALUES ('Planet and Spaceships', 'C#');
INSERT INTO Exercise (ExerciseName, Language)
VALUES ('Random Numbers', 'C#');

INSERT INTO ExerciseIntersection (ExerciseId, StudentId)
VALUES (1, 1);
INSERT INTO ExerciseIntersection (ExerciseId, StudentId)
VALUES (2, 1);
INSERT INTO ExerciseIntersection (ExerciseId, StudentId)
VALUES (3, 2);
INSERT INTO ExerciseIntersection (ExerciseId, StudentId)
VALUES (4, 2);
INSERT INTO ExerciseIntersection (ExerciseId, StudentId)
VALUES (1, 3);
INSERT INTO ExerciseIntersection (ExerciseId, StudentId)
VALUES (2, 3);
INSERT INTO ExerciseIntersection (ExerciseId, StudentId)
VALUES (3, 4);
INSERT INTO ExerciseIntersection (ExerciseId, StudentId)
VALUES (4, 4);
INSERT INTO ExerciseIntersection (ExerciseId, StudentId)
VALUES (1, 5);
INSERT INTO ExerciseIntersection (ExerciseId, StudentId)
VALUES (2, 5);
INSERT INTO ExerciseIntersection (ExerciseId, StudentId)
VALUES (3, 6);
INSERT INTO ExerciseIntersection (ExerciseId, StudentId)
VALUES (4, 6);
INSERT INTO ExerciseIntersection (ExerciseId, StudentId)
VALUES (1, 7);
INSERT INTO ExerciseIntersection (ExerciseId, StudentId)
VALUES (2, 7);
INSERT INTO ExerciseIntersection (ExerciseId, StudentId)
VALUES (3, 8);
INSERT INTO ExerciseIntersection (ExerciseId, StudentId)
VALUES (4, 8);
INSERT INTO ExerciseIntersection (ExerciseId, StudentId)
VALUES (1, 1);
INSERT INTO ExerciseIntersection (ExerciseId, StudentId)
VALUES (2, 2);

/* Exercise intersection is the main table so don't see students without exercises - NULL 
SELECT s.StudentFirstName,
c.CohortName,
e.ExerciseName
From ExerciseIntersection j
RIGHT JOIN Student s on j.StudentId = s.id
RIGHT JOIN Exercise e on j.ExerciseId = e.id
LEFT JOIN Cohort c on s.CohortId = c.id;

This Lists NULL because student is the main table - Also shows null if there is no cohort
SELECT s.StudentFirstName,
       e.ExerciseName,
       c.CohortName
FROM Student s
LEFT JOIN ExerciseIntersection j on s.Id = j.StudentId
LEFT JOIN Exercise e on j.ExerciseId = e.id
LEFT JOIN Cohort c on s.CohortId = c.id;

What if you wante to select students where there are no exercises - NULL cannot be equal to itself so say ...
WHERE e.ExerciseName IS NOT NULL or IS NULL

What if we wanted to find all of the students who started with "A" - Can't use an = ... So use LIKE
	SELECT s.StudentFirstName,
		   s.StudentLastName
	FROM Student s
	WHERE StudentFirstName LIKE 'B%'; */
