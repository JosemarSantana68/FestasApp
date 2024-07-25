//----------------------------------------------------------------------------------------
//   Festa.Com - Aplicativo para Controle de Festas & Eventos
//   Autor: Josemar Santana
//   Linguagem: C#
//
//   Inicio de criação do aplicativo: 23/05/2024
//   Criação do módulo: 09/07/2024
//   Ultima Alteração: 09/07/2024
//   
//   CLASSE repContratos herda de clsFestasContratos,
//   utiliza ENTITY FRAMEWORK / LINQ para auxiliar nas relações com Banco de Dados MySql
//----------------------------------------------------------------------------------------


namespace FestasApp.Repositories
{
    public class repContratosEF : clsFestasContratos
    {
        // Construtor
        public repContratosEF() { }
        //
        // Carrega uma lista de contratos
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
        //
        // Método para upload de arquivos
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
        //
        // Método para preencher contratos com dados
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
        //
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

