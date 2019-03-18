
CREATE TABLE Cohort (
  Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
  CohortName TEXT NOT NULL
);

CREATE TABLE Student (
  Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
  StudentFirstName TEXT NOT NULL,
  StudentLastName TEXT NOT NULL,
  StudentSlackHandle TEXT NOT NULL,
  CohortId INTEGER NOT NULL,
  CONSTRAINT FK_StudentCohort FOREIGN KEY(CohortId) REFERENCES Cohort(Id)
);

CREATE TABLE Instructor (
  Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
  InstructorFirstName TEXT NOT NULL,
  InstructorLastName TEXT NOT NULL,
  InstructorSlackHandle TEXT NOT NULL,
  CohortId INTEGER NOT NULL,
  CONSTRAINT FK_InstructorCohort FOREIGN KEY(CohortId) REFERENCES Cohort(Id)
);

CREATE TABLE Exercise (
  Id INTEGER NOT NULL PRIMARY KEY IDENTITY,
  ExerciseName TEXT NOT NULL,
  Language TEXT NOT NULL
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
VALUES ('Steve', 'Huntsman', 'SteveHuntsman@slack', 2);
INSERT INTO Instructor (InstructorFirstName, InstructorLastName, InstructorSlackHandle, CohortId)
VALUES ('SQLInsertionAttack', 'Queen', 'Hacker@slack', 2);
INSERT INTO Instructor (InstructorFirstName, InstructorLastName, InstructorSlackHandle, CohortId)
VALUES ('Singsong', 'Birds', 'SingsongBirds@slack', 2);
INSERT INTO Instructor (InstructorFirstName, InstructorLastName, InstructorSlackHandle, CohortId)
VALUES ('Poison', 'Apple', 'PoisonApple@slack', 2);

INSERT INTO Exercise (ExerciseName, Language)
VALUES ('Ternary Traveler', 'JavaScript');
INSERT INTO Exercise (ExerciseName, Language)
VALUES ('Kennel', 'React');
INSERT INTO Exercise (ExerciseName, Language)
VALUES ('Planet and Spaceships', 'C#');
INSERT INTO Exercise (ExerciseName, Language)
VALUES ('Random Numbers', 'C#');
