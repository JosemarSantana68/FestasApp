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

// campos da tabela
// cli_id           int NOT NULL auto_increment,
// cli_nome         varchar(100) NOT NULL,
// cli_telefone1    varchar(11) NOT NULL,
// cli_telefone2    varchar(11),
// cli_cpf          varchar(11),
// cli_endereco     varchar(100),
// cli_cep          varchar(10),
// cli_cidade       varchar(50),
// cli_uf           varchar(20),
// primary key(cli_id)

namespace FestasApp.Models
{
    [Table("tblclientes")]
    public class clsClientes
    {
        // Propriedades correspondentes aos campos da tabela `tblclientes`
        [Key]
        public int cli_id { get; set; }
        public string? cli_nome { get; set; }
        public string? cli_telefone1 { get; set; }
        public string? cli_telefone2 { get; set; }
        public string? cli_cpf { get; set; }
        public string? cli_endereco { get; set; }
        public string? cli_cep { get; set; }
        public string? cli_cidade { get; set; }
        public string? cli_uf { get; set; }

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
            cli_id = id;
            cli_nome = nome;
            cli_telefone1 = telefone1;
            cli_telefone2 = telefone2;
            cli_cpf = cpf;
            cli_endereco = endereco;
            cli_cep = cep;
            cli_cidade = cidade;
            cli_uf = uf;
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
                using (MySqlConnection cn = new MySqlConnection(myConnMySql.strConnMySql))
                {
                    cn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@Nome", cli_nome);
                        cmd.Parameters.AddWithValue("@Telefone1", cli_telefone1);
                        cmd.Parameters.AddWithValue("@Telefone2", cli_telefone2);
                        cmd.Parameters.AddWithValue("@CPF", cli_cpf);
                        cmd.Parameters.AddWithValue("@Endereco", cli_endereco);
                        cmd.Parameters.AddWithValue("@CEP", cli_cep);
                        cmd.Parameters.AddWithValue("@Cidade", cli_cidade);
                        cmd.Parameters.AddWithValue("@UF", cli_uf);

                        cmd.ExecuteNonQuery();

                        // Para recuperar o ID do cliente inserido
                        cmd.CommandText = "SELECT LAST_INSERT_ID()";
                        cli_id = Convert.ToInt32(cmd.ExecuteScalar());
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
        public void ReadUmCliente(int IdCliente)
        {
            // Definindo a consulta SQL para selecionar o cliente pelo ID
            string sql = "SELECT * FROM tblClientes WHERE cli_id=@IdCliente";

            try
            {
                // Usando 'using' para garantir o fechamento da conexão e liberar recursos
                using (MySqlConnection cn = new MySqlConnection(myConnMySql.strConnMySql))
                {
                    cn.Open();

                    // Preparando o comando SQL com o parâmetro para evitar SQL Injection
                    using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@IdCliente", IdCliente);
                        // execute o DataReader para lê registro na tabela
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows && dr.Read())
                            {
                                // Atribuindo valores das colunas do dr às propriedades da classe
                                //this.Id = Convert.ToInt32(dr["cli_id"]);
                                this.cli_id = IdCliente;
                                this.cli_nome = dr["cli_nome"] != DBNull.Value ? dr["cli_nome"].ToString() : null;
                                this.cli_telefone1 = dr["cli_telefone1"].ToString();
                                this.cli_telefone2 = dr["cli_telefone2"].ToString();
                                this.cli_cpf = dr["cli_cpf"].ToString();
                                this.cli_endereco = dr["cli_endereco"].ToString();
                                this.cli_cep = dr["cli_cep"].ToString();
                                this.cli_cidade = dr["cli_cidade"].ToString();
                                this.cli_uf = dr["cli_uf"].ToString();
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
                using (MySqlConnection cn = new MySqlConnection(myConnMySql.strConnMySql))
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
                using (MySqlConnection cn = new MySqlConnection(myConnMySql.strConnMySql))
                {
                    cn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@Id", cli_id);
                        cmd.Parameters.AddWithValue("@Nome", cli_nome);
                        cmd.Parameters.AddWithValue("@Telefone1", cli_telefone1);
                        cmd.Parameters.AddWithValue("@Telefone2", cli_telefone2);
                        cmd.Parameters.AddWithValue("@CPF", cli_cpf);
                        cmd.Parameters.AddWithValue("@Endereco", cli_endereco);
                        cmd.Parameters.AddWithValue("@CEP", cli_cep);
                        cmd.Parameters.AddWithValue("@Cidade", cli_cidade);
                        cmd.Parameters.AddWithValue("@UF", cli_uf);

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
                using (MySqlConnection cn = new MySqlConnection(myConnMySql.strConnMySql))
                {
                    cn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@Id", cli_id);
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
    } // end class clsClientes
} // end namespace
 