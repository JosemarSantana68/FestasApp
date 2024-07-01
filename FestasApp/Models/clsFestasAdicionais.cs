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
//   CLASSE FESTAS ADICIONAIS - C.R.U.D.
//
//************************************************************
/*
 TABLE `tblfestasadicionais` (
  `add_id`              int NOT NULL AUTO_INCREMENT,
  `add_fest_id`         int NOT NULL,
  `add_itensfest_id`    int NOT NULL,
  `add_qtde`            int DEFAULT NULL,
  `add_valor`           decimal(10,2) DEFAULT NULL,
  PRIMARY KEY (`add_id`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
 */

namespace FestasApp.Models
{
    [Table("tblfestasadicionais")]
    public class clsFestasAdicionais
    {
        [Key]
        public int add_id { get; set; }
        //
        [ForeignKey("Festas")]
        public int add_fest_id { get; set; }
        //
        [ForeignKey("ItensFestas")]
        public int add_itensfest_id { get; set; }
        //
      
        public int add_qtde {  get; set; }
        public double add_valor { get; set; }

        // relação com clsFestas
        public clsFestas? Festas { get; set; }

        // relação com clsFestasItens
        public clsFestasItens? ItensFestas { get; set; }


        // Construtor padrão
        public clsFestasAdicionais() { }
        // Construtor que inicializa todas as propriedades
        public clsFestasAdicionais(int add_id, int add_fest_id, int add_itensfest_id, int add_qtde, double add_valor)
        {
            this.add_id = add_id;
            this.add_fest_id = add_fest_id;
            this.add_itensfest_id = add_itensfest_id;
            this.add_qtde = add_qtde;
            this.add_valor = add_valor;
        }
        //
        // C.READ.U.D. - Método para obter os itens de festa especifica 
        // COM NOMES DAS AUXILIARES
        public static DataTable ReadAddItens(int festId)
        {
            DataTable dt = new DataTable();
            // Consulta SQL para selecionar os dados das festas com o nome do cliente
            string sql = @"
                            SELECT 
                                i.itensfest_nome,
                                a.add_qtde,                
                                a.add_valor               
                                FROM tblfestasadicionais a
                            JOIN tblfestasitens i ON a.add_itensfest_id = i.itensfest_id
                            WHERE a.add_fest_id = @festId";
            try
            {
                using (MySqlConnection cn = new MySqlConnection(ConnMySql.strConnMySql))
                {
                    cn.Open();
                    using (MySqlDataAdapter da = new MySqlDataAdapter(sql, cn))
                    {
                        da.SelectCommand.Parameters.AddWithValue("@festId", festId);
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


    } // end class clsFestasAdicionais
} // end namespace
