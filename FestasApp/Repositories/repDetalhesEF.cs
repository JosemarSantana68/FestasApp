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
//   CLASSE repFestasDetalhesEF herda de clsFestasDetalhes,
//   utiliza ENTITY FRAMEWORK / LINQ para auxiliar nas relações com Banco de Dados MySql
//  
//************************************************************

namespace FestasApp.Repositories
{
    public class repDetalhesEF : clsFestasDetalhes
    {
        // construtor
        public repDetalhesEF() { }
        //
        // carrega um objeto com detalhes de uma festa, passado o id
        public clsFestasDetalhes? GetDetalhesFestaEF(int festaId)
        {
            // testa conexão
            if (!myConnMySql.TestarConexao())
                return null;

            try
            {
                using (var context = new clsFestasContext())
                {
                    // Obtém os detalhes da festa selecionada
                    var entdetalhesFesta = context.Detalhes
                                                .Include(d => d.Festas)
                                                .FirstOrDefault(d => d.detfest_fest_id == festaId);

                    if (entdetalhesFesta != null)
                    {
                        this.detfest_id = entdetalhesFesta.detfest_id;
                        this.detfest_fest_id = entdetalhesFesta.detfest_fest_id;
                        this.detfest_iniciohora = entdetalhesFesta.detfest_iniciohora;
                        this.detfest_fimhora = entdetalhesFesta.detfest_fimhora;
                        this.detfest_ctt_id = entdetalhesFesta.detfest_ctt_id;
                        this.detfest_totalpessoas = entdetalhesFesta.detfest_totalpessoas;
                        this.detfest_adultos = entdetalhesFesta.detfest_adultos;
                        this.detfest_criancaspagantes = entdetalhesFesta.detfest_criancaspagantes;
                        this.detfest_criancasnaopagantes = entdetalhesFesta.detfest_criancasnaopagantes;
                        this.detfest_pessoasamais = entdetalhesFesta.detfest_pessoasamais;
                        this.detfest_observacao = entdetalhesFesta.detfest_observacao;

                        return this; // Retornar a instância atual
                    }
                    
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
