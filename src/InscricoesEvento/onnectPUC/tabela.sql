CREATE TABLE Inscricoes (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    EventoId INT NOT NULL,
    UsuarioId INT NOT NULL,
    DataInscricao DATETIME NOT NULL DEFAULT GETUTCDATE(),
    Ativa BIT NOT NULL DEFAULT 1,

    CONSTRAINT UQ_Evento_Usuario UNIQUE (EventoId, UsuarioId)
);
