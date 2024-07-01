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
//   CLASSE FESTAS TIPOS EVENTOS - C.R.U.D.
//
//************************************************************
/*
CREATE TABLE `tblfestastipoevento` (
  `tpev_id` int NOT NULL AUTO_INCREMENT,
  `tpev_nome` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`tpev_id`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
 */

namespace FestasApp.Models
{
    [Table("tblfestastipoevento")]
    public class clsFestasTipoEvento
    {
        [Key]
        public int tpev_id { get; set; }
        public string tpev_nome { get; set; } = string.Empty;
        
        // construtores
        public clsFestasTipoEvento() { }
        public clsFestasTipoEvento(int id, string nome)
        {
            tpev_id = id;
            tpev_nome = nome;
        }

    } // end class clsFestasTipoEvento
}
