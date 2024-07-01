//***********************************************************
//
//   Festa.Com - Aplicativo para Controle de Festas & Eventos
//   Autor: Josemar Santana
//   Linguagem: C#
//
//   Inicio do Sistema: 23/05/2024
//   Inicio deste Módulo: 10/06/2024
//   Ultima Alteração: 10/06/2024 
//   
//   CLASSE DE USUARIOS - C.R.U.D
//
//************************************************************
// TABLE `tblusuarios` 
//  `user_id`       int NOT NULL AUTO_INCREMENT,
//  `user_nome`     varchar(100)    NOT NULL,
//  `user_login`    varchar(50)     DEFAULT NULL,
//  `user_email`    varchar(100)    DEFAULT NULL,
//  `user_senha`    varchar(50)     NOT NULL,
//  `user_ativo`    tinyint         DEFAULT NULL,

namespace FestasApp.Models
{
    [Table("tblusuarios")]
    public class clsUsuarios
    {
        // Propriedades correspondentes aos campos da tabela `tblUsuarios`
        [Key]
        public int user_id { get; set; }
        public string? user_nome { get; set; }
        public string? user_login { get; set; }
        public string? user_email { get; set; }
        public string? user_senha { get; set; }
        public bool user_ativo { get; set; }

        // Construtor padrão
        public clsUsuarios() { }

        // Construtor que inicializa todas as propriedades
        public clsUsuarios(int id,
                            string nome,
                            string login,
                            string email,
                            string senha,
                            bool ativo)
        {
            user_id = id;
            user_nome = nome;
            user_login = login;
            user_email = email;
            user_senha = senha;
            user_ativo = ativo;
        }
        //
        // CREATE.R.U.D.
        // Método para inserir um novo usuário na tabela `tblUsuarios`
        public bool CreateUsuario()
        {
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
                using (MySqlConnection cn = new MySqlConnection(ConnMySql.strConnMySql))
                {
                    cn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@Nome", user_nome);
                        cmd.Parameters.AddWithValue("@Login", user_login);
                        cmd.Parameters.AddWithValue("@Email", user_email);
                        cmd.Parameters.AddWithValue("@Senha", user_senha);
                        // se Ativo == true, grava 1 na tabela, se não grava 0
                        cmd.Parameters.AddWithValue("@Ativo", user_ativo ? 1 : 0); // Converter booleano para tinyint

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
                using (MySqlConnection cn = new MySqlConnection(ConnMySql.strConnMySql))
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
            string sql = "SELECT * FROM tblusuarios";
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
        public bool UpdateUsuario()
        {
            string sql = "UPDATE tblusuarios SET user_nome = @Nome, user_login = @Login, " +
                         "user_email = @Email, user_senha = @Senha, user_ativo = @Ativo " +
                         "WHERE user_id = @Id";
            try
            {
                using (MySqlConnection cn = new MySqlConnection(ConnMySql.strConnMySql))
                {
                    cn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@Id", user_id);
                        cmd.Parameters.AddWithValue("@Nome", user_nome);
                        cmd.Parameters.AddWithValue("@Login", user_login);
                        cmd.Parameters.AddWithValue("@Email", user_email);
                        cmd.Parameters.AddWithValue("@Senha", user_senha);
                        // se Ativo == true, grava 1 na tabela, se não grava 0
                        cmd.Parameters.AddWithValue("@Ativo", user_ativo ? 1 : 0); // Converter booleano para tinyint

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
        public bool DeleteUsuario()
        {
            string sql = "DELETE FROM tblusuarios WHERE user_id = @Id";
            try
            {
                using (MySqlConnection cn = new MySqlConnection(ConnMySql.strConnMySql))
                {
                    cn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@Id", user_id);
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
    } // end class
} // end namespace clsUsuarios
