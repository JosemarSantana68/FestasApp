//----------------------------------------------------------------------------------------
//   Festa.Com - Aplicativo para Controle de Festas & Eventos
//   Autor: Josemar Santana
//   Linguagem: C#
//
//   Inicio de criação do aplicativo: 23/05/2024
//   Criação do módulo: 11/07/2024
//   Ultima Alteração: 11/07/2024
//   
//   CLASSE  class repTipoEventoEF herda de clsFestasTemas,
//   utiliza ENTITY FRAMEWORK / LINQ para auxiliar nas relações com Banco de Dados MySql
//----------------------------------------------------------------------------------------

namespace FestasApp.Repositories
{
   

    internal class repTipoEventoEF : clsFestasTipoEvento
    {
        private clsParam _param;

        public repTipoEventoEF() 
        {
            _param = new clsParam();
        }
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
        // Carrega a lista de Status
        public static List<clsFestasTipoEvento> GetTipoEvento()
        {
            // Testa a conexão
            if (!TestarConexao())
                return []; // Retornando uma lista vazia em vez de null

            try
            {
                using (var context = new clsFestasContext())
                {
                    var lista = context.TipoEvento.OrderBy(l => l.tpev_nome).ToList();
                    return lista;
                }
            }
            catch (Exception) { }
            return []; // Retornando uma lista vazia em vez de null
        }
        //
        // método retorna um Registro através do Id
        public clsFestasTipoEvento? GetItem(int Id)
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
                    var entItem = context.TipoEvento.Find(Id);

                    if (entItem != null)
                    {
                        // copiar propriedades do registro encontrado para a instância atual
                        this.tpev_nome = entItem.tpev_nome;
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
        public static bool AddItem(clsFestasTipoEvento newItem)
        {
            // testa conexão
            if (!TestarConexao())
                return false;
            
            try
            {
                using (var context = new clsFestasContext())
                {
                    context.TipoEvento.Add(newItem);
                    context.SaveChanges();
                    myLogger.LogInfo("Item adicionado com sucesso.");
                    //
                    //_param.Id = newItem.tpev_id;

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
        public static bool AlterItem(int idItem, clsFestasTipoEvento itemAlterado)
        {
            // testa conexão
            if (!TestarConexao())
                return false;

            try
            {
                using (clsFestasContext context = new())
                {
                    var itemExist = context.TipoEvento.Find(idItem);
                    if (itemExist != null)
                    {
                        itemExist.tpev_nome = itemAlterado.tpev_nome;
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
                    var itemExist = context.TipoEvento.Find(idItem);
                    if (itemExist != null)
                    {
                        context.TipoEvento.Remove(itemExist);
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

    } // end class repTipoEventoEF : clsFestasTemas

} // end namespace FestasApp.Repositories
