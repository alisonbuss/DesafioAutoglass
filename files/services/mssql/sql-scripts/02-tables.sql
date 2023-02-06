
-- -----------------------------------------------------
-- TABLE: Produtos
-- -----------------------------------------------------

CREATE TABLE [quickstart].[domain].[Produtos] (
    [Id] UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(),
    [Codigo] NVARCHAR(33) NOT NULL,               -- Código do produto (sequencial e não nulo)
    [Descricao] NVARCHAR(200) NOT NULL,           -- Descrição do produto (não nulo)
    [Situacao] BIT NOT NULL,                      -- Situação do produto (Ativo ou Inativo)
    [DataFabricacao] DATE NOT NULL,               -- Data de fabricação
    [DataValidade] DATE NOT NULL,                 -- Data de validade
    [CodigoFornecedor] NVARCHAR(33) NOT NULL,     -- Código do fornecedor
    [DescricaoFornecedor] NVARCHAR(200) NOT NULL, -- Descrição do fornecedor
    [CNPJFornecedor] NVARCHAR(14) NULL            -- CNPJ do fornecedor
)
GO
