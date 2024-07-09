//***********************************************************
//
//   Festa.Com - Aplicativo para Controle de Festas & Eventos
//   Autor: Josemar Santana
//   Linguagem: C#
//
//   Inicio: 23/05/2024
//   Criação do Módulo: 27/06/2024
//   Ultima Alteração: 27/06/2024
//   
//          TABELAS AUXILIARES
//   CLASSE FESTAS ESPAÇOS - C.R.U.D.
//
//************************************************************
/*
  TABLE `tblfestasespacos` (
  `espc_id` int NOT NULL AUTO_INCREMENT,
  `espc_nome` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`espc_id`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
 */

namespace FestasApp.Models
{
    [Table("tblfestasespacos")]
    // Classe que representa a tabela tblfestasespacos
    public class clsFestasEspacos
    {
        // Propriedades que representam as colunas da tabela
        [Key]
        public int espc_id { get; set; }
        public string espc_nome { get; set; } = string.Empty;

        // Construtor padrão
        public clsFestasEspacos() { }

        // Construtor que inicializa todas as propriedades
        public clsFestasEspacos(int id, string nome)
        {
            espc_id = id;
            espc_nome = nome;
        }

        //---------------------------------------
        // C.R.E.A.D.U.D.
        // Método para obter os dados de TODOS registros
        public List<clsFestasEspacos> ReadAll()
        {
            List<clsFestasEspacos> lstFestasEspacos = new List<clsFestasEspacos>();

            // Consulta SQL para obter todos os registros da tabela tblfestasespacos
            string sql = "SELECT * FROM tblfestasespacos";

            try
            {
                // Usando bloco using para garantir que a conexão será fechada corretamente
                using (MySqlConnection conn = new(myConnMySql.strConnMySql))
                {
                    // Abrir conexão com o banco de dados
                    conn.Open();

                    // Criar comando SQL
                    MySqlCommand cmd = new(sql, conn);

                    // Executar o comando e obter o reader
                    MySqlDataReader reader = cmd.ExecuteReader();

                    // Ler os dados retornados pelo reader
                    while (reader.Read())
                    {
                        // Adicionar cada registro à lista
                        lstFestasEspacos.Add(new clsFestasEspacos()
                        {
                            espc_id = reader.GetInt32("espc_id"),
                            espc_nome = reader.GetString("espc_nome")
                        });
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
                // Trata outros tipos de erros
                throw new Exception($"Erro ao obter dados do usuário: {ex.Message}");
            }
            // Retorna a lista de registros
            return lstFestasEspacos;
        }
    } // end class clsFestasEspacos
} // end namespace

