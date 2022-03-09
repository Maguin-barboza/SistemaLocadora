CREATE TABLE Cliente(
	Id INT NOT NULL AUTO_INCREMENT,
    Nome VARCHAR(200) NOT NULL,
    CPF VARCHAR(11) NOT NULL,
    DataNascimento DATETIME NOT NULL,
    PRIMARY KEY(Id),
    INDEX(Nome, CPF)
);

CREATE TABLE Filme(
	Id INT NOT NULL AUTO_INCREMENT,
    Titulo VARCHAR(100) NOT NULL,
    ClassificacaoIndicativa INT,
    Lancamento TINYINT,
    PRIMARY KEY(Id),
    INDEX(Lancamento, Titulo)
);

CREATE TABLE Locacao(
	Id INT NOT NULL AUTO_INCREMENT,
    Id_Cliente INT NOT NULL,
    Id_Filme INT NOT NULL,
    DataLocacao DATETIME NOT NULL,
    DataDevolucao DATETIME NOT NULL,
    PRIMARY KEY(Id),
    FOREIGN KEY (Id_Cliente) REFERENCES Cliente(Id),
    FOREIGN KEY (Id_Filme) REFERENCES Filme(Id)
);