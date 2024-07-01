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
//   CLASSE FESTAS ITENS - C.R.U.D.
//
//************************************************************
/*
  TABLE `tblfestasitens` (
  `itensfest_id`        int NOT NULL AUTO_INCREMENT,
  `itensfest_tipo`      varchar(50) DEFAULT NULL,
  `itensfest_nome`      varchar(100) DEFAULT NULL,
  `itensfest_descricao` text,
  `itensfest_valor`     decimal(10,2) DEFAULT NULL,
  PRIMARY KEY (`itensfest_id`)
) ENGINE=MyISAM AUTO_INCREMENT=9 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
 */

namespace FestasApp.Models
{
    [Table("tblfestasitens")]
    public class clsFestasItens
    {
        [Key]
        public int itensfest_id { get; set; }

        public string itensfest_tipo { get; set; } = string.Empty;
        public string itensfest_nome { get; set; } = string.Empty;
        public string itensfest_descricao { get; set; } = string.Empty;
        public double itensfest_valor { get; set; }


        public clsFestasItens() { }
        public clsFestasItens(int itensfest_id, string itensfest_tipo, string itensfest_nome, string itensfest_descricao, double itensfest_valor)
        {
            this.itensfest_id = itensfest_id;
            this.itensfest_tipo = itensfest_tipo;
            this.itensfest_nome = itensfest_nome;
            this.itensfest_descricao = itensfest_descricao;
            this.itensfest_valor = itensfest_valor;
        }

      
    } // end class clsFestasItens
}
