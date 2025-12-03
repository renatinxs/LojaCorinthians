using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using MySql.Data.MySqlClient;
using System.Data;


namespace LojaCorinthians.Controllers
{
    public class ProdutoController : Controller
    {

        private readonly IConfiguration _configuration;
        public ProdutoController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        public IActionResult Listar()
        {
            List<Produto> produtos = new List<Produto>();
            using (var conn = new MySqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {

                conn.Open();
                string sql = "Select * from tbProduto ";
                MySqlCommand command = new MySqlCommand(sql, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                conn.Close();
                foreach (DataRow row in dataTable.Rows)
                {
                    produtos.Add(
                        new Produto
                        {
                            codProd = Convert.ToInt32(row["codProd"]),
                            Prodnome = row["Prodnome"].ToString(),
                            descricao = row["descricao"].ToString(),
                            categoria = row["categoria"].ToString(),
                            preco = Convert.ToDouble(row["preco"])
                        });


                }
                return View(produtos);
            }





        }

        public IActionResult Editar(int id)
        {
            string? connectionString = _configuration.GetConnectionString("DefaultConnection");
            using var connection = new MySqlConnection(connectionString);
            connection.Open();

            string sql = "select * from tbProduto where codProd=@codProd";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@codProd", id);
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlDataReader reader;
            Produto produto = new Produto();
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                produto.codProd = Convert.ToInt32(reader["codProd"]);
                produto.Prodnome = Convert.ToString(reader["Prodnome"]);
                produto.descricao = Convert.ToString(reader["descricao"]);
                produto.categoria = Convert.ToString(reader["categoria"]);
                produto.preco = Convert.ToDouble(reader["preco"]);



            }

            return View(produto);

        }
        [HttpPost]
        public IActionResult Editar(Produto produto)
        {
            string? connectionString = _configuration.GetConnectionString("DefaultConnection");
            using var connection = new MySqlConnection(connectionString);
            connection.Open();

            string sql = "UPDATE tbProduto SET Prodnome = @Prodnome, descricao = @descricao, categoria = @categoria, preco = @preco WHERE codProd = @codProd";

            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Prodnome", produto.Prodnome);
            command.Parameters.AddWithValue("@descricao", produto.descricao);
            command.Parameters.AddWithValue("@categoria", produto.categoria);
            command.Parameters.AddWithValue("@preco", produto.preco);
            command.Parameters.AddWithValue("@codProd", produto.codProd);



            command.ExecuteNonQuery();

            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        public IActionResult Cadastrar(Produto produto)
        {
            string? connectionString = _configuration.GetConnectionString("DefaultConnection");
            using var connection = new MySqlConnection(connectionString);
            connection.Open();

            string sql = "INSERT INTO tbProduto (Prodnome,descricao,categoria,preco) VALUES (@Prodnome, @descricao, @categoria, @preco)";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@Prodnome", produto.Prodnome);
            command.Parameters.AddWithValue("@descricao", produto.descricao);
            command.Parameters.AddWithValue("@categoria", produto.categoria);
            command.Parameters.AddWithValue("@preco", produto.preco);
            command.ExecuteNonQuery();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Deletar(int id)
        {
            string? connectionString = _configuration.GetConnectionString("DefaultConnection");
            using var connection = new MySqlConnection(connectionString);
            connection.Open();

            string sql = "Delete from tbProduto where codProd = @codProd";
            MySqlCommand command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@codProd", id);

            command.ExecuteNonQuery();

            return RedirectToAction("Index", "Home");
        }


    }





}
