//***********************************************************
//
//   Festa.Com - Aplicativo para Controle de Festas & Eventos
//   Autor: Josemar Santana
//   Linguagem: C#
//
//   Inicio: 23/05/2024
//   Ultima Alteração: 
//   
//   CLASSE DE CLIENTE
//
//************************************************************

using FestasApp.Controllers; // namespace da conexão
using MySql.Data.MySqlClient;
using System.Data;

namespace FestasApp.Views.Clientes
{
    public class clsClientes
    {
        // campos da tabela
        // cli_id int NOT NULL auto_increment,
        // cli_nome varchar(100) NOT NULL,
        // cli_telefone1 varchar(11) NOT NULL,
        // cli_telefone2 varchar(11),
        // cli_cpf varchar(11),
        // cli_endereco varchar(100),
        // cli_cep varchar(10),
        // cli_cidade varchar(50),
        // cli_uf varchar(20),
        // primary key(cli_id)

        // Propriedades correspondentes aos campos da tabela `tblclientes`
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Telefone1 { get; set; }
        public string? Telefone2 { get; set; }
        public string? CPF { get; set; }
        public string? Endereco { get; set; }
        public string? CEP { get; set; }
        public string? Cidade { get; set; }
        public string? UF { get; set; }

        // Construtor padrão
        public clsClientes() { }

        // Construtor que inicializa todas as propriedades
        public clsClientes(int id, 
                        string nome, 
                        string telefone1, 
                        string telefone2, 
                        string cpf, 
                        string endereco, 
                        string cep, 
                        string cidade, 
                        string uf)
        {
            Id = id;
            Nome = nome;
            Telefone1 = telefone1;
            Telefone2 = telefone2;
            CPF = cpf;
            Endereco = endereco;
            CEP = cep;
            Cidade = cidade;
            UF = uf;
        }
        //------------------------------------------------------------
        // Método para inserir um novo cliente na tabela `tblclientes`
        public bool CreateCliente()
        {
            string sql = "INSERT INTO tblclientes (cli_nome, " +
                                                  "cli_telefone1, " +
                                                  "cli_telefone2, " +
                                                  "cli_cpf, " +
                                                  "cli_endereco, " +
                                                  "cli_cep, " +
                                                  "cli_cidade, " +
                                                  "cli_uf) " +
                         "VALUES (@Nome, " +
                                 "@Telefone1, " +
                                 "@Telefone2, " +
                                 "@CPF, " +
                                 "@Endereco, " +
                                 "@CEP, " +
                                 "@Cidade, " +
                                 "@UF)";
            try
            {
                using (MySqlConnection cn = new MySqlConnection(ConnMySql.strConnMySql))
                {
                    cn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@Nome", Nome);
                        cmd.Parameters.AddWithValue("@Telefone1", Telefone1);
                        cmd.Parameters.AddWithValue("@Telefone2", Telefone2);
                        cmd.Parameters.AddWithValue("@CPF", CPF);
                        cmd.Parameters.AddWithValue("@Endereco", Endereco);
                        cmd.Parameters.AddWithValue("@CEP", CEP);
                        cmd.Parameters.AddWithValue("@Cidade", Cidade);
                        cmd.Parameters.AddWithValue("@UF", UF);

                        cmd.ExecuteNonQuery();

                        // Para recuperar o ID do cliente inserido
                        cmd.CommandText = "SELECT LAST_INSERT_ID()";
                        Id = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                return true;
            }
            catch (MySqlException mysqlEx)
            {
                // Trata erros específicos do MySQL
                throw new Exception($"Erro no banco de dados: {mysqlEx.Message}");
            }
            catch (Exception ex)
            {
                // Trata outros tipos de exceções
                throw new Exception($"Erro ao inserir cliente: {ex.Message}");
            }
            // return sem necessidade após usar throw...
            //return false;
        }
        //------------------------------------------------------------
        // SELECT - WHERE (especifico)
        // Método para obter os dados de somente UM cliente a partir do seu ID
        public void ReadUmCliente(int _idCliente)
        {
            // Definindo a consulta SQL para selecionar o cliente pelo ID
            string sql = "SELECT * FROM tblClientes WHERE cli_id=@IdCliente";

            try
            {
                // Usando 'using' para garantir o fechamento da conexão e liberar recursos
                using (MySqlConnection cn = new MySqlConnection(ConnMySql.strConnMySql))
                {
                    cn.Open();

                    // Preparando o comando SQL com o parâmetro para evitar SQL Injection
                    using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@IdCliente", _idCliente);

                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows && dr.Read())
                            {
                                // Atribuindo valores das colunas às propriedades da classe
                                this.Id = Convert.ToInt32(dr["cli_id"]);
                                this.Nome = dr["cli_nome"].ToString();
                                this.Telefone1 = dr["cli_telefone1"].ToString();
                                this.Telefone2 = dr["cli_telefone2"].ToString();
                                this.CPF = dr["cli_cpf"].ToString();
                                this.Endereco = dr["cli_endereco"].ToString();
                                this.CEP = dr["cli_cep"].ToString();
                                this.Cidade = dr["cli_cidade"].ToString();
                                this.UF = dr["cli_uf"].ToString();
                            }
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                // Exibindo mensagem de erro em caso de exceção
                //FormMenuBase.ShowMyMessageBox("Erro ao obter dados do cliente: " + ex.Message);
                throw new Exception("Erro ao obter dados do cliente: " + ex.Message);
            }
        } // end GetUMCliente.
        //-------------------------------------------------
        // SELECT (Todos)
        // Obtém TODOS os clientes da tabela `tblclientes`.
        // retorna Um DataTable contendo todos os clientes.
        public static DataTable ReadAllClientes()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT cli_id, " +
                                "cli_nome, " +
                                "cli_telefone1, " +
                                "cli_telefone2, " +
                                "cli_cpf, " +
                                "cli_endereco, " +
                                "cli_cep, " +
                                "cli_cidade, " +
                                "cli_uf  " +
                                "FROM tblclientes";

            try
            {
                using (MySqlConnection cn = new MySqlConnection(ConnMySql.strConnMySql))
                {
                    cn.Open();
                    using (MySqlDataAdapter da = new MySqlDataAdapter(sql, cn))
                    {
                        da.Fill(dt);
                    }
                }
            }
            catch (MySqlException mysqlEx)
            {
                // Trata erros específicos do MySQL
                //FormMenuBase.ShowMyMessageBox($"Erro no banco de dados: {mysqlEx.Message}", "SQL exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw new Exception($"Erro no banco de dados: {mysqlEx.Message}");
            }
            catch (Exception ex)
            {
                // Trata outros tipos de exceções
                //FormMenuBase.ShowMyMessageBox($"Erro: {ex.Message}", "Erro no Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                

                // Use a maneira adequada de exibir mensagens de erro em um contexto de UI.
                // Evite MessageBox.Show em código de backend.
                throw new Exception($"Erro ao obter clientes: {ex.Message}");
            }
            // Retorna DataTable...
            return dt;
        }
        //-----------------------------
        // UPDATE - ALTERAR registro
        public bool UpdateCliente()
        {
            string sql = "UPDATE tblclientes SET " +
                                "cli_nome=@Nome, " +
                                "cli_telefone1=@Telefone1, " +
                                "cli_telefone2=@Telefone2, " +
                                "cli_cpf=@CPF, " +
                                "cli_endereco=@Endereco, " +
                                "cli_cep=@CEP, " +
                                "cli_cidade=@Cidade, " +
                                "cli_uf=@UF " +
                                "WHERE cli_id=@Id";
            try
            {
                using(MySqlConnection cn = new MySqlConnection(ConnMySql.strConnMySql))
                {
                    cn.Open();
                    using(MySqlCommand cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@Id", Id);
                        cmd.Parameters.AddWithValue("@Nome", Nome);
                        cmd.Parameters.AddWithValue("@Telefone1", Telefone1);
                        cmd.Parameters.AddWithValue("@Telefone2", Telefone2);
                        cmd.Parameters.AddWithValue("@CPF", CPF);
                        cmd.Parameters.AddWithValue("@Endereco", Endereco);
                        cmd.Parameters.AddWithValue("@CEP", CEP);
                        cmd.Parameters.AddWithValue("@Cidade", Cidade);
                        cmd.Parameters.AddWithValue("@UF", UF);

                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (MySqlException mysqlEx)
            {
                // Trata erros específicos do MySQL
                throw new Exception($"Erro no banco de dados: {mysqlEx.Message}");
            }
            catch (Exception ex)
            {
                // Trata outros tipos de exceções
                throw new Exception($"Erro ao salvar cliente: {ex.Message}");
            }
        }
        
        //-------------------------------------------------------
        // Método para excluir um cliente da tabela `tblclientes`
        public bool DeleteCliente()
        {
            string sql = "DELETE FROM tblclientes WHERE cli_id=@Id";
            try
            {
                using (MySqlConnection cn = new MySqlConnection(ConnMySql.strConnMySql))
                {
                    cn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@Id", Id);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (MySqlException mysqlEx)
            {
                // Trata erros específicos do MySQL
                throw new Exception($"Erro no banco de dados: {mysqlEx.Message}");
            }
            catch (Exception ex)
            {
                // Trata outros tipos de exceções
                throw new Exception($"Erro ao excluir cliente: {ex.Message}");
            }
        }

    } // end class
} // end namespace
