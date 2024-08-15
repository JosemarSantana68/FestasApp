//-----------------------------------------------------------------------------------------
//
//   Festa.Com - Aplicativo para Controle de Festas & Eventos
//   Autor: Josemar Santana
//   Linguagem: C#
//
//   Inicio de criação do aplicativo: 23/05/2024
//   Criação do módulo: 05/07/2024
//   Ultima Alteração: 05/07/2024
//   
//   CLASSE repClientesEF herda de clsClientes,
//   utiliza ENTITY FRAMEWORK / LINQ para auxiliar nas relações com Banco de Dados MySql
//  
//-----------------------------------------------------------------------------------------
//

namespace FestasApp.Repositories
{
    /// <summary>
    /// Classe do Repertório Clientes com EF
    /// </summary>
    public class repClientesEF
    {
        /// <summary>
        /// Construtor padrão
        /// </summary>
        public repClientesEF() { }
        //
        /// <summary>
        /// Método para testar a conexão
        /// </summary>
        /// <returns></returns>
        public bool TestarConexao()
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
        /// Retorna um cliente através do Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public clsClientes? GetCliente(int Id)
        {
            // se não houver cliente selecionado abandona
            if (Id <= 0) 
                return null;

            // testa a conexão
            if (!TestarConexao())
                return null;

            try
            {
                using (clsFestasContext context = new())
                {
                    /*      Find(Id) é mais eficiente quando você sabe que está lidando com a chave primária da tabela, 
                     *  porque pode aproveitar o cache do contexto do Entity Framework, o que evita consultas desnecessárias ao banco de dados.
                     * 
                     *      FirstOrDefault deve ser usado quando você precisa aplicar uma condição mais complexa que
                     *  não envolve apenas a chave primária ou quando você quer ter mais controle sobre a consulta SQL gerada.
                     *  Portanto, para buscar um registro pela chave primária, Find(Id) é a abordagem recomendada e mais eficiente. */

                    // Para obter registros com uma condição específica, retorna uma lista:
                    //var clientes = context.Clientes.Where(c => c.cli_nome.Contains("Josemar")).ToList();

                    // Para obter um único registro por ID:
                    //var cliente = context.Clientes.FirstOrDefault(c => c.cli_id == Id);

                    var entCliente = context.Clientes.Find(Id);

                    // se encontrou cliente
                    if (entCliente != null)
                    {
                        clsClientes cliente = new()
                        {
                            // Copiar propriedades do cliente encontrado para a instância atual
                            cli_id = entCliente.cli_id,
                            cli_nome = entCliente.cli_nome,
                            cli_telefone1 = entCliente.cli_telefone1,
                            cli_telefone2 = entCliente.cli_telefone2,
                            cli_cpf = entCliente.cli_cpf,
                            cli_endereco = entCliente.cli_endereco,
                            cli_cep = entCliente.cli_cep,
                            cli_cidade = entCliente.cli_cidade,
                            cli_uf = entCliente.cli_uf
                        };
                        return cliente; // Retornar a instância atual
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
        /// <summary>
        /// Retorna uma lista com todos os clientes
        /// </summary>
        /// <returns></returns>
        public List<clsClientes> GetClientesEF()
        {
            // testa a conexão
            if (!TestarConexao())
                return new List<clsClientes>(); // Retornando uma lista vazia em vez de null
            try
            {
                using (clsFestasContext context = new())
                {
                    // Carregar os dados do DbSet<T>
                    return context.Clientes.OrderBy(c => c.cli_nome).ToList();
                }
            }
            catch (MySqlException mysqlEx)
            {
                myLogger.LogError("Erro ao carregar a lista de clientes.", mysqlEx);
            }
            catch (Exception ex)
            {
                myLogger.LogError("Erro ao carregar a lista de clientes.", ex);
            }
            return []; // Retornando uma lista vazia em vez de null
        }
        /// <summary>
        /// Salvar cliente
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        public bool SaveCliente(clsClientes cliente)
        {
            // testa a conexão
            if (!TestarConexao())
                return false;

            try
            {
                using (clsFestasContext context = new())
                {
                    // EDITA
                    if (cliente.cli_id > 0)
                    {
                        context.Entry(cliente).State = EntityState.Modified;
                    }
                    // NOVO
                    else
                    {
                        context.Clientes.Add(cliente);
                    }
                    context.SaveChanges();
                    return true;
                }
            }
            catch (DbUpdateException dbEx)
            {
                // Trata exceções relacionadas a atualizações de banco de dados
                // Pode-se registrar o erro ou retornar uma mensagem de erro detalhada
                Console.WriteLine($"Erro ao salvar o cliente: {dbEx.Message}");
                return false;
            }
            catch (Exception ex)
            {
                // Trata outras exceções
                Console.WriteLine($"Erro inesperado: {ex.Message}");
                return false;
            }
        }
        /// <summary>
        /// Delete cliente
        /// </summary>
        /// <param name="cliente"></param>
        /// <returns></returns>
        public bool DeleteClienteEF(clsClientes cliente)
        {
            try
            {
                using (clsFestasContext context = new())
                {
                    if (cliente != null)
                    {
                        context.Clientes.Remove(cliente);
                        context.SaveChanges();
                        return true;
                    }
                }
            }
            catch (DbException dbEx)
            {
                // Trata exceções relacionadas a atualizações de banco de dados
                // Pode-se registrar o erro ou retornar uma mensagem de erro detalhada
                Console.WriteLine($"Erro ao deletar o cliente: {dbEx.Message}");
                return false;
            }
            catch (Exception ex)
            {
                // Trata outras exceções
                Console.WriteLine($"Erro inesperado: {ex.Message}");
                return false;
            }
            return false;
        }
        //

    } // end class clsClientesEF : clsClientes
} // end namespace
