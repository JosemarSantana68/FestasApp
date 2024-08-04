//----------------------------------------------------------------------------------------
//   Festa.Com - Aplicativo para Controle de Festas & Eventos
//   Autor: Josemar Santana
//   Linguagem: C#
//
//   Inicio de criação do aplicativo: 23/05/2024
//   Criação do módulo: 11/07/2024
//   Ultima Alteração: 11/07/2024
//   
//   CLASSE  class repPacotesEF herda de clsFestasPacotes,
//   utiliza ENTITY FRAMEWORK / LINQ para auxiliar nas relações com Banco de Dados MySql
//----------------------------------------------------------------------------------------

namespace FestasApp.Repositories
{
    internal class repPacotesEF : clsFestasPacotes
    {
        // construtor padrão
        public repPacotesEF() { }
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
        // Carrega uma lista de pacotes
        public static List<clsFestasPacotes> GetPacotes()
        {
            // Testa a conexão
            if (!TestarConexao())
                return []; // Retornando uma lista vazia em vez de null

            try
            {
                using (clsFestasContext context = new())
                {
                    var lista = context.Pacotes.OrderBy(l => l.pct_nome).ToList();
                    myLogger.LogInfo("Lista de pacotes de festas carregada com sucesso.");
                    return lista;
                }
            }
            catch (Exception ex)
            {
                myLogger.LogError("Erro ao carregar a pacotes de espaços de festas.", ex);
                return new List<clsFestasPacotes>();
            }
        }
        //
        // captura e retorna um Item através do Id
        public clsFestasPacotes? GetItem(int Id)
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
                    var entItem = context.Pacotes.Find(Id);

                    if (entItem != null)
                    {
                        // Copiar propriedades do item encontrado para a instância atual
                        this.pct_id = entItem.pct_id;
                        this.pct_nome = entItem.pct_nome;
                        this.pct_descricao = entItem.pct_descricao;
                        this.pct_duracao = entItem.pct_duracao;
                        this.pct_valor = entItem.pct_valor;
                        myLogger.LogInfo($"Pacote de Festas com Id {Id} encontrado e carregado com sucesso.");
                        return this; // retorna registro encontratdo
                    }
                }
            }
            catch (Exception ex)
            {
                myLogger.LogError($"Erro ao carregar o pacote de festas com Id {Id}.", ex);
                return null;
            }
            return null;
        }
        //
        // método para adicionar um novo registro a tabela
        public static bool AddItem(clsFestasPacotes newItem)
        {
            // testa conexão
            if (!TestarConexao())
                return false;

            try
            {
                using (clsFestasContext context = new())
                {
                    context.Pacotes.Add(newItem);
                    context.SaveChanges();
                    myLogger.LogInfo("Pacote de festas adicionado com sucesso.");
                    return true;
                }
            }
            catch (Exception ex)
            {
                myLogger.LogError("Erro ao adicionar um novo pacote de festas.", ex);
                return false;
            }
        }
        //
        // método para editar um registro na tabela
        public static bool AlterItem(int idItem, clsFestasPacotes itemAlterado)
        {
            // testa conexão
            if (!TestarConexao())
                return false;

            try
            {
                using (clsFestasContext context = new())
                {
                    var itemExist = context.Pacotes.Find(idItem);
                    if (itemExist != null)
                    {
                        itemExist.pct_nome = itemAlterado.pct_nome;
                        itemExist.pct_descricao = itemAlterado.pct_descricao;
                        itemExist.pct_duracao = itemAlterado.pct_duracao;
                        itemExist.pct_valor = itemAlterado.pct_valor;

                        context.SaveChanges();
                        myLogger.LogInfo($"Pacote de festas com Id {idItem} atualizado com sucesso.");
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                myLogger.LogError($"Erro ao atualizar o pacote de festas com Id {idItem}.", ex);
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
                    var itemExist = context.Pacotes.Find(idItem);
                    if (itemExist != null)
                    {
                        context.Pacotes.Remove(itemExist);
                        context.SaveChanges();
                        myLogger.LogInfo($"Pacote de festas com Id {idItem} removido com sucesso.");
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                myLogger.LogError($"Erro ao deletar o pacote de festas com Id {idItem}.", ex);
                return false;
            }
            return false;
        }

    } // end  class repPacotesEF : clsFestasPacotes
} // end namespace FestasApp.Repositories
