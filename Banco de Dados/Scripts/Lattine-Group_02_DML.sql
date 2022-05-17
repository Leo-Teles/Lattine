USE lattine;
GO

INSERT INTO contatosLattine (localizacao)
VALUES
('Alameda Tocantins, 350 Barueri - São Paulo / SP');
GO

INSERT INTO telefone (idContatosLattine, numero) 
VALUES
(1, '11 4209-1000');
GO

INSERT INTO tipoUsuario (titulo) 
VALUES
('Administrador'),
('Cliente'),
('Funcionário Lattine Group');
GO

INSERT INTO usuario (idTipoUsuario, nome, sobrenome, email, senha, dataCadastro) 
VALUES
(1, 'Luca', 'Silvestri', 'luca@email.com', 'luca*123', '25/03/2022'),
(2, 'Flávia', 'Brito', 'flavia@email.com', 'flavia*123', '25/03/2022'),
(3, 'Gabriel', 'Brito', 'gabriel@email.com', 'gabriel*123', '25/03/2022');
GO

INSERT INTO infraestrutura (idUsuario, dataCadastro) 
VALUES
(1, '25/03/2022'),
(2, '25/03/2022'),
(3, '25/03/2022');
GO

INSERT INTO maquinaVirtual (idInfraestrutura, nomeMaquinaVirtual, opcoesDisponibilidade, sistemaOperacional, tamanho, nomeAdmin, origemChavePublicaSSH) 
VALUES
(1, 'Minha Máquina Virtual', 'Zona de disponibilidade', 'Windows Server 2019', 'Standard_D2s_v3 - 2vCPU,8Gib de memória', 'Luca', 'Gerar novo par de chaves');
GO

INSERT INTO enderecoIP (endereco) 
VALUES
('192.168.3.151');
GO

INSERT INTO subRede(nomeSubRede, intervalosEndereco) 
VALUES
('Minha Sub-Rede', '10.0.0.1.0/24');
GO

INSERT INTO redeVirtual (idInfraestrutura, idEnderecoIP, idSubRede, nomeRedeVirtual, bastionHost, protecaoDDoS, fireWall) 
VALUES
(2, 1, 1, 'Minha Rede Virtual', 1, 1, 1);
GO

INSERT INTO servicoAplicacional (idInfraestrutura, nomeServicoAplicacional, pilhaRuntime, SKUeTamanho) 
VALUES
(3, 'Meu Serviço Aplicacional', '.NET 6 (LTS)', 'Básico B1- 100 ACU total, 1.75 GB de memória');
GO