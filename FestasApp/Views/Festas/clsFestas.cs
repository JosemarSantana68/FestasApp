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

using FestasApp.Controllers;
using MySql.Data.MySqlClient;
using System.Data;

namespace FestasApp.Views.Festas
{
    public class clsFestas
    {
        // Propriedades correspondentes aos campos da tabela `tblfestas`
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int UsuarioId { get; set; }
        public int? PacoteId { get; set; }
        public int? TemaId { get; set; }
        public int? EspacoId { get; set; }
        public int? StatusId { get; set; }
        public int? TipoEventoId { get; set; }
        public DateTime DataVenda { get; set; }
        public DateTime DataFesta { get; set; }
        public double? Valor { get; set; }

        // Construtor padrão
        public clsFestas() { }

        // Construtor que inicializa todas as propriedades
        public clsFestas(int id, 
                         int clienteId, 
                         int usuarioId, 
                         int? pacoteId, 
                         int? temaId, 
                         int? espacoId, 
                         int? statusId, 
                         int? tipoEventoId, 
                         DateTime dataVenda, 
                         DateTime dataFesta, 
                         double? valor)
        {
            Id = id;
            ClienteId = clienteId;
            UsuarioId = usuarioId;
            PacoteId = pacoteId;
            TemaId = temaId;
            EspacoId = espacoId;
            StatusId = statusId;
            TipoEventoId = tipoEventoId;
            DataVenda = dataVenda;
            DataFesta = dataFesta;
            Valor = valor;
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
                        cmd.Parameters.AddWithValue("@ClienteId", ClienteId);
                        cmd.Parameters.AddWithValue("@UsuarioId", UsuarioId);
                        cmd.Parameters.AddWithValue("@PacoteId", PacoteId);
                        cmd.Parameters.AddWithValue("@TemaId", TemaId);
                        cmd.Parameters.AddWithValue("@EspacoId", EspacoId);
                        cmd.Parameters.AddWithValue("@StatusId", StatusId);
                        cmd.Parameters.AddWithValue("@TipoEventoId", TipoEventoId);
                        cmd.Parameters.AddWithValue("@DataVenda", DataVenda);
                        cmd.Parameters.AddWithValue("@DataFesta", DataFesta);
                        cmd.Parameters.AddWithValue("@Valor", Valor);

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
        // C.READ.U.D. - Método para obter os dados de uma festa específica pelo seu ID
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
                                // Atribuindo valores das colunas às propriedades da classe
                                Id = Convert.ToInt32(dr["fest_id"]);
                                ClienteId = Convert.ToInt32(dr["fest_cli_id"]);
                                UsuarioId = Convert.ToInt32(dr["fest_user_id"]);
                                PacoteId = dr["fest_pct_id"] as int?;
                                TemaId = dr["fest_tema_id"] as int?;
                                EspacoId = dr["fest_espc_id"] as int?;
                                StatusId = dr["fest_stt_id"] as int?;
                                TipoEventoId = dr["fest_tpEv_id"] as int?;
                                DataVenda = Convert.ToDateTime(dr["fest_dtVenda"]);
                                DataFesta = Convert.ToDateTime(dr["fest_dtFesta"]);
                                Valor = dr["fest_valor"] as double?;
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
        // C.READ.U.D. - Método para obter os dados de todas as festas
        public static DataTable ReadAllFestas()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM tblfestas";
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
            string sql = "UPDATE tblfestas SET fest_cli_id = @ClienteId, fest_user_id = @UsuarioId, fest_pct_id = @PacoteId, fest_tema_id = @TemaId, fest_espc_id = @EspacoId, " +
                         "fest_stt_id = @StatusId, fest_tpEv_id = @TipoEventoId, fest_dtVenda = @DataVenda, fest_dtFesta = @DataFesta, fest_valor = @Valor " +
                         "WHERE fest_id = @Id";
            try
            {
                using (MySqlConnection cn = new MySqlConnection(ConnMySql.strConnMySql))
                {
                    cn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, cn))
                    {
                        cmd.Parameters.AddWithValue("@Id", Id);
                        cmd.Parameters.AddWithValue("@ClienteId", ClienteId);
                        cmd.Parameters.AddWithValue("@UsuarioId", UsuarioId);
                        cmd.Parameters.AddWithValue("@PacoteId", PacoteId);
                        cmd.Parameters.AddWithValue("@TemaId", TemaId);
                        cmd.Parameters.AddWithValue("@EspacoId", EspacoId);
                        cmd.Parameters.AddWithValue("@StatusId", StatusId);
                        cmd.Parameters.AddWithValue("@TipoEventoId", TipoEventoId);
                        cmd.Parameters.AddWithValue("@DataVenda", DataVenda);
                        cmd.Parameters.AddWithValue("@DataFesta", DataFesta);
                        cmd.Parameters.AddWithValue("@Valor", Valor);

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
                throw new Exception($"Erro ao excluir festa: {ex.Message}");
            }
        }
    }
}

