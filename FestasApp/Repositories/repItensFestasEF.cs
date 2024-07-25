//----------------------------------------------------------------------------------------
//   Festa.Com - Aplicativo para Controle de Festas & Eventos
//   Autor: Josemar Santana
//   Linguagem: C#
//
//   Inicio de criação do aplicativo: 23/05/2024
//   Criação do módulo: 09/07/2024
//   Ultima Alteração: 09/07/2024
//   
//   CLASSE repItensFestasEF herda de clsFestasItens,
//   utiliza ENTITY FRAMEWORK / LINQ para auxiliar nas relações com Banco de Dados MySql
//----------------------------------------------------------------------------------------

namespace FestasApp.Repositories
{
    public class repItensFestasEF : clsFestasItens
    {
        // construtor
        public repItensFestasEF() { }
        //
        // carrega uma lista da tblFestasItens
        public static List<clsFestasItens> GetItensFestas()
        {
            // testa a conexão
            if (!myConnMySql.TestarConexao())
                return [];

            try
            {
                using (var context = new clsFestasContext())
                {
                    var listaItensFestas = context.ItensFestas.OrderBy(i => i.itensfest_nome).ToList();
                    return listaItensFestas;
                }
            }
            catch (Exception) { }

            return [];
        }
        //
        // retorna um Item através do Id
        public clsFestasItens? GetItem(int Id)
        {
            // se não tiver Item selecionado
            if (Id == 0)
                return null;

            // testa a conexão
            if (!myConnMySql.TestarConexao())
                return null;
            
            try
            {
                using (var context = new clsFestasContext())
                {
                    var entItem = context.ItensFestas.Find(Id);

                    if (entItem != null)
                    {
                        // Copiar propriedades do item encontrado para a instância atual
                        this.itensfest_id = entItem.itensfest_id;
                        this.itensfest_nome = entItem.itensfest_nome;
                        this.itensfest_tipo = entItem.itensfest_tipo;
                        this.itensfest_descricao = entItem.itensfest_descricao;
                        this.itensfest_valor = entItem.itensfest_valor;

                        return this; // Retornar a instância atual
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
        // Método para adicionar um novo item de festa
        public static bool AdicionarItemFesta(clsFestasItens novoItem)
        {
            // Testa a conexão
            if (!myConnMySql.TestarConexao())
                return false;

            try
            {
                using (var context = new clsFestasContext())
                {
                    context.ItensFestas.Add(novoItem);
                    context.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false; 
            }
        }
        //
        // Método para editar um item de festa existente
        public static bool EditarItemFesta(int itensfest_id, clsFestasItens itemEditado)
        {
            // Testa a conexão
            if (!myConnMySql.TestarConexao())
                return false;

            try
            {
                using (var context = new clsFestasContext())
                {
                    var itemExistente = context.ItensFestas.Find(itensfest_id);
                    if (itemExistente != null)
                    {
                        itemExistente.itensfest_tipo = itemEditado.itensfest_tipo;
                        itemExistente.itensfest_nome = itemEditado.itensfest_nome;
                        itemExistente.itensfest_descricao = itemEditado.itensfest_descricao;
                        itemExistente.itensfest_valor = itemEditado.itensfest_valor;
                        context.SaveChanges();
                        return true;
                    }
                }
            }
            catch (Exception) { }

            return false;
        }
        //
        // Método para excluir um item de festa
        public static bool ExcluirItemFesta(int itensfest_id)
        {
            // Testa a conexão
            if (!myConnMySql.TestarConexao())
                return false;

            try
            {
                using (var context = new clsFestasContext())
                {
                    var item = context.ItensFestas.Find(itensfest_id);
                    if (item != null)
                    {
                        context.ItensFestas.Remove(item);
                        context.SaveChanges();
                        return true;
                    }
                }
            }
            catch (Exception) { }

            return false;
        }
        //
    } // end class repItensFestasEF : clsFestasItens
} // end namespace FestasApp.Repositories
