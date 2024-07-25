//--------------------------------------------------------------------------
//   Festa.Com - Aplicativo para Controle de Festas & Eventos
//   Autor: Josemar Santana
//   Linguagem: C#
//
//   Inicio do Sistema: 23/05/2024
//   Inicio deste Módulo: 07/07/2024
//   Ultima Alteração: 07/07/2024 
//   
//   CLASSE repUsuarios herda de clsUsuarios, criada para conter os metodos
//  C.R.U.D, utilizando comandos SQL em MySql - banco de dados.
//--------------------------------------------------------------------------

namespace FestasApp.Repositories
{
    public class repUsuarios : clsUsuarios
    {
        // construtor
        public repUsuarios() { }
        //
        // Método para testar a conexão
        private static bool TestarConexao()
        {
            if (!myConnMySql.TestarConexao())
            {
                myLogger.LogInfo("Conexão com o banco de dados falhou.");
                return false;
            }
            return true;
        }

        // retorna uma lista com todos os clientes
        public static List<clsUsuarios> GetUsuariosEF()
        {
            // testa a conexão
            if (!TestarConexao())
                //return []; // Retornando uma lista vazia em vez de null
                return new List<clsUsuarios>(); // Retornando uma lista vazia em vez de null

            try
            {
                using (clsFestasContext context = new())
                {
                    var listaUsuarios = context.Usuarios.OrderBy(u => u.user_nome).ToList();
                    return listaUsuarios;
                }
            }
            catch (MySqlException mysqlEx)
            {
                myLogger.LogError("Erro ao carregar a lista de usuários.", mysqlEx);
            }
            catch (Exception ex)
            {
                myLogger.LogError("Erro ao carregar a lista de usuários.", ex);
            }
            return [];
        }
        //
        // CREATE.R.U.D.
        // Método para inserir um novo usuário na tabela `tblUsuarios`
        public bool CreateUsuario(clsUsuarios usuario)
        {
            // Testa a conexão
            if (!TestarConexao())
                return false; 

            string sql = "INSERT INTO tblusuarios (" +
                                        "user_nome, " +
                                        "user_login, " +
                                        "user_email, " +
                                        "user_senha, " +
                                        "user_ativo) " +
                                "VALUES (@Nome, " +
                                        "@Login, " +
                                        "@Email, " +
                                        "@Senha, " +
                                        "@Ativo)";
            try
            {
                using (MySqlConnection cn = new MySqlConnection(myConnMySql.strConnMySql))
                {
                    cn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                    {
                        

                        cmd.Parameters.AddWithValue("@Nome", usuario.user_nome);
                        cmd.Parameters.AddWithValue("@Login", usuario.user_login);
                        cmd.Parameters.AddWithValue("@Email", usuario.user_email);
                        cmd.Parameters.AddWithValue("@Senha", usuario.user_senha);
                        // se Ativo == true, grava 1 na tabela, se não grava 0
                        cmd.Parameters.AddWithValue("@Ativo", usuario.user_ativo ? 1 : 0); // Converter booleano para tinyint

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
                throw new Exception($"Erro ao inserir usuário: {ex.Message}");
            }
        }
        //-----------------------------------------------------------------------
        // C.READ.U.D.
        // Método para obter os dados de UM UNICO usuário específico pelo seu ID
        public void ReadUsuario(int idUsuario)
        {
            string sql = "SELECT * FROM tblusuarios WHERE user_id = @IdUsuario";
            try
            {
                using (MySqlConnection cn = new MySqlConnection(myConnMySql.strConnMySql))
                {
                    cn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);

                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows && dr.Read())
                            {
                                // Atribuindo valores das colunas às propriedades da classe
                                user_id = Convert.ToInt32(dr["user_id"]);
                                user_nome = dr["user_nome"].ToString();
                                user_login = dr["user_login"].ToString();
                                user_email = dr["user_email"].ToString();
                                user_senha = dr["user_senha"].ToString();
                                //Ativo = Convert.ToBoolean(dr["user_ativo"]);

                                // se == 1 é true, senão false...
                                user_ativo = Convert.ToInt32(dr["user_ativo"]) == 1; // Converter tinyint para booleano

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao obter dados do usuário: {ex.Message}");
            }
        }
        //---------------------------------------
        // C.READ.U.D.
        // Método para obter os dados de TODOS usuários
        public static DataTable ReadAllUsuario()
        {
            DataTable dt = new DataTable();

            // Testa a conexão
            if (!TestarConexao())
                return dt;

            string sql = "SELECT * FROM tblusuarios";
            try
            {
                using (MySqlConnection cn = new(myConnMySql.strConnMySql))
                {
                    cn.Open();
                    using (MySqlDataAdapter da = new(sql, cn))
                    {
                        da.Fill(dt);
                    }
                }
            }
            catch (MySqlException mysqlEx)
            {
                // Trata erros específicos do MySQL
                throw new Exception($"Erro no banco de dados: {mysqlEx.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao obter dados do usuário: {ex.Message}");
            }
            // Retorna DataTable...
            return dt;
        }
        //-------------------------------------------------------------------
        // C.R.UPDATE.D.
        // Método para atualizar os dados de um usuário na tabela `tblUsuarios`
        public bool UpdateUsuario(clsUsuarios usuarios)
        {
            // Testa a conexão
            if (!TestarConexao())
                return false;

            string sql = "UPDATE tblusuarios SET user_nome = @Nome, user_login = @Login, " +
                         "user_email = @Email, user_senha = @Senha, user_ativo = @Ativo " +
                         "WHERE user_id = @Id";
            try
            {
                using (MySqlConnection cn = new MySqlConnection(myConnMySql.strConnMySql))
                {
                    cn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@Id", usuarios.user_id);
                        cmd.Parameters.AddWithValue("@Nome", usuarios.user_nome);
                        cmd.Parameters.AddWithValue("@Login", usuarios.user_login);
                        cmd.Parameters.AddWithValue("@Email", usuarios.user_email);
                        cmd.Parameters.AddWithValue("@Senha", usuarios.user_senha);
                        // se Ativo == true, grava 1 na tabela, se não grava 0
                        cmd.Parameters.AddWithValue("@Ativo", usuarios.user_ativo ? 1 : 0); // Converter booleano para tinyint

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
                throw new Exception($"Erro ao atualizar usuário: {ex.Message}");
            }
        }
        //----------------------------------------------------
        // C.R.U.DELETE.
        // Método para excluir um usuário da tabela `tblUsuarios`
        public bool DeleteUsuario(int Id)
        {
            // Testa a conexão
            if (!TestarConexao())
                return false;

            string sql = "DELETE FROM tblusuarios WHERE user_id = @Id";
            try
            {
                using (MySqlConnection cn = new MySqlConnection(myConnMySql.strConnMySql))
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
                throw new Exception($"Erro ao excluir usuário: {ex.Message}");
            }
        }
        //
    } // end class repUsuarios : clsUsuarios
} // end namespace FestasApp.Repositories
