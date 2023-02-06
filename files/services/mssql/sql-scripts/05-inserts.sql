
INSERT INTO [quickstart].[domain].[Produtos] (
    [Codigo], [Descricao], [Situacao], [DataFabricacao], [DataValidade], [CodigoFornecedor], [DescricaoFornecedor], [CNPJFornecedor]
)
VALUES
    ('PROD001BC', 'Produto 001', 1, '2023-01-22', '2023-06-23','FORN001A', 'Fornecedor Dest A', '28102339000118'),
    ('PROD002BC', 'Produto 002', 1, '2023-02-01', '2023-11-17','FORN001A', 'Fornecedor Dest A', '28102339000118'),
    ('PROD003BC', 'Produto 003', 1, '2023-01-29', '2023-04-15','FORN003F', 'Fornecedor Dest F', '02424232000100');
GO
