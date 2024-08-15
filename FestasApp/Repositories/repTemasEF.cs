//----------------------------------------------------------------------------------------
//   Festa.Com - Aplicativo para Controle de Festas & Eventos
//   Autor: Josemar Santana
//   Linguagem: C#
//
//   Inicio de criação do aplicativo: 23/05/2024
//   Criação do módulo: 11/07/2024
//   Ultima Alteração: 11/07/2024
//   
//   CLASSE  class repTemasEF herda de clsFestasTemas,
//   utiliza ENTITY FRAMEWORK / LINQ para auxiliar nas relações com Banco de Dados MySql
//----------------------------------------------------------------------------------------

namespace FestasApp.Repositories
{
    internal class repTemasEF : clsFestasTemas
    {
        public repTemasEF() { }
        //
        //
        /// <summary>
        /// Método para testar a conexão
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Carrega a lista de Status
        /// </summary>
        /// <returns></returns>
        public static List<clsFestasTemas> GetTemas()
        {
            // Testa a conexão
            if (!TestarConexao())
                return []; // Retornando uma lista vazia em vez de null

            try
            {
                using (var context = new clsFestasContext())
                {
                    var lista = context.Temas.OrderBy(l => l.tema_nome).ToList();
                    return lista;
                }
            }
            catch (Exception) { }
            return []; // Retornando uma lista vazia em vez de null
        }
        //
        /// <summary>
        /// retorna um Item através do Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public clsFestasTemas? GetItem(int Id)
        {
            // se não tiver Item selecionado
            if (Id <= 0)
                return null;

            // testa a conexão
            if (!TestarConexao())
            {
                return null;
            }

            try
            {
                using (clsFestasContext context = new())
                {
                    var entItem = context.Temas.Find(Id);

                    if (entItem != null)
                    {
                        // Copiar propriedades do item encontrado para a instância atual
                        this.tema_id = entItem.tema_id;
                        this.tema_nome = entItem.tema_nome;
                        this.tema_descricao = entItem.tema_descricao;
                        myLogger.LogInfo($"Tema de Festas com Id {Id} encontrado e carregado com sucesso.");
                        return this; // retorna registro encontratdo
                    }
                }
            }
            catch (Exception ex)
            {
                myLogger.LogError($"Erro ao carregar o tema de festas com Id {Id}.", ex);
                return null;
            }
            return null;
        }
        //
        /// <summary>
        /// método para adicionar um novo registro a tabela
        /// </summary>
        /// <param name="newItem"></param>
        /// <returns></returns>
        public static bool AddItem(clsFestasTemas newItem)
        {
            // testa conexão
            if (!TestarConexao())
                return false;

            try
            {
                using (clsFestasContext context = new())
                {
                    context.Temas.Add(newItem);
                    context.SaveChanges();
                    myLogger.LogInfo("Tema de festas adicionado com sucesso.");
                    return true;
                }
            }
            catch (Exception ex)
            {
                myLogger.LogError("Erro ao adicionar um novo Tema de festas.", ex);
                return false;
            }
        }
        //
        /// <summary>
        /// método para editar um registro na tabela
        /// </summary>
        /// <param name="idItem"></param>
        /// <param name="itemAlterado"></param>
        /// <returns></returns>
        public static bool AlterItem(int idItem, clsFestasTemas itemAlterado)
        {
            // testa conexão
            if (!TestarConexao())
                return false;

            try
            {
                using (clsFestasContext context = new())
                {
                    var itemExist = context.Temas.Find(idItem);
                    if (itemExist != null)
                    {
                        itemExist.tema_nome = itemAlterado.tema_nome;
                        itemExist.tema_descricao = itemAlterado.tema_descricao;

                        context.SaveChanges();
                        myLogger.LogInfo($"Tema de festas com Id {idItem} atualizado com sucesso.");
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                myLogger.LogError($"Erro ao atualizar o Tema de festas com Id {idItem}.", ex);
                return false;
            }
            return false;
        }
        //
        /// <summary>
        /// método para deletar item na tabela
        /// </summary>
        /// <param name="idItem"></param>
        /// <returns></returns>
        public static bool DeleteItem(int idItem)
        {
            // testa conexão
            if (!TestarConexao())
                return false;

            try
            {
                using (clsFestasContext context = new())
                {
                    var itemExist = context.Temas.Find(idItem);
                    if (itemExist != null)
                    {
                        context.Temas.Remove(itemExist);
                        context.SaveChanges();
                        myLogger.LogInfo($"Tema de festas com Id {idItem} removido com sucesso.");
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                myLogger.LogError($"Erro ao deletar o Tema de festas com Id {idItem}.", ex);
                return false;
            }
            return false;
        }

    } // end class repTemasEF : clsFestasTemas

} // end namespace FestasApp.Repositories
