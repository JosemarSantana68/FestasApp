//----------------------------------------------------------------------------------------
//   Festa.Com - Aplicativo para Controle de Festas & Eventos
//   Autor: Josemar Santana
//   Linguagem: C#
//
//   Inicio de criação do aplicativo: 23/05/2024
//   Criação do módulo: 09/07/2024
//   Ultima Alteração: 05/08/2024
//   
//   CLASSE repContratos herda de clsFestasContratos,
//   utiliza ENTITY FRAMEWORK / LINQ para auxiliar nas relações com Banco de Dados MySql
//----------------------------------------------------------------------------------------


namespace FestasApp.Repositories
{
    public class repContratosEF : clsFestasContratos
    {
        /// <summary>
        /// Construtor
        /// </summary>
        public repContratosEF() { }

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
        /// <summary>
        /// método retorna um item através do Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public clsFestasContratos? GetItem(int Id)
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
                    var entItem = context.Contratos.Find(Id);

                    if (entItem != null)
                    {
                        // copiar propriedades do registro encontrado para a instância atual
                        this.ctt_nome = entItem.ctt_nome;
                        this.ctt_caminho_arquivo = entItem.ctt_caminho_arquivo;
                        myLogger.LogInfo($"Contrato com Id {Id} encontrado e carregado com sucesso.");
                        return this; // retorna registro encontratdo
                    }
                }
            }
            catch (Exception ex)
            {
                myLogger.LogError($"Erro ao carregar o Contrato com Id {Id}.", ex);
                return null;
            }
            return null;
        }
        /// <summary>
        /// método para adicionar um novo registro a tabela
        /// </summary>
        /// <param name="newItem"></param>
        /// <returns></returns>
        public static bool AddItem(clsFestasContratos newItem)
        {
            // testa conexão
            if (!TestarConexao())
                return false;

            try
            {
                using (clsFestasContext context = new())
                {
                    context.Contratos.Add(newItem);
                    context.SaveChanges();
                    myLogger.LogInfo("Contrato de festas adicionado com sucesso.");
                    return true;
                }
            }
            catch (Exception ex)
            {
                myLogger.LogError("Erro ao adicionar um novo Contrato de festas.", ex);
                return false;
            }
        }
        //
        /// <summary>
        /// Carrega uma lista de contratos
        /// </summary>
        /// <returns></returns>
        public static List<clsFestasContratos> GetContratos()
        {
            // Testa a conexão
            if (!myConnMySql.TestarConexao())
                return new List<clsFestasContratos>(); // Retornando uma lista vazia em vez de null

            try
            {
                using (var context = new clsFestasContext())
                {
                    var listaContratos = context.Contratos.OrderBy(c => c.ctt_nome).ToList();
                    return listaContratos;
                }
            }
            catch (Exception) { }
            return new List<clsFestasContratos>(); // Retornando uma lista vazia em vez de null
        }
        /// <summary>
        /// método para editar um registro na tabela Contratos
        /// </summary>
        /// <param name="idItem"></param>
        /// <param name="itemAlterado"></param>
        /// <returns></returns>
        public static bool AlterItem(int idItem, clsFestasContratos itemAlterado)
        {
            // testa conexão
            if (!TestarConexao())
                return false;

            try
            {
                using (clsFestasContext context = new())
                {
                    var itemExist = context.Contratos.Find(idItem);
                    if (itemExist != null)
                    {
                        itemExist.ctt_nome = itemAlterado.ctt_nome;
                        itemExist.ctt_caminho_arquivo = itemAlterado.ctt_caminho_arquivo;

                        context.SaveChanges();
                        myLogger.LogInfo($"Contrato de festas com Id {idItem} atualizado com sucesso.");
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                myLogger.LogError($"Erro ao atualizar o Contrato de festas com Id {idItem}.", ex);
                return false;
            }
            return false;
        }
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
                    var itemExist = context.Contratos.Find(idItem);
                    if (itemExist != null)
                    {
                        context.Contratos.Remove(itemExist);
                        context.SaveChanges();
                        myLogger.LogInfo($"Contrato de festas com Id {idItem} removido com sucesso.");
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                myLogger.LogError($"Erro ao deletar o Contrato de festas com Id {idItem}.", ex);
                return false;
            }
            return false;
        }
        //
        /// <summary>
        /// Método para upload de arquivos
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static string UploadContrato(IFormFile file)
        {
            if (file == null || file.Length == 0)
                throw new ArgumentException("Nenhum arquivo foi selecionado para upload.");

            var path = Path.Combine(Directory.GetCurrentDirectory(), "Contratos", file.FileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return path;
        }
        /// <summary>
        /// Método para upload de arquivos
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static string UploadContratoNovo(string filePath)
        {
            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
                throw new ArgumentException("Nenhum arquivo válido foi selecionado para upload.");

            var fileName = Path.GetFileName(filePath); // caminho do txtPath.Text

            // diretório padrão do .net8\widows...
            // E:\1_MEUS_PROJETOS\CSHARP\FestasApp\FestasApp\FestasApp\bin\Debug\net8.0-windows\Contratos
            //var destinationDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Contratos");

            // diretório base da aplicação
            // E:\1_MEUS_PROJETOS\CSHARP\FestasApp\FestasApp\FestasApp\bin\Debug\net8.0-windows\Contratos
            var appBaseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var destinationDirectory = Path.Combine(appBaseDirectory, "Contratos");

            // Verificar se o diretório existe, se não, criar
            if (!Directory.Exists(destinationDirectory))
            {
                Directory.CreateDirectory(destinationDirectory);
            }

            var destinationPath = Path.Combine(destinationDirectory, fileName);

            File.Copy(filePath, destinationPath, true);

            return destinationPath;
        }


        //
        /// <summary>
        /// Método para preencher contratos com dados
        /// </summary>
        /// <param name="templatePath"></param>
        /// <param name="outputPath"></param>
        /// <param name="dados"></param>
        public static void PreencherContrato(string templatePath, string outputPath, Dictionary<string, string> dados)
        {
            using (var reader = new iTextSharp.text.pdf.PdfReader(templatePath)) // Usando o namespace completo para evitar ambiguidade
            using (var output = new FileStream(outputPath, FileMode.Create))
            using (var stamper = new PdfStamper(reader, output))
            {
                var form = stamper.AcroFields;
                foreach (var campo in dados)
                {
                    form.SetField(campo.Key, campo.Value);
                }
                stamper.FormFlattening = true;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="contratoId"></param>
        /// <param name="novoCaminho"></param>
        public static void AtualizarCaminhoArquivo(int contratoId, string novoCaminho)
        {
            if (!myConnMySql.TestarConexao())
                return;
            try
            {
                using (var context = new clsFestasContext())
                {
                    var contrato = context.Contratos.SingleOrDefault(c => c.ctt_id == contratoId);
                    if (contrato != null)
                    {
                        contrato.ctt_caminho_arquivo = novoCaminho;
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                // Lidar com exceções conforme necessário
                Console.WriteLine("Erro ao atualizar caminho do arquivo: " + ex.Message);
            }
        }


    } // end class repContratos : clsFestasContratos
} // end namespace FestasApp.Repositories

