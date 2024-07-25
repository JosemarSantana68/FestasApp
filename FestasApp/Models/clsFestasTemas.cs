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
//   CLASSE FESTAS TEMAS - C.R.U.D.
//
//************************************************************
/*
 TABLE `tblfestastemas` (
  `tema_id` int NOT NULL AUTO_INCREMENT,
  `tema_nome` varchar(100) DEFAULT NULL,
  `tema_descricao` text,
  PRIMARY KEY (`tema_id`)
) ENGINE=MyISAM AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
 */

namespace FestasApp.Models
{
    [Table("tblfestastemas")]
    public class clsFestasTemas
    {
        [Key]
        public int tema_id { get; set; }
        public string tema_nome { get; set; } = string.Empty;
        public string? tema_descricao { get; set; } = string.Empty;

        public clsFestasTemas() { }

        public clsFestasTemas(string tema_nome, string? tema_descricao)
        {
            this.tema_nome = tema_nome;
            this.tema_descricao = tema_descricao;
        }
    }// end class clsFestasTemas
}
