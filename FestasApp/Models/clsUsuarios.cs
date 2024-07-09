//***********************************************************
//
//   Festa.Com - Aplicativo para Controle de Festas & Eventos
//   Autor: Josemar Santana
//   Linguagem: C#
//
//   Inicio do Sistema: 23/05/2024
//   Inicio deste Módulo: 10/06/2024
//   Ultima Alteração: 10/06/2024 
//   
//   CLASSE DE USUARIOS - C.R.U.D
//
//************************************************************
// TABLE `tblusuarios` 
//  `user_id`       int NOT NULL AUTO_INCREMENT,
//  `user_nome`     varchar(100)    NOT NULL,
//  `user_login`    varchar(50)     DEFAULT NULL,
//  `user_email`    varchar(100)    DEFAULT NULL,
//  `user_senha`    varchar(50)     NOT NULL,
//  `user_ativo`    tinyint         DEFAULT NULL,

namespace FestasApp.Models
{
    [Table("tblusuarios")]
    public class clsUsuarios
    {
        // Propriedades correspondentes aos campos da tabela `tblUsuarios`
        [Key]
        public int user_id { get; set; }
        public string? user_nome { get; set; }
        public string? user_login { get; set; }
        public string? user_email { get; set; }
        public string? user_senha { get; set; }
        public bool user_ativo { get; set; }

        // Construtor padrão
        public clsUsuarios() { }

        // Construtor que inicializa todas as propriedades
        public clsUsuarios(int id,
                            string nome,
                            string login,
                            string email,
                            string senha,
                            bool ativo)
        {
            user_id = id;
            user_nome = nome;
            user_login = login;
            user_email = email;
            user_senha = senha;
            user_ativo = ativo;
        }
        
    } // end class
} // end namespace clsUsuarios
