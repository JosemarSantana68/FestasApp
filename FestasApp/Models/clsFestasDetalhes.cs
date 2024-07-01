//***********************************************************
//
//   Festa.Com - Aplicativo para Controle de Festas & Eventos
//   Autor: Josemar Santana
//   Linguagem: C#
//
//   Inicio: 23/05/2024
//   Criação do Módulo: 20/06/2024
//   Ultima Alteração: 20/06/2024
//   
//   CLASSE FESTAS-DETALHES - C.R.U.D.
//
//************************************************************
/*
 TABLE `tblfestasdetalhes` (
  `detfest_id`                  int     NOT NULL AUTO_INCREMENT,
  `detfest_fest_id`             int     NOT NULL,
  `detfest_iniciohora`          time    DEFAULT NULL,
  `detfest_fimhora`             time    DEFAULT NULL,
  `detfest_contratomodelo`      tinyint     DEFAULT NULL,
  `detfest_totalpessoas`        smallint DEFAULT NULL,
  `detfest_adultos`             smallint DEFAULT NULL,
  `detfest_criancaspagantes`    smallint DEFAULT NULL,
  `detfest_criancasnaopagantes` smallint DEFAULT NULL,
  `detfest_pessoasamais`        smallint DEFAULT NULL,
  `detfest_observacao`          text,
  PRIMARY KEY (`detfest_id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci COMMENT='Detalhes das Festas, relaciona com tblfestas';
 */

namespace FestasApp.Models
{
    [Table("tblfestasdetalhes")]
    public class clsFestasDetalhes
    {
        [Key]
        public int detfest_id { get; set; }
        //
        [ForeignKey("Festas")]
        public int detfest_fest_id { get; set; }
        //
        public TimeSpan? detfest_iniciohora { get; set; }
        public TimeSpan? detfest_fimhora { get; set; }
        public int? detfest_contratomodelo { get; set; }
        public int? detfest_totalpessoas { get; set; }
        public int? detfest_adultos { get; set; }
        public int? detfest_criancaspagantes { get; set; }
        public int? detfest_criancasnaopagantes { get; set; }
        public int? detfest_pessoasamais { get; set; }
        public string detfest_observacao { get; set; } = string.Empty;

        // relação com clsFestas
        public clsFestas? Festas { get; set; }

        // Construtor padrão
        public clsFestasDetalhes() { }
        // Construtor com parâmetros
        public clsFestasDetalhes(int detfest_id, int detfest_fest_id, TimeSpan? detfest_iniciohora, TimeSpan? detfest_fimhora, int? detfest_contratomodelo, int? detfest_totalpessoas, int? detfest_adultos, int? detfest_criancaspagantes, int? detfest_criancasnaopagantes, int? detfest_pessoasamais, string detfest_observacao)
        {
            this.detfest_id = detfest_id;
            this.detfest_fest_id = detfest_fest_id;
            this.detfest_iniciohora = detfest_iniciohora;
            this.detfest_fimhora = detfest_fimhora;
            this.detfest_contratomodelo = detfest_contratomodelo;
            this.detfest_totalpessoas = detfest_totalpessoas;
            this.detfest_adultos = detfest_adultos;
            this.detfest_criancaspagantes = detfest_criancaspagantes;
            this.detfest_criancasnaopagantes = detfest_criancasnaopagantes;
            this.detfest_pessoasamais = detfest_pessoasamais;
            this.detfest_observacao = detfest_observacao;
        }

        //-------------------------------------------------------------------------
        // Implementação do método CRUD (Create) seguindo o mesmo padrão de estrutura
        public bool Create()
        {
            string sql = "INSERT INTO tblfestasdetalhes (detfest_fest_id, detfest_iniciohora, detfest_fimhora, detfest_contratomodelo, detfest_totalpessoas, detfest_adultos, detfest_criancaspagantes, detfest_criancasnaopagantes, detfest_pessoasamais, detfest_observacao)" +
                         "VALUES (@FestId, @InicioHora, @FimHora, @ContratoModeloId, @TotalPessoas, @Adultos, @CriancasPagantes, @CriancasNaoPagantes, @PessoasAMais, @Observacao)";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnMySql.strConnMySql))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@FestId", detfest_fest_id);
                        cmd.Parameters.AddWithValue("@InicioHora", detfest_iniciohora);
                        cmd.Parameters.AddWithValue("@FimHora", detfest_fimhora);
                        cmd.Parameters.AddWithValue("@ContratoModeloId", detfest_contratomodelo);
                        cmd.Parameters.AddWithValue("@TotalPessoas", detfest_totalpessoas);
                        cmd.Parameters.AddWithValue("@Adultos", detfest_adultos);
                        cmd.Parameters.AddWithValue("@CriancasPagantes", detfest_criancaspagantes);
                        cmd.Parameters.AddWithValue("@CriancasNaoPagantes", detfest_criancasnaopagantes);
                        cmd.Parameters.AddWithValue("@PessoasAMais", detfest_pessoasamais);
                        cmd.Parameters.AddWithValue("@Observacao", detfest_observacao);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (MySqlException mysqlEx)
            {
                throw new Exception($"Erro no banco de dados: {mysqlEx.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao inserir registro: {ex.Message}");
            }
        }
        //-------------------------------------------------------------------------
        // Implementação do método CRUD (Read) seguindo o mesmo padrão de estrutura
        public void ReadOnlyOne(int IdFesta)
        {
            // faz a pesquisa pelo Id da Festa
            string sql = "SELECT * FROM tblfestasdetalhes WHERE detfest_fest_id = @Idfesta";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnMySql.strConnMySql))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Idfesta", IdFesta);
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.HasRows && dr.Read())
                            {
                                detfest_fest_id = IdFesta;
                                detfest_iniciohora = dr["detfest_iniciohora"] as TimeSpan?;
                                detfest_fimhora = dr["detfest_fimhora"] as TimeSpan?;
                                detfest_contratomodelo = dr["detfest_contratomodelo"] != DBNull.Value ? (int?)(sbyte)dr["detfest_contratomodelo"] : null;
                                detfest_totalpessoas = dr["detfest_totalpessoas"] != DBNull.Value ? (int?)Convert.ToInt32(dr["detfest_totalpessoas"]) : null;
                                detfest_adultos = dr["detfest_adultos"] != DBNull.Value ? (int?)Convert.ToInt32(dr["detfest_adultos"]) : null;
                                detfest_criancaspagantes = dr["detfest_criancaspagantes"] != DBNull.Value ? (int?)Convert.ToInt32(dr["detfest_criancaspagantes"]) : null;
                                detfest_criancasnaopagantes = dr["detfest_criancasnaopagantes"] != DBNull.Value ? (int?)Convert.ToInt32(dr["detfest_criancasnaopagantes"]) : null;
                                detfest_pessoasamais = dr["detfest_pessoasamais"] != DBNull.Value ? (int?)Convert.ToInt32(dr["detfest_pessoasamais"]) : null;
                                detfest_observacao = dr["detfest_observacao"] != DBNull.Value ? (string)dr["detfest_observacao"] : string.Empty;
                            }
                        }
                    }
                }
            }
            catch (MySqlException mysqlEx)
            {
                throw new Exception($"Erro no banco de dados: {mysqlEx.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao ler registros: {ex.Message}");
            }
        }
        //-------------------------------------------------------------------------
        // Implementação do método CRUD (Read) seguindo o mesmo padrão de estrutura
        public static DataTable ReadAll()
        {
            string sql = "SELECT * FROM tblfestasdetalhes";
            DataTable dt = new DataTable();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnMySql.strConnMySql))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            dt.Load(dr);
                        }
                    }
                }
            }
            catch (MySqlException mysqlEx)
            {
                throw new Exception($"Erro no banco de dados: {mysqlEx.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao ler registros: {ex.Message}");
            }
            return dt;
        }
        //------------------------------------------------------------------------------------------------
        // Implementação do método CRUD (Update) seguindo o mesmo padrão de estrutura
        public bool Update()
        {
            string sql = "UPDATE tblfestasdetalhes SET detfest_fest_id = @FestId, detfest_iniciohora = @InicioHora, detfest_fimhora = @FimHora, detfest_contratomodelo = @ContratoModeloId, detfest_totalpessoas = @TotalPessoas, detfest_adultos = @Adultos, detfest_criancaspagantes = @CriancasPagantes, detfest_criancasnaopagantes = @CriancasNaoPagantes, detfest_pessoasamais = @PessoasAMais, detfest_observacao = @Observacao WHERE detfest_id = @Id";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnMySql.strConnMySql))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", detfest_id);
                        cmd.Parameters.AddWithValue("@FestId", detfest_fest_id);
                        cmd.Parameters.AddWithValue("@InicioHora", detfest_iniciohora);
                        cmd.Parameters.AddWithValue("@FimHora", detfest_fimhora);
                        cmd.Parameters.AddWithValue("@ContratoModeloId", detfest_contratomodelo);
                        cmd.Parameters.AddWithValue("@TotalPessoas", detfest_totalpessoas);
                        cmd.Parameters.AddWithValue("@Adultos", detfest_adultos);
                        cmd.Parameters.AddWithValue("@CriancasPagantes", detfest_criancaspagantes);
                        cmd.Parameters.AddWithValue("@CriancasNaoPagantes", detfest_criancasnaopagantes);
                        cmd.Parameters.AddWithValue("@PessoasAMais", detfest_pessoasamais);
                        cmd.Parameters.AddWithValue("@Observacao", detfest_observacao);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (MySqlException mysqlEx)
            {
                throw new Exception($"Erro no banco de dados: {mysqlEx.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao atualizar registro: {ex.Message}");
            }
        }
        //
        // Implementação do método CRUD (Delete) seguindo o mesmo padrão de estrutura
        public bool Delete()
        {
            string sql = "DELETE FROM tblfestasdetalhes WHERE detfest_id = @Id";
            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnMySql.strConnMySql))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", detfest_fest_id);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (MySqlException mysqlEx)
            {
                throw new Exception($"Erro no banco de dados: {mysqlEx.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao excluir registro: {ex.Message}");
            }
        }

    }// end class clsFestasDetalhes
} // end namespace FestasApp.Views.FestasDetalhes
