//***********************************************************
//
//   Festa.Com - Aplicativo para Controle de Festas & Eventos
//   Autor: Josemar Santana
//   Linguagem: C#
//
//   Inicio: 23/05/2024
//   Criação do Módulo: 19/06/2024
//   Ultima Alteração: 19/06/2024
//   
//   CLASSE FESTAS-PACOTES - C.R.U.D.
//
//************************************************************
/*
 TABLE `tblfestaspacotes` (
  `pct_id`          int             NOT NULL AUTO_INCREMENT,
  `pct_nome`        varchar(150)    NOT NULL,
  `pct_descricao`   varchar(300)    DEFAULT NULL,
  `pct_duracao`     varchar(50)     DEFAULT NULL,
  `pct_valor`       decimal(10,2)   DEFAULT NULL,
  PRIMARY KEY (`pct_id`)
) 
ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci 
COMMENT='Tipos de Pacotes, relação com tblfestas'; 
*/

namespace FestasApp.Models
{
    internal class clsFestasPacotes
    {
        // propriedades
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string Duracao { get; set; } = string.Empty;
        public double Valor { get; set; }

        // Construtor padrão
        public clsFestasPacotes() { }

        // Construtor que inicializa todas as propriedades
        public clsFestasPacotes(int id, string nome, string descricao, string duracao, double valor)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Duracao = duracao;
            Valor = valor;
        }
        //
        //----------------------------------------------------------------
        // CREATE.R.U.D. - Método para inserir uma novo registro na tabela
        public bool CreatePacotes()
        {
            // sql - Remover pct_id da consulta, pois é AUTO_INCREMENT
            string sql = "INSERT INTO tblfestaspacotes (pct_nome, pct_descricao, pct_duracao, pct_valor) " +
                         "VALUES (@Nome, @Descricao, @Duracao, @Valor)";
            try
            {
                // conexão
                using (MySqlConnection conn = new MySqlConnection(ConnMySql.strConnMySql))
                {
                    // abrir conexão
                    conn.Open();
                    // comando
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        // parametros comando
                        cmd.Parameters.AddWithValue("@Nome", Nome);
                        cmd.Parameters.AddWithValue("@Descricao", Descricao);
                        cmd.Parameters.AddWithValue("@Duracao", Duracao);
                        cmd.Parameters.AddWithValue("@Valor", Valor);
                        // executa comando
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
                throw new Exception($"Erro ao inserir registro: {ex.Message}");
            }
        } // end create

        //------------------------------------------------------------------------------------------
        // C.READ.U.D. - Método para obter os dados de um registro específica da tabela, pelo seu ID
        public void ReadUnicoPacote(int IdPctFesta)
        {
            // sql
            string sql = "SELECT * FROM tblfestaspacotes WHERE pct_id = @Id";

            try
            {
                using (MySqlConnection conn = new MySqlConnection(ConnMySql.strConnMySql))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", IdPctFesta);
                        // execute o DataReader para lê registro na tabela
                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            // se encontrar, popula os propriedades da classe
                            if (dr.HasRows && dr.Read())
                            {
                                Id = IdPctFesta; // Mantém o valor do parâmetro

                                // Verificações para evitar NullReferenceException
                                Nome = dr[nameof(Nome)]?.ToString() ?? string.Empty;
                                Descricao = dr[nameof(Descricao)]?.ToString() ?? string.Empty;
                                Duracao = dr[nameof(Duracao)]?.ToString() ?? string.Empty;
                                Valor = dr[nameof(Valor)] != DBNull.Value ? Convert.ToDouble(dr[nameof(Valor)]) : 0;
                            }
                        }
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
                // Trata outros tipos de exceções
                throw new Exception($"Erro ao recuperar registro: {ex.Message}");
            }
        }

        //------------------------------------------------------------------------
        // C.READ.U.D. - Método para obter os dados de todos os registro da tabela

        //------------------------------------------------------------------------
        // C.R.UPDATE.D. - Método para atualizar os dados de um registro na tabela

        //-----------------------------------------------------------
        // C.R.U.DELETE. - Método para excluir uma registro da tabela
        public bool DeletePacoteFesta()
        {
            string sql = "DELETE FROM tblfestaspacotes WHERE pct_id = @Id";
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
                // Trata erros específicos do MySQL
                throw new Exception($"Erro no banco de dados: {mysqlEx.Message}");
            }
            catch (Exception ex)
            {
                // Trata outros tipos de exceções
                throw new Exception($"Erro ao excluir registro: {ex.Message}");
            }
        } // end delete

    } // end class clsFestasPacotes
} // end FestasApp.Views.FestasPacotes
