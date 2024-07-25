//----------------------------------------------------------------------------------------
//   Festa.Com - Aplicativo para Controle de Festas & Eventos
//   Autor: Josemar Santana
//   Linguagem: C# .NET
//
//   Inicio de criação do aplicativo: 23/05/2024
//   Criação do módulo: 11/07/2024
//   Ultima Alteração: 14/07/2024
//   
//   CLASSE  class repStatusEF herda de clsFestasStatus,
//   utiliza ENTITY FRAMEWORK / LINQ para auxiliar nas relações com Banco de Dados MySql
//----------------------------------------------------------------------------------------

namespace FestasApp.Repositories
{
    internal class repStatusEF : clsFestasStatus
    {
        public repStatusEF() { }
        //
        // Método para testar a conexão
        private static bool TestarConexao()
        {
            if (!myConnMySql.TestarConexao())
            {
                myLogger.LogInfo("Conexão com o banco de dados falhou.");
                return false;
            }
            return true;
        }
        //
        // método carrega a lista de Status
        public static List<clsFestasStatus> GetStatus()
        {
            // Testa a conexão
            if (!TestarConexao())
                //return []; // Retornando uma lista vazia em vez de null
                return new List<clsFestasStatus>(); // Retornando uma lista vazia em vez de null

            try
            {
                using (var context = new clsFestasContext())
                {

                    var lista = context.Status.OrderBy(l => l.stt_status).ToList();
                    myLogger.LogInfo("Lista de status carregada com sucesso.");
                    return lista;

                }
            }
            catch (Exception ex)
            {
                myLogger.LogError("Erro ao carregar a lista de status.", ex);
                return new List<clsFestasStatus>();
            }
        }
        //
        // método retorna um Status através do Id
        public clsFestasStatus? GetItem(int Id)
        {
            // se não tiver Status selecionado
            if (Id <= 0)
                return null;

            // testa conexão
            if (!TestarConexao())
                return null;

            try
            {
                using (clsFestasContext context = new())
                {
                    var entItem = context.Status.Find(Id);

                    if (entItem != null)
                    {
                        // copiar propriedades do registro encontrado para a instância atual
                        this.stt_status = entItem.stt_status;
                        myLogger.LogInfo($"Item com Id {Id} encontrado e carregado com sucesso.");
                        return this; // retorna registro encontratdo
                    }
                }
            }
            catch (Exception ex)
            {
                myLogger.LogError($"Erro ao carregar o item com Id {Id}.", ex);
                return null;
            }
            return null;
        }
        //
        // método para adicionar um novo registro a tabela
        public static bool AddItem(clsFestasStatus newItem)
        {
            // testa conexão
            if(!TestarConexao())
                return false;

            try
            {
                using (var context = new clsFestasContext())
                {
                    context.Status.Add(newItem);
                    context.SaveChanges();
                    myLogger.LogInfo("Item adicionado com sucesso.");
                    return true;
                }
            }
            catch (Exception ex)
            {
                myLogger.LogError("Erro ao adicionar um novo item.", ex);
                return false;
            }
        }
        //
        // método para editar um registro na tabela
        public static bool AlterItem(int idItem, clsFestasStatus itemAlterado)
        {
            // testa conexão
            if (!TestarConexao())
                return false;

            try
            {
                using (clsFestasContext context = new())
                {
                    var itemExist = context.Status.Find(idItem);
                    if (itemExist != null)
                    {
                        itemExist.stt_status = itemAlterado.stt_status;
                        context.SaveChanges();
                        myLogger.LogInfo($"Item com Id {idItem} atualizado com sucesso.");
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                myLogger.LogError($"Erro ao atualizar o item com Id {idItem}.", ex);
                return false;
            }
            return false;
        }
        //
        // método para deletar item na tabela
        public static bool DeleteItem(int idItem)
        {
            // testa conexão
            if (!TestarConexao())
                return false;

            try
            {
                using (clsFestasContext context = new())
                {
                    var itemExist = context.Status.Find(idItem);
                    if (itemExist != null)
                    {
                        context.Status.Remove(itemExist);
                        context.SaveChanges();
                        myLogger.LogInfo($"Item com Id {idItem} removido com sucesso.");
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                myLogger.LogError($"Erro ao deletar o item com Id {idItem}.", ex);
                return false;
            }
            return false;
        }
        //

    } // end class repStatusEF : clsFestasStatus
} // end namespace FestasApp.Repositories
