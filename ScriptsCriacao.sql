--CRIAR O BANCO
CREATE DATABASE programacao_do_zero;

--USAR O BANCO
USE programacao_do_zero;

--CRIAR TABELA USUÁRIO
CREATE TABLE usuario (
	id INT NOT NULL AUTO_INCREMENT,
	nome VARCHAR(50) NOT NULL,
	sobrenome VARCHAR(150) NOT NULL,
	telefone VARCHAR(15) NOT NULL,
	email VARCHAR(50) NOT NULL,
	genero VARCHAR(20) NOT NULL,
	senha VARCHAR(30) NOT NULL,
	PRIMARY KEY (id)
);

--CRIAR TABELA ENDEREÇO
CREATE TABLE endereco (
	id INT NOT NULL AUTO_INCREMENT,
	rua VARCHAR(250) NOT NULL,
    numero VARCHAR(30) NOT NULL,
	bairro VARCHAR(150) NOT NULL,
    cidade VARCHAR(250) NOT NULL,
    complemento VARCHAR(150) NULL,
    cep VARCHAR(9) NOT NULL,
    estado VARCHAR(2) NOT NULL,
    PRIMARY KEY (id)
);

--ALTERAR TABELA ENDEREÇO
ALTER TABLE endereco ADD usuario_id INT NOT NULL;

--ADICIONAR CHAVE ESTRANGEIRA
ALTER TABLE endereco ADD CONSTRAINT Fk_usuario FOREIGN KEY (usuario_id) REFERENCES usuario(id);

--INSERIR USUÁRIO 
INSERT INTO usuario(nome, sobrenome, 
 telefone, email, 
 genero, senha) VALUES ('Ramon', 'Fernandes', '(75) 98209-1546', 'ramonfsf@outlook.com.br', 'Masculino', '1234566')

 INSERT INTO usuario(nome, sobrenome, 
 telefone, email, 
 genero, senha) VALUES ('Queila', 'Monique', '(75) 98102-4003', 'silvaq776@gmail.com', 'Feminino', '1234566')

 --SELECIONAR TODOS OS USUÁRIOS
 SELECT * FROM usuario;

 --SELECIONAR UM USUÁRIO ESPECÍFICO
 SELECT * FROM usuario WHERE email = 'ramonfsf@outlook.com.br';

 --ALTERAR USUÁRIO
 UPDATE usuario SET email = 'ramonrf7665@gmail.com' WHERE id = 1

 --EXCLUIR USUÁRIO
 DELETE FROM usuario WHERE id = 2;

 DELETE FROM usuario WHERE id IN (1,2);

 DELETE FROM usuario WHERE id > 2;