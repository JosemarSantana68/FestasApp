//***********************************************************
//
//   Festa.Com - Aplicativo para Controle de Festas & Eventos
//   Autor: Josemar Santana
//   Linguagem: C#
//
//   Inicio de criação do aplicativo: 23/05/2024
//   Criação do módulo: 08/07/2024
//   Ultima Alteração: 08/07/2024
//   
//   CLASSE repFestasEF herda de clsFestas,
//   utiliza ENTITY FRAMEWORK / LINQ para auxiliar nas relações com Banco de Dados MySql
//  
//************************************************************

namespace FestasApp.Repositories
{
    public class repFestasEF : clsFestas
    {
        // construtor
        public repFestasEF() { }
        //
        // retorna um objeto festa através do id
        public clsFestas? GetFesta(int idFesta)
        {
            // se não tiver festa selecionada
            if (idFesta == 0)
                return null;

            // testa a conexão
            if (!myConnMySql.TestarConexao())
                return null;

            try
            {
                using (var context = new clsFestasContext())
                {
                    // obter um único registro por ID:
                    //var entFesta = context.Festas.Find(idFesta);
                    var entFesta = context.Festas.FirstOrDefault(f => f.fest_id == idFesta);

                    if (entFesta != null)
                    {
                        // Copiar propriedades da festa encontrada para a instância atual
                        fest_id = entFesta.fest_id;
                        fest_cli_id = entFesta.fest_cli_id;
                        fest_user_id = entFesta.fest_user_id;
                        fest_pct_id = entFesta.fest_pct_id;
                        fest_tema_id = entFesta?.fest_tema_id;
                        fest_espc_id = entFesta?.fest_espc_id;
                        fest_stt_id = entFesta?.fest_stt_id;
                        fest_tpEv_id = entFesta?.fest_tpEv_id;
                        fest_dtVenda = entFesta?.fest_dtFesta;
                        fest_dtFesta = entFesta?.fest_dtFesta;
                        fest_valor = entFesta?.fest_valor;

                        return this; // Retornar a instância atual
                    }
                }
            }
            catch (Exception ex)
            {
                // Log de erro (opcional)
                //Console.WriteLine($"Erro ao buscar festa: {ex.Message}");
                return null;
            }
            return null;
        }
        //
        public static List<clsFestas>? GetFestasEF()
        {
            // testa conexão
            if (!myConnMySql.TestarConexao())
                return null;

            try
            {
                using (var context = new clsFestasContext())
                {
                    var listaFestas = context.Festas
                    .Include(f => f.Cliente)
                    .Include(f => f.Pacote)
                    .Include(f => f.Tema)
                    .Include(f => f.Espaco)
                    .Include(f => f.Status)
                    .Include(f => f.TipoEvento)
                    .Include(f => f.Usuario)
                    .OrderBy(f => f.fest_dtFesta)
                    .ToList();

                    return listaFestas;
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
        


    } // end class repFestasEF
}
