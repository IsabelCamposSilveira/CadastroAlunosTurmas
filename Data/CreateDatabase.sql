-- Criação do Banco de Dados
CREATE DATABASE BancoEscola;

USE BancoEscola;

-- Criação das Tabelas
CREATE TABLE Alunos (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    Nome VARCHAR(255) NOT NULL,
    DataNascimento DATE NOT NULL,
    Genero ENUM('Masculino', 'Feminino', 'Outro') NOT NULL,
    CPF VARCHAR(11) NOT NULL,
    RG VARCHAR(20) NOT NULL,
    Telefone VARCHAR(20),
    Bairro VARCHAR(255) NOT NULL,
    RuaNumero VARCHAR(255) NOT NULL
);

CREATE TABLE Turmas (
    ID INT AUTO_INCREMENT PRIMARY KEY,
    Turno ENUM('Manhã', 'Tarde', 'Noite') NOT NULL,
    AnoEscolar INT NOT NULL,
    Nome VARCHAR(255) NOT NULL
);

-- Relacionamento entre Tabelas
ALTER TABLE Alunos
ADD COLUMN TurmaID INT,
ADD CONSTRAINT FK_Turma_Aluno FOREIGN KEY (TurmaID) REFERENCES Turmas(ID);
