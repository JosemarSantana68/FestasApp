//----------------------------------------------------------------------------------------
//   Festa.Com - Aplicativo para Controle de Festas & Eventos
//   Autor: Josemar Santana
//   Linguagem: C#
//
//   Inicio de criação do aplicativo: 23/05/2024
//   Criação do módulo: 09/07/2024
//   Ultima Alteração: 09/07/2024
//   
//   CLASSE repEspacosEF herda de clsFestasEspacos,
//   utiliza ENTITY FRAMEWORK / LINQ para auxiliar nas relações com Banco de Dados MySql
//----------------------------------------------------------------------------------------

namespace FestasApp.Repositories
{
    public class repEspacosEF : clsFestasEspacos
    {
        // construtor
        public repEspacosEF() { }
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
        // carrega uma lista da tblfestasespacos
        public static List<clsFestasEspacos> GetEspacos()
        {
            if (!TestarConexao())
                return new List<clsFestasEspacos>(); // Retornando uma lista vazia em vez de null

            try
            {
                using (clsFestasContext context = new ())
                {
                    var listaEspacos = context.Espacos.OrderBy(l => l.espc_nome).ToList();
                    myLogger.LogInfo("Lista de espaços de festas carregada com sucesso.");
                    return listaEspacos;
                }
            }
            catch (Exception ex)
            {
                myLogger.LogError("Erro ao carregar a lista de espaços de festas.", ex);
                return new List<clsFestasEspacos>();
            }
        }
        //
        // método retorna um Status através do Id
        public clsFestasEspacos? GetItem(int Id)
        {
            // se não tiver Registro selecionado
            if (Id <= 0)
                return null;

            // testa conexão
            if (!TestarConexao())
                return null;

            try
            {
                using (clsFestasContext context = new())
                {
                    var entItem = context.Espacos.Find(Id);

                    if (entItem != null)
                    {
                        // copiar propriedades do registro encontrado para a instância atual
                        this.espc_nome = entItem.espc_nome;
                        myLogger.LogInfo($"Espaço Festa com Id {Id} encontrado e carregado com sucesso.");
                        return this; // retorna registro encontratdo
                    }
                }
            }
            catch (Exception ex)
            {
                myLogger.LogError($"Erro ao carregar o espaço festas com Id {Id}.", ex);
                return null;
            }
            return null;
        }
        //
        // método para adicionar um novo registro a tabela
        public static bool AddItem(clsFestasEspacos newItem)
        {
            // testa conexão
            if (!TestarConexao())
                return false;

            try
            {
                using (clsFestasContext context = new())
                {
                    context.Espacos.Add(newItem);
                    context.SaveChanges();
                    myLogger.LogInfo("Espaço festas adicionado com sucesso.");
                    return true;
                }
            }
            catch (Exception ex)
            {
                myLogger.LogError("Erro ao adicionar um novo espaço festa.", ex);
                return false;
            }
        }
        //
        // método para editar um registro na tabela
        public static bool AlterItem(int idItem, clsFestasEspacos itemAlterado)
        {
            // testa conexão
            if (!TestarConexao())
                return false;

            try
            {
                using (clsFestasContext context = new())
                {
                    var itemExist = context.Espacos.Find(idItem);
                    if (itemExist != null)
                    {
                        itemExist.espc_nome = itemAlterado.espc_nome;
                        context.SaveChanges();
                        myLogger.LogInfo($"Espaço festa com Id {idItem} atualizado com sucesso.");
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                myLogger.LogError($"Erro ao atualizar o espaço festa com Id {idItem}.", ex);
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
                    var itemExist = context.Espacos.Find(idItem);
                    if (itemExist != null)
                    {
                        context.Espacos.Remove(itemExist);
                        context.SaveChanges();
                        myLogger.LogInfo($"Espaço festas com Id {idItem} removido com sucesso.");
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                myLogger.LogError($"Erro ao deletar o espaço festas com Id {idItem}.", ex);
                return false;
            }
            return false;
        }

    } // end class repEspacosEF : clsFestasEspacos
} // end namespace FestasApp.Repositories
