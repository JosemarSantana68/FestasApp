//-------------------------------------------------------------
//
//   Festa.Com - Aplicativo para Controle de Festas & Eventos
//   Autor: Josemar Santana
//   Linguagem: C#
//
//   Inicio: 23/05/2024
//   Criação do módulo: 23/05/2024
//   Ultima Alteração: 15/07/2024
//   
//   CLASSE DA CONEXÃO MYSQL
//
//-------------------------------------------------------------

namespace FestasApp.Controllers
{
    static class myConnMySql
    {
        private const string servidor = "localhost";
        private const string bancoDados = "festasapp";
        private const string usuario = "root";
        private const string senha = "";

        static public string strConnMySql = $"server = {servidor}; User Id = {usuario}; database = {bancoDados}; password={senha}";

        // Método para testar a conexão e atualizar status no label
        public static bool TestarConexao()
        {
            var formMenuMain = FormMenuMain.Instance;
            try
            {
                using (MySqlConnection conn = new(strConnMySql))
                {
                    conn.Open();
                    formMenuMain!.SetLabelStatusConexao(true);
                    return true;
                }
            }
            catch (MySqlException)
            {
                formMenuMain!.SetLabelStatusConexao(false);
                return false;
            }
        }
    } // end static class myConnMySql
} // end namespace FestasApp.Controllers
