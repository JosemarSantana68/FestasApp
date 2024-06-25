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
    internal class clsFestasDetalhes
    {
        public int Id { get; set; }
        public int FestId { get; set; }
        public TimeSpan? InicioHora { get; set; }
        public TimeSpan? FimHora { get; set; }
        public int? ContratoModeloId { get; set; }
        public int? TotalPessoas { get; set; }
        public int? Adultos { get; set; }
        public int? CriancasPagantes { get; set; }
        public int? CriancasNaoPagantes { get; set; }
        public int? PessoasAMais { get; set; }
        public string Observacao { get; set; } = string.Empty;

        // Construtor padrão
        public clsFestasDetalhes() { }

        // Construtor com parâmetros
        public clsFestasDetalhes(int festId, TimeSpan? inicioHora, TimeSpan? fimHora, int? contratoModeloId, int? totalPessoas, int? adultos, int? criancasPagantes, int? criancasNaoPagantes, int? pessoasAMais, string observacao)
        {
            FestId = festId;
            InicioHora = inicioHora;
            FimHora = fimHora;
            ContratoModeloId = contratoModeloId;
            TotalPessoas = totalPessoas;
            Adultos = adultos;
            CriancasPagantes = criancasPagantes;
            CriancasNaoPagantes = criancasNaoPagantes;
            PessoasAMais = pessoasAMais;
            Observacao = observacao;
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
                        cmd.Parameters.AddWithValue("@FestId", FestId);
                        cmd.Parameters.AddWithValue("@InicioHora", InicioHora);
                        cmd.Parameters.AddWithValue("@FimHora", FimHora);
                        cmd.Parameters.AddWithValue("@ContratoModeloId", ContratoModeloId);
                        cmd.Parameters.AddWithValue("@TotalPessoas", TotalPessoas);
                        cmd.Parameters.AddWithValue("@Adultos", Adultos);
                        cmd.Parameters.AddWithValue("@CriancasPagantes", CriancasPagantes);
                        cmd.Parameters.AddWithValue("@CriancasNaoPagantes", CriancasNaoPagantes);
                        cmd.Parameters.AddWithValue("@PessoasAMais", PessoasAMais);
                        cmd.Parameters.AddWithValue("@Observacao", Observacao);
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
                                FestId = IdFesta;
                                InicioHora = dr["detfest_iniciohora"] as TimeSpan?;
                                FimHora = dr["detfest_fimhora"] as TimeSpan?;
                                ContratoModeloId = dr["detfest_contratomodelo"] != DBNull.Value ? (int?)(sbyte)dr["detfest_contratomodelo"] : null;
                                TotalPessoas = dr["detfest_totalpessoas"] != DBNull.Value ? (int?)Convert.ToInt32(dr["detfest_totalpessoas"]) : null;
                                Adultos = dr["detfest_adultos"] != DBNull.Value ? (int?)Convert.ToInt32(dr["detfest_adultos"]) : null;
                                CriancasPagantes = dr["detfest_criancaspagantes"] != DBNull.Value ? (int?)Convert.ToInt32(dr["detfest_criancaspagantes"]) : null;
                                CriancasNaoPagantes = dr["detfest_criancasnaopagantes"] != DBNull.Value ? (int?)Convert.ToInt32(dr["detfest_criancasnaopagantes"]) : null;
                                PessoasAMais = dr["detfest_pessoasamais"] != DBNull.Value ? (int?)Convert.ToInt32(dr["detfest_pessoasamais"]) : null;
                                Observacao = dr["detfest_observacao"] != DBNull.Value ? (string)dr["detfest_observacao"] : string.Empty;
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
                        cmd.Parameters.AddWithValue("@FestId", FestId);
                        cmd.Parameters.AddWithValue("@InicioHora", InicioHora);
                        cmd.Parameters.AddWithValue("@FimHora", FimHora);
                        cmd.Parameters.AddWithValue("@ContratoModeloId", ContratoModeloId);
                        cmd.Parameters.AddWithValue("@TotalPessoas", TotalPessoas);
                        cmd.Parameters.AddWithValue("@Adultos", Adultos);
                        cmd.Parameters.AddWithValue("@CriancasPagantes", CriancasPagantes);
                        cmd.Parameters.AddWithValue("@CriancasNaoPagantes", CriancasNaoPagantes);
                        cmd.Parameters.AddWithValue("@PessoasAMais", PessoasAMais);
                        cmd.Parameters.AddWithValue("@Observacao", Observacao);
                        cmd.Parameters.AddWithValue("@Id", Id);
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
                        cmd.Parameters.AddWithValue("@Id", Id);
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
