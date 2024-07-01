//***********************************************************
//
//   Festa.Com - Aplicativo para Controle de Festas & Eventos
//   Autor: Josemar Santana
//   Linguagem: C#
//
//   Inicio: 23/05/2024
//   Ultima Alteração: 
//   
//   CLASSE DA CONEXÃO MYSQL
//
//************************************************************

namespace FestasApp.Controllers
{
    static class ConnMySql
    {
        private const string servidor = "localhost";
        private const string bancoDados = "festasapp";
        private const string usuario = "root";
        private const string senha = "";

        static public string strConnMySql = $"server = {servidor}; User Id = {usuario}; database = {bancoDados}; password={senha}";

        // Método para testar a conexão
        public static bool TestarConexao()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(strConnMySql))
                {
                    conn.Open();
                    return true;
                }
            }
            catch (MySqlException)
            {
                return false;
            }
        }
    }
}
