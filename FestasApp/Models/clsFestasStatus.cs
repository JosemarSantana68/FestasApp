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
CREATE TABLE `tblfestasstatus` (
  `stt_id` int NOT NULL AUTO_INCREMENT,
  `stt_status` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`stt_id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
 */

namespace FestasApp.Models
{
    [Table("tblfestasstatus")]
    public class clsFestasStatus
    {
        [Key]
        public int stt_id { get; set; }
        public string stt_status { get; set; } = string.Empty;
        public clsFestasStatus() { }
        public clsFestasStatus(int id, string status)
        {
            stt_id = id;
            stt_status = status;
        }
    }
}
