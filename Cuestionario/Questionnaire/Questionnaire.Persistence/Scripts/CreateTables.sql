use [MARR.Questionnaire]
go

--Creacion tabla Categories
CREATE TABLE Categories(
id int identity(1,1) not null PRIMARY KEY,
description varchar(255) not null
)

--Creacion tabla Difficulties
CREATE TABLE Difficulties(
id int identity(1,1) not null PRIMARY KEY,
description varchar(255) not null
)

--Creacion tabla Questions
CREATE TABLE Questions(
id int identity(1,1) not null PRIMARY KEY,
categoryId int not null,
difficultyId int not null,
description varchar(255) not null,
questionType int not null,
questionProvider int not null,
correctAnswerId int,
CONSTRAINT FK_Questions_categoryId FOREIGN KEY (categoryId) REFERENCES Categories(id),
CONSTRAINT FK_Questions_difficultyId FOREIGN KEY (difficultyId) REFERENCES Difficulties(id)
)

--Creacion tabla Answers
CREATE TABLE Answers(
id int identity(1,1) not null PRIMARY KEY,
description varchar(255) not null,
questionId int not null,
CONSTRAINT FK_Answers_questionId FOREIGN KEY (questionId) REFERENCES Questions(id)
)

--Creacion tabla AnswerSessions
CREATE TABLE AnswerSessions(
id int identity(1,1) not null PRIMARY KEY,
username varchar(50) not null,
categoryId int not null,
difficultyId int not null,
score float not null,
startTime DateTime not null,
endTime DateTime,
CONSTRAINT FK_AnswerSessions_categoryId FOREIGN KEY (categoryId) REFERENCES Categories(id),
CONSTRAINT FK_AnswerSessions_difficultyId FOREIGN KEY (difficultyId) REFERENCES Difficulties(id)
)

--Creacion tabla UserAnswers
CREATE TABLE UserAnswers(
id int identity(1,1) not null PRIMARY KEY,
questionId int not null,
answerSessionId int not null,
chosenAnswerId int not null,
CONSTRAINT FK_UserAnswers_questionId FOREIGN KEY (questionId) REFERENCES Questions(id),
CONSTRAINT FK_UserAnswers_answerSessionId FOREIGN KEY (answerSessionId) REFERENCES AnswerSessions(id),
CONSTRAINT FK_UserAnswers_chosenAnswerId FOREIGN KEY (chosenAnswerId) REFERENCES Answers(id)
)


ALTER TABLE Questions ADD CONSTRAINT FK_Questions_correctAnswerId FOREIGN KEY (correctAnswerId) REFERENCES Answers(id);
