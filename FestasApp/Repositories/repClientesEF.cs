//***********************************************************
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
//************************************************************

using System.Data.Common;

namespace FestasApp.Repositories
{
    public class repClientesEF : clsClientes
    {
        // construtor
        public repClientesEF() { }
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
        // retorna um cliente através do Id
        public clsClientes? GetCliente(int Id)
        {
            // se não tiver cliente selecionado
            if (Id == 0) 
                return null;

            // testa a conexão
            if (!TestarConexao())
            {
                return null;
            }

            try
            {
                using (var context = new clsFestasContext())
                {
                    // Para obter registros com uma condição específica:
                    //var clientes = context.Clientes.Where(c => c.cli_nome.Contains("Josemar")).ToList();

                    // Para obter um único registro por ID:
                    //var cliente = context.Clientes.FirstOrDefault(c => c.cli_id == Id);

                    var entCliente = context.Clientes.Find(Id);

                    if (entCliente != null)
                    {
                        // Copiar propriedades do cliente encontrado para a instância atual
                        cli_id = entCliente.cli_id;
                        cli_nome = entCliente.cli_nome;
                        cli_telefone1 = entCliente.cli_telefone1;
                        cli_telefone2 = entCliente.cli_telefone2;
                        cli_cpf = entCliente.cli_cpf;
                        cli_endereco = entCliente.cli_endereco;
                        cli_cep = entCliente.cli_cep;
                        cli_cidade = entCliente.cli_cidade;
                        cli_uf = entCliente.cli_uf;

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
        // retorna uma lista com todos os clientes
        public static List<clsClientes> GetClientesEF()
        {
            // testa a conexão
            if (!TestarConexao())
                //return []; // Retornando uma lista vazia em vez de null
                return new List<clsClientes>(); // Retornando uma lista vazia em vez de null

            try
            {
                using (clsFestasContext context = new())
                {
                    // Carregar os dados do DbSet<T>
                    //var listaClientes = context.Clientes.ToList();
                    var listaClientes = context.Clientes.OrderBy(c => c.cli_nome).ToList();
                    return listaClientes;
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
            return [];
        }
        //
        // salvar cliente
        public static bool SaveCliente(clsClientes cliente)
        {
            // testa a conexão
            if (!myConnMySql.TestarConexao())
                return false;

            try
            {
                using (var context = new clsFestasContext())
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
        //
        // delete cliente
        public static bool DeleteClienteEF(clsClientes cliente)
        {
            try
            {
                using (var context = new clsFestasContext())
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


    } // end class clsClientesEF : clsClientes
} // end namespace
