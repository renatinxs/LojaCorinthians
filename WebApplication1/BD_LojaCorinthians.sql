create database dbCorinthians ;
use dbCorinthians;

-- 1. Tabela Cliente
CREATE TABLE tbCliente (
    codCli INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(75) NOT NULL,
    endereco VARCHAR(200) NOT NULL,
    telefone CHAR(11) NOT NULL,
    email VARCHAR(100) NOT NULL
);

-- 2. Tabela Funcionários
CREATE TABLE tbFuncionarios (
    codFunc INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(75) NOT NULL,
    cargo VARCHAR(75) NOT NULL,
    dataAdmiss DATE NOT NULL
);

-- 3. Tabela Fornecedores
CREATE TABLE tbFornecedores (
    codForn INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(75) NOT NULL,
    endereco VARCHAR(200) NOT NULL,
    telefone CHAR(11) NOT NULL,
    email VARCHAR(100) NOT NULL
);

-- 4. Tabela Produto 
CREATE TABLE tbProduto (
    codProd INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    descricao VARCHAR(200) NULL,
    preco DECIMAL(8, 2) NOT NULL,
    categoria VARCHAR(50) NOT NULL
);

-- 5. Tabela Estoque 
CREATE TABLE tbEstoque (
    codProd INT NOT NULL PRIMARY KEY,
    qtdEsto INT NOT NULL,
    dataFabri DATE NOT NULL,
    capaEsto INT NOT NULL,
    FOREIGN KEY (codProd) REFERENCES tbProduto(codProd)
);

-- 6. Tabela Pedidos
CREATE TABLE tbPedidos (
    numPedi INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    dataPedi DATE NOT NULL,
    codCli INT NOT NULL,
    FOREIGN KEY (codCli) REFERENCES tbCliente(codCli)
);

-- 7. Tabela ItensPedidos
CREATE TABLE tbItensPedidos (
    numPedi INT NOT NULL,
    codProd INT NOT NULL,
    qtd INT NOT NULL,
    PRIMARY KEY (numPedi, codProd),
    FOREIGN KEY (numPedi) REFERENCES tbPedidos(numPedi),
    FOREIGN KEY (codProd) REFERENCES tbProduto(codProd)
);

-- 8. Tabela Pagamentos 
CREATE TABLE tbPagamentos (
    codPaga INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    numPedi INT NOT NULL,
    formPaga VARCHAR(50) NOT NULL,
    dataPaga DATE NOT NULL,
    valPago DECIMAL(8, 2) NOT NULL,
    FOREIGN KEY (numPedi) REFERENCES tbPedidos(numPedi)
);

-- 9. Tabela Pedido Entrega 
CREATE TABLE tbPediDeli (
    numPedi INT NOT NULL PRIMARY KEY,
    endEntre VARCHAR(200) NOT NULL,
    dataEntre DATE NOT NULL,
    horaEntre TIME NOT NULL,
    statusEntre VARCHAR(25) NOT NULL,
    taxaEntre DECIMAL(10, 2) NOT NULL,
    FOREIGN KEY (numPedi) REFERENCES tbPedidos(numPedi)
);
