//--------------------------------------------------------------
//
//   Festa.Com - Aplicativo para Controle de Festas & Eventos
//   Autor: Josemar Santana
//   Linguagem: C#
//
//   Inicio: 23/05/2024
//   Criação do Módulo: 04/07/2024
//   Ultima Alteração: 004/07/2024
//   
//   CLASSE FESTAS-CONTRATOS.
//
//--------------------------------------------------------------
/*
CREATE TABLE `tblfestascontratos` (
  `ctt_id` int NOT NULL AUTO_INCREMENT,
  `ctt_nome` varchar(100) DEFAULT NULL,
  `ctt_caminho_arquivo` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`ctt_id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
*/

namespace FestasApp.Models
{
    [Table("tblfestascontratos")]
    public class clsFestasContratos
    {
        [Key]
        public int ctt_id { get; set; }
        public string? ctt_nome { get; set; }
        public string? ctt_caminho_arquivo { get; set; } // Caminho para o arquivo PDF

        public clsFestasContratos() { }
        public clsFestasContratos(string? ctt_nome, string? ctt_caminho_arquivo)
        {
            this.ctt_nome = ctt_nome;
            this.ctt_caminho_arquivo = ctt_caminho_arquivo;
        }
    }
}
