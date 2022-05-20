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

INSERT INTO maquinaVirtual (nomeMaquinaVirtual, opcoesDisponibilidade, sistemaOperacional, tamanho, nomeAdmin, origemChavePublicaSSH, idUsuario, dataCadastro) 
VALUES
('Minha Máquina Virtual', 'Zona de disponibilidade', 'Windows Server 2019', 'Standard_D2s_v3 - 2vCPU,8Gib de memória', 'Luca', 'Gerar novo par de chaves', 1, '25/03/2022');
GO

INSERT INTO enderecoIP (idUsuario, endereco) 
VALUES
(2, '192.168.3.151');
GO

INSERT INTO subRede(idUsuario, nomeSubRede, intervalosEndereco) 
VALUES
(2, 'Minha Sub-Rede', '10.0.0.1.0/24');
GO

INSERT INTO redeVirtual (idEnderecoIP, idSubRede, nomeRedeVirtual, bastionHost, protecaoDDoS, fireWall, idUsuario, dataCadastro) 
VALUES
(1, 1, 'Minha Rede Virtual', 1, 1, 1, 2, '25/03/2022');
GO

INSERT INTO servicoAplicacional (nomeServicoAplicacional, pilhaRuntime, SKUeTamanho, idUsuario, dataCadastro) 
VALUES
('Meu Serviço Aplicacional', '.NET 6 (LTS)', 'Básico B1- 100 ACU total, 1.75 GB de memória', 2, '25/03/2022');
GO