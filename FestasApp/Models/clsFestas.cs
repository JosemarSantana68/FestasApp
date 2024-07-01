//***********************************************************
//
//   Festa.Com - Aplicativo para Controle de Festas & Eventos
//   Autor: Josemar Santana
//   Linguagem: C#
//
//   Inicio: 23/05/2024
//   Criação do Módulo: 17/06/2024
//   Ultima Alteração: 17/06/2024
//   
//   CLASSE FESTAS - C.R.U.D.
//
//************************************************************

/*
CREATE TABLE `tblfestas` (
  `fest_id`         int NOT NULL AUTO_INCREMENT,
  `fest_cli_id`     int NOT NULL,
  `fest_user_id`    int NOT NULL,
  `fest_pct_id`     int DEFAULT NULL,
  `fest_tema_id`    int DEFAULT NULL,
  `fest_espc_id`    int DEFAULT NULL,
  `fest_stt_id`     int DEFAULT NULL,
  `fest_tpEv_id`    int DEFAULT NULL,
  `fest_dtVenda`    date NOT NULL,
  `fest_dtFesta`    date NOT NULL,
  `fest_valor`      DECIMAL(10, 2) DEFAULT NULL,
  PRIMARY KEY (`fest_id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
 */

namespace FestasApp.Models
{
    [Table("tblfestas")]
    public class clsFestas
    {
        // Propriedades correspondentes aos campos da tabela `tblfestas`
        [Key]
        public int fest_id { get; set; }

        [ForeignKey("Cliente")]
        public int fest_cli_id { get; set; } // Não anulável

        [ForeignKey("Usuario")]
        public int fest_user_id { get; set; } // Não anulável

        [ForeignKey("Pacote")]
        public int? fest_pct_id { get; set; }

        [ForeignKey("Tema")]
        public int? fest_tema_id { get; set; }

        [ForeignKey("Espaco")]
        public int? fest_espc_id { get; set; }

        [ForeignKey("Status")]
        public int? fest_stt_id { get; set; }

        [ForeignKey("TipoEvento")]
        public int? fest_tpEv_id { get; set; }

        public DateTime? fest_dtVenda { get; set; }
        public DateTime? fest_dtFesta { get; set; }
        public double? fest_valor { get; set; }

        // Propriedades de navegação para tabelas auxiliares
        /*(a propriedade que representa a entidade relacionada)*/
        public clsFestasTipoEvento? TipoEvento { get; set; }
        public clsClientes? Cliente { get; set; }
        public clsUsuarios? Usuario { get; set; }
        public clsFestasPacotes? Pacote { get; set; }
        public clsFestasTemas? Tema { get; set; }
        public clsFestasEspacos? Espaco { get; set; }
        public clsFestasStatus? Status { get; set; }

        // Propriedade de navegação para clsFestasDetalhes
        public ICollection<clsFestasDetalhes>? Detalhes { get; set; }

        // Propriedade de navegação para clsFestasAdicionais
        public ICollection<clsFestasAdicionais>? Adicionais { get; set; }


        // Construtor padrão
        public clsFestas() { }

        // Construtor que inicializa todas as propriedades
        public clsFestas(int id, int clienteId, int usuarioId, int? pacoteId, int? temaId, int? espacoId, int? statusId, int? tipoEventoId, DateTime dataVenda, DateTime dataFesta, double? valor)
        {
            fest_id = id;
            fest_cli_id = clienteId;
            fest_user_id = usuarioId;
            fest_pct_id = pacoteId;
            fest_tema_id = temaId;
            fest_espc_id = espacoId;
            fest_stt_id = statusId;
            fest_tpEv_id = tipoEventoId;
            fest_dtVenda = dataVenda;
            fest_dtFesta = dataFesta;
            fest_valor = valor;
        }

        //-------------------------------------------------------------------------
        // CREATE.R.U.D. - Método para inserir uma nova festa na tabela `tblfestas`
        public bool CreateFesta()
        {
            string sql = "INSERT INTO tblfestas (" +
                        "fest_cli_id, " +
                        "fest_user_id, " +
                        "fest_pct_id, " +
                        "fest_tema_id, " +
                        "fest_espc_id, " +
                        "fest_stt_id, " +
                        "fest_tpEv_id, " +
                        "fest_dtVenda, " +
                        "fest_dtFesta, " +
                        "fest_valor) " +
                         "VALUES (@ClienteId, " +
                         "@UsuarioId, " +
                         "@PacoteId, " +
                         "@TemaId, " +
                         "@EspacoId, " +
                         "@StatusId, " +
                         "@TipoEventoId, " +
                         "@DataVenda, " +
                         "@DataFesta, " +
                         "@Valor)";
            try
            {
                using (MySqlConnection cn = new MySqlConnection(ConnMySql.strConnMySql))
                {
                    cn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@ClienteId", fest_cli_id);
                        cmd.Parameters.AddWithValue("@UsuarioId", fest_user_id);
                        cmd.Parameters.AddWithValue("@PacoteId", fest_pct_id);
                        cmd.Parameters.AddWithValue("@TemaId", fest_tema_id);
                        cmd.Parameters.AddWithValue("@EspacoId", fest_espc_id);
                        cmd.Parameters.AddWithValue("@StatusId", fest_stt_id);
                        cmd.Parameters.AddWithValue("@TipoEventoId", fest_tpEv_id);
                        cmd.Parameters.AddWithValue("@DataVenda", fest_dtVenda);
                        cmd.Parameters.AddWithValue("@DataFesta", fest_dtFesta);
                        cmd.Parameters.AddWithValue("@Valor", fest_valor);

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
                throw new Exception($"Erro ao inserir festa: {ex.Message}");
            }
        }
        //-----------------------------------------------------------------------------
        // C.READ.U.D. - Método para obter os dados de UMA ÚNICA festa específica pelo seu ID
        public void ReadFesta(int idFesta)
        {
            string sql = "SELECT * FROM tblfestas WHERE fest_id = @IdFesta";
            try
            {
                using (MySqlConnection cn = new MySqlConnection(ConnMySql.strConnMySql))
                {
                    cn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@IdFesta", idFesta);

                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows && dr.Read())
                            {
                                // Atribuindo valores das colunas DataReader às propriedades da classe
                               fest_id = idFesta;
                               fest_cli_id = Convert.ToInt32(dr["fest_cli_id"]); // Não anulável
                               fest_user_id = Convert.ToInt32(dr["fest_user_id"]); // Não anulável
                               fest_pct_id = dr["fest_pct_id"] != DBNull.Value ? dr["fest_pct_id"] as int? : null;
                               fest_tema_id = dr["fest_tema_id"] != DBNull.Value ? dr["fest_tema_id"] as int? : null;
                               fest_espc_id = dr["fest_espc_id"] != DBNull.Value ? dr["fest_espc_id"] as int? : null;
                               fest_stt_id = dr["fest_stt_id"] != DBNull.Value ? dr["fest_stt_id"] as int? : null; 
                               fest_tpEv_id = dr["fest_tpEv_id"] != DBNull.Value ? dr["fest_tpEv_id"] as int? : null; 
                               fest_dtVenda = Convert.ToDateTime(dr["fest_dtVenda"]);
                               fest_dtFesta = Convert.ToDateTime(dr["fest_dtFesta"]);
                               fest_valor = dr["fest_valor"] != DBNull.Value ? dr["fest_valor"] as double? : null;                              
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao obter dados da festa: {ex.Message}");
            }
        }
        //------------------------------------------------------------
        // C.READ.U.D. - Método para obter os dados de TODAS as festas 
        // COM NOMES DAS AUXILIARES
        public static DataTable ReadAllFestas()
        {
            DataTable dt = new DataTable();
                
            // Consulta SQL para selecionar os dados das festas com o nome do cliente
            string sql = @"SELECT 
                            f.fest_id, 
                            f.fest_dtFesta,
                            c.cli_nome, 
                            p.pct_nome,                
                            t.tema_nome,               
                            e.espc_nome,               
                            s.stt_status,              
                            ev.tpev_nome,  
                            f.fest_valor,               
                            u.user_nome,               
                            f.fest_dtVenda            
                        FROM tblfestas f
                        JOIN tblclientes c ON f.fest_cli_id = c.cli_id
                        JOIN tblusuarios u ON f.fest_user_id = u.user_id
                        JOIN tblfestaspacotes p ON f.fest_pct_id = p.pct_id
                        JOIN tblfestastemas t ON f.fest_tema_id = t.tema_id
                        JOIN tblfestasespacos e ON f.fest_espc_id = e.espc_id
                        JOIN tblfestasstatus s ON f.fest_stt_id = s.stt_id
                        JOIN tblfestastipoevento ev ON f.fest_tpEv_id = ev.tpev_id";
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
                throw new Exception($"Erro ao obter dados das festas: {ex.Message}");
            }
            
        // Retorna DataTable
        return dt;
        }
        //------------------------------------------------------------
        // C.READ.U.D. - Método para obter os dados de todas as festas
        public static DataTable ReadAllFestasSEMUSO()
        {
            DataTable dt = new DataTable();
            // Consulta SQL para selecionar os dados das festas com o nome do cliente
            string sql = "SELECT " +
                        "f.fest_id, " +         // 0 - id da festa
                        "f.fest_cli_id, " +
                        "c.cli_nome AS NomeCliente, " + // col2 - Alias para cli_nome como NomeCliente
                        "f.fest_user_id, " +
                        "u.user_nome," +         // 4 - nom usuario/vendedor
                        "f.fest_pct_id, " +
                        "f.fest_tema_id, " +
                        "fest_espc_id, " +
                        "esp.espc_nome, " +   // col-8 Nome EspaçoFesta
                        "f.fest_stt_id, " +
                        "f.fest_tpEv_id, " +
                        "f.fest_dtVenda, " +
                        "f.fest_dtFesta, " +
                        "f.fest_valor " +
                        "FROM tblfestas f " +
                        "JOIN tblclientes c ON f.fest_cli_id = c.cli_id " +
                        "JOIN tblusuarios u ON f.fest_user_id = u.user_id " +
                        "JOIN tblfestasespacos esp ON f.fest_espc_id = esp.espc_id  ";
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
                throw new Exception($"Erro ao obter dados das festas: {ex.Message}");
            }
            // Retorna DataTable
            return dt;
        }

        //-------------------------------------------------------------------------------
        // C.R.UPDATE.D. - Método para atualizar os dados de uma festa na tabela `tblfestas`
        public bool UpdateFesta()
        {
            string sql = "UPDATE tblfestas SET " +
                                "fest_cli_id = @ClienteId, " +
                                "fest_user_id = @UsuarioId, " +
                                "fest_pct_id = @PacoteId, " +
                                "fest_tema_id = @TemaId, " +
                                "fest_espc_id = @EspacoId, " +
                                "fest_stt_id = @StatusId, " +
                                "fest_tpEv_id = @TipoEventoId, " +
                                "fest_dtVenda = @DataVenda, " +
                                "fest_dtFesta = @DataFesta, " +
                                "fest_valor = @Valor " +
                         "WHERE fest_id = @Id";
            try
            {
                using (MySqlConnection cn = new MySqlConnection(ConnMySql.strConnMySql))
                {
                    cn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                    {
                        // parametro de WHERE fest_id = @Id
                        cmd.Parameters.AddWithValue("@Id",fest_id);
                        // parametros para atualizar
                        cmd.Parameters.AddWithValue("@ClienteId", fest_cli_id);
                        cmd.Parameters.AddWithValue("@UsuarioId", fest_user_id);
                        cmd.Parameters.AddWithValue("@PacoteId",fest_pct_id);
                        cmd.Parameters.AddWithValue("@TemaId",fest_tema_id);
                        cmd.Parameters.AddWithValue("@EspacoId",fest_espc_id);
                        cmd.Parameters.AddWithValue("@StatusId",fest_stt_id);
                        cmd.Parameters.AddWithValue("@TipoEventoId",fest_tpEv_id);
                        cmd.Parameters.AddWithValue("@DataVenda",fest_dtVenda);
                        cmd.Parameters.AddWithValue("@DataFesta",fest_dtFesta);
                        cmd.Parameters.AddWithValue("@Valor",fest_valor);

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
                throw new Exception($"Erro ao atualizar festa: {ex.Message}");
            }
        }
        //-------------------------------------------------------------------
        // C.R.U.DELETE. - Método para excluir uma festa da tabela `tblfestas`
        public bool DeleteFesta()
        {
            string sql = "DELETE FROM tblfestas WHERE fest_id = @Id";
            try
            {
                using (MySqlConnection cn = new MySqlConnection(ConnMySql.strConnMySql))
                {
                    cn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@Id", fest_id);
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
                throw new Exception($"Erro ao excluir festa: {ex.Message}");
            }
        }
    }
}

