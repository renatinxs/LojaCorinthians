Dupla: Renato Oliveira Cordeiro e Leonardo OLiveira

MODEL Produto
Arquivo: Produto.cs


<img width="500" height="500" alt="produto.cs" src="https://github.com/user-attachments/assets/6c148f3b-d786-4fb5-97f5-b8dd5a88cc40" />

Este código define a estrutura básica de um item no nosso sistema. Ele garante que todo Produto tenha um código, um nome, um preço, etc.
Possui a mesma estrutura na tabela do banco de dados.

CONTROLERS

ProdutoController.cs

<img width="457" height="250" alt="abrir" src="https://github.com/user-attachments/assets/d2823928-8daa-4b50-bbed-8c363b0e1c2c" />

Função: Define a classe principal do Controller (ProdutoController).O construtor recebe o objeto IConfiguration para poder acessar a string de conexão do banco de dados (que está no appsettings.json).


O método Cadastrar() marcado com [HttpGet] apenas retorna a View (página HTML) para exibir o formulário de cadastro de um novo produto.




<img width="730" height="475" alt="select geral" src="https://github.com/user-attachments/assets/82cf7681-5050-41b6-801a-da7f5afca69d" />

Função: Busca e exibe uma lista de todos os produtos cadastrados. Executa um SELECT *. Os resultados são lidos, linha por linha, e mapeados para objetos C# do tipo Produto, que são adicionados a uma lista (List<Produto>). 
Essa lista é então enviada para a View para ser exibida em uma tabela.



<img width="650" height="483" alt="editar select" src="https://github.com/user-attachments/assets/eee79f0b-8bb8-45ee-927d-9a8342d04e8f" />

Função: Recebe o id de um produto e busca seus dados no banco para pré-preencher o formulário de edição. Executa um SELECT com uma cláusula WHERE para buscar apenas o produto correspondente ao id.  lê o único registro encontrado, preenche o objeto Produto, e o envia para a View de edição.

  
<img width="1110" height="387" alt="editar update" src="https://github.com/user-attachments/assets/6a78a535-a39a-47cd-8ff1-aae153592b02" />

Função: Recebe o objeto Produto com os dados modificados e atualiza o registro no banco de dados.

 Executa um comando UPDATE parametrizado. O codProd é usado na cláusula WHERE para garantir que apenas o produto correto seja atualizado. Após a alteração, redireciona para a página inicial.
 

<img width="978" height="305" alt="insert" src="https://github.com/user-attachments/assets/43ac05f6-4f38-4641-b19d-8236532f010c" />

Função: Recebe os dados de um Produto submetidos via formulário (HttpPost) e o salva no banco de dados.

 Monta um comando INSERT e utiliza parâmetros (@Prodnome, @descricao, etc.). O método ExecuteNonQuery() executa o comando. No final, redireciona o usuário para a página inicial.
 

 <img width="695" height="233" alt="delete" src="https://github.com/user-attachments/assets/655263af-d1a8-49fd-b360-aaea5090cd42" />

 
Função: Remove um produto do banco de dados.

 Recebe o id do produto a ser excluído. Monta um comando DELETE que usa a cláusula WHERE codProd = @codProd para garantir que apenas o registro correspondente àquele ID seja apagado. Após a exclusão, o usuário é redirecionado para a página inicial.




<h3>VIEWS</h3> 


<h3>VIEWS DO PRODUTO</h3> 

 

<h4>Cadastrar.cshtml:</h4> 
Formulário para adicionar produto.


<h4>Editar.cshtml:</h4>

Tela para edição de produto.
O campo Prodid fica travado (readonly).



<h4>Listar.cshtml:</h4>

Mostra todos os produtos em tabela.
Possui links de edição e exclusão.

<h3>VIEWS DO LAYOUT</h3> 

<h4>_Produto:</h4>
Dá formato aos cards dos produtos.

<h4>_Carrosel:</h4>
Faz um carrosel no inicio.


<h3>BANCO DE DADOS – appsettings.json </h3>
Arquivo:

{ "ConnectionStrings": { "DefaultConnection": "Server=localhost;database=dbLoja;user=root;password=2121" },

"Logging": { "LogLevel": { "Default": "Information", "Microsoft.AspNetCore": "Warning" } }, "AllowedHosts": "*" }

Função:
Configura a conexão com o MySQL.

O controller usa essa string para abrir a conexão:

_configuration.GetConnectionString("DefaultConnection")

 

