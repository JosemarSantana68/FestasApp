//----------------------------------------------------------------------------------------
//   Festa.Com - Aplicativo para Controle de Festas & Eventos
//   Autor: Josemar Santana
//   Linguagem: C#
//
//   Inicio de criação do aplicativo: 23/05/2024
//   Criação do módulo: 09/07/2024
//   Ultima Alteração: 09/07/2024
//   
//   CLASSE repFestasAdicionais herda de clsFestasAdicionais,
//   utiliza ENTITY FRAMEWORK / LINQ para auxiliar nas relações com Banco de Dados MySql
//----------------------------------------------------------------------------------------

namespace FestasApp.Repositories
{
    public class repAdicionaisEF : clsFestasAdicionais
    {
        // construtor
        public repAdicionaisEF() { }
        //
        //
        public static List<clsFestasAdicionais>? GetItensFestaEF(int festaId)
        {
            // testa conexão
            if (!myConnMySql.TestarConexao())
                return null;

            try
            {
                using (var context = new clsFestasContext())
                {
                    // Obtém os adicionais da festa selecionada, incluindo os itens relacionados
                    var adicionaisFesta = context.Adicionais // tblFestasAdicionais
                                                    .Include(a => a.ItensFestas)    // tblFestasItens        
                                                    .Where(a => a.add_fest_id == festaId) // filtra adicionais do id da festa
                                                    .ToList();

                    return adicionaisFesta;
                }
            }
            catch (MySqlException) //mysqlEx
            {
                // Trata erros específicos do MySQL
                //FormMenuMain.ShowMyMessageBox($"Erro no banco de dados: {mysqlEx.Message}", "SQL exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception) //ex
            {
                // Trata outros tipos de exceções
                //FormMenuMain.ShowMyMessageBox($"Erro: {ex.Message}", "Erro no Banco de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return null;
        }

    }
}
