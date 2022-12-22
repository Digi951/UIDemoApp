-- SQLite
CREATE TABLE User
(
    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
    Username TEXT NOT NULL,
    Password TEXT NOT NULL,
    NAME TEXT NOT NULL,
    Lastname TEXT NOT NULL,
    Email TEXT NOT NULL
)

INSERT INTO User VALUES (NULL, "admin", "admin", "Digi951", " ", "Digi@gmail.de")
INSERT INTO User VALUES (NULL, "rainer", "1234", "Rainer", "Zufall", "rainerz@gmail.de")
INSERT INTO User VALUES (NULL, "frank", "4321", "Frank", "Furt", "frankf@gmail.de")
INSERT INTO User VALUES (NULL, "jim", "0000", "Jim", "Panse", "jimp@gmail.de")